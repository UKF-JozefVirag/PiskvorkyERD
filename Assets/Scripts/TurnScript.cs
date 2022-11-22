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
    private static GameObject[] XO;
    public GameObject WinGamePanel = null;
    public TMP_Text WinGameText;

    private void Start()
    {
        IComparer myComparer = new TokenComparer();
        spriteRenderer.sprite = null;
        XO = GameObject.FindGameObjectsWithTag("Tokens");
        Array.Sort(XO, myComparer);
    }

    private void Update()
    {
        CheckBoard();
    }

    private void OnMouseDown()
    {
        
        if (unplayed && GameScript.instance.getCanClick())
        {
            GameScript.instance.setCanClick(false);
            int index = GetItemIndex(this.gameObject);
            RenderItem(index);

            int x = index % 3, y = index / 3;
            StartCoroutine(Rest.Post(GameScript.instance.getLobbyId(), GameScript.instance.getIsHost() ? 0 : 1, x, y));
        }
    }

    private int GetItemIndex(GameObject go)
    {
        for (int i = 0; i < XO.Length; i++)
        {
            if (go == XO[i])
            {
                return i;
            }
        }
        return -1;
    }

    public static void RenderItem(int index)
    {
        if (index < 0) return;

        GameObject go = XO[index];
        go.GetComponent<TurnScript>().SetUnplayed(false);
        int sprite = go.GetComponent<TurnScript>().GetGameBoard().GetComponent<GameScript>().PlayerTurn();
        go.GetComponent<TurnScript>().GetSpriteRenderer().sprite = go.GetComponent<TurnScript>().GetSprites()[sprite];
    }

    public static void RenderItem(int x, int y)
    {
        RenderItem(x+y*3);
    }

    public Sprite[] GetSprites()
    {
        return images;
    }

    public GameObject GetGameBoard()
    {
        return gameBoard;
    }
    public SpriteRenderer GetSpriteRenderer()
    {
        return spriteRenderer;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameBoard = GameObject.Find("GameBoard");
        WinGamePanel.SetActive(false);
    }
    
    private bool Remiza()
    {
        foreach (GameObject x in XO)
        {
            if (x.GetComponent<TurnScript>().GetUnplayed())
            {
                return false;
            }
            
        }
        return true;
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

        else if (Remiza())
        {
            Remiiza();
            return;
        }

    }


    public void WinX()
    {
        WinGamePanel.SetActive(true);
        TurnOffXO();
        WinGameText.text = "Player 'X' Won!";
        GameScript.instance.setCanClick(true);
    }

    public void WinO()
    {
        WinGamePanel.SetActive(true);
        TurnOffXO();
        WinGameText.text = "Player 'O' Won!";
        GameScript.instance.setCanClick(true);
    }

    public void Remiiza()
    {
        WinGamePanel.SetActive(true);
        TurnOffXO();
        WinGameText.text = "Remiza";
        GameScript.instance.setCanClick(true);
    }


    public void TurnOffXO()
    {
        XO = GameObject.FindGameObjectsWithTag("Tokens");
        foreach (GameObject xdd in XO)
        {
            xdd.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void SetUnplayed(bool un)
    {
        this.unplayed = un;
    }

    public bool GetUnplayed()
    {
        return this.unplayed;
    }

}
