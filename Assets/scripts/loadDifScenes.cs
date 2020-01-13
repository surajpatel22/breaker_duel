using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadDifScenes : MonoBehaviour
{
	public float speed_easy;
	public float speed_medium;
	public float speed_hard;

	void Update() { }

	public void easy()
	{
		PlayerPrefs.SetInt("AI", 0);
		PlayerPrefs.SetFloat("Speed", speed_easy);
		PlayerPrefs.SetInt("second paddle", 0);
		SceneManager.LoadScene("brick breaker");
	}

	public void medium()
	{
		PlayerPrefs.SetInt("AI", 0);
		PlayerPrefs.SetFloat("Speed", speed_medium);
		PlayerPrefs.SetInt("second paddle", 0);
		SceneManager.LoadScene("brick breaker");
	}

	public void hard()
	{
		PlayerPrefs.SetInt("AI", 0);
		PlayerPrefs.SetFloat("Speed", speed_hard);
		PlayerPrefs.SetInt("more paddles", 1);

		SceneManager.LoadScene("brick breaker");
	}
}
