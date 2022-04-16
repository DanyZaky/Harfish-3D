using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDropping : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Telur")
        {
            SoundManager.Instance.PlaySFX("SFX Dropping");
        }
    }
}
