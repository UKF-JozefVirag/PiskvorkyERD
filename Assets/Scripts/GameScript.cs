using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameScript : MonoBehaviour
{


    private int spriteIndex = -1;
    private GameObject[] XOS;

    private void Awake()
    {

    }

    public int PlayerTurn()
    {
        spriteIndex++;
        return spriteIndex % 2; //always return 0 - 1
    }


}
