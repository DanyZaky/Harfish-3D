using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMixing : MonoBehaviour
{
    [SerializeField] private DialogueStripping ds;
    [SerializeField] private GameObject tutorial1Obj, tutorial2Obj, buttonTuang1, buttonTuang2, bowl1, bowl2, powerBar;

    [SerializeField] private CountInBowl cib1, cib2;
    [SerializeField] private Animator buluAnim;

    [SerializeField] private SpeedMixing sm;

    void Start()
    {
        tutorial1Obj.SetActive(false);
        tutorial2Obj.SetActive(false);
    }

    void Update()
    {
        if (ds.startTutorial == true)
        {
            tutorial1Obj.SetActive(true);
        }

        if (cib1.isAbis == true && cib2.isAbis == true)
        {
            buluAnim.Play("cobs");
            tutorial2Obj.SetActive(true);
            tutorial1Obj.SetActive(false);
            ds.startTutorial = false;

            buttonTuang1.SetActive(false);
            buttonTuang2.SetActive(false);
            bowl1.SetActive(false);
            bowl2.SetActive(false);
            powerBar.SetActive(false);

            if (sm.telurTeradukCount > 20)
            {
                tutorial2Obj.SetActive(false);
            }
        }
    }
}
