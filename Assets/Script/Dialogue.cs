using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComp;
    public Image characterObj;
    public string[] lines;
    public Sprite[] giriCharacter;
    public float textSpeed;
    [SerializeField] GameObject panelDialogue;
    [SerializeField] GameObject tutor1DisplayObj;

    //starting
    public GameObject[] IkanDiKolam;

    private int index;

    void Start()
    {
        textComp.text = string.Empty;
        characterObj.sprite = giriCharacter[index];

        tutor1DisplayObj.SetActive(false);

        for (int i = 0; i < IkanDiKolam.Length; i++)
        {
            IkanDiKolam[i].GetComponent<BoxCollider2D>().enabled = false;
        }

        StartDialogue();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (textComp.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComp.text = lines[index];
                characterObj.sprite = giriCharacter[index];
            }
        }

        Debug.Log(giriCharacter[index]);
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComp.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComp.text = string.Empty;
            characterObj.sprite = giriCharacter[index];

            StartCoroutine(TypeLine());
        }
        else
        {
            panelDialogue.SetActive(false);
            tutor1DisplayObj.SetActive(true);

            for (int i = 0; i < IkanDiKolam.Length; i++)
            {
                IkanDiKolam[i].GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
}
