using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TcpManager : MonoBehaviour
{

    public TCPClient tcp;
    string message;
    public RenderTexture droneCam;
    public string[] msgparts = new string[4];
    public float scan;
    public float wp_x;
    public float wp_z;
    public float wp_y;

    // Start is called before the first frame update
    void Start()
    {
        tcp.ConnectToTcpServer();

    }

    // Update is called once per frame
    void Update()
    {
        if (scan == 1)
        {
            tcp.SendTcpImage(droneCam);
        }
        DecodeMessage();

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            tcp.SendTcpImage(droneCam);
        }*/
    }

    void DecodeMessage()
    {
        message = tcp.serverMessage;

        msgparts = message.Split(',');

        if (msgparts.Length == 4)
        {
            scan = float.Parse(msgparts[0]);
            wp_x = float.Parse(msgparts[1]);
            wp_z = float.Parse(msgparts[2]);
            wp_y = float.Parse(msgparts[3]);
        }

        /*if (msgparts.Length == 3)
        {
            theta = float.Parse(msgparts[0]);
            fi = float.Parse(msgparts[1]);
            detect = float.Parse(msgparts[2]);

        }
        else
        {
            Debug.Log("message not recieved");
        } */

    }
}
