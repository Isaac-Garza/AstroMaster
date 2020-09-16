using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;

    private Transform player;
    private Vector3 target;

    

    private void OnTriggerEnter(Collider other)
    {
        print("hit" + other.name + "!");

        playerHP stats;

        if (stats = other.GetComponent<playerHP>())
        {
            stats.ChangeHealth(-10);
        }

        shieldhpscript status;

        if (status = other.GetComponent<shieldhpscript>())
        {
            status.ChangeHealth(-10);
        }

        

        Destroy(gameObject);


        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }
    }


    void DestroyProjectile()
    {
        Destroy(gameObject, lifetime);
    }


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector3(player.position.x, player.position.y, player.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z)
        {
            DestroyProjectile();
        }
    }

    

}