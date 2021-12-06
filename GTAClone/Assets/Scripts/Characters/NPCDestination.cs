using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDestination : MonoBehaviour
{
    public int trigNum;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            if (trigNum == 8)
            {
                trigNum = 0;
            }
            if (trigNum == 7)
            {
                this.gameObject.transform.position = new Vector3(270, 16, 127);
                trigNum = 8;
            }
            if (trigNum == 6)
            {
                this.gameObject.transform.position = new Vector3(270, 16, 206);
                trigNum = 7;
            }
            if (trigNum == 5)
            {
                this.gameObject.transform.position = new Vector3(211, 16, 206);
                trigNum = 6;
            }
            if (trigNum == 4)
            {
                this.gameObject.transform.position = new Vector3(211, 16, 307);
                trigNum = 5;
            }
            if (trigNum == 3)
            {
                this.gameObject.transform.position = new Vector3(352, 16, 307);
                trigNum = 4;
            }
            if (trigNum == 2)
            {
                this.gameObject.transform.position = new Vector3(352, 16, 207);
                trigNum = 3;
            }
            if (trigNum == 1)
            {
                this.gameObject.transform.position = new Vector3(293, 16, 205);
                trigNum = 2;
            }
            if (trigNum == 0)
            {
                this.gameObject.transform.position = new Vector3(293, 16, 127);
                trigNum = 1;
            }
        }
    }
}