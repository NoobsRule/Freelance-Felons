using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAICity : MonoBehaviour
{
    public GameObject[] destinations;
    public GameObject currentDest;
    public int index;
    NavMeshAgent theAgent;
    public static bool fleeMode = false;
    public GameObject fleeDest;
    public AudioSource helpMeFX;
    public bool isFleeing = false;

    void Start()
    {
        theAgent = GetComponent<NavMeshAgent>();

        destinations = GameObject.FindGameObjectsWithTag("NPCWP");
        index = Random.Range(0, destinations.Length);
        currentDest = destinations[index];
    }

    void Update()
    {


        if (fleeMode == false)
        {
            theAgent.SetDestination(currentDest.transform.position);
        }
        else
        {
            theAgent.SetDestination(fleeDest.transform.position);
            if (isFleeing == false)
            {
                isFleeing = true;
                StartCoroutine(FleeingNPC());
            }
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.name == currentDest.name)
        {
            destinations = GameObject.FindGameObjectsWithTag("NPCWP");
            index = Random.Range(0, destinations.Length);
            currentDest = destinations[index];
        }
    }

    IEnumerator FleeingNPC()
    {
        helpMeFX.Play();
        yield return new WaitForSeconds(20);
        fleeMode = false;
        isFleeing = false;
        this.gameObject.GetComponent<Animator>().Play("Walking");
        this.gameObject.GetComponent<NavMeshAgent>().speed = 2;
    }
}
