using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class scoreBoard : MonoBehaviour
{
    public Text score;
    public static int p1score = 0;
    public static int p2score = 0;
    public GameObject mgo;

    void FixedUpdate()
    {
        score.text = p1score.ToString() + "  " + p2score.ToString();
        if (p1score == 11)
        {
            score.text = "P1 Wins";
            mgo.GetComponent<pause>().endGame();
            p1score = 0;
            p2score = 0;
        }
        else if (p2score == 11)
        {
            score.text = "P2 Wins";
            mgo.GetComponent<pause>().endGame();
            p1score = 0;
            p2score = 0;
        }
        else if (p1score == 11 && p2score == 11)
        {
            score.text = "TIE!";
            mgo.GetComponent<pause>().endGame();
            p1score = 0;
            p2score = 0;
        }
    }
}