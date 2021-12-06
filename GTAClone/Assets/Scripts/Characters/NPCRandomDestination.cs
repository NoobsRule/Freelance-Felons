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
                this.gameObject.transform.position = new Vector3(268, 16, 345);
            }
            if (genPos == 7)
            {
                this.gameObject.transform.position = new Vector3(285, 16, 245);
            }
            if (genPos == 6)
            {
                this.gameObject.transform.position = new Vector3(204, 16, 167);
            }
            if (genPos == 5)
            {
                this.gameObject.transform.position = new Vector3(186, 16, 367);
            }
            if (genPos == 4)
            {
                this.gameObject.transform.position = new Vector3(327, 16, 368);
            }
            if (genPos == 3)
            {
                this.gameObject.transform.position = new Vector3(327, 16, 267);
            }
            if (genPos == 2)
            {
                this.gameObject.transform.position = new Vector3(227, 16, 246);
            }
            if (genPos == 1)
            {
                this.gameObject.transform.position = new Vector3(245, 16, 267);
            }
        }
    }
}
