using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField]
    bool canSwitch;
    string message;
    enum typeOfPlayer { SOLDIER, PLANE}
    typeOfPlayer thisType;
    PlaneGroundSwitch entryPoint;
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.GetComponent<Player>() != null)
        {
            thisType = typeOfPlayer.SOLDIER;
            message = "Press E to Enter Plane";
        }
        if (this.gameObject.GetComponent<SopwithCamel>() != null)
        {
            thisType = typeOfPlayer.PLANE;
            message = "Press E to Exit Plane";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canSwitch)
        {
            UI.instance.messageInactive();
            entryPoint.StartSpawn(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlaneGroundSwitch>() != null)
        {
            entryPoint = other.gameObject.GetComponent<PlaneGroundSwitch>();
            canSwitch = true;
            UI.instance.messageActive(message);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canSwitch = false;
        UI.instance.messageInactive();
    }
}
