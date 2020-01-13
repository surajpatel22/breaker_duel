using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovePlayer2_local : MonoBehaviour
{
    private Vector3 touchPosition;
    private Rigidbody rb;
    private Vector3 direction;
    private float moveSpeed = 10f;
    private Touch touch;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (!(PlayerPrefs.GetInt("AI", 0) == 2))
        {
            Destroy(GetComponent<PaddleMovePlayer2_local>());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                touch = Input.GetTouch(i);
                if (Camera.main.ScreenToWorldPoint(touch.position).y > 0) { break; }
                if (i == Input.touchCount - 1) { return; }
            }

            
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);

            if (direction.x < 0 && !Physics.CheckSphere(transform.position + new Vector3(-1.05f, 0, 0), 0.04f))
            {
                rb.velocity = new Vector3(direction.x, 0f, 0f) * moveSpeed;
            }
            else if (direction.x > 0 && !Physics.CheckSphere(transform.position + new Vector3(1.05f, 0, 0), 0.04f))
            {
                rb.velocity = new Vector3(direction.x, 0f, 0f) * moveSpeed;
            }

            if (touch.phase == TouchPhase.Ended)
                rb.velocity = Vector3.zero;
        }
    }
}