using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControls : MonoBehaviour
{
    public float forwardSpeed, turnSpeed = 7.5f, hoverSpeed = 5f, thrustSpeed = 2.0f;
    private float activeForwardSpeed, activeTurnSpeed, activeHoverSpeed, activeThrustSpeed;
    private float forwardAcceleration = 2.5f, turnAcceleration = 2f, hoverAcceleration = 2f;

    public float lookRotationSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;


    // Start is called before the first frame update
    void Start()
    {
        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;
    }

    // Update is called once per frame
    void Update()
    {
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y =screenCenter.y) / screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        // rotate
        //transform.Rotate(-mouseDistance.y * lookRotationSpeed * Time.deltaTime, mouseDistance.x * lookRotationSpeed * Time.deltaTime, 0f, Space.Self);


        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, /*Input.GetAxis("Forward") **/ forwardSpeed, forwardAcceleration * Time.deltaTime);
        activeTurnSpeed = Mathf.Lerp(activeTurnSpeed, Input.GetAxisRaw("Horizontal") * turnSpeed, turnAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Vertical") * hoverSpeed, hoverAcceleration * Time.deltaTime);

        // Automatically move forward
        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        transform.Rotate(-activeHoverSpeed * lookRotationSpeed * Time.deltaTime, activeTurnSpeed * lookRotationSpeed * Time.deltaTime, 0f, Space.Self);
        // transform.position += (transform.right * activeTurnSpeed * Time.deltaTime) + (transform.up * activeHoverSpeed * Time.deltaTime);
    }
}
