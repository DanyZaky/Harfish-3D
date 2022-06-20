#define FAR_DISTANCE 1e5
#define DEPTH_EPS 1e-3

Texture3D<float4> GridNormals;
SamplerState samplerGridNormals;

Texture3D<float> GridDensity;
SamplerState samplerGridDensity;

float3 WorldToUVW(float3 p)
{
    return (p - (ContainerPosition - ContainerScale * 0.5)) / ContainerScale + 0.5/GridSize;
}

float3 GetNodeF(float3 p)
{
    return GridSize * WorldToUVW(p);
}

int GetNodeID(int3 node)
{
    node = clamp(node, int3(0, 0, 0), int3(GridSize) - int3(1, 1, 1));
    return node.x + node.y * GridSize.x +
            node.z * GridSize.x * GridSize.y;
}

int GetNodeID(float3 node)
{
    return GetNodeID(int3(node));
}

float3 Simulation2World(float3 pos)
{
    return ContainerScale * pos / GridSize + (ContainerPosition - ContainerScale * 0.5);
}

bool insideGrid(float3 pos)
{
    float3 Size = ContainerScale * 0.5 + 0.01*ContainerScale / GridSize;
    return all(pos > ContainerPosition - Size) && all(pos < ContainerPosition + Size);
}

float3 getNode(int ID)
{
    uint3 S = GridSize;
    return float3(ID % S.x, (ID / S.x) % S.y, ID / (S.x * S.y));
}

//opticalDensity is the path length
//incomingLight is the light in the direction of the ray
//illumination is the light coming from light sources at the point of sampling(currently assumed constant)
//should be dependent on the shadowmap, otherwise "glow"
float3 IntegrateAbsorptionScattering(float opticalDensity, float3 incomingLight, float3 illumination)
{
    // emission coefficient
    float sigmaI = 0.0;
    // scattering coefficient
    float sigmaS = ScatteringAmount;
    // absorption coefficient
    float sigmaA = AbsorptionAmount;
    // extinction (= outscatter + absorption) coefficient
    float3 sigmaE = max(1.0e-9, sigmaS + (1.0 - RefractionColor.xyz) * sigmaA);
    // lighting (= inscatter + emission) coefficient
    float sigmaL = max(1.0e-9, sigmaI + sigmaS);

    float3  extinction = exp(- sigmaE * opticalDensity);

    // See slide 28 at http://www.frostbite.com/2015/08/physically-based-unified-volumetric-rendering-in-frostbite/
    const float phaseFunction = 1.0;
    float3 emissColor = illumination * RefractionColor.xyz; // environment light
    float3 S     =  emissColor * sigmaL * phaseFunction;    // incoming light
    float3 Sint  = S * (1.0 - extinction) / sigmaE;         // integrate along the current step segment

    return Sint + incomingLight * extinction;
}

float SampleDensity(float3 pos)
{
    return GridDensity.SampleLevel(samplerGridDensity, WorldToUVW(pos), 0);
}

float3 SampleNormals(float3 pos)
{
    return GridNormals.SampleLevel(samplerGridNormals, WorldToUVW(pos), 0).xyz;
}

float2 msign( float2 v )
{
    return float2( (v.x>=0.0) ? 1.0 : -1.0, 
                 (v.y>=0.0) ? 1.0 : -1.0 );
}

uint EncodeDirection( in float3 nor )
{
    nor.xy /= ( abs( nor.x ) + abs( nor.y ) + abs( nor.z ) );
    nor.xy  = (nor.z >= 0.0) ? nor.xy : (1.0-abs(nor.yx))*msign(nor.xy);

    uint2 d = uint2(round(32767.5 + nor.xy*32767.5));  return d.x|(d.y<<16u);
}

float3 DecodeDirection( uint data )
{
    uint2 iv = uint2( data, data>>16u ) & 65535u; float2 v = float2(iv)/32767.5 - 1.0;
    
    float3 nor = float3(v, 1.0 - abs(v.x) - abs(v.y)); // Rune Stubbe's version,
    float t = max(-nor.z,0.0);                     // much faster than original
    nor.x += (nor.x>0.0)?-t:t;                     // implementation of this
    nor.y += (nor.y>0.0)?-t:t;                     // technique

    return normalize( nor );
}

uint4 getQuad(uint quadID)
{
    uint gridCount = int(GridSize.x) * int(GridSize.y) * int(GridSize.z);
    uint axis = quadID / gridCount;
    uint3 voxel = getNode(quadID % gridCount);
    return uint4(voxel, axis);
}

uint3 getVoxel(uint4 quad, uint indexID)
{
    uint axis = quad.w;
    uint3 Ydir = uint3(((axis + 1) % 3)==0, ((axis + 1) % 3)==1, ((axis + 1) % 3)==2);
    uint3 Zdir = uint3(((axis + 2) % 3)==0, ((axis + 2) % 3)==1, ((axis + 2) % 3)==2);
    return quad.xyz + ((indexID & 1) > 0) * Ydir + ((indexID & 2) > 0) * Zdir;
}

float4 RayDepths;

float TraceRay(inout float3 pos, float3 ray, float depth)
{
    if (depth == 0.0) depth = FAR_DISTANCE;
    pos += ray * depth;
    return depth;
}

float4 AirLiquidBounce(inout float3 pos, float3 ray, float3 normal, float3 light)
{
    //fix artifacts with air ray depth
    if (RayDepths[1] < DEPTH_EPS) RayDepths[1] = FAR_DISTANCE;
    float AirDepth = TraceRay(pos, ray, RayDepths[1]);
    normal = SampleNormals(pos);   

    if (all(normal == 0)) AirDepth = FAR_DISTANCE;

    if (AirDepth >= FAR_DISTANCE) 
    {
        return float4(RefractSample(pos, ray), 0);
    }
    else
    {
        normal = normalize(normal);

        float3 color = 0.0;

        float NV = abs(dot(normal, -ray)); 
        float fresnel = FresnelTerm(Metalness, NV);
                
        float3 ReflectRay = reflect(ray, normal);
        float3 ReflectedColor = ReflectSample(pos, ReflectRay);
        color += ReflectionColor.xyz * fresnel * ReflectedColor / Average(ReflectionColor.xyz);

        float3 RefractRay = refract(ray, normal, 1.0 / LiquidIOR);   
        float LiquidDepth = TraceRay(pos, RefractRay, RayDepths[2]);

        float3 RefractNormal = -normalize(SampleNormals(pos));
        float3 SecondRefractRay = refract(RefractRay, RefractNormal, LiquidIOR);
        float3 opacity = ComputeAbsorption(LiquidDepth);
        float3 RefractColor;
        float opticalDensity = LiquidDepth;

        if (length(SecondRefractRay) > 0.5)
        {
            RefractColor = RefractSample(pos, SecondRefractRay);
        }
        else //full internal reflection
        {
            float3 SecondReflectRay = reflect(RefractRay, RefractNormal);
            RefractColor = ReflectSample(pos, SecondReflectRay);
        }
    
        color += (1.0 - fresnel) * IntegrateAbsorptionScattering(opticalDensity, RefractColor, light);
        return float4(color, LiquidDepth);
    }
}

float3 RefractionRay(float3 pos, float3 cameraRay, float3 surfaceNormal, bool isUnderwater)
{
    float3 RefractPosition = pos;
    float opticalDensity = 0.0;
    float3 ray = cameraRay;
    float3 normal = surfaceNormal;

    if(!isUnderwater)
    {
        ray = refract(cameraRay, surfaceNormal, 1.0 / LiquidIOR);
        float LiquidDepth = TraceRay(RefractPosition, ray, RayDepths[0]);

        #ifdef STORE_DEPTH
            RayDepths.x = LiquidDepth; //store the depths in vertices
        #endif
        normal = -normalize(SampleNormals(RefractPosition));

        float3 RefractScreenPos = PositionToScreen(RefractPosition);
        float4 CorrectedScenePosition = GetDepthAndPos(RefractScreenPos.xy);
        float CorrectedLiquidDepth = min(distance(CorrectedScenePosition.xyz, pos), LiquidDepth);
        opticalDensity += CorrectedLiquidDepth;
    }

    float3 RefractColor = 0.0;
    float3 RefractRay = refract(ray, normal, LiquidIOR);

    #ifdef HDRP
        float3 lightColor = LightColor;
        float3 lightDirWorld = LightDirection;
    #else
        float3 lightColor = _LightColor0;
        float3 lightDirWorld = normalize(_WorldSpaceLightPos0.xyz);
    #endif

    if(length(RefractRay) > 0.5)
    {
        float3 SecondPosition = RefractPosition;
        float4 SecondPath = AirLiquidBounce(SecondPosition, RefractRay, -normal, lightColor); //refraction
        RefractColor = SecondPath.xyz;
    }
    else //full internal reflection
    {
        float3 SecondReflectRay = reflect(ray, normal);
        RefractColor = ReflectSample(pos, SecondReflectRay);
    }

    if (isUnderwater) return RefractColor;

    return IntegrateAbsorptionScattering(opticalDensity, RefractColor, lightColor);
}