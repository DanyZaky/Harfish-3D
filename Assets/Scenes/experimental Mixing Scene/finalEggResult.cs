using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalEggResult : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float eggCount;
    public float spermCount;
    public int finalEggCount;
    collideDetector myCollide;
    public Text myText;
    public int resInt;
    void Start()
    {
        myCollide = GameObject.Find("areaDetector").GetComponent<collideDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        eggCount = (float)myCollide.GetEgg();
        spermCount = (float)myCollide.GetSperm();
        if(eggCount != 0 && spermCount != 0){
            float finalRes = spermCount - (spermCount*0.5f) + (eggCount * 0.1f);
            if (finalRes >= eggCount){
                finalRes = eggCount - 1;
            }
            //penalty code

            resInt = (int)finalRes;
            myText.text = resInt.ToString();
        }
        
    }

    public void decreaseEgg(){
        resInt--;
        myText.text = resInt.ToString();
    }
}
