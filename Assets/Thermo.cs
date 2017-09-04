using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using HoloToolkit;
using HoloToolkit.Unity.InputModule;
using System;
using MixedRealityNetworking;
using System.Text;


public class Thermo : MonoBehaviour, IInputClickHandler, IInputHandler
{

    public bool lightStatus;
    public String bulbData;
    static byte[] toBytes = Encoding.ASCII.GetBytes("32 C");
    static byte[] toBytes2 = Encoding.ASCII.GetBytes("start");
    NetworkMessage mOn = new NetworkMessage(0, toBytes2);
    public NetworkMessage thermoData = new NetworkMessage(2, toBytes);



    void Start()
    {
        Debug.Log("Subscribed");
    }

    void Update()
    {

        GameObject.Find("Temperature").GetComponent<TextMesh>().text = MixedRealitySocket.tempHum;
        Debug.Log(MixedRealitySocket.tempHum);

    }

    public void OnInputClicked(InputEventData eventData)
    {

    }

    public void OnInputUp(InputEventData eventData)
    {

    }

    public void OnInputDown(InputEventData eventData)
    {

    }






}
