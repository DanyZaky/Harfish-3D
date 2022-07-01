using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Ikan Variable", menuName = "Ikan Variable")]
public class IkanVariable : ScriptableObject
{
    [Header("Suntik")]
    public float speedIkan;

    [Header("Strip Betina")]
    public float TimerStrippingBetina;
    public float MaxTelur;

    [Header("Strip Jantan")]
    public float TimerStrippingJantan;
    public float MaxSperma;

    [Header("Mixing")]
    public float TimerMixing;

    [Header("Dropping")]
    public float TimerDropping;
}
