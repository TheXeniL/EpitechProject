using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using HoloToolkit;
using HoloToolkit.Unity.InputModule;
using System;
using MixedRealityNetworking;
using System.Text;

public class BoxSpeaker : MonoBehaviour, IInputClickHandler, IInputHandler {

	static byte[] toBytes1 = Encoding.ASCII.GetBytes("OnSpeaker");
	static byte[] toBytes2 = Encoding.ASCII.GetBytes("OffSpeaker");
	NetworkMessage mOn = new NetworkMessage(0, toBytes1);
	NetworkMessage mOff = new NetworkMessage(0, toBytes2);

	public bool speakerStatus;
	public String speakerData;


	public void OnInputClicked(InputEventData eventData)
    {
        if (speakerStatus == false)
		{
			SocketClientManager.SendMessage(mOn);
            speakerStatus = true;
			Debug.Log("Speaker pressed On");
		}

        else if (speakerStatus == true)
		{
			SocketClientManager.SendMessage(mOff);
            speakerStatus = false;
			Debug.Log("Speaker pressed Off");
		}

    }

    public void OnInputDown(InputEventData eventData)
    {
    }

    public void OnInputUp(InputEventData eventData)
    {
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (speakerStatus == true) {
			transform.Rotate (Vector3.up * 50 * Time.deltaTime);
		}

		if (speakerStatus == true)
		{
            
			GetComponent<Renderer>().material.color = Color.yellow;

            GameObject.Find("FrontTextSpeaker").GetComponent<TextMesh>().text = "ON";
			GameObject.Find("BackTextSpeaker").GetComponent<TextMesh>().text = "ON";

			GameObject.Find("FrontTextSpeaker").GetComponent<TextMesh>().color = Color.black;
			GameObject.Find("BackTextSpeaker").GetComponent<TextMesh>().color = Color.black;


		}

        if (speakerStatus == false)
		{
			GetComponent<Renderer>().material.color = Color.blue;

			GameObject.Find("FrontTextSpeaker").GetComponent<TextMesh>().text = "OFF";
			GameObject.Find("BackTextSpeaker").GetComponent<TextMesh>().text = "OFF";

			GameObject.Find("FrontTextSpeaker").GetComponent<TextMesh>().color = Color.white;
			GameObject.Find("BackTextSpeaker").GetComponent<TextMesh>().color = Color.white;
		}
		
	}
}
