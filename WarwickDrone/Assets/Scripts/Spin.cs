using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour
{
    /*public Vector3 posTarget = new Vector3(0.0f, 0.0f, 0.0f);
    public GameObject WarwickDrone;

    float speed = 1f;
    public float rotationleft = 360;
    float rotationspeed = 15;
    private float rotation;
    public float scanDetection;
    public float secondScan = 0;
    public float waypoint;
    private Vector3 diff;

    // Update is called once per frame
    void Update()
    {
        if (posTarget != transform.position)
        {
            transform.position = Vector3.Lerp(transform.position, posTarget, Time.deltaTime * speed);
        }

        diff = posTarget - transform.position;

        if (diff.y < 0.1 && diff.x < 0.1 && diff.z < 0.1)
        {
            RotationControl();
            WarwickDrone.transform.Rotate(0, rotation, 0);

        }
    }

    IEnumerator Rotate(float duration)
    {
        Quaternion startRot = transform.rotation;
        float t = 0.0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            transform.rotation = startRot * Quaternion.AngleAxis(t / duration * 360f, Vector3.right); //or transform.right if you want it to be locally based
            yield return null;
        }
        transform.rotation = startRot;
    }

    public void RotationControl()
    {
        rotation = rotationspeed * Time.deltaTime;
        if (rotationleft > rotation)
        {
            rotationleft -= rotation;
            if (scanDetection == 0)
            {
                scanDetection = vision.detectionOutput;
            }
        }
        else
        {
            rotation = rotationleft;
            rotationleft = 0;
            if (scanDetection == 1 && secondScan == 0)
            {
                rotationleft = 360;
                scanDetection = 0;
                secondScan = 1;
            }
            else if (scanDetection == 1 && secondScan == 1)
            {
                Debug.Log("Moving to next planting location");
                secondScan = 0;
                waypoint = 1;
            }
            else if (scanDetection == 0)
            {
                Debug.Log("Plant seed and move to next location");
                waypoint = 1;
            }
        }
    }*/
}
