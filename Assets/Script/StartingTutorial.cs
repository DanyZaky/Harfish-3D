using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingTutorial : MonoBehaviour
{
    [SerializeField] private DialogueStripping ds;
    [SerializeField] private GameObject fingerTutor;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (ds.startTutorial)
        {
            fingerTutor.SetActive(true);
        }
        else
        {
            fingerTutor.SetActive(false);
        }
    }
}
