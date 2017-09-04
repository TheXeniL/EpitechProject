using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit;
using HoloToolkit.Unity.InputModule;
using System;


namespace EpitechProject
{
    public class ChangePlaceButton : MonoBehaviour, IInputClickHandler, IInputHandler
    {
        bool buttonClicked = false;
        bool changePlace;

        HandDraggable dragOption = new HandDraggable();

        public void OnInputClicked(InputEventData eventData)
        {
            if (buttonClicked == false)
            {
                transform.position += new Vector3(0, 0, 0.01f);
                buttonClicked = true;
                GameObject.Find("Menu").GetComponent<HandDraggable>().IsDraggingEnabled = true;
            }
            else if (buttonClicked == true)
            {
                transform.position += new Vector3(0, 0, -0.01f);
                buttonClicked = false;
                GameObject.Find("Menu").GetComponent<HandDraggable>().IsDraggingEnabled = false;
            }



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
            GetComponent<Renderer>().material.color = Color.yellow;
            changePlace = GameObject.Find("Menu").GetComponent<HandDraggable>().IsDraggingEnabled;
            changePlace = false;
        }

        // Update is called once per frame
        void Update()
        {

        }


    }
}
