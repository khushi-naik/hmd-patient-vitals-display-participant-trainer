using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using UnityEngine;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

public class TcpConnectionScript : MonoBehaviour
{
    private TcpClient client;
    private StreamWriter writer;
    private string serverIp = "10.69.55.175";//"10.121.204.39";
    private int serverPort = 80;
    private int i = 0;
    private float timer;
    private ConcurrentQueue<string> messageQueue = new ConcurrentQueue<string>();
    private Thread sendThread;
    private bool isRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        connectToServer();
        sendThread = new Thread(SendMessages);
        sendThread.Start();
    }


    void connectToServer()
    {
        try
        {
            client = new TcpClient(serverIp,serverPort);
            Debug.Log("Connected to server hereee");

            writer = new StreamWriter(client.GetStream());
            writer.AutoFlush = true;
        }
        catch (Exception e)
        {
            Debug.LogError("connection error: "+e.Message);
        }
    }

    public void sendMessage(string message)
    {
        if (client != null && client.Connected)
        {
            messageQueue.Enqueue(message);
        }
        else
        {
            Debug.LogWarning("Client is not connected to the server");
        }
    }

    private void SendMessages()
    {
        while (isRunning)
        {
            if (messageQueue.TryDequeue(out string message))
            {
                try
                {
                    writer.WriteLine(message);
                    Debug.Log("Message sent to server: " + message);
                }
                catch (Exception e)
                {
                    Debug.LogError("Error sending message: " + e.Message);
                }
            }
            Thread.Sleep(2); // Adjust the sleep time as needed
        }
    }

    private void OnDestroy()
    {
        isRunning = false;
        sendThread.Join();
        writer?.Close();
        client?.Close();
    }

    /*public void sendMessage(string message)
    {
        if (client != null && client.Connected)
        {
            try
            {
                writer.WriteLine(message);
                Debug.Log("message sent to server: " + message);

            }
            catch (Exception e)
            {
                Debug.LogError("error sending message " + e.Message);
            }
        }
        else
        {
            Debug.LogWarning("Client is not connected to the server");
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        /*timer += Time.deltaTime;
        if(timer >= 1f)
        {
            sendMessage(i.ToString());
            i++;
            timer = 0f;
        }*/
        
    }
}
