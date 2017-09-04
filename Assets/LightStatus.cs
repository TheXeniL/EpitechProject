using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EpitechProject
{
    public class LightStatus : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Button1.button1Clicked)
            {
                GetComponent<TextMesh>().text = "Lights on";
                GetComponent<TextMesh>().color = Color.green;
            }

            if (Button2.button2Clicked)
            {
                GetComponent<TextMesh>().text = "Lights off";
                GetComponent<TextMesh>().color = Color.red;

            }
        }
    }
}
