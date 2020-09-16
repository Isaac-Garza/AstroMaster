using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shieldhpscript : MonoBehaviour
{
    public Transform HealthBar;
    public Slider healthFill;

    public float currentHealth;

    public float maxHealth = 100;

    public float healthBarYOffset = 2;

    public int energy = 20;

    public int health = 100;

    public GameObject deathEffect;

    public GameObject GameoverScreen;

    public Transform player;

    // In-Game Text
    public Text warningText;
    public Text pickUpText;
    public GameObject FloatingTextPrefab;
    public float delay = 2f;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
        void Die()
        {

            Instantiate(deathEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);

        }


    }

    void OnTriggerEnter(Collider other)
    {

        switch (other.gameObject.tag)
        {
            case "Energy":
                if (currentHealth < maxHealth)
                {
                    currentHealth += energy;
                    if (currentHealth > 100)
                        currentHealth = 100;
                    healthFill.value = currentHealth / maxHealth;
                    StartCoroutine(ShowPickUp(energy.ToString() + " Energy", delay));
                    other.gameObject.SetActive(false);
                }
                else
                {
                    StartCoroutine(ShowWarning("Max Energy!", delay));
                }
                break;
        }
    }

    IEnumerator ShowPickUp(string message, float delay)
    {

        pickUpText.text = "+" + message;
        pickUpText.enabled = true;
        yield return new WaitForSeconds(delay);
        pickUpText.enabled = false;
    }

    IEnumerator ShowWarning(string message, float delay)
    {
        warningText.text = message;
        warningText.enabled = true;
        yield return new WaitForSeconds(delay);
        warningText.enabled = false;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        healthFill.value = currentHealth / maxHealth;
    }
}