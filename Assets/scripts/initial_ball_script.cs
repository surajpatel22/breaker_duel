using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initial_ball_script : MonoBehaviour
{
    public Rigidbody rb;
    public ParticleSystem death;
    //public AudioSource audioData;
    //public AudioSource audioData1;

    private double start_time;

    public float initial_speed_x; //set in unity
    public float initial_speed_y; //set in unity
    private float speed;

    public float acceleration; //set in unity

    public int spawn_rate;

    public GameObject ball;

    private Vector3 up = new Vector3(0, 1, 0);
    private Vector3 right = new Vector3(1, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        //audioData = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        int randint = Random.Range(0, 3);

        if (randint < 2)
        {
            initial_speed_y *= -1;
        }
        if (randint % 2 == 0)
        {
            initial_speed_x *= -1;
        }


        rb.velocity = new Vector3(initial_speed_x, initial_speed_y, 0);
        speed = rb.velocity.magnitude;


        start_time = Time.time;
    }

    void OnCollisionEnter(Collision collision)
    {
        if ((Time.time - start_time > spawn_rate) &&  //during collision so not at same time
            !Physics.CheckSphere(new Vector3(0, 0, 0), 0.5f))
        {
            Instantiate(ball, new Vector3(0, 0, 0), Quaternion.identity);
            start_time += spawn_rate;
        }


        if ((collision.collider.gameObject.tag == "Brick"))
        {
            Instantiate(death, collision.collider.gameObject.transform.position, Quaternion.identity);
            GetComponent<AudioSource>().Play(0);
            Destroy(collision.collider.gameObject, 0.1f);
        }
        if ((collision.collider.gameObject.tag == "Player"))
        {
            collision.collider.gameObject.GetComponent<AudioSource>().Play(0);
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 v = rb.velocity;

        if (Vector3.Angle(v, up) < 2)
        {
            v += new Vector3(0.2f * Mathf.Sign(v.x), 0, 0);
        }
        if (Vector3.Angle(v, right) < 2)
        {
            v += new Vector3(0, Mathf.Sign(v.y)* 0.2f, 0);
        }

        v = v.normalized;
        v *= speed;
        rb.velocity = v;
        if (speed < 8) { speed *= 1 + acceleration * 0.0001f; }


    }
}
