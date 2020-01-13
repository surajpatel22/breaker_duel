using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class scoreBoard : MonoBehaviour
{
    public Text score;
    public static int p1score = 0;
    public static int p2score = 0;
    // Update is called once per frame

    void Start()
    {
    }

    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(5);
    }

    void FixedUpdate()
    {
        score.text = p1score.ToString() + " - " + p2score.ToString();
        if (p1score == 11)
        {
            score.text = "Player 1 Wins";
            StartCoroutine(waiter());
            SceneManager.LoadScene("brick breaker");
            p1score = 0;
            p2score = 0;
        }
        else if (p2score == 11)
        {
            score.text = "Player 2 Wins";
            StartCoroutine(waiter());
            SceneManager.LoadScene("brick breaker");
            p1score = 0;
            p2score = 0;
        }
        else if (p1score == 11 && p2score == 11)
        {
            score.text = "TIE!";
            StartCoroutine(waiter());
            SceneManager.LoadScene("brick breaker");
            p1score = 0;
            p2score = 0;
        }
    }
}