using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSopwithHopefully : MonoBehaviour
{
    Rigidbody rigid;
    public float speed = 50, angleX, angleY, rotatSpeed;
    private float defaultSpeed;
    Vector2 move;

    public bool fillingUp = true;
    private bool ableToBoost = true, ableToBrake = true;
    public float energyDecreaseRate;
    private bool boosting, braking;
    // Start is called before the first frame update
    void Start()
    {
        defaultSpeed = speed;
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z) && ableToBoost)
        {
            Boost();
        }
        else if (Input.GetKeyUp(KeyCode.Z) && ableToBoost)
        {
            StopBoosting();
        }
        else if(Input.GetKeyDown(KeyCode.C) && ableToBrake)
        {
            Brake();
        }
        else if (Input.GetKeyUp(KeyCode.C) && ableToBrake)
        {
            StopBraking();
        }

        if (fillingUp == true && UI.instance.currentEnergy < UI.instance.maxEnergy)
        {
            UI.instance.currentEnergy += energyDecreaseRate * Time.deltaTime;
        }

        if(boosting)
        {

            UI.instance.currentEnergy -= energyDecreaseRate * Time.deltaTime;
        }
        if (boosting && UI.instance.currentEnergy < .02f)
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
        if (UI.instance.currentEnergy > .01f && fillingUp == false)
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
        this.transform.rotation = new Quaternion(0f, this.transform.rotation.y, 0f, 0f);
    }

}
