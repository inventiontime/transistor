using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public enum Screen { Machine, List }
    public enum ListMode { Balance, From, To }

    public Screen currentScreen;
    public ListMode listMode;


    Display display;

    public int displayNumber;
    public int noOfPlayers;

    public int fromPlayer;
    public int toPlayer;

    public int[] balance;
    public string[] names;
    public GameObject[] screens;

    private void Start()
    {
        display = FindObjectOfType<Display>();
    }

    public void NumberKeyPressed(int i)
    {
        displayNumber *= 10;
        displayNumber += i;

        if (displayNumber > 100000000)
            displayNumber = 100000000;
    }

    public void ClearKeyPressed()
    {
        displayNumber = 0;
    }

    public void BalanceKeyPressed()
    {
        listMode = ListMode.Balance;
        ChangeScreen(Screen.List);
    }

    public void FromKeyPressed()
    {
        listMode = ListMode.From;
        ChangeScreen(Screen.List);
    }

    public void ToKeyPressed()
    {
        listMode = ListMode.To;
        ChangeScreen(Screen.List);
    }

    public void GoKeyPressed()
    {
        balance[fromPlayer] -= displayNumber;
        balance[toPlayer] += displayNumber;
        displayNumber = 0;
    }

    public void CardPressed(int i)
    {
        switch(listMode)
        {
            case ListMode.Balance:
                ChangeScreen(Screen.Machine);
                break;

            case ListMode.From:
                fromPlayer = i;
                ChangeScreen(Screen.Machine);
                break;

            case ListMode.To:
                toPlayer = i;
                ChangeScreen(Screen.Machine);
                break;
        }
    }

    public void ChangeScreen(Screen screen)
    {
        currentScreen = screen;

        for (int i = 0; i < screens.Length; i++)
            screens[i].SetActive(false);

        screens[(int)screen].SetActive(true);
    }
}
