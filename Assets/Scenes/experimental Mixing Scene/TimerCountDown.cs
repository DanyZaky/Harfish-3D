using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountDown : MonoBehaviour
{
    // Start is called before the first frame update
    public float CountDownFrom = 120f;
    public float timeLeft = 120f;
    public Text myText;
    public Color warningColor;
    public Color allertCollor;
    public bool isStart = false;

    [SerializeField] private GameObject winPanel;
    void Start()
    {
        myText.text = CountDownFrom.ToString();
        timeLeft = CountDownFrom;

        winPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isStart == true){
            timeLeft = timeLeft - Time.deltaTime;
            int count = ((int)timeLeft);
            // if (count < 60 && count >=30){
            //     myText.color = warningColor;
            // }
            // if(count < 30){
            //     myText.color = allertCollor;
            // }
            myText.text = count.ToString();

            if (timeLeft <= 0)
            {
                winPanel.SetActive(true);
                timeLeft = 0f;
                isStart = false;
            }
        }

        

    }

    public void setIsStarting(){
        isStart = true;
    }
}
