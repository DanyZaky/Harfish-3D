using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
        SoundManager.Instance.PlayBGM("BGM 2");
        SoundManager.Instance.PlaySFX("SFX Button");
    }

    public void startPijah()
    {
        SceneManager.LoadScene(2);
        SoundManager.Instance.PlayBGM("BGM 1");
        SoundManager.Instance.PlaySFX("SFX Button");
    }

    public void nextScene(int value)
    {
        SceneManager.LoadScene(value);
        SoundManager.Instance.PlaySFX("SFX Button");

        if (value == 0)
        {
            SoundManager.Instance.PlayBGM("BGM 1");
        }
        if (value == 1)
        {
            SoundManager.Instance.PlayBGM("BGM 2");
        }
        if (value == 2)
        {
            SoundManager.Instance.PlayBGM("BGM 1");
        }
        if (value == 3)
        {
            SoundManager.Instance.PlayBGM("BGM 1");
        }
        if (value == 4)
        {
            SoundManager.Instance.PlayBGM("BGM 2");
        }
        if (value == 5)
        {
            SoundManager.Instance.PlayBGM("BGM 1");
        }
    }
}
