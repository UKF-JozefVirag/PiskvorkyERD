using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public GameObject cnvMain;
    public TMP_InputField id;
	public void CreateGame() 
	{
        PlayerPrefs.SetInt("game", -1);
		SceneManager.LoadScene("Game");
	}

	public void JoinGame() 
	{
        PlayerPrefs.SetInt("game", int.Parse(id.text));
        SceneManager.LoadScene("Game");
	}

    void Start()
    {
    			    
    }

    void Update()
    {
      		  
    }
}