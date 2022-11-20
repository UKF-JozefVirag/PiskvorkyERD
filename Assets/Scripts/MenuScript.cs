using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuScript : MonoBehaviour
{
public GameObject cnvMain;
	public void CreateGame() 
	{
		SceneManager.LoadScene("Game");
	}

	public void JoinGame() 
	{
		SceneManager.LoadScene("Game");
	}

    	// Start is called before the first frame update
    	void Start()
    	{
    			    
    	}

    	// Update is called once per frame
    	void Update()
    	{
      		  
    	}
}