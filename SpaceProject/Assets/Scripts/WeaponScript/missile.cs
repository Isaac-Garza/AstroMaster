using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class missile : MonoBehaviour
{
    public Transform target;

    public float speed = 5f;
    public float rotateSpeed = 200f;

    public GameObject explosionEffect;
    public GameObject player;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.FindGameObjectsWithTag("Player").transform;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.right).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D ()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
