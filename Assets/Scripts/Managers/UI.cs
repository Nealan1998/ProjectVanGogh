using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI instance;

    public RectTransform health, energy;
    //public float maxHealth, currentHealth, maxEnergy, currentEnergy;
    public Text messageText, balloonsText;
    private float percentHealth, percentEnergy;

    public Image healthMeter, energyMeter;
    // Start is called before the first frame update
    void Start()
    {
        //maxHealth = health.sizeDelta.x;
        //GameManager.instance.health = health.sizeDelta.x;
        //maxEnergy = energy.sizeDelta.x;
        //currentEnergy = energy.sizeDelta.x;
        instance = this;
        DontDestroyOnLoad(instance);
    }

    // Update is called once per frame
    void Update()
    {
        // set size of health bars.
        //health.sizeDelta = new Vector2(currentHealth, health.sizeDelta.y);
        //energy.sizeDelta = new Vector2(currentEnergy, energy.sizeDelta.y);

        // Set constraints


        // Set Percents
        percentHealth = GameManager.instance.health / GameManager.instance.maxHealth;
        percentEnergy = GameManager.instance.energy / GameManager.instance.maxEnergy;

        // Set meters
        healthMeter.fillAmount = percentHealth;
        energyMeter.fillAmount = percentEnergy;

        // Health no higher than max
        if (GameManager.instance.health > GameManager.instance.maxHealth)
        {
            GameManager.instance.health = GameManager.instance.maxHealth;
        }

        // Health no lower than 0
        if (GameManager.instance.health < 0)
        {
            GameManager.instance.health = 0;
            SceneLoader.instance.GoToScene("Game Over");
            Destroy(CameraMovement.instance.gameObject);
            Destroy(this.gameObject);
        }


        if (GameManager.instance.energy > GameManager.instance.maxEnergy)
        {
            GameManager.instance.energy = GameManager.instance.maxEnergy;
            FindObjectOfType<SopwithCamel>().canFillUp = true;
            energyMeter.color = new Color (1f, 1f, 1f, 1f);
        }


        if (GameManager.instance.energy < 0)
        {
            GameManager.instance.energy = 0;
            FindObjectOfType<SopwithCamel>().canFillUp = false;
            energyMeter.color = new Color(0, 1f, 0, 1f);
        }

    }

    public void IncreaseHealth(float increase)
    {
        GameManager.instance.health += increase;
        if (GameManager.instance.health > GameManager.instance.maxHealth)
        {
            GameManager.instance.health = GameManager.instance.maxHealth;
        }
    }

    public void DecreaseHealth(float decrease)
    {
        GameManager.instance.health -= decrease;
    }

    public void IncreaseEnergy(float increase)
    {
        GameManager.instance.energy += increase;
    }

    public void DecreaseEnergy(float decrease)
    {
        GameManager.instance.energy -= decrease;
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
