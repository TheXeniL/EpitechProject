using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MixedRealityNetworking;
using System.Text;
using System;

public class MixedRealitySocket : MonoBehaviour {
    // Use this for initialization

    public static event Action<NetworkMessage> returnMessage;
    static byte[] toBytes = Encoding.ASCII.GetBytes("32 C");
    public NetworkMessage thermoData = new NetworkMessage(2, toBytes);
    public static String tempHum;

    public void printMessage(NetworkMessage nm)
    {
        Debug.Log(nm.Content);
        thermoData = nm;
    }

    void Start () {
        SocketClientManager.Host = "192.168.43.181";
        SocketClientManager.Port = 50090;


        SocketClientManager.Connect();


    }
	
	// Update is called once per frame
	void Update () {


    }
}
