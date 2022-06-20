using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penyakit : MonoBehaviour
{
    private float waktuOksidasi;
    [SerializeField] private float Ketahanan;
    [SerializeField] private AerManager M;
    private float time = 0;
    public void KehabisanNapas(float status)
    {
        waktuOksidasi = status;
    }

    void Update()
    {
        if(!M.isPaused)
        {
            if(waktuOksidasi > 0)
            {
                time += Time.deltaTime * (waktuOksidasi+1);
                //Debug.Log(time);
                if(time >= Ketahanan)
                {
                    Destroy (GameObject.FindWithTag("Ikan"));
                    time = 0;
                    //Debug.Log("Terbunuh");
                }
            }
            else time = 0;
        }
    }
}
