using UnityEngine;
using UnityEngine.UI;

public class scoreDisplay : MonoBehaviour
{
    int score;
    public Text myText;
    void Start()
    {
        float randf = Random.Range(0f, 1000f);
        score = (int) randf;
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = score.ToString();
    }
}
