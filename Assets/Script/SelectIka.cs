using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectIka : MonoBehaviour
{
    [SerializeField] private GameObject ikanHiasActive, ikanKonsumsiActive, ikanHiasDisable, ikanKonsumsiDisable,
        selectIkanHias, selectIkanKonsumsi;
    void Start()
    {
        ikanHiasActive.SetActive(false);
        ikanKonsumsiDisable.SetActive(false);

        ikanHiasDisable.SetActive(true);
        ikanKonsumsiActive.SetActive(true);

        selectIkanHias.SetActive(true);
        selectIkanKonsumsi.SetActive(false);
    }

    public void ikanHiasButton()
    {
        ikanHiasActive.SetActive(false);
        ikanKonsumsiDisable.SetActive(false);

        ikanHiasDisable.SetActive(true);
        ikanKonsumsiActive.SetActive(true);

        selectIkanHias.SetActive(true);
        selectIkanKonsumsi.SetActive(false);

        SoundManager.Instance.PlaySFX("SFX Button");
    }

    public void ikanKonsumsiButton()
    {
        ikanHiasActive.SetActive(true);
        ikanKonsumsiDisable.SetActive(true);

        ikanHiasDisable.SetActive(false);
        ikanKonsumsiActive.SetActive(false);

        selectIkanHias.SetActive(false);
        selectIkanKonsumsi.SetActive(true);

        SoundManager.Instance.PlaySFX("SFX Button");
    }
}
