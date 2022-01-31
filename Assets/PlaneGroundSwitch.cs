using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGroundSwitch : MonoBehaviour
{
    public GameObject player, plane, dummyPlane;
    public bool holdingPlane;
    public Transform playerTransform, planeTransform;

    private void Start()
    {
        Vector3 runwayPosition = this.transform.position;
        Quaternion runwayRotation = this.transform.rotation;
        
    }

    public void StartSpawn(GameObject newToHold)
    {
        //newToHold.SetActive(false);
        if(GameManager.instance.CheckIfPilot() == true)
        {
            GameManager.instance.SwitchPlaystyle();
            CameraMovement.instance.ChangeTarget(player.transform);
            player.SetActive(true);
            plane.SetActive(false);
            dummyPlane.SetActive(true);
            player.transform.position = playerTransform.position;
            player.transform.rotation = playerTransform.rotation;
            //holding = newToHold;
            holdingPlane = true;
        }
        else if(GameManager.instance.CheckIfSoldier() == true && holdingPlane == true)
        {
            GameManager.instance.SwitchPlaystyle();
            CameraMovement.instance.ChangeTarget(plane.transform);
            plane.SetActive(true);
            player.SetActive(false);
            dummyPlane.SetActive(false);
            plane.transform.position = planeTransform.position;
            plane.transform.rotation = planeTransform.rotation;
            holdingPlane = false;
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
