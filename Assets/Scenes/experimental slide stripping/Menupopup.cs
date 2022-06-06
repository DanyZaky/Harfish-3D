using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menupopup : MonoBehaviour
{
    public GameObject menupanel;
    public GameObject popuppanel;
    // Start is called before the first frame update
    public void pause()
    {
        menupanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void resume()
    {
        menupanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void popupaktif()
    {
        popuppanel.SetActive(true);
    }
    public void popupoff()
    {
        popuppanel.SetActive(false);
    }
    public void home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
}
