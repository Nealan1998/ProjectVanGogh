using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI instance;

    public RectTransform health, energy;
    public float maxHealth, currentHealth, maxEnergy, currentEnergy;
    public Text messageText;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health.sizeDelta.x;
        currentHealth = health.sizeDelta.x;
        maxEnergy = energy.sizeDelta.x;
        currentEnergy = energy.sizeDelta.x;
        instance = this;
        DontDestroyOnLoad(instance);
    }

    // Update is called once per frame
    void Update()
    {
        // set size of health bars.
        health.sizeDelta = new Vector2(currentHealth, health.sizeDelta.y);
        energy.sizeDelta = new Vector2(currentEnergy, energy.sizeDelta.y);

        // Set constraints

        // Health no higher than max
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        // Health no lower than 0
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }


        if (currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }


        if (currentEnergy < 0)
        {
            currentEnergy = 0;
        }
    }

    public void IncreaseHealth(float increase)
    {
        currentHealth += increase;
    }

    public void DecreaseHealth(float decrease)
    {
        currentHealth -= decrease;
    }

    public void IncreaseEnergy(float increase)
    {
        currentEnergy += increase;
    }

    public void DecreaseEnergy(float decrease)
    {
        currentEnergy -= decrease;
    }

    public void messageActive(string newMessage)
    {
        messageText.text = newMessage;
        messageText.gameObject.SetActive(true);
    }

    public void messageInactive()
    {

        messageText.gameObject.SetActive(false);
    }
}
