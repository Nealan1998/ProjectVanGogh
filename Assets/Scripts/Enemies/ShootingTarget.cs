using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTarget : MonoBehaviour
{
    public float maxHealth, currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damageToRemove)
    {
        currentHealth -= damageToRemove;
    }
}
