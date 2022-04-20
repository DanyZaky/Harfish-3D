using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LeaderboardController : MonoBehaviour
{
    public InputField PlayerUsername;
    public TextMeshProUGUI hScore;
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
        LootLockerSDKManager.SubmitScore(PlayerUsername.text, int.Parse(hScore.text), 2472, (response) =>
        {
            if (response.statusCode == 200) {
                Debug.Log("Successful");
            } else {
                Debug.Log("failed: " + response.Error);
            }
        });

        SceneManager.LoadScene(0);
        SoundManager.Instance.PlaySFX("SFX Button");
    }
}
