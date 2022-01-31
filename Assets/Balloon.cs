using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Plane")
        {
            GameManager.instance.ballonsPopped++;
            Destroy(this.gameObject);
        }
    }
}
