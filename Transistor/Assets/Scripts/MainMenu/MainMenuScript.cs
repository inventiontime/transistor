using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public Button playButton;

    void Start() =>
        playButton.interactable =
            PlayerPrefs.GetInt("TransistorTutorialCompleted") != 0 &&
            PlayerPrefs.GetInt("DeviceTutorialCompleted") != 0 &&
            PlayerPrefs.GetInt("EditorTutorialCompleted") != 0;

    public void Play() => SceneManager.LoadScene("StageSelect");

    public void HowTo() => SceneManager.LoadScene("TutorialMenu");
}
