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

    public void startGame(int value)
    {
        SceneManager.LoadScene(value);
        SoundManager.Instance.PlayBGM("BGM 2");
        SoundManager.Instance.PlaySFX("SFX Button");
    }

    public void startPijah(int value)
    {
        SceneManager.LoadScene(value);
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
        if (value == 1 || value == 6 || value == 11 || value == 16 || value == 21 || value == 26 || value == 31 || value == 36 || value == 41 || value == 46 ||
            value == 51 || value == 56 || value == 61 || value == 66 || value == 71 || value == 76 || value == 81 || value == 86 || value == 91 || value == 96)
        {
            SoundManager.Instance.PlayBGM("BGM 2");
        }
        if (value == 2 || value == 7 || value == 12 || value == 17 || value == 22 || value == 27 || value == 32 || value == 37 || value == 42 || value == 47 ||
            value == 52 || value == 57 || value == 62 || value == 67 || value == 72 || value == 77 || value == 82 || value == 87 || value == 92 || value == 97)
        {
            SoundManager.Instance.PlayBGM("BGM 1");
        }
        if (value == 3 || value == 8 || value == 13 || value == 18 || value == 23 || value == 28 || value == 33 || value == 38 || value == 43 || value == 48 ||
            value == 53 || value == 58 || value == 63 || value == 68 || value == 73 || value == 78 || value == 83 || value == 88 || value == 93 || value == 98)
        {
            SoundManager.Instance.PlayBGM("BGM 1");
        }
        if (value == 4 || value == 9 || value == 14 || value == 19 || value == 24 || value == 29 || value == 34 || value == 39 || value == 44 || value == 49 ||
            value == 54 || value == 59 || value == 64 || value == 69 || value == 74 || value == 79 || value == 84 || value == 89 || value == 94 || value == 99)
        {
            SoundManager.Instance.PlayBGM("BGM 2");
        }
        if (value == 5 || value == 10 || value == 15 || value == 20 || value == 25 || value == 30 || value == 35 || value == 40 || value == 45 || value == 50 ||
            value == 55 || value == 60 || value == 65 || value == 70 || value == 75 || value == 80 || value == 85 || value == 90 || value == 95 || value == 100)
        {
            SoundManager.Instance.PlayBGM("BGM 1");
        }
    }
}
