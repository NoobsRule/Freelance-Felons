using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;

    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = desiredPosition;

        //transform.LookAt(target);
        //transform.Rotate(x, target.transform.eulerAngles.y, z);

        y = target.transform.eulerAngles.y + 90;
        Vector3 newRotation = new Vector3(x , y, z);
        this.transform.eulerAngles = newRotation;
    }
}
