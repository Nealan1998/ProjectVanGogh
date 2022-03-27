using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGroundSwitch : MonoBehaviour
{
    public GameObject player, follower, plane, dummyPlane;
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
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
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
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
            plane.SetActive(true);
            player.SetActive(false);
            dummyPlane.SetActive(false);
            plane.transform.position = planeTransform.position;
            plane.transform.rotation = planeTransform.rotation;
            holdingPlane = false;
        }
    }
    
}
