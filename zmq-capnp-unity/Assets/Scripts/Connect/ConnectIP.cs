using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Serialization;

#if WINDOWS_UWP
using Windows.Storage;
#endif

public class ConnectIP : MonoBehaviour
{ 
    ZMQConnection connection;

    public string ip;
    public string IP{ get => ip; set => ip = value; }
    public bool connectOnStart = true;

    private void Awake()
    {
        connection = GetComponent<ZMQConnection>();
    }

    
    void Start()
    {
        ip = connection.IPAddress;
#if WINDOWS_UWP
        // Get IP address from localSettings
        var localSettings = ApplicationData.Current.LocalSettings;
        if(localSettings.Values["IP"] != null){
            ip = localSettings.Values["IP"].ToString();
        }
#endif
        if (connectOnStart)
        {
            connection.Connect(ip, connection.SubPort, connection.PubPort);
        }
    }

    public void Connect(string inputIP)
    {
        ip = inputIP; 
        connection.Disconnect();
        connection.Connect(ip, connection.SubPort, connection.PubPort);

#if WINDOWS_UWP
        // Save IP address to localSettings
        var localSettings = ApplicationData.Current.LocalSettings;
        localSettings.Values["IP"] = ip;
#endif
    }
}
