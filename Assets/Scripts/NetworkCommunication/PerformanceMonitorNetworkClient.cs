using PerformanceMonitor.Lib;
using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

/// <summary>
/// Client class for the Performance Monitor server app.
/// </summary>
public class PerformanceMonitorNetworkClient : MonoBehaviour
{
    /// <summary>
    /// IP address of the Performance Monitor server app.
    /// </summary>
    public string ip = "192.168.0.102";

    public int port = 13000;

    /// <summary>
    /// Subscribers receive constant updates with the latest data.
    /// </summary>
    public PerformanceDataUpdateEvent dataUpdate;

    public bool IsOnline { get { return worker != null && worker.IsBusy; } }

    private volatile PerformanceData data;

    private BackgroundWorker worker;

    private int count;

    private void Start()
    {
        worker = new BackgroundWorker() { WorkerSupportsCancellation = true }; 
        worker.DoWork += Worker_DoWork; 
        worker.RunWorkerCompleted += Worker_RunWorkerCompleted; 
    }

    private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        Debug.Log("Connection task finished");
        
    }

    /// <summary>
    /// Asynchronously connects and reads data from the server.
    /// </summary>
    private void Worker_DoWork(object sender, DoWorkEventArgs e) 
    {
        var localAddr = IPAddress.Parse(ip);
        
        using (var client = new TcpClient())
        {
            int count = 0;
            while (!client.Connected)
            {
                if (worker.CancellationPending)
                {
                    Debug.Log(string.Format("Connection CANCELED {0}:{1}", ip, port));
                    return;
                }

                try
                {
                    client.Connect(localAddr, port); 
                }
                catch
                {
                    Debug.Log(string.Format("Connection unavailable {0}:{1} try {2}", ip, port, count));

                    if (++count > 9)
                    {
                        Debug.Log(string.Format("Connection TIMEOUT {0}:{1}", ip, port));
                        return;
                    }

                    Thread.Sleep(1000);
                }
            }

            Debug.Log(string.Format("CONNECTED {0}:{1}", ip, port));

            if (worker.CancellationPending)
                return;

            using (var stream = client.GetStream())
            {
                while (!worker.CancellationPending)
                {
                    var headerBuffer = new byte[sizeof(int)];
                    int headerBytesRead = stream.Read(headerBuffer, 0, headerBuffer.Length);

                    if (headerBytesRead == 0)
                    {
                        Debug.Log(string.Format("Connection LOST {0}:{1}", ip, port));
                        break;
                    }

                    int messageLength = BitConverter.ToInt32(headerBuffer, 0);

                    var messageBuffer = new byte[messageLength];
                    int messageBytesRead = stream.Read(messageBuffer, 0, messageLength);
                    var message = messageBuffer.Deserialize<PerformanceData>();
                    data = message;
                }
            }
        }
    }

    /// <summary>
    /// Invokes every frame.
    /// Invokes update event for subscribed components.
    /// </summary>
    private void Update()
    {
        if (data != null)
        {
            if (dataUpdate != null)
                dataUpdate.Invoke(data);
            data = null;
        }
    }

    private void OnDestroy()
    {
        Disconnect();
    }

    /// <summary>
    /// Changes the IP address of the server.
    /// </summary>
    /// <param name="ip"></param>
    public void SetIp(string ip)
    {
        this.ip = ip;
    }

    /// <summary>
    /// Connects to the server (non blocking - executes asynchronously and logs the result).
    /// </summary>
    public void Connect()
    {
        Disconnect();
        while (worker.IsBusy) ;
        worker.RunWorkerAsync();
    }

    /// <summary>
    /// Disconnects from the server.
    /// </summary>
    public void Disconnect()
    {
        if (worker.IsBusy)
        {
            Debug.Log("Closing existing connection...");
            worker.CancelAsync();
        }
    }
}