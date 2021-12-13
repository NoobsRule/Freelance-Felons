using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRandomDestination : MonoBehaviour
{
    public int genPos;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            genPos = Random.Range(1, 9);

            if (genPos == 8)
            {
                this.gameObject.transform.position = new Vector3(3172, 26, 2521);
            }
            if (genPos == 7)
            {
                this.gameObject.transform.position = new Vector3(3239, 26, 2665);
            }
            if (genPos == 6)
            {
                this.gameObject.transform.position = new Vector3(3156, 26, 2622);
            }
            if (genPos == 5)
            {
                this.gameObject.transform.position = new Vector3(2993, 26, 2622);
            }
            if (genPos == 4)
            {
                this.gameObject.transform.position = new Vector3(3032, 26, 2745);
            }
            if (genPos == 3)
            {
                this.gameObject.transform.position = new Vector3(3134, 26, 2622);
            }
            if (genPos == 2)
            {
                this.gameObject.transform.position = new Vector3(3091, 26, 2522);
            }
            if (genPos == 1)
            {
                this.gameObject.transform.position = new Vector3(3074, 26, 2621);
            }
        }
    }
}
