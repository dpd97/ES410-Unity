using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public TcpManager vision;
    public SITLManager sitl;
    public GameObject WarwickDrone;

    public Quaternion start = new Quaternion(0f, 0f, 0f, 0f);
    public Quaternion quartTarget = new Quaternion(0f, 0f, 0f, 0f);
    public Vector3 rotTarget = new Vector3(0f, 0f, 0f);
    public Vector3 posTarget = new Vector3(0.0f, 0.0f, 0.0f);
    //private float timeCount = 0f;
    private float speed = 1f;
    public float lerpspeed;
    public float turningRate = 30f;
  
 
    // Update is called once per frame
    void Update()

    {
        posTarget.x = sitl.x;
        posTarget.y = sitl.y;
        posTarget.z = sitl.z;
        rotTarget.x = -(sitl.roll * Mathf.Rad2Deg);
        rotTarget.y = sitl.yaw * Mathf.Rad2Deg;
        rotTarget.z = -(sitl.pitch * Mathf.Rad2Deg);
        lerpspeed = Time.deltaTime * speed;

        if (posTarget != transform.position)
        {
            WarwickDrone.transform.position = Vector3.Lerp(transform.position, posTarget, lerpspeed);
        }

        quartTarget = Quaternion.Euler(rotTarget);

        //WarwickDrone.transform.rotation = Quaternion.Lerp(transform.rotation, quartTarget, lerpspeed);

        WarwickDrone.transform.rotation = Quaternion.RotateTowards(transform.rotation, quartTarget, turningRate * Time.deltaTime);

    }

}

