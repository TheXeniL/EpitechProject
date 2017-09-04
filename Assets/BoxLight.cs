using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using HoloToolkit;
using HoloToolkit.Unity.InputModule;
using System;
using MixedRealityNetworking;
using System.Text;


public class BoxLight : MonoBehaviour, IInputClickHandler, IInputHandler
{

    // Creating messages

    static byte[] toBytes1 = Encoding.ASCII.GetBytes("OnLight");
    static byte[] toBytes2 = Encoding.ASCII.GetBytes("OffLight");
    NetworkMessage mOn = new NetworkMessage(0, toBytes1);
    NetworkMessage mOff = new NetworkMessage(0, toBytes2);

    //_____________________________________________________________

    public bool lightStatus;
    public String bulbData;
  
    void Start ()
    {
        lightStatus = false;
	}

    void Update()
    {
		if (lightStatus == true) 
		{
			transform.Rotate (Vector3.up * 50 * Time.deltaTime);
		}

        if (lightStatus == true)
        {
			
            GetComponent<Renderer>().material.color = Color.yellow;

            GameObject.Find("FrontTextLight").GetComponent<TextMesh>().text = "ON";
            GameObject.Find("BackTextLight").GetComponent<TextMesh>().text = "ON";

            GameObject.Find("FrontTextLight").GetComponent<TextMesh>().color = Color.black;
            GameObject.Find("BackTextLight").GetComponent<TextMesh>().color = Color.black;


        }

        if (lightStatus == false)
        {
            GetComponent<Renderer>().material.color = Color.blue;

            GameObject.Find("FrontTextLight").GetComponent<TextMesh>().text = "OFF";
            GameObject.Find("BackTextLight").GetComponent<TextMesh>().text = "OFF";

            GameObject.Find("FrontTextLight").GetComponent<TextMesh>().color = Color.white;
            GameObject.Find("BackTextLight").GetComponent<TextMesh>().color = Color.white;
        }

    }

    public void OnInputClicked(InputEventData eventData)
    {
        if (lightStatus == false)
        {
            SocketClientManager.SendMessage(mOn);
            lightStatus = true;
        }

        else if (lightStatus == true)
        {
            SocketClientManager.SendMessage(mOff);
			lightStatus = false;
        }
    }

    public void OnInputUp(InputEventData eventData)
    {
      
    }

    public void OnInputDown(InputEventData eventData)
    {
       
    }
}
