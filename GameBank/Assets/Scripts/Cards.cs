using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cards : MonoBehaviour
{
    Controller controller;

    public GameObject[] cards;
    public TextMeshProUGUI[] cardText;

    void Start()
    {
        controller = FindObjectOfType<Controller>();
    }

    void Update()
    {
        for (int i = controller.noOfPlayers; i < 6; i++)
            cards[i].SetActive(false);

        for (int i = 0; i < controller.noOfPlayers; i++)
            cardText[i].text = controller.names[i] + " : " + controller.balance[i].ToString();
    }
}
