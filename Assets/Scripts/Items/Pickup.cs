using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public PickupTypes pickupType;
    public int value;
    public bool shouldMove;
    Transform targetLocation;
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.instance.currentPlaystyle == PlaystyleEnum.PILOT)
        {
            targetLocation = GameManager.instance.thePlane.transform;
        }
        else
        {
            targetLocation = GameManager.instance.thePlayer.transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Move toward the player
        if(shouldMove)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, GameManager.instance.currentPlayer.transform.position, 50.0f * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Plane" || collision.gameObject.tag == "Player")
        {
            PerformAction();
        }
    }

    void PerformAction()
    {

        // Refill player's health with milkshakes
        if (pickupType == PickupTypes.MILKSHAKE)
        {
            GameManager.instance.health += value;
            if (GameManager.instance.health > GameManager.instance.maxHealth)
            {
                GameManager.instance.health = GameManager.instance.maxHealth;
            }
        }

        // Add Money to the player's stash with coins
        if (pickupType == PickupTypes.COIN)
        {

        }


        // Refill weapons
        if(pickupType == PickupTypes.WEAPON)
        {

        }

        Destroy(this.gameObject);
    }
}
