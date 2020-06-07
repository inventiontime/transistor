using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMenuController : MonoBehaviour
{
    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;

    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;

    void Start()
    {
        lock1.SetActive(false);
        lock2.SetActive(true ? PlayerPrefs.GetInt("DeviceTutorialCompleted") == 0 : false);
        lock3.SetActive(true ? PlayerPrefs.GetInt("EditorTutorialCompleted") == 0 : false);

        if(PlayerPrefs.GetInt("DeviceTutorialCompleted") == 0)
        {
            arrow1.SetActive(true);
            arrow2.SetActive(false);
            arrow3.SetActive(false);
        }
        else if(PlayerPrefs.GetInt("EditorTutorialCompleted") == 0)
        {
            arrow1.SetActive(false);
            arrow2.SetActive(true);
            arrow3.SetActive(false);
        }
        else if(PlayerPrefs.GetInt("TransistorTutorialCompleted") == 0)
        {
            arrow1.SetActive(false);
            arrow2.SetActive(false);
            arrow3.SetActive(true);
        }
        else
        {
            arrow1.SetActive(false);
            arrow2.SetActive(false);
            arrow3.SetActive(false);
        }
    }
    
    public void ButtonPressed(int i)
    {
        switch(i)
        {
            case 1:
                SceneManager.LoadScene("DeviceTutorialScene");
                break;

            case 2:
                SceneManager.LoadScene("GameSceneTutorial");
                break;

            case 3:
                SceneManager.LoadScene("TransistorTutorialScene");
                break;
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
