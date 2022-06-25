using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTrigger : MonoBehaviour
{
    private bool inTrigger;
    private GameObject thePlayer;

    public carManager carMan;

    void Update()
    {
        if(inTrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                carMan.vehicleControl(thePlayer);
                inTrigger = false;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            inTrigger = true;
            thePlayer = col.gameObject;
        }
    }

    void OnTriggerExit()
    {
        inTrigger = false;
        thePlayer = null;
    }
}
