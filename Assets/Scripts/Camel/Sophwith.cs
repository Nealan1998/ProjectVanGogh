using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sophwith : MonoBehaviour
{
    private Rigidbody rigid;
    [Header("Movement")]
    public float forwardSpeed = 20, horiSpeed = 4, vertiSpeed = 4, movSmooth = 4;
    private float forwardSpeedMulti = 100f;
    [Header("Rotation")]
    public float maxHoriRot = 0.1f, maxTurnRot = 0.1f, maxVertiRot = 0.06f, rotSmooth = 5;
    private float speedMulti = 1000;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();

    }

    private void FixedUpdate()
    {
        HandleMovement();
    }
    private void HandleRotation()
    {
        float horiRot = Input.GetAxis("Horizontal") * maxHoriRot;
        float turnRot = Input.GetAxis("Horizontal") * maxTurnRot;
        float vertiRot = Input.GetAxis("Vertical") * maxVertiRot;

        transform.eulerAngles = new Vector3(transform.rotation.x, turnRot, transform.rotation.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(vertiRot, this.transform.rotation.y/*turnRot /*transform.rotation.y*/, -horiRot, transform.rotation.w), Time.deltaTime * rotSmooth);
    }

    private void HandleMovement()
    {
        transform.position += transform.forward * Time.deltaTime * forwardSpeed;
        /*rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, forwardSpeed * forwardSpeedMulti * Time.deltaTime);
        float xVelocity = Input.GetAxis("Horizontal") * speedMulti * horiSpeed * Time.deltaTime;
        float yVelocity = -Input.GetAxis("Vertical") * speedMulti * vertiSpeed * Time.deltaTime;
        float zVelocity = Input.GetAxis("Horizontal") * Time.deltaTime;
        rigid.velocity = Vector3.Lerp(rigid.velocity, new Vector3(xVelocity, yVelocity, zVelocity), Time.deltaTime * movSmooth);*/
    }
}
