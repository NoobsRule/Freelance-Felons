using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class carManager : MonoBehaviour
{
    public Camera carCam;
    public CarUserControl userCtrl;

    private bool inVeh;
    private GameObject thePlayer;

    void Start()
    {
        userCtrl.enabled = false;
        carCam.enabled = false;
        inVeh = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (inVeh == true)
            {
                vehicleControl(null);
            }
        }
    }

    public void vehicleControl(GameObject playerObj)
    {
        if (inVeh == false)
        {
            thePlayer = playerObj;
            this.GetComponent<TrafficCar>().enabled = true;
            this.GetComponent<NavMeshObstacle>().enabled = true;
            carCam.enabled = true;
            userCtrl.enabled = true;
            thePlayer.SetActive(false);
            thePlayer.transform.parent = this.transform;

            StartCoroutine(Time(true));
        }
        else
        {
            thePlayer.SetActive(true);
            this.GetComponent<TrafficCar>().enabled = false;
            this.GetComponent<NavMeshObstacle>().enabled = false;
            carCam.enabled = false;
            userCtrl.enabled = false;
            thePlayer.transform.parent = null;
            thePlayer = null;

            StartCoroutine(Time(false));
        }
    }

    private IEnumerator Time(bool inVehicle)
    {
        yield return new WaitForSeconds(1);
        inVeh = inVehicle;
    }
}

