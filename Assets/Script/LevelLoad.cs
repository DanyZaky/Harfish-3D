using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoad : MonoBehaviour
{
    public GameObject loadingScene;
    public Slider sliderLoad;
    
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));

        if (sceneIndex == 0)
        {
            SoundManager.Instance.PlayBGM("BGM 1");
        }
        if (sceneIndex == 1 || sceneIndex == 6 || sceneIndex == 11 || sceneIndex == 16 || sceneIndex == 21 || sceneIndex == 26 || sceneIndex == 31 || sceneIndex == 36 || sceneIndex == 41 || sceneIndex == 46 ||
            sceneIndex == 51 || sceneIndex == 56 || sceneIndex == 61 || sceneIndex == 66 || sceneIndex == 71 || sceneIndex == 76 || sceneIndex == 81 || sceneIndex == 86 || sceneIndex == 91 || sceneIndex == 96)
        {
            SoundManager.Instance.PlayBGM("BGM 2");
        }
        if (sceneIndex == 2 || sceneIndex == 7 || sceneIndex == 12 || sceneIndex == 17 || sceneIndex == 22 || sceneIndex == 27 || sceneIndex == 32 || sceneIndex == 37 || sceneIndex == 42 || sceneIndex == 47 ||
            sceneIndex == 52 || sceneIndex == 57 || sceneIndex == 62 || sceneIndex == 67 || sceneIndex == 72 || sceneIndex == 77 || sceneIndex == 82 || sceneIndex == 87 || sceneIndex == 92 || sceneIndex == 97)
        {
            SoundManager.Instance.PlayBGM("BGM 1");
        }
        if (sceneIndex == 3 || sceneIndex == 8 || sceneIndex == 13 || sceneIndex == 18 || sceneIndex == 23 || sceneIndex == 28 || sceneIndex == 33 || sceneIndex == 38 || sceneIndex == 43 || sceneIndex == 48 ||
            sceneIndex == 53 || sceneIndex == 58 || sceneIndex == 63 || sceneIndex == 68 || sceneIndex == 73 || sceneIndex == 78 || sceneIndex == 83 || sceneIndex == 88 || sceneIndex == 93 || sceneIndex == 98)
        {
            SoundManager.Instance.PlayBGM("BGM 1");
        }
        if (sceneIndex == 4 || sceneIndex == 9 || sceneIndex == 14 || sceneIndex == 19 || sceneIndex == 24 || sceneIndex == 29 || sceneIndex == 34 || sceneIndex == 39 || sceneIndex == 44 || sceneIndex == 49 ||
            sceneIndex == 54 || sceneIndex == 59 || sceneIndex == 64 || sceneIndex == 69 || sceneIndex == 74 || sceneIndex == 79 || sceneIndex == 84 || sceneIndex == 89 || sceneIndex == 94 || sceneIndex == 99)
        {
            SoundManager.Instance.PlayBGM("BGM 2");
        }
        if (sceneIndex == 5 || sceneIndex == 10 || sceneIndex == 15 || sceneIndex == 20 || sceneIndex == 25 || sceneIndex == 30 || sceneIndex == 35 || sceneIndex == 40 || sceneIndex == 45 || sceneIndex == 50 ||
            sceneIndex == 55 || sceneIndex == 60 || sceneIndex == 65 || sceneIndex == 70 || sceneIndex == 75 || sceneIndex == 80 || sceneIndex == 85 || sceneIndex == 90 || sceneIndex == 95 || sceneIndex == 100)
        {
            SoundManager.Instance.PlayBGM("BGM 1");
        }
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScene.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            sliderLoad.value = progress;

            yield return null;
        }
    }
}
