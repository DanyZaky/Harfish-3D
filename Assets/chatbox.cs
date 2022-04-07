using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chatbox : MonoBehaviour
{
    
    public GameObject chat;
    public bool chatboxmuncul;
 
    public void OnMouseDown()
    {
        chat.SetActive(chatboxmuncul);
    }
}
    
