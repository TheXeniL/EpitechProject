using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit;
using HoloToolkit.Unity.InputModule;
using System;
using MixedRealityNetworking;
using System.Text;

namespace EpitechProject
{

    public class Button2 : MonoBehaviour, IInputClickHandler, IInputHandler
    {
		public static bool button2Clicked = false;
        static byte[] toBytes = Encoding.ASCII.GetBytes("LightsOff1");
        NetworkMessage nm = new NetworkMessage(0, toBytes);

        public void OnInputClicked(InputEventData eventData)
        {
            if (button2Clicked == false)
            {
                transform.position += new Vector3(0, 0, 0.01f);
                SocketClientManager.SendMessage(nm);
            }

            button2Clicked = true;

            if (Button1.button1Clicked == true)
            {
                Button1.FindObjectOfType<Button1>().transform.position += new Vector3(0, 0, -0.01f);
            }

            Button1.button1Clicked = false;


        }

        public void OnInputDown(InputEventData eventData)
        {

        }

        public void OnInputUp(InputEventData eventData)
        {

        }

        // Use this for initialization
        void Start()
        {
            GetComponent<Renderer>().material.color = Color.red;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}