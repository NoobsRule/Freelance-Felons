using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControlv2 : MonoBehaviour
{
    public GameObject thePlayer;
    public bool isRunning;
    public bool isStepping = false;
    public int stepNum;
    public AudioSource footStep1;
    public AudioSource footStep2;

    public CharacterController controller;
    public float speed = 8f;
    public float rotationSpeed;
    public Transform camera;

    void Update()
    {
        //Movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        float magnitude = Mathf.Clamp01(direction.magnitude) * speed;
        direction = Quaternion.AngleAxis(camera.rotation.eulerAngles.y, Vector3.up) * direction;
        direction.Normalize();

        controller.SimpleMove(direction * magnitude);

        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        //Animations
        if (magnitude >= 0.1f)
        {
            isRunning = true;

            if (isStepping == false)
            {
                StartCoroutine(RunSound());
            }

            if (FiringPistol.isAiming == true)
            {
                thePlayer.GetComponent<Animator>().Play("Pistol Walk");
            }
            else
            {
                thePlayer.GetComponent<Animator>().Play("Running");
            }
        }
        else
        {
            isRunning = false;

            if (FiringPistol.isAiming == false)
            {
                thePlayer.GetComponent<Animator>().Play("Idle");
            }
            else
            {
                if (FiringPistol.isFiring == false)
                {
                    thePlayer.GetComponent<Animator>().Play("Pistol Idle");
                }
                else
                {
                    thePlayer.GetComponent<Animator>().Play("shooting");
                }
            }
        }
    }

    //SoundFX
    IEnumerator RunSound()
    {
        if (isRunning == true && isStepping == false)
        {
            isStepping = true;
            stepNum = Random.Range(1, 3);
            if (stepNum == 1)
            {
                footStep1.Play();
            }
            else
            {
                footStep2.Play();
            }
        }
        yield return new WaitForSeconds(0.3f);
        isStepping = false;
    }
}
