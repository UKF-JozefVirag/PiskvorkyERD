using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurnScript : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    GameObject gameBoard;
    public Sprite[] images;
    private bool unplayed = true;
    private GameObject[] XO;

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
        XO = GameObject.FindGameObjectsWithTag("Tokens");
        spriteRenderer.sprite = null;
    }

    private void Update()
    {
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
    }


    private void CheckBoard()
    {
        /*
           ...
           ...
           XXX
        */
        if (XO[0].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[1].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[2].GetComponent<SpriteRenderer>().sprite == images[0]){
            gameBoard.GetComponent<GameScript>().WinX();
        }
        else if (XO[0].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[1].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[2].GetComponent<SpriteRenderer>().sprite == images[1])
        {
            gameBoard.GetComponent<GameScript>().WinO();
        }
         /*
           ...
           XXX
           ...
        */
        else if (XO[3].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[4].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[5].GetComponent<SpriteRenderer>().sprite == images[0]){
            gameBoard.GetComponent<GameScript>().WinX();
        }
        else if (XO[3].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[4].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[5].GetComponent<SpriteRenderer>().sprite == images[1])
        {
            gameBoard.GetComponent<GameScript>().WinO();
        }
         /*
           XXX
           ...
           ...
        */
        else if (XO[8].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[7].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[6].GetComponent<SpriteRenderer>().sprite == images[0]){
            gameBoard.GetComponent<GameScript>().WinX();
        }
        else if (XO[8].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[7].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[6].GetComponent<SpriteRenderer>().sprite == images[1])
        {
            gameBoard.GetComponent<GameScript>().WinO();
        } 
        
        /*
           X..
           X..
           X..
        */
        else if (XO[8].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[5].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[2].GetComponent<SpriteRenderer>().sprite == images[0]){
            gameBoard.GetComponent<GameScript>().WinX();
        }
        else if (XO[8].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[5].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[2].GetComponent<SpriteRenderer>().sprite == images[1])
        {
            gameBoard.GetComponent<GameScript>().WinO();
        }
        /*
           .X.
           .X.
           .X.
        */
        else if (XO[7].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[3].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[1].GetComponent<SpriteRenderer>().sprite == images[0]){
            gameBoard.GetComponent<GameScript>().WinX();
        }
        else if (XO[7].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[3].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[1].GetComponent<SpriteRenderer>().sprite == images[1])
        {
            gameBoard.GetComponent<GameScript>().WinO();
        }
        /*
           ..X
           ..X
           ..X
        */
        else if (XO[6].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[3].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[0].GetComponent<SpriteRenderer>().sprite == images[0]){
            gameBoard.GetComponent<GameScript>().WinX();
        }
        else if (XO[6].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[3].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[0].GetComponent<SpriteRenderer>().sprite == images[1])
        {
            gameBoard.GetComponent<GameScript>().WinO();
        }
        /*
           X..
           .X.
           ..X
        */
        else if (XO[8].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[4].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[0].GetComponent<SpriteRenderer>().sprite == images[0]){
            gameBoard.GetComponent<GameScript>().WinX();
        }
        else if (XO[8].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[4].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[0].GetComponent<SpriteRenderer>().sprite == images[1])
        {
            gameBoard.GetComponent<GameScript>().WinO();
        }
        /*
           ..X
           .X.
           X..
        */
        else if (XO[6].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[4].GetComponent<SpriteRenderer>().sprite == images[0] && 
            XO[2].GetComponent<SpriteRenderer>().sprite == images[0]){
            gameBoard.GetComponent<GameScript>().WinX();
        }
        else if (XO[6].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[4].GetComponent<SpriteRenderer>().sprite == images[1] &&
            XO[2].GetComponent<SpriteRenderer>().sprite == images[1])
        {
            gameBoard.GetComponent<GameScript>().WinO();
        }
    }


}
