using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForTarget : MonoBehaviour
{

    public bool canTarget;
    public GameObject currentTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            canTarget = true;
            currentTarget = other.gameObject;
            StopCoroutine(LeaveTarget());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canTarget = false;
        StartCoroutine(LeaveTarget());
    }

    IEnumerator LeaveTarget()
    {
        yield return new WaitForSeconds(3);
        currentTarget = null;
    }
}
