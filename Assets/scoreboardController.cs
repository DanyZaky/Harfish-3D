using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine;

public class scoreboardController : MonoBehaviour
{
    public string[] playerName;
    public string[] score;
    void Start()
    {
        LootLockerSDKManager.StartSession("guest".ToString(), (response)=>{
            if (response.success){
                Debug.Log("success!");
            }else{
                Debug.Log("failed");
            }
        });   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
