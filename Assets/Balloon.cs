using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public Transform target;
    private void Start()
    {
    }
    private void Update()
    {
        transform.LookAt(target);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Plane")
        {
            GameManager.instance.ballonsPopped++;
            Destroy(this.gameObject);
        }
    }
}
