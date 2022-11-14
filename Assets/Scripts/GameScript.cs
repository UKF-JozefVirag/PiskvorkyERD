using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameScript : MonoBehaviour
{

    public static GameScript instance;

    private int spriteIndex = -1;
    private GameObject[] XOS;

    // Vars related to REST API
    private int lobbyId = -1;
    private int player = 0;
    private bool server = true;

    private void Awake()
    {
        if(instance != null) return;
        instance = this;

        if(server) {
            player = 0;
            StartCoroutine(Rest.CreateLobby());
        } else {
            player = 1;
            // TODO: Get lobbyId where player want to connect (for now I am hardcoding it)
            int lobbyIdToConnect = 0;
            StartCoroutine(Rest.ConnectToLobby(lobbyIdToConnect));
        }
    }

    public int PlayerTurn()
    {
        spriteIndex++;
        return spriteIndex % 2; //always return 0 - 1
    }

    public void setLobbyId(int lobbyId) {
        this.lobbyId = lobbyId;
        GameObject.Find("Lobby ID Label").GetComponent<TMP_Text>().text = $"Lobby ID: {lobbyId}";
    }

    public int getLobbyId() {
        return lobbyId;
    }

    public int getPlayer() {
        return player;
    }


}
