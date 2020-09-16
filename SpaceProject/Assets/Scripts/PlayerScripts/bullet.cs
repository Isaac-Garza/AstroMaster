using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet: MonoBehaviour
{
    public float speed = 200f;
    public int damage = 40;
    public float lifetime;
    public Rigidbody rb;

    // Start is called before the first frame update

    void Start()
    {
        Destroy(gameObject, lifetime);
        rb.velocity = (transform.forward * speed);
    }

    void OnTriggerEnter(Collider hitInfo)
    {
        enemy enemy = hitInfo.GetComponent<enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);

    }
}

