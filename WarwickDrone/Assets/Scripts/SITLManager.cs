using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SITLManager : MonoBehaviour
{
    public SITLClient tcp;
    public string[] msgparts = new string[6];
    private string msg;
    public float x;
    public float y;
    public float z;
    public float roll;
    public float pitch;
    public float yaw;

    // Start is called before the first frame update
    void Start()
    {
        tcp.ConnectToTcpServer();
    }

    // Update is called once per frame
    void Update()
    {
        DecodeMessage();
    }

    void DecodeMessage()
    {
       msg = tcp.serverMessage;

        msgparts = msg.Split(',');

        if (msgparts.Length == 6)
        {
            x = float.Parse(msgparts[0]);
            z = float.Parse(msgparts[1]);
            y = float.Parse(msgparts[2]);
            pitch = float.Parse(msgparts[3]);
            roll = float.Parse(msgparts[4]);
            yaw = float.Parse(msgparts[5]);

        }
        else
        {
            Debug.Log("message not recieved");
        }

    }

    /*void GPStoFrame()
    {
        x = Radius * Mathf.Cos(latitude) * Mathf.Cos(longitude);
        y = Radius * Mathf.Cos(latitude) * Mathf.Sin(longitude);
        z = Radius * Mathf.Sin(latitude);

        float[,] PosfO = new float[,] { { x }, { y }, { z }, { 1 } };

        for (int row=0; row < 4; row++)
        {
            int col;
            col = 0;
            sitlPosition[row, col] = 0;
            for (int i=0; i<4; i++)
            {
                sitlPosition[row, col] += pose[row, i] * PosfO[i, 0];
            }

        }

        sitlPosition[3, 0] += altitude;

        Debug.Log("sitlPosition.x = " + sitlPosition[0,0]);
    }*/

    /*void SetGPSorigin()
    {
        if (originSet == 0)
        {
            theta = latitude - 90;
            fi = longitude;

            x = Radius * Mathf.Cos(latitude) * Mathf.Cos(longitude);
            y = Radius * Mathf.Cos(latitude) * Mathf.Sin(longitude);
            z = Radius * Mathf.Sin(latitude);

            ct = Mathf.Cos(theta);
            st = Mathf.Sin(theta);
            cf = Mathf.Cos(fi);
            sf = Mathf.Sin(fi);

            float[,] Pose = new float[4, 4]
            {
            {cf, -ct*sf, st*sf, x},
            {sf, ct*cf, -st*cf, y},
            { 0, st, ct, z},
            { 0, 0, 0, 1}
            };

            pose = Pose;
            originSet = 1;
        }
        else
        {
            return;
        }
        
    }*/
}
