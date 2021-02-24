using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TcpManager : MonoBehaviour
{

    public TCPClient tcp;
    string message;
    public RenderTexture droneCam;
    public string[] msgparts = new string[1];
    public float scan;

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

        if (msgparts.Length == 1)
        {
            scan = float.Parse(msgparts[0]);
        }

    }
}
