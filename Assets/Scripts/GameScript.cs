using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{

    public static GameScript instance;

    private int spriteIndex = -1;
    private bool canClick = false;
    private bool isHost;
    public TMP_Text rada;

    // Vars related to REST API
    private int lobbyId = -1;

    private void Start()
    {
        Invoke("OpakujucasaMetoda", 1f);
    }

    private void Update()
    {
        rada.text = canClick ? "Si na rade" : "Nie si na rade";

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GoToMenu();
        }
    }

    private void OpakujucasaMetoda()
    {
        StartCoroutine(Rest.Get(getLobbyId()));
        Invoke("OpakujucasaMetoda", 1f);
    }

    private void Awake()
    {
        if(instance != null) return;
        instance = this;

        int lobbyIdToConnect = PlayerPrefs.GetInt("game");
        if(lobbyIdToConnect == -1) {
            setIsHost(true);
            PlayerPrefs.SetInt("p1x", -1);
            PlayerPrefs.SetInt("p1y", -1);
            PlayerPrefs.SetInt("p2x", -2);
            PlayerPrefs.SetInt("p2y", -2);
            StartCoroutine(Rest.CreateLobby());
        } else {
            setIsHost(false);
            PlayerPrefs.SetInt("p1x", -1);
            PlayerPrefs.SetInt("p1y", -1);
            PlayerPrefs.SetInt("p2x", -1);
            PlayerPrefs.SetInt("p2y", -1);
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

    public void GoToMenu()
    {
        Debug.Log("xd");
        SceneManager.LoadScene("Menu");
    }
         
    public bool getCanClick()
    {
        return canClick;
    }

    public void setCanClick(bool canC)
    {
        this.canClick = canC;
    }

    public bool getIsHost()
    {
        return isHost;
    }

    public void setIsHost(bool host)
    {
        this.isHost = host;
    }

}
