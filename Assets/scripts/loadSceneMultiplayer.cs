using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadSceneMultiplayer : MonoBehaviour
{
	 void Update() { }

	public void ButtonInteract()
	{
		PlayerPrefs.SetInt("AI", 2);
		SceneManager.LoadScene("brick breaker");
	}
}
