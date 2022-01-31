using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGroundSwitch : MonoBehaviour
{
    public GameObject holding, dummyPlane;
    public bool holdingPlane;
    Transform planeTransform, playerTransform;

    private void Start()
    {
        Vector3 runwayPosition = this.transform.position;
        Quaternion runwayRotation = this.transform.rotation;
        planeTransform.position = new Vector3(runwayPosition.x, runwayPosition.y + 10.0f, runwayPosition.z);
        planeTransform.rotation = new Quaternion(0f, runwayPosition.x, 0f, 0f);
        playerTransform.position = new Vector3(runwayPosition.x - 2f, runwayPosition.y, runwayPosition.z);
    }

    public void StartSpawn(GameObject newToHold)
    {
        newToHold.SetActive(false);
        if(newToHold.tag == "Player")
        {
            dummyPlane.SetActive(true);
            holding.transform.position = playerTransform.position;
            holding.transform.rotation = playerTransform.rotation;
            holding.SetActive(true);
            holding = newToHold;
        }
        if(newToHold.tag == "Plane")
        {
            dummyPlane.SetActive(false);
            holding.transform.position = planeTransform.position;
            holding.transform.rotation = planeTransform.rotation;
            holding.SetActive(true);
            holding = newToHold;
        }
    }
    /*enum type {PLANE, PLAYER};
    [SerializeField]
    type currentType;
    string lookFor;

    public bool canSwitch;

    GameObject dummyPlane, player, plane;

    [SerializeField]
    Vector3 spawnPoint;
    string message;
    // Start is called before the first frame update
    void Start()
    {
        if (currentType == type.PLANE)
        {
            lookFor = "Plane";
            message = "Press 'E' to Exit Plane";
            spawnPoint = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 20f, this.gameObject.transform.position.z);
        }
        else if (currentType == type.PLAYER)
        {
            lookFor = "Player";
            message = "Press 'E' to Enter Plane";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canSwitch && Input.GetKeyDown(KeyCode.E))
        {
            PerformAction();
        }
    }

    public void OnTriggerEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Runway")
        //{
            canSwitch = true;
            UI.instance.messageActive(message);
//}    
    }

    public void OnTriggerExit(Collider other)
    {
       // if (other.gameObject.tag == "Runway")
        //{
            canSwitch = false;
            UI.instance.messageInactive();
       // }
    }

    void PerformAction()
    {
        if (currentType == type.PLAYER)
        {
            player.SetActive(false);
            dummyPlane.SetActive(false);
            plane.SetActive(true);
            plane.gameObject.transform.position = spawnPoint;
        }

        if (currentType == type.PLANE)
        {
            plane.SetActive(false);
            player.SetActive(true);
            dummyPlane.SetActive(true);

            player.gameObject.transform.position = spawnPoint;
        }
    }*/
}
