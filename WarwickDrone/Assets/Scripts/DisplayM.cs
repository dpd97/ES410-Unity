using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayM : MonoBehaviour
{
    public DisplayTCP tcp;
    public string[] msgparts = new string[6]; // put in place of the 6, the number of parts in your message
    private string msg;
    // delete these and declare the variables you want e.g. public string velocity
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

        if (msgparts.Length == 6) // number of things in the message
        {
            // here set the variables you declared, to the relevant position in the string, starting with 0
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