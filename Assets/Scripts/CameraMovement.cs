using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    public float sonicSpeed = 0.125f;
    public Vector3 offset;
    public static CameraMovement instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = plane.position + offset;
        Vector3 moveCamTo = target.transform.position - target.transform.forward * 10.0f + Vector3.up * 5.0f;
        float bias = 0.96f;
        Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1 - bias);
        Camera.main.transform.LookAt(target.transform.position + target.transform.forward * 30.0f);
    }

    // Change the current object to follow
    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
