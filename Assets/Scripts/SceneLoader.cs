using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public void OnMouseClick(string SceneName) //UI Buttons
	{
		SceneManager.LoadScene(SceneName, mode: LoadSceneMode.Single); //Loads game when menu button is pressed  
	}

	public void GameOver(){
		SceneManager.LoadScene("GameOver", mode: LoadSceneMode.Single);
	}
}
