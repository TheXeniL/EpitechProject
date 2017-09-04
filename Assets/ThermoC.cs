using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using HoloToolkit;
using HoloToolkit.Unity.InputModule;
using System;
using MixedRealityNetworking;
using System.Text;


public class ThermoC : MonoBehaviour, IInputClickHandler, IInputHandler
{


    static byte[] toBytes = Encoding.ASCII.GetBytes("");

    public NetworkMessage thermoData = new NetworkMessage(0, toBytes);

    public static event Action<NetworkMessage> returnMessage;


    public void printMessage(NetworkMessage nm)
    {
		Debug.Log ("PrintMessage activated");
        Debug.Log(nm);
        thermoData = nm;
    }


    void Start()
    {
    
        ThermoC.returnMessage += printMessage;
		Debug.Log ("ThermoC initialized");
		SocketClientManager.Subscribe(0, returnMessage);

    }

    void Update()
    {
		SocketClientManager.Subscribe(0, returnMessage);
       // GameObject.Find("Temperature").GetComponent<TextMesh>().text = System.Text.Encoding.UTF8.GetString(thermoData.Content);
         
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
