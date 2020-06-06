using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameObject BuildScreen;
    public GameObject ListScreen;

    public string startScreen;

    GameObject[] screens;

    void Start()
    {
        screens = new GameObject[2];

        screens[0] = BuildScreen;
        screens[1] = ListScreen;

        loadScreen(startScreen);
    }

    public void loadScreen(string screen)
    {
        for (int i = 0; i < screens.Length; i++)
            screens[i].SetActive(false);

        switch (screen)
        {
            case "BuildScreen":
                BuildScreen.SetActive(true);
                break;

            case "ListScreen":
                ListScreen.SetActive(true);
                break;
        }
    }
}
