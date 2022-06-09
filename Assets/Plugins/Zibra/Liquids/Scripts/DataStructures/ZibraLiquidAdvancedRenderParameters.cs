using System;
using UnityEngine;
using UnityEngine.Serialization;

#if UNITY_EDITOR
using UnityEngine.SceneManagement;
using UnityEditor;
#endif

namespace com.zibra.liquid.DataStructures
{
    [ExecuteInEditMode]
    public class ZibraLiquidAdvancedRenderParameters : MonoBehaviour
    {
        public enum LiquidRefractionQuality
        {
            PerVertexRender,
            PerPixelRender
        }

        [Tooltip("Controls the quality of the liquid depth")]
        public LiquidRefractionQuality RefractionQuality = LiquidRefractionQuality.PerPixelRender;

        public enum RayMarchingBounces
        {
            SingleBounce,
            TwoBounces
        }

        [Tooltip("Number of bounces of the refraction ray, to see the liquid behing itself you need 2 bounces")]
        public RayMarchingBounces RefractionBounces = RayMarchingBounces.SingleBounce;

        [Tooltip("Enable underwater rendering. Disable it if you don't need it, since it's a bit slower.")]
        public bool UnderwaterRender = false;

        [Tooltip(
            "Number of additional sphere render iterations, controls how large spheres can get, has a large impact on performance")]
        [Range(0, 8)]
        public int AdditionalJFAIterations = 0;

        [Tooltip("Number of iterations that move the mesh vertex to the liquid isosurface")]
        [Range(0, 20)]
        public int VertexOptimizationIterations = 5;

        [Tooltip("Number of smoothing iterations for the mesh")]
        [Range(0, 8)]
        public int MeshOptimizationIterations = 2;

        [Tooltip(
            "This parameter moves liquid mesh vertices to be closer to the actual liquid surface. It should be manually fine tuned until you get a smooth mesh.")]
        [Range(0.0f, 2.0f)]
        public float VertexOptimizationStep = 0.82f;

        [Tooltip("The strenght of the mesh smoothing per iteration")]
        [Range(0.0f, 1.0f)]
        public float MeshOptimizationStep = 0.91f;

        [Tooltip("The isovalue at which the mesh vertices are generated")]
        [Range(0.01f, 2.0f)]
        public float DualContourIsoSurfaceLevel = 0.025f;

        [Tooltip("Controls the position of the fluid surface. Lower values result in thicker surface.")]
        [Range(0.01f, 2.0f)]
        public float IsoSurfaceLevel = 0.36f;

        [Tooltip("The isosufrace level for the ray marching. Should be about 1-1/2 of the liquid density.")]
        [Range(0.0f, 5.0f)]
        public float RayMarchIsoSurface = 0.65f;

        [Tooltip("Maximum number of steps the ray can go, has a large effect on the performance")]
        [Range(4, 128)]
        public int RayMarchMaxSteps = 128;

        [Tooltip("Step size of the ray marching, controls accuracy, also has a large effect on performance")]
        [Range(0.0f, 1.0f)]
        public float RayMarchStepSize = 0.2f;

        [Tooltip(
            "Varies the ray marching step size, in some cases might improve performace by slightly reducing ray marching quality")]
        [Range(1.0f, 10.0f)]
        public float RayMarchStepFactor = 4.0f;
    }
}