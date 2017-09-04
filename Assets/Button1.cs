using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using HoloToolkit;
using HoloToolkit.Unity.InputModule;
using System;
using MixedRealityNetworking;
using System.Text;

namespace EpitechProject
{
    public class Button1 : MonoBehaviour, IInputClickHandler, IInputHandler
    {
		public static bool button1Clicked = false;
        private Vector3 destination;
        private static byte[] toBytes = Encoding.ASCII.GetBytes("LightsOn1");
        private NetworkMessage nm = new NetworkMessage(0, toBytes);


        // Use this for initialization
        void Start()
        {
            GetComponent<Renderer>().material.color = Color.green;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnInputClicked(InputEventData eventData)
        {
            if (button1Clicked == false)
            {
                transform.position += new Vector3(0, 0, 0.01f);
                SocketClientManager.SendMessage(nm);

            }

            button1Clicked = true;

            if (Button2.button2Clicked == true)
            {
                Button2.FindObjectOfType<Button2>().transform.position += new Vector3(0, 0, -0.01f);

            }

            Button2.button2Clicked = false;


        }

        public void OnInputUp(InputEventData eventData)
        {

        }

        public void OnInputDown(InputEventData eventData)
        {

        }
    }
}