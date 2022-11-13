using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TokenComparer : IComparer
{
    int IComparer.Compare(object x, object y)
    {
        return ((new CaseInsensitiveComparer()).Compare(((GameObject)x).name, ((GameObject)y).name));
    }
}

public class TurnScript : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    GameObject gameBoard;
    public Sprite[] images;
    private bool unplayed = true;
    private GameObject[] XO;
    public GameObject WinGamePanel = null;
    public TMP_Text WinGameText;

    /*
     * 
     *XO[0] = Token9
     *XO[1] = Token8
     *XO[2] = Token7
     *XO[3] = Token6
     *XO[4] = Token5
     *XO[5] = Token4
     *XO[6] = Token3
     *XO[7] = Token2
     *XO[8] = Token1
     *
     */

    private void Start()
    {
        IComparer myComparer = new TokenComparer();
        spriteRenderer.sprite = null;
        XO = GameObject.FindGameObjectsWithTag("Tokens");
        Array.Sort(XO, myComparer);
    }

    private void Update()
    {
        Debug.Log(XO[0]);
        CheckBoard();
    }

    private void OnMouseDown()
    {
        if (unplayed)
        {
            int index = gameBoard.GetComponent<GameScript>().PlayerTurn();
            spriteRenderer.sprite = images[index];
            unplayed = false;
        }
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameBoard = GameObject.Find("GameBoard");
        WinGamePanel.SetActive(false);
    }


    private void CheckBoard()
    {
        /*
           ...
           ...
           XXX
        */
        if (XO[6].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[7].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[8].GetComponent<SpriteRenderer>().sprite == images[0]){
            WinX();
        }
        else if (XO[6].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[7].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[8].GetComponent<SpriteRenderer>().sprite == images[1]){
            WinO();
        }
         /*
           ...
           XXX
           ...
        */
        else if (XO[3].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[4].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[5].GetComponent<SpriteRenderer>().sprite == images[0]){
            WinX();
        }
        else if (XO[3].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[4].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[5].GetComponent<SpriteRenderer>().sprite == images[1])
        {
            WinO();
        }
         /*
           XXX
           ...
           ...
        */
        else if (XO[0].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[1].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[2].GetComponent<SpriteRenderer>().sprite == images[0]){
            WinX();
        }
        else if (XO[0].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[1].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[2].GetComponent<SpriteRenderer>().sprite == images[1])
        {
            WinO();
        } 
        
        /*
           X..
           X..
           X..
        */
        else if (XO[0].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[3].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[6].GetComponent<SpriteRenderer>().sprite == images[0]){
            WinX();
        }
        else if (XO[0].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[3].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[6].GetComponent<SpriteRenderer>().sprite == images[1])
        {
            WinO();
        }
        /*
           .X.
           .X.
           .X.
        */
        else if (XO[1].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[4].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[7].GetComponent<SpriteRenderer>().sprite == images[0]){
            WinX();
        }
        else if (XO[1].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[4].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[7].GetComponent<SpriteRenderer>().sprite == images[1])
        {
            WinO();
        }
        /*
           ..X
           ..X
           ..X
        */
        else if (XO[2].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[5].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[8].GetComponent<SpriteRenderer>().sprite == images[0]){
            WinX();
        }
        else if (XO[2].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[5].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[8].GetComponent<SpriteRenderer>().sprite == images[1])
        {
            WinO();
        }
        /*
           X..
           .X.
           ..X
        */
        else if (XO[0].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[4].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[8].GetComponent<SpriteRenderer>().sprite == images[0]){
            WinX();
        }
        else if (XO[0].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[4].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[8].GetComponent<SpriteRenderer>().sprite == images[1])
        {
            WinO();
        }
        /*
           ..X
           .X.
           X..
        */
        else if (XO[2].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[4].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[6].GetComponent<SpriteRenderer>().sprite == images[0]){
            WinX();
        }
        else if (XO[2].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[4].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[6].GetComponent<SpriteRenderer>().sprite == images[1])
        {
            WinO();
        }
    }


    public void WinX()
    {
        WinGamePanel.SetActive(true);
        TurnOffXO();
        WinGameText.text = "Player 'X' Won!";
        Debug.Log("asdasd");
    }

    public void WinO()
    {
        WinGamePanel.SetActive(true);
        TurnOffXO();
        WinGameText.text = "Player 'O' Won!";
    }

    public void TurnOffXO()
    {
        XO = GameObject.FindGameObjectsWithTag("Tokens");
        foreach (GameObject xdd in XO)
        {
            xdd.GetComponent<BoxCollider2D>().enabled = false;
        }
    }


}
