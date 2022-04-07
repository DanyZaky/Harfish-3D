using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideDetector : MonoBehaviour
{
    // Start is called before the first frame update
    public int eggCount;
    public int spermCount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) {
        // Debug.Log(other.gameObject.tag);
    }
    void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "egg"){
            eggCount++;
        }
        if(other.gameObject.tag == "sperm"){
            spermCount++;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "egg"){
            eggCount--;
        }
        if(other.gameObject.tag == "sperm"){
            spermCount--;
        }
    }

    public int GetSperm(){
        return spermCount;
    }

    public int GetEgg(){
        return eggCount;
    }
}
