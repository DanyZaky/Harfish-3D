using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetHighscore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScore;

    void Start()
    {
        highScore.SetText(PlayerPrefs.GetFloat("TerpijahCount").ToString("0"));
        Debug.Log(PlayerPrefs.GetFloat("TerpijahCount"));
    }
}
