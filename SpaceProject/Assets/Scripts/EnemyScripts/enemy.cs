using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{

    public Slider m_Slider;                             // The slider to represent how much health the tank currently has.
    public Image m_FillImage;                           // The image component of the slider.
    public Color m_FullHealthColor = Color.green;       // The color the health bar will be when on full health.
    public Color m_ZeroHealthColor = Color.red;         // The color the health bar will be when on no health.
    private float m_CurrentHealth;                      // How much health the tank currently has.
    private bool m_Dead;                                // Has the tank been reduced beyond zero health yet?
    public float health = 100f;


    public GameObject deathEffect;

    public GameObject moneyDrop;

    public GameObject healthDrop;

    public GameObject energyDrop;

    public float dropEnergy = 50;

    public float dropMoney = 80;

    public float dropHealth = 60;

    public Transform firePoint;

  
    

    public float dropRate = 60;

    public float random;

    public void TakeDamage(float damage)
    {
        // Reduce current health by the amount of damage done.
        m_CurrentHealth -= damage;
        // Trigger floating text


        // Change the UI elements appropriately.
        SetHealthUI();

        if (m_CurrentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        enemycount.scoreValue += 1;
        Scorescript.scoreValue += 10;
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        

        Drop();
        Destroy(gameObject);
    }

    
    

    void Drop()
    {
        if (random <= dropMoney)
            Instantiate(moneyDrop, transform.position, Quaternion.identity);
        if (random <= dropEnergy)
            Instantiate(energyDrop, transform.position, Quaternion.identity);
        if (random <= dropHealth)
            Instantiate(healthDrop, transform.position, Quaternion.identity);
    }

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    public Transform player;
    public float rotationSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;

        
    }

    private void OnEnable()
    {
        // When the tank is enabled, reset the tank's health and whether or not it's dead.
        m_CurrentHealth = health;

        // Update the health slider's value and color.
        SetHealthUI();
    }

    private void SetHealthUI()
    {
        // Set the slider's value appropriately.
        m_Slider.value = m_CurrentHealth;

        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth / health);
    }

    // Update is called once per frame
    void Update()
    {
        random = Random.Range(1, 100);
        
        if (player != null)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), rotationSpeed * Time.deltaTime);
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