using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ikan : MonoBehaviour
{
    [SerializeField] int variousMove, waktuMatiKenaJamur;
    private Vector3[] moveSpots;
    [SerializeField] private Vector3 area;
    [SerializeField] private float speed, pertumbuhan, waktuTumbuh;
    public bool jamuran;

    private int randomSpot;
    private float waitTime,startWaitTime,rotationValue, waktuMati;
    private bool isRotate,sudahTumbuh;
    
    void Start()
    {
        jamuran = false;
        waktuMati = waktuMatiKenaJamur;
        sudahTumbuh = false;
        moveSpots = new Vector3[variousMove];
        for(int i = 0; i < variousMove; i++)
        {
            moveSpots[i] = new Vector3(transform.position.x + Random.Range(-area.x / 2, area.x / 2),transform.position.y + Random.Range(-area.y / 2, area.y / 2), transform.position.z + Random.Range(-area.z / 2, area.z / 2));
           // Debug.Log(moveSpots[i]);
        }
        randomSpot = Random.Range(0, moveSpots.Length);

    }

    void Update()
    {
        Gerak();
        if(waktuTumbuh>0)
        {
            waktuTumbuh -= Time.deltaTime;
        }
        else if(waktuTumbuh < 0 && !sudahTumbuh)
        {
            Tumbuh();
            
        }
        if(jamuran == true)
        {
            waktuMati -= Time.deltaTime;
            //transform.GetChild(1).gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.green);
            if(waktuMati <= 0) Destroy(gameObject);
            if(transform.GetChild(2).gameObject.activeSelf == false) jamuran = false;
        }
        else 
        {
            waktuMati = waktuMatiKenaJamur;
            transform.GetChild(1).gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.white);
        }
    }

    void Gerak()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot], speed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, moveSpots[randomSpot]) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        //direction
        if (moveSpots[randomSpot].x > transform.position.x && rotationValue != 0)
        {
            isRotate = true;

            if (isRotate == true)
            {
                rotationValue -= 10;
                transform.localRotation = Quaternion.Euler(0, rotationValue, 0);
                
                if(rotationValue <= 0)
                {
                    isRotate = false;
                    rotationValue = 0;
                    transform.localRotation = Quaternion.Euler(0, rotationValue, 0);
                }
            }
        }
        else if (moveSpots[randomSpot].x < transform.position.x && rotationValue != 180)
        {
            isRotate = true;

            if (isRotate == true)
            {
                rotationValue += 10;
                transform.localRotation = Quaternion.Euler(0, rotationValue, 0);

                if (rotationValue >= 180)
                {
                    isRotate = false;
                    rotationValue = 180;
                    transform.localRotation = Quaternion.Euler(0, rotationValue, 0);
                }
            }
        }
    }
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.tag == "Jamur")
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    private void Tumbuh()
    {
        transform.localScale = new Vector3(transform.localScale.x*pertumbuhan,transform.localScale.y*pertumbuhan,transform.localScale.z*pertumbuhan);
        sudahTumbuh = true;
    }
}
