using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueStripping : MonoBehaviour
{
    public TextMeshProUGUI textComp;
    public Image characterObj;
    public string[] lines;
    public Sprite[] giriCharacter;
    public float textSpeed;
    [SerializeField] GameObject panelDialogue;

    public bool startTutorial;

    private int index;

    void Start()
    {
        textComp.text = string.Empty;
        characterObj.sprite = giriCharacter[index];

        startTutorial = false;

        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
        if (index < lines.Length - 1)
        {
            index++;
            textComp.text = string.Empty;
            characterObj.sprite = giriCharacter[index];

            StartCoroutine(TypeLine());
        }
        else
        {
            panelDialogue.SetActive(false);
            startTutorial = true;
        }
    }
}
