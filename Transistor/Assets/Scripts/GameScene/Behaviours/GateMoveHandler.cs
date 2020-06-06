using UnityEngine;

public class GateMoveHandler : MonoBehaviour
{
    public GameObject gate;
    public bool noPrevPosition;
    public Vector3 prevPosition;

    void Update()
    {
        if (gate != null && Input.GetMouseButton(0))
        {
            gate.GetComponent<CommonScript>().ShowTint(false);
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            gate.transform.position = position;

            gate.GetComponent<CommonScript>().RefreshWires();
        }

        if (gate != null && Input.GetMouseButtonUp(0))
        {
            if (!gate.GetComponent<CommonScript>().IsInOKPosition())
            {
                if (noPrevPosition)
                {
                    Destroy(gate);
                }
                else
                {
                    gate.transform.position = prevPosition;
                    gate.GetComponent<CommonScript>().RefreshWires();
                    gate.GetComponent<CommonScript>().ShowTint(true);
                }
            }
            else
            {
                gate.GetComponent<CommonScript>().RefreshWires();
            }

            gate = null;
        }
    }
}
