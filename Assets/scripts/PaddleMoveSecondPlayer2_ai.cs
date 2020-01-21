using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMoveSecondPlayer2_ai : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction;
    private float moveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (PlayerPrefs.GetInt("more paddles", 0) == 0)
        {
            Destroy(gameObject);
        }

        moveSpeed = PlayerPrefs.GetFloat("Speed", 0);

        if (transform.position.y == 2.5f)
        {
            moveSpeed *= 5f;
        }
        else
        {
            transform.localScale += new Vector3(-0.5f, 0f, 0f);
        }

        GameObject.Find("Player 2").transform.Translate(new Vector3(0.75f, 0f, 0f));

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("The_ball");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance && (go.transform.position.y < 2 || transform.position.y == 2.5) && 
                (go.transform.position.y < 2.5 || transform.position.y == 2) && 
                go.GetComponent<Rigidbody>().velocity.y > 0 && (transform.position.y == 2.5 || go.transform.position.x < 0))
            {
                closest = go;
                distance = curDistance;
            }
        }
        if (closest != null)
        {
            direction = (closest.transform.position - transform.position);
        }

        if (transform.position.y == 2.5 && direction.x < 0 && !Physics.CheckSphere(transform.position + new Vector3(-1.1f, 0, 0), 0.04f))
        {
            rb.velocity = new Vector3(direction.x, 0f, 0f) * moveSpeed;
        }
        else if (transform.position.y == 2 && direction.x < 0 && !Physics.CheckSphere(transform.position + new Vector3(-0.85f, 0, 0), 0.04f))
        {
            rb.velocity = new Vector3(direction.x, 0f, 0f) * moveSpeed;
        }
        else if (transform.position.y == 2 && direction.x > 0 && transform.position.x + 0.85f < 0)
        {
            rb.velocity = new Vector3(direction.x, 0f, 0f) * moveSpeed;
        }
        else if (transform.position.y == 2.5 && direction.x > 0 && !Physics.CheckSphere(transform.position + new Vector3(1.1f, 0, 0), 0.04f))
        {
            rb.velocity = new Vector3(direction.x, 0f, 0f) * moveSpeed;
        }
        else
        {
            rb.velocity = new Vector3(0f, 0f, 0f) * moveSpeed;
        }
    }
}