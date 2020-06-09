using UnityEngine;

public class ListHandler : MonoBehaviour
{
    public GameObject selectedListObject = null;
    public GateMoveHandler gateMoveHandler;
    public GameObject spawnGateUnder;

    void Update()
    {
        if (selectedListObject != null)
        {
            gateMoveHandler.gate = Instantiate(selectedListObject, spawnGateUnder.transform); ;
            gateMoveHandler.noPrevPosition = true;
            selectedListObject = null;
        }
    }
}
