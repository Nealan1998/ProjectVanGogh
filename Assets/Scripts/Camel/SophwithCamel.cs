using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SophwithCamel : MonoBehaviour
{
    public float speed = 90.0f, turnSpeed = 7.5f;
    float activeTurnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveCamTo = transform.position - transform.forward * 10.0f + Vector3.up * 5.0f;
        float bias = 0.96f;
        Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1 - bias);
        Camera.main.transform.LookAt(transform.position + transform.forward * 30.0f );
        // Automaticlly move forward
        transform.position += transform.forward * Time.deltaTime * speed;

        speed -= transform.forward.y * 50.0f;
        if (speed < 35.0f)
        {
            speed = 35.0f;
        }
        // Set rotation to match input
        activeTurnSpeed = Mathf.Lerp(activeTurnSpeed, Input.GetAxisRaw("Horizontal") * turnSpeed, 2f * Time.deltaTime);


        //transform.Rotate( Input.GetAxis("Vertical"), 0.0f, - Input.GetAxis("Horizontal"));

        // Handle Horizontal movement
        if ( this.transform.rotation.z > -45 && this.transform.rotation.z < 45 )
        {
            transform.Rotate(0.0f, 0.0f, -Input.GetAxis("Horizontal"));
        }
        if (this.transform.rotation.z >= 45 && Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(0.0f, 0.0f, 0.0f);
        }


        // Handle Ground Collisions
        float terrainHeightCurrent = Terrain.activeTerrain.SampleHeight(transform.position);
        if(terrainHeightCurrent > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, terrainHeightCurrent, transform.position.z);
        }
    }
}
