using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class SITLClient : MonoBehaviour
{
    #region private members 	
    private TcpClient socketConnection;
    private Thread clientReceiveThread;
    #endregion

    public string ipAdress = "192.168.1.75";
    public int port = 5590;
    public string serverMessage;

    /// <summary> 	
    /// Setup socket connection. 	
    /// </summary> 	
    public void ConnectToTcpServer()
    {
        try
        {
            clientReceiveThread = new Thread(new ThreadStart(ListenForData));
            clientReceiveThread.IsBackground = true;
            clientReceiveThread.Start();
        }
        catch (Exception e)
        {
            Debug.Log("On client connect exception " + e);
        }
    }

    /// <summary> 	
    /// Runs in background clientReceiveThread; Listens for incomming data. 	
    /// </summary>     
    private void ListenForData()
    {
        try
        {
            socketConnection = new TcpClient(ipAdress, port);
            Byte[] bytes = new Byte[1024];

            while (true)
            {
                // Get a stream object for reading 				
                using (NetworkStream stream = socketConnection.GetStream())
                {
                    int length;
                    // Read incomming stream into byte arrary. 					
                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        var incommingData = new byte[length];
                        Array.Copy(bytes, 0, incommingData, 0, length);
                        // Convert byte array to string message. 						
                        serverMessage = Encoding.ASCII.GetString(incommingData);
                        //Debug.Log("server message received as: " + serverMessage);
                    }
                }
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }

    /// <summary> 	
    /// Send message to server using socket connection. 	
    /// </summary> 	
    public void SendTcpMessage(string clientMessage)
    {
        if (socketConnection == null)
        {
            return;
        }
        try
        {
            // Get a stream object for writing. 			
            NetworkStream stream = socketConnection.GetStream();
            if (stream.CanWrite)
            {
                // Convert string message to byte array.                 
                byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(clientMessage);
                // Write byte array to socketConnection stream.                 
                stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
                Debug.Log("Message sent " + clientMessage);
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }

    public void CloseConnection()
    {
        if (socketConnection != null)
            socketConnection.Close();
    }

    private void OnDisable()
    {
        if (socketConnection != null)
            socketConnection.Close();
    }

    private void OnDestroy()
    {
        if (socketConnection != null)
            socketConnection.Close();
    }
}
