using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        scoreBoard.p1score = scoreBoard.p1score + 1;
        other.transform.position = new Vector3(0, 0, 0);
    }
}