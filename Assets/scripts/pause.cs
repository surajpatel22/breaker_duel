using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    private bool pauseScene;
    private float fixedDeltaTime;

    public GameObject l1;
    public GameObject l2;
    public GameObject l3;
    public GameObject l4;

    void Start()
    {
        pauseScene = false;
        this.fixedDeltaTime = Time.fixedDeltaTime;
        Time.timeScale = 1f;
    }

    public void pauseing()
    {
        if (pauseScene)
        {
            pauseScene = false;
            l1.SetActive(false);
            l2.SetActive(false);
            l3.SetActive(false);
            l4.SetActive(true);
        }   
        else
        {
            pauseScene = true;
            l1.SetActive(true);
            l2.SetActive(true);
            l3.SetActive(true);
            l4.SetActive(true);
        }
    }
    public void restart()
    {
        Time.timeScale = 1f;
        pauseScene = false;
        l1.SetActive(false);
        l2.SetActive(false);
        l3.SetActive(false);
        l4.SetActive(true);
        SceneManager.LoadScene("brick breaker");
    }
    public void mainMenu()
    {
        Time.timeScale = 1f;
        pauseScene = false;
        l1.SetActive(false);
        l2.SetActive(false);
        l3.SetActive(false);
        l4.SetActive(true);
        SceneManager.LoadScene("Menu");
    }
    public void endGame()
    {
        pauseScene = true;
        l1.SetActive(true);
        l2.SetActive(true);
        l3.SetActive(true);
        l4.SetActive(false);
    }
    void Update()
    {
        if (pauseScene)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
    }
}
