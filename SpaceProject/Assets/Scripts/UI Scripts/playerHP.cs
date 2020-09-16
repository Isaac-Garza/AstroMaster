using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHP : MonoBehaviour
{
    public Transform HealthBar;
    public Slider healthFill;

    public float currentHealth;

    public float maxHealth;

    public float healthBarYOffset = 2;

    public int health = 100;

    public GameObject deathEffect;

    public GameObject GameoverScreen;

    public Transform player;

    // Pick Up Modifiers
    public int moneyTotal = 0;
    public int energyTotal = 0;
    public int fuelTotal = 0;
    public int ammoTotal = 0;
    public int maxMoney = 9999;
    public int maxAmmount = 100;
    string gameObjectTag;

    // Pick Up Amount Modifiers
    public int money = 10;
    public int energy = 20;
    public int fuel = 20;

    // In-Game Text
    public Text warningText;
    public Text pickUpText;
    public GameObject FloatingTextPrefab;
    public float delay = 2f;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        moneyTotal = 0;
        setDefaultWarningMessages();
    }

    void setDefaultWarningMessages()
    {
        pickUpText.text = "";
        warningText.text = "";
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

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        healthFill.value = currentHealth / maxHealth;
    }

    void OnTriggerEnter(Collider other)
    {

        switch (other.gameObject.tag)
        {
            case "Money":
                if (moneyTotal < maxMoney)
                {
                    moneyTotal += money;
                    StartCoroutine(ShowPickUp(money.ToString() + " Money", delay));
                    other.gameObject.SetActive(false);
                }
                else
                {
                    StartCoroutine(ShowWarning("Max Money!", delay));
                }
                break;
            case "Energy":
                if (energyTotal < maxAmmount)
                {
                    energyTotal += energy;
                    StartCoroutine(ShowPickUp(energy.ToString() + " Energy", delay));
                    other.gameObject.SetActive(false);
                }
                else
                {
                    StartCoroutine(ShowWarning("Max Energy!", delay));
                }
                break;
            case "Fuel":
                if (currentHealth < maxAmmount)
                {
                    currentHealth += fuel;
                    if (currentHealth > maxAmmount)
                        currentHealth = maxAmmount;
                    healthFill.value = currentHealth / maxHealth;
                    StartCoroutine(ShowPickUp(fuel.ToString() + " Health", delay));
                    other.gameObject.SetActive(false);
                }
                else
                {
                    StartCoroutine(ShowWarning("Max Health!", delay));
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






}
