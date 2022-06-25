using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class carManager : MonoBehaviour
{
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;

    public Camera carCam;
    public CarUserControl userCtrl;
    public int upValue = 2;

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

        if (inVeh == true)
        {
            x = this.transform.eulerAngles.x;
            y = this.transform.eulerAngles.y;
            z = this.transform.eulerAngles.z;
            Vector3 newRotation = new Vector3(x, y, z);
            thePlayer.transform.eulerAngles = newRotation;
        }
    }

    public void vehicleControl(GameObject playerObj)
    {
        if (inVeh == false)
        {
            thePlayer = playerObj;
            this.GetComponent<TrafficCar>().enabled = true;
            this.GetComponent<UnityEngine.AI.NavMeshObstacle>().enabled = true;
            this.tag = "Player";
            carCam.enabled = true;
            userCtrl.enabled = true;
            thePlayer.SetActive(false);
            thePlayer.transform.parent = this.transform;
            thePlayer.transform.Translate(0, upValue, 0);

            StartCoroutine(Time(true));
        }
        else
        {
            thePlayer.SetActive(true);
            this.GetComponent<TrafficCar>().enabled = false;
            this.GetComponent<UnityEngine.AI.NavMeshObstacle>().enabled = false;
            this.tag = "RoadCars";
            carCam.enabled = false;
            userCtrl.enabled = false;
            thePlayer.transform.parent = null;
            thePlayer.transform.Translate(0, upValue, 0);
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

