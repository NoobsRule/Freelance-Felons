using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public GameObject ourPistol;
    public AudioSource gunPickup;
    public GameObject pistolFireObj;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gunPickup.Play();
            ourPistol.SetActive(true);
            this.gameObject.SetActive(false);
            pistolFireObj.SetActive(true);
        }
    }
}
