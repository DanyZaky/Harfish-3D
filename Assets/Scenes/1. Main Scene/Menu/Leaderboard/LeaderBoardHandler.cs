using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;
public class LeaderBoardHandler : MonoBehaviour
{
    
    private int currentPosition, count;
    private bool hias, konsumsi;
    [SerializeField] Text namaIkanTextBox;
    [SerializeField] GameObject parentIkan, gambarIkanObject, rankPrefabs,noRank;
    [SerializeField] GameObject[] topGlobal;
    //[SerializeField] GameObject[] menu;
    [SerializeField] string[] namaIkan;
    [SerializeField] string[][] namaPemain, scorePemain;
    [SerializeField] Sprite[] gambarIkan,gambarStep;
    [SerializeField] float[] posisiGambarIkan;
    [SerializeField] RectTransform content;
    private Vector2 tempSize;
    [SerializeField] int[] dbID;
    [SerializeField] Scrollbar scroll;
    private int[] banyak;
    private LootLockerLeaderboardMember[] allMember;
    void Start()
    {
        //banyak  = new int[dbID.Length+5];
        currentPosition = 0;
        tempSize = content.sizeDelta;
        Mulai();
        // namaPemain = new string[dbID.Length+5][];
        // scorePemain = new string[dbID.Length+5][];
        // for(int i = 0; i<dbID.Length; i++)
        // {
        //     namaPemain[i] = new string[105];
        //     scorePemain[i] = new string[105];

        // }
        //GetScore();
        //AllScore();
        Change();
    }

    private void Mulai()
    {
        LootLockerSDKManager.StartSession("guest".ToString(), (response)=>{
            if (response.success){
                Debug.Log("success!");
            }else{
                Debug.Log("failed");
            }
        });  
    }

    // private void AllScore()
    // {
    //     for(int i = 0;i < dbID.Length; i++)
    //     {
    //         LootLockerSDKManager.GetScoreList(dbID[i], 100, async (response) => {
    //             if(response.success){
    //                 allMember = response.items;
                    
    //                 for(int j =0;j<allMember.Length;j++)
    //                 {
    //                     banyak[i] = j;
    //                     namaPemain[i][j] = allMember[j].member_id;
    //                     scorePemain[i][j] = allMember[j].score.ToString();
    //                 }
    //             }else{
    //                 Debug.Log("failed: " + response.Error);
    //             }
    //         } );  
    //     }
    // }

    private void GetScore()
    {
        LootLockerSDKManager.GetScoreList(dbID[currentPosition], 100, async (response) => {
            if(response.success){
                allMember = response.items;
                Peringkat();
            }else{
                Debug.Log("failed: " + response.Error);
            }
        } );
    }
    
    private void Peringkat()
    {
        if(allMember.Length == 0)
        //if(banyak[currentPosition] == 0)
        {
            noRank.SetActive(true);
        }
        else
        {
            if(noRank.activeSelf)
            noRank.SetActive(false);
            for(int j = 0; j < allMember.Length; j++)
            {
                if(j<3)
                {
                    //topGlobal[j].transform.GetChild(1).GetComponent<Text>().text = namaPemain[currentPosition][j];
                    //topGlobal[j].transform.GetChild(2).GetComponent<Text>().text = scorePemain[currentPosition][j];
                    topGlobal[j].transform.GetChild(2).GetComponent<Text>().text = allMember[j].score.ToString();
                    topGlobal[j].transform.GetChild(1).GetComponent<Text>().text = allMember[j].member_id;
                    topGlobal[j].SetActive(true);
                }
                else
                {
                   // content.sizeDelta = new Vector2(tempSize.x, content.sizeDelta.y+100);
                    GameObject nr = Instantiate(rankPrefabs) as GameObject;
                    nr.transform.SetParent(GameObject.Find("Content").transform,false);
                    nr.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = (j+1).ToString();
                   // nr.transform.GetChild(1).GetComponent<Text>().text = namaPemain[currentPosition][j];
                   // nr.transform.GetChild(2).GetComponent<Text>().text = scorePemain[currentPosition][j];
                     nr.transform.GetChild(1).GetComponent<Text>().text = allMember[j].member_id;
                     nr.transform.GetChild(2).GetComponent<Text>().text = allMember[j].score.ToString();
                     
                }
                if(j<3)
                content.sizeDelta = new Vector2(tempSize.x, 420);
                else
                {
                    content.sizeDelta = new Vector2(tempSize.x, 88.5f*(j+1));
                    content.position =  new Vector3(content.position.x,-5000,content.position.z) ;

                }
            }
        }
    }
    

    private void Change()
    {
        gambarIkanObject.GetComponent<Image>().sprite = gambarIkan[currentPosition];
        gambarIkanObject.transform.localPosition = new Vector3 (posisiGambarIkan[currentPosition], 0,0);
        namaIkanTextBox.text = namaIkan[currentPosition].ToUpper();
        parentIkan.transform.GetChild(currentPosition).GetComponent<Image>().sprite = gambarStep[1];
        parentIkan.transform.GetChild(currentPosition).GetComponent<RectTransform>().sizeDelta = new Vector2(40,40);
        Destroying();
        GetScore();
        
        
        //Peringkat();
        
        
    }
    public void Next()
    {
        currentPosition++;
        parentIkan.transform.GetChild(currentPosition-1).GetComponent<Image>().sprite = gambarStep[0];
        parentIkan.transform.GetChild(currentPosition-1).GetComponent<RectTransform>().sizeDelta = new Vector2(20,20);
        if(hias)
            if(currentPosition >= 14) currentPosition = 0;  
        if(konsumsi)
            if(currentPosition >= 6) currentPosition = 0;
        Change();
        
    }

    public void Back()
    {
        currentPosition--;
        parentIkan.transform.GetChild(currentPosition+1).GetComponent<RectTransform>().sizeDelta = new Vector2(20,20);
        parentIkan.transform.GetChild(currentPosition+1).GetComponent<Image>().sprite = gambarStep[0];
        if(hias)
            if(currentPosition <= -1) currentPosition = 13;
        if(konsumsi)
            if(currentPosition <= -1) currentPosition = 5;
        Change();
    }

    // public void Return()
    // {
    //     menu[0].SetActive(true);
    //     if(hias)
    //     {
    //         menu[1].SetActive(false);
    //         hias = false;
    //     }
    //     if(konsumsi)
    //     {
    //         menu[2].SetActive(false);
    //         konsumsi = false;
    //     }
    // }

    public void Hias()
    {
        hias = true;
    }

    public void Konsumsi()
    {
        konsumsi = true;
    }
    
    private void Destroying()
    {
        GameObject contents = GameObject.Find("Content");
        if( contents.transform.childCount> 0)
        {
            for(int i = 3; i<contents.transform.childCount;i++)
            {
                Destroy(contents.transform.GetChild(i).gameObject);
            }
        }
       // content.sizeDelta = new Vector2(tempSize.x, tempSize.y);
        topGlobal[0].SetActive(false);
        topGlobal[1].SetActive(false);
        topGlobal[2].SetActive(false);
        
    }

}
