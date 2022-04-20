using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine;

public class LeaderboardController : MonoBehaviour
{
    public InputField PlayerUsername;
    public Text score;
    public int ID;
    int sessionID;

    private void Start() {
        float randf = Random.Range(0f, 1000f);
        sessionID = (int) randf;
        LootLockerSDKManager.StartSession(sessionID.ToString(), (response)=>{
            if (response.success){
                Debug.Log("success!");
            }else{
                Debug.Log("failed");
            }
        });    
    }

    public void submitScore(){
        LootLockerSDKManager.SubmitScore(PlayerUsername.text, int.Parse(score.text), 2472, (response) =>
        {
            if (response.statusCode == 200) {
                Debug.Log("Successful");
            } else {
                Debug.Log("failed: " + response.Error);
            }
        });
    }
}
