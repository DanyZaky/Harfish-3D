using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class eggRatio : MonoBehaviour
{
    // Start is called before the first frame update
    public int eggCount;
    public int spermCount;
    collideDetector myCollide;
    public Text myText;
    void Start()
    {
        myCollide = GameObject.Find("areaDetector").GetComponent<collideDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        eggCount = myCollide.GetEgg();
        spermCount = myCollide.GetSperm();

        if(eggCount != 0 && spermCount != 0){
            var ratio = GCD(eggCount, spermCount);
    //      var gcd = GCD(A, B);
    //      return string.Format("{0}:{1}", A / gcd, B / gcd)
            myText.text = string.Format("{0} : {1}", eggCount / ratio, spermCount/ ratio);
        }
    }

    static int GCD(int a, int b) {
        return b == 0 ? Math.Abs(a) : GCD(b, a % b);
    }
}
