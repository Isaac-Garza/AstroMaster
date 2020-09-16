using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{

    public int health = 100;

    public int damage = 10;

    public GameObject deathEffect;

    public GameObject moneyDrop;

    public Transform firePoint;

    public float dropRate;

    public float random;

    public void TakeDamage()

    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Drop();
        Destroy(gameObject);
    }

    void Drop()
    {

        random = Random.Range(1, 100);
        print(random);
        if (random <= dropRate)
            Instantiate(moneyDrop, transform.position, Quaternion.identity);
    }

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector3.Distance(transform.position, player.position) < stoppingDistance && Vector3.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector3.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBtwShots <= 0)
        {

            //Instantiate(projectile, transform.position, Quaternion.identity);
            Instantiate(projectile, firePoint.position, firePoint.rotation);
            timeBtwShots = startTimeBtwShots;

        }

        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}

