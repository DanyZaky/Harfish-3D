using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDropping : MonoBehaviour
{
    [SerializeField] private DialogueStripping ds;
    [SerializeField] private timer t;
    [SerializeField] private GameObject tutorial;
    [SerializeField] private ProgressBars pb;

    void Start()
    {
        tutorial.SetActive(false);
        t.timerActive = false;
    }

    void Update()
    {
        if (ds.startTutorial == true)
        {
            tutorial.SetActive(true);
            t.timerActive = true;
        }

        if (pb.currentJumlahTelur > 20)
        {
            ds.startTutorial = false;
            tutorial.SetActive(false);
        }
    }
}
