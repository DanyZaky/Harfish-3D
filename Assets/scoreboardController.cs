using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine;

public class scoreboardController : MonoBehaviour
{
    public Text[] playerName;
    public Text[] score;
    public bool personalRank = false;
    public GameObject personalRanking;
    public GameObject generalRanking;
    public Text gotoWhat;
    public Text memberID;
    public int dbID = 2472;

    public Text PersonalRank;
    public Text PersonalName;
    public Text PersonalScore;

    void Start()
    {
        LootLockerSDKManager.StartSession("guest".ToString(), (response)=>{
            if (response.success){
                Debug.Log("success!");
            }else{
                Debug.Log("failed");
            }
        });  

        LootLockerSDKManager.GetScoreList(dbID, 10, async (response) => {
            if(response.success){
                LootLockerLeaderboardMember[] allMember = response.items;

                for(int i = 0; i < score.Length; i++){
                    if (i >= allMember.Length){
                        continue;
                    }
                    score[i].text = allMember[i].score.ToString();
                    playerName[i].text = allMember[i].member_id;
                }
            }else{
                Debug.Log("failed: " + response.Error);
            }
        } );
    }

    // Update is called once per frame
    void Update()
    {
        if(personalRank){
            generalRanking.SetActive(false);
            personalRanking.SetActive(true);
            gotoWhat.text = "PEMIJAH TERBAIK";
        }else{
            generalRanking.SetActive(true);
            personalRanking.SetActive(false);
            gotoWhat.text = "CEK RANKING-KU";
        }
    }

    public void changeState(){
        if(personalRank){
            personalRank = false;
        }else{
            personalRank = true;
        }
    }

    public void getPersonalRank(){
        LootLockerSDKManager.GetMemberRank(dbID.ToString(), memberID.text, (response)=>{
            if (response.statusCode == 200) {
                PersonalName.text = response.member_id;
                PersonalRank.text = response.rank.ToString();
                PersonalScore.text = response.score.ToString();
                
            } else {
                Debug.Log("failed: " + response.Error);
            }
        });
    }
}
