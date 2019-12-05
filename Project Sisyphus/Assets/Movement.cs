using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float torque;
    public Rigidbody rb;
    public bool[] rM = { false, false, false, false };


    private int count=0;
    public int max;
    private double vThreshold=5.5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    bool checkIfInput(bool[] rM) {
        int sum = 0;
        for (int i = 0; i < rM.Length; i++) {
            if (rM[i] == false) {
                sum++;
            }

        }
        if (sum == rM.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && checkIfInput(rM))
        {
            count = 0;
            rM[0] = true;
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && checkIfInput(rM))
        {
            count = 0;
            rM[1] = true;
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && checkIfInput(rM))
        {
            count = 0;
            rM[2] = true;
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY;

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && checkIfInput(rM))
        {
            count = 0;
            rM[3] = true;
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY;
        }

        if (rM[0])
        {
            rb.AddTorque(torque, 0, 0);

        }
        if (rM[1])
        {
            rb.AddTorque(0, 0, -torque);

        }

        if (rM[2])
        {
            rb.AddTorque(-torque,0,0);

        }

        if (rM[3])
        {
            rb.AddTorque(0, 0, torque);

        }
        if (rM[0] && System.Math.Floor(rb.angularVelocity.x) >= vThreshold) {
            rM[0] = false;
            count = 0;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.None;
        }
        if (rM[1] && System.Math.Floor(rb.angularVelocity.z) <= -vThreshold)
        {
            rM[1] = false;
            count = 0;
            rb.angularVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.None;

        }
        if (rM[2] && System.Math.Floor(rb.angularVelocity.x) <= -vThreshold)
        {
            rM[2] = false;
            count = 0;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.None;
        }
        if (rM[3] && System.Math.Floor(rb.angularVelocity.z) >= vThreshold)
        {
            rM[3] = false;
            count = 0;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.None;
        }
        count++;

    }
}
