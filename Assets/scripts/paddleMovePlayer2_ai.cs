using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleMovePlayer2_ai : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction;
    private float moveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (PlayerPrefs.GetInt("AI", 0) == 2)
        {
            Destroy(GetComponent<paddleMovePlayer2_ai>());
        }
        if (PlayerPrefs.GetInt("more paddles", 0) == 1)
        {
            transform.localScale += new Vector3(-0.5f, 0f, 0f);
        }


        moveSpeed = PlayerPrefs.GetFloat("Speed", 0);

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
            if (curDistance < distance && (go.transform.position.y < 2) && go.GetComponent<Rigidbody>().velocity.y > 0 && (PlayerPrefs.GetInt("more paddles", 0) == 0 || go.transform.position.x > 0))
            {
                closest = go;
                distance = curDistance;
            }
        }
        if (closest != null)
        {
            direction = (closest.transform.position - transform.position);
        }


        if (PlayerPrefs.GetInt("more paddles", 0) == 1 && direction.x < 0 && transform.position.x - 0.85f > 0)
        {
            rb.velocity = new Vector3(direction.x, 0f, 0f) * moveSpeed;
        }
        else if (PlayerPrefs.GetInt("more paddles", 0) == 0 && direction.x < 0 && !Physics.CheckSphere(transform.position + new Vector3(-1.05f, 0, 0), 0.04f))
        {
            rb.velocity = new Vector3(direction.x, 0f, 0f) * moveSpeed;
        }
        else if (PlayerPrefs.GetInt("more paddles", 0) == 1 && direction.x > 0 && !Physics.CheckSphere(transform.position + new Vector3(0.85f, 0, 0), 0.04f))
        {
            rb.velocity = new Vector3(direction.x, 0f, 0f) * moveSpeed;
        }
        else if (PlayerPrefs.GetInt("more paddles", 0) == 0 && direction.x > 0 && !Physics.CheckSphere(transform.position + new Vector3(1.05f, 0, 0), 0.04f))
        {
            rb.velocity = new Vector3(direction.x, 0f, 0f) * moveSpeed;
        }
        else
        {
            rb.velocity = new Vector3(0f, 0f, 0f) * moveSpeed;
        }
    }
}