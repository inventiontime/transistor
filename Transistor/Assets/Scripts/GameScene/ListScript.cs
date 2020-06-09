using UnityEngine;
using UnityEngine.UI;

public class ListScript : MonoBehaviour
{
    public ListHandler listHandler;
    public ScreenManager screenManager;
    public GameObject[] listPositions;
    public Button leftButton;
    public Button rightButton;

    GameObject[] gates;
    GameObject[] listPositionObjects;

    int pageNo = 0;


    int listLength => listPositions.Length;
    int noOfGates => gates.Length;

    void Start()
    {
        gates = GameManager.Instance.levelData.gates;

        listPositionObjects = new GameObject[listLength];

        InstantiateList();
    }

    void Update()
    {
        if (pageNo > 0)
            leftButton.interactable = true;
        else
            leftButton.interactable = false;

        if (pageNo < Mathf.Ceil((float)noOfGates / listLength) - 1)
            rightButton.interactable = true;
        else
            rightButton.interactable = false;
    }

    public void NextPage()
    {
        DestroyList();
        pageNo++;
        InstantiateList();
    }

    public void PrevPage()
    {
        if (pageNo > 0)
        {
            DestroyList();
            pageNo--;
            InstantiateList();
        }
    }

    void InstantiateList()
    {
        for (int i = 0; i < Mathf.Min(listLength, noOfGates - (pageNo * listLength)); i++)
            listPositionObjects[i] = Instantiate(gates[pageNo * listLength + i], listPositions[i].transform);
    }

    void DestroyList()
    {
        for (int i = 0; i < Mathf.Min(listLength, noOfGates - (pageNo * listLength)); i++)
            Destroy(listPositionObjects[i]);
    }

    public void GateSelected(int i)
    {
        listHandler.selectedListObject = gates[pageNo * listLength + i];
        screenManager.loadScreen("BuildScreen");
    }
}
