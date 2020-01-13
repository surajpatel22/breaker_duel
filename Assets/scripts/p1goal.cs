using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        scoreBoard.p2score = scoreBoard.p2score + 1;
        other.transform.position = new Vector3(0, 0, 0);
    }
}