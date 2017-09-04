using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit;
using HoloToolkit.Unity.InputModule;
using System;



public class MoveButton : MonoBehaviour, IInputClickHandler, IInputHandler
{
        bool buttonClicked = false;
        bool changePlace;
		public string objectToPlace;

        HandDraggable dragOption = new HandDraggable();

        public MoveButton(string objectToPlace)
        {
        
        this.objectToPlace = objectToPlace;

        }

        public void OnInputClicked(InputEventData eventData)
        {

			if (buttonClicked == false)
			{
				GetComponent<Renderer>().material.color = Color.green;
				buttonClicked = true;
                GameObject.Find(objectToPlace).GetComponent<HandDraggable>().IsDraggingEnabled = true;
                GameObject.Find(objectToPlace).GetComponent<Collider>().enabled = true; 
			}

			else if (buttonClicked == true)
			{
				GetComponent<Renderer>().material.color = Color.white;
				buttonClicked = false;
				GameObject.Find(objectToPlace).GetComponent<HandDraggable>().IsDraggingEnabled = false;
                GameObject.Find(objectToPlace).GetComponent<Collider>().enabled = false;

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
           
        }

        // Update is called once per frame
        void Update()
        {

        }
}