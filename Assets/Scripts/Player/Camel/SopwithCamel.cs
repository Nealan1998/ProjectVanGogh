using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SopwithCamel : MonoBehaviour
{
    Rigidbody rigid;
    public float speed = 50, angleX, angleY, rotatSpeed;
    private float defaultSpeed;
    Vector2 move;

    public bool fillingUp = true, canFillUp = true;
    private bool ableToBoost = true, ableToBrake = true;
    public float energyDecreaseRate, energyIncreaseRate;
    private bool boosting, braking;
    public GameObject bulletPrefab;

    public AudioSource thudSound;
    // Start is called before the first frame update
    void Start()
    {
        canFillUp = true;
        defaultSpeed = speed;
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        /*if((Input.GetKeyDown(KeyCode.LeftShift)))
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = this.transform.position;
            bullet.transform.rotation = this.transform.rotation;
        }*/

        if ((Input.GetKeyDown(KeyCode.Z) && ableToBoost && canFillUp))
        {
            Boost();
        }
        else if (Input.GetKeyUp(KeyCode.Z) && ableToBoost && canFillUp)
        {
            StopBoosting();
        }
        else if(Input.GetKeyDown(KeyCode.C) && ableToBrake )
        {
            Brake();
        }
        else if (Input.GetKeyUp(KeyCode.C) && ableToBrake)
        {
            StopBraking();
        }

        if (fillingUp == true && GameManager.instance.energy < GameManager.instance.maxEnergy)
        {
            GameManager.instance.energy += energyIncreaseRate * Time.deltaTime;
        }

        if(boosting )
        {

            GameManager.instance.energy -= energyDecreaseRate * Time.deltaTime;
        }
        if (boosting && GameManager.instance.energy < .02f)
        {
            StopBoosting();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rigid.velocity = transform.forward * speed * Time.deltaTime;
        TurnCamel();


    }

    void TurnCamel()
    {
        transform.Rotate(Vector3.up, move.x * rotatSpeed * Time.fixedDeltaTime);
        TurnCamelVisual();
    }    
    void TurnCamelVisual()
    {
        transform.localEulerAngles = new Vector3(move.y * angleY, transform.localEulerAngles.y, -move.x * angleX);
    }

    void Boost()
    {
        fillingUp = false;
        boosting = true;
        if (GameManager.instance.energy > .01f && fillingUp == false)
        {
            speed = speed * 2.25f;
            ableToBrake = false;
        }
    }

    void StopBoosting()
    {
        speed = defaultSpeed;
        boosting = false;
        ableToBrake = true;
        fillingUp = true;
    }

    void Brake()
    {
        fillingUp = false;
        speed = speed / 2.25f;
        ableToBoost = false;
    }

    void StopBraking()
    {
        fillingUp = true;
        speed = defaultSpeed;
        ableToBoost = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag != "Balloon" && collision.gameObject.tag != "Player Weapon")
        {
            this.transform.rotation = new Quaternion(0f, this.transform.rotation.y, 0f, 0f);
            GameManager.instance.health -= 20;
            thudSound.Play();
        }
    }

}
