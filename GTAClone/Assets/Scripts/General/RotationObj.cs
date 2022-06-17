using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObj : MonoBehaviour
{
    public int rotateSpeed = 1;

    void Update()
    {
        int newSpeed = rotateSpeed / 4;
        transform.Rotate(0, newSpeed, 0, Space.World);
    }
}
