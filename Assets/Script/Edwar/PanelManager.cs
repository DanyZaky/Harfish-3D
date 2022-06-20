using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject Menu1, Menu2, Menu3, Menu4, Menu5;
    public void menu1()
    {
        Menu1.SetActive(true);
    }
    public void menu2()
    {
        Menu2.SetActive(true);
    }
    public void menu3()
    {
        Menu3.SetActive(true);
    }
    public void menu4()
    {
        Menu4.SetActive(true);
    }
    public void menu5()
    {
        Menu5.SetActive(true);
    }
}
