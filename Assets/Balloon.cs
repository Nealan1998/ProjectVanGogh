using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Balloon : MonoBehaviour
{
    public Transform target;
    public GameObject particleEffect;
    private void Start()
    {
        //target = CameraMovement.instance.gameObject.transform;
    }
    private void Update()
    {

        transform.LookAt(target);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Plane")
        {
            Instantiate(particleEffect, this.transform.position, this.transform.rotation);
            GameManager.instance.ballonsPopped++;
            UI.instance.balloonsText.text = GameManager.instance.ballonsPopped.ToString();
            // To be removed after demo
            if(GameManager.instance.ballonsPopped >= 10)
            {
                Destroy(CameraMovement.instance.gameObject);
                Destroy(UI.instance.gameObject);
                SceneLoader.instance.GoToScene("Win Screen");
            }
            AudioManager.instance.PlaySFX(0);
            Destroy(this.gameObject);
        }
    }
}
