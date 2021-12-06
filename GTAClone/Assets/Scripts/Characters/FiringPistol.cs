using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPistol : MonoBehaviour
{
    public static bool isAiming = false;
    public GameObject thePlayer;
    public AudioSource pistolShot;
    public static bool isFiring = false;
    public GameObject aimingObj;

    public static float distanceFromTarget;
    public float toTarget;
    public int shotDamage;

    void Update()
    {
        RaycastHit Hit;

        if (Input.GetMouseButton(1))
        {
            isAiming = true;
            if (isFiring == false)
            {
                //thePlayer.GetComponent<Animator>().Play("Pistol Walk");
                aimingObj.SetActive(true);
            }
        }
        else
        {
            isAiming = false;
            aimingObj.SetActive(false);
            //thePlayer.GetComponent<Animation>().Play("Idle");
        }

        if(isAiming == true && Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
            {
                toTarget = Hit.distance;
                distanceFromTarget = toTarget;
                shotDamage = 50;
                Hit.transform.SendMessage("HurtNPC", shotDamage, SendMessageOptions.DontRequireReceiver);
            }
            isFiring = true;
            StartCoroutine(PistolSound());
            thePlayer.GetComponent<Animator>().Play("Shooting");
            StartCoroutine(FireThePistol());
        }
    }

    IEnumerator FireThePistol()
    {
        yield return new WaitForSeconds(0.4f);
        isFiring = false;
    }

    IEnumerator PistolSound()
    {
        yield return new WaitForSeconds(0.1f);
        pistolShot.Play();
    }
}
