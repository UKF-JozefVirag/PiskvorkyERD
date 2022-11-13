using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScript : MonoBehaviour
{

    public GameObject WinGamePanel;
    public TMP_Text WinGameText;
    private int spriteIndex = -1;
    private GameObject[] XOS;

    private void Awake()
    {
        WinGamePanel.SetActive(false);
    }

    public int PlayerTurn()
    {
        spriteIndex++;
        return spriteIndex % 2; //always return 0 - 1
    }

    public void WinX()
    {
        WinGamePanel.SetActive(true);
        TurnOffXO();
        WinGameText.text = "Player 'X' Won!";
    }

    public void WinO()
    {
        WinGamePanel.SetActive(true);
        TurnOffXO();
        WinGameText.text = "Player 'O' Won!";
    }

    public void TurnOffXO()
    {
        XOS = GameObject.FindGameObjectsWithTag("Tokens");
        foreach (GameObject xo in XOS)
        {
            xo.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
