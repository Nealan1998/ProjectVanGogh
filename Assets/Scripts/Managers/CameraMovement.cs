using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    public float sonicSpeed = 0.125f, bias = 0.96f;
    public static CameraMovement instance;
    public Vector3 offset;
    private bool justFollowPlayer;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.instance.currentPlaystyle == PlaystyleEnum.PILOT)
        //transform.position = plane.position + offset;
        {
            Vector3 moveCamTo = target.transform.position - target.transform.forward * 10.0f + Vector3.up * 5.0f;
            Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1 - bias);

            Camera.main.transform.LookAt(target.transform.position + target.transform.forward * 30.0f);

        }
        else if (GameManager.instance.currentPlaystyle == PlaystyleEnum.SOLDIER && justFollowPlayer == false)
        {

            Vector3 moveCamTo = target.transform.position - target.transform.forward * 15.0f + Vector3.up * 5.0f;
            Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1 - bias);

            Camera.main.transform.LookAt(target.transform.position + target.transform.forward * 30.0f);


            //Vector3 moveCamTo = target.transform.position - target.transform.forward;
            //Camera.main.transform.position = Camera.main.transform.position + moveCamTo;

            //transform.LookAt(target);
            //transform.RotateAround(target.transform.position, Vector3.up, sonicSpeed * Time.deltaTime);

            //transform.position

            //transform.rotation = target.transform.rotation;
            //transform.rotation = target.rotation;
            //transform.position = target.position - offset;
            //Camera.main.transform.LookAt(target.transform.position + target.transform.forward * 30.0f);
            //Camera.main.transform.LookAt(target.transform.right * 30.0f);
        }
    }

    // Change the current object to follow
    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
    }


    public void Rotate(bool positive)
    {
        /*if (positive == true)
        {
            transform.RotateAround(target.transform.position, Vector3.up, 72);
        }*/
    }
}
