using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void Play()
    {
        if(PlayerPrefs.GetInt("TransistorTutorialCompleted") == 0 || PlayerPrefs.GetInt("DeviceTutorialCompleted") == 0 || PlayerPrefs.GetInt("EditorTutorialCompleted") == 0)
            SceneManager.LoadScene("TutorialMenu");
        else
            SceneManager.LoadScene("LevelSelect");
    }

    public void HowTo() => SceneManager.LoadScene("TutorialMenu");
}
