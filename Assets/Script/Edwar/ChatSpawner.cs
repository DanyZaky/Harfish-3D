using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatSpawner : MonoBehaviour
{
    public GameObject chatObj, panelNotifRight, PrefabNotif, PrefabPesanMasuk, PanelPesanMasuk;


    bool isSpawning;
    public float timeChatSpawn;
    private float timeChatSpawnCounter;

    public int max = 10;
    int jumlah;

    int nama_random;
    int nama_ikan_random;
    public TMP_Text txtNama, txtJumlah, txtWaktu;



    public TextAsset AssetPembeliTxt;
    private string[,] pembeli;
    private string[] pembeliGetAssetTxt;
    int indexMessage;

    public TMP_Text txtHeaderName;
    public Image Gambar;
    public Sprite[] gambar;





    public string[] nama;
    public string[] nama_ikan;
    private void Start()
    {
        pembeliGetAssetTxt = AssetPembeliTxt.ToString().Split('#');
        pembeli = new string[pembeliGetAssetTxt.Length, 12];
        Pembeli();
        ShowBoxChat();

        isSpawning = false;
        timeChatSpawnCounter = Random.Range(3, timeChatSpawn);
    }

    private void Update()
    {
        updateTextMessage();
        timeChatSpawnCounter -= 1f * Time.deltaTime;

        if (isSpawning == false)
        {
            if (timeChatSpawnCounter <= 0)
            {
                timeChatSpawnCounter = timeChatSpawn;
                isSpawning = true;
            }
        }

        if (isSpawning == true)
        {
            GameObject newIkan = Instantiate(PrefabNotif, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
            newIkan.transform.SetParent(panelNotifRight.transform, false);


            jumlah = Random.Range(1, max);
            nama_random = Random.Range(0, nama.Length);
            nama_ikan_random = Random.Range(0, nama_ikan.Length);

            //GameObject ww = newIkan.transform.GetChild(1).gameObject;
            //ww.transform.GetComponent<TMPro.TextMeshProUGUI>().text = timeChatSpawnCounter.ToString();

            //GameObject aa = newIkan.transform.GetChild(0).GetChild(0).gameObject;
            //aa.transform.GetComponent<TMPro.TextMeshProUGUI>().text = "Nama : "+nama[nama_random];
            GameObject aa = newIkan.transform.GetChild(0).GetChild(0).gameObject;
            aa.transform.GetComponent<TMPro.TextMeshProUGUI>().text = "Pesan baru dari " + nama[nama_random];
            //GameObject bb = newIkan.transform.GetChild(0).GetChild(1).gameObject;
            //bb.transform.GetComponent<TMPro.TextMeshProUGUI>().text = "Pesanan : " + jumlah + " ekor "+ nama_ikan[nama_ikan_random];
            //GameObject cc = newIkan.transform.GetChild(0).GetChild(2).gameObject;
            //cc.transform.GetComponent<TMPro.TextMeshProUGUI>().text = "Harga : 200/ekor";

            pesan_masuk();

            isSpawning = false;

        }
    }

    public void buttonSell()
    {
        isSpawning = false;
        timeChatSpawnCounter = timeChatSpawn;
    }
    public void buttonCloseNotif()
    {
        transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
    }
    public void pesan_masuk()
    {
        GameObject newIkan = Instantiate(PrefabPesanMasuk, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
        newIkan.transform.SetParent(PanelPesanMasuk.transform, false);

        GameObject aa = newIkan.transform.GetChild(1).GetChild(0).gameObject;
        aa.transform.GetComponent<TMPro.TextMeshProUGUI>().text = nama[nama_random];
        //GameObject bb = newIkan.transform.GetChild(1).GetChild(1).gameObject;
        //bb.transform.GetComponent<TMPro.TextMeshProUGUI>().text = "Pesanan : " + jumlah + " ekor " + nama_ikan[nama_ikan_random];
        //GameObject cc = newIkan.transform.GetChild(0).GetChild(2).gameObject;
        //cc.transform.GetComponent<TMPro.TextMeshProUGUI>().text = "Harga : 200/ekor";
    }
    public void Pembeli()
    {
        for (int i = 0; i < pembeliGetAssetTxt.Length; i++)
        {
            string[] tempSoal = pembeliGetAssetTxt[i].Split('+');
            for (int j = 0; j < tempSoal.Length; j++)
            {
                pembeli[i, j] = tempSoal[j];
                continue;

            }
            continue;
        }
    }
    private void ShowBoxChat()
    {
        for (int i = 0; i < pembeliGetAssetTxt.Length; i++)
        {
            print(pembeli[i, 0]);
            GameObject newBoxMessage = Instantiate(PrefabPesanMasuk, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
            newBoxMessage.transform.SetParent(PanelPesanMasuk.transform, false);

            int id = int.Parse(pembeli[i, 1]);
            newBoxMessage.transform.GetComponent<Button>().onClick.AddListener(() => ShowMessage(id));

            Image ProfilePicture = newBoxMessage.transform.GetChild(0).gameObject.GetComponent<Image>();
            ProfilePicture.sprite = gambar[id-1];

            GameObject aa = newBoxMessage.transform.GetChild(1).GetChild(0).gameObject;
            aa.transform.GetComponent<TMPro.TextMeshProUGUI>().text = pembeli[i, 0];

            
        }

    }

    public void ShowMessage(int PembeliID)
    {
        indexMessage = PembeliID - 1;
    }
    private void updateTextMessage()
    {
        Gambar.sprite = gambar[indexMessage];
        txtHeaderName.text = pembeli[indexMessage, 0];
        //txtContentChat.text = pembeli[indexMessage, 0];
    }

}
