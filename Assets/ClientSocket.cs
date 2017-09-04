/**
using UnityEngine;
using System;
using System.IO;
using System.Net.Sockets;
using MixedRealityNetworking;


namespace EpitechProject
{
    public class ClientSocket : MonoBehaviour
    {
        public bool socketReady = false;
        public TcpClient s;
        public NetworkStream theStream;
        public StreamWriter theWriter;
        public StreamReader theReader;
        public String Host = "192.168.43.181";
        public Int32 Port = 50090;
        public bool lightStatus;
        public string lightStatusText;


        void Start()
        {
            setupSocket();                        // setup the server connection when the program starts
        }

        // Update is called once per frame
        void Update()
        {

            while (theStream != null && theStream.DataAvailable)
            {                  // if new data is recieved from Arduino
                string recievedData = readSocket();            // write it to a string

                if (recievedData == "LightsOn")
                {            // compare that string and adjust the current light status accordingly
                    lightStatus = true;
                }

                if (recievedData == "LightsOff")
                {
                    lightStatus = false;
                }

            }

        }

        public void setupSocket()
        {
            try
            {
                s = new TcpClient(Host, Port);

                theStream = s.GetStream();
                theWriter = new StreamWriter(theStream);
                theReader = new StreamReader(theStream);
                socketReady = true;
            }
            catch (Exception e)
            {
                Debug.Log("Socket error:" + e);
            }
        }

        public void writeSocket(string theLine)
        {
            // function to write data out
            if (!socketReady)
                return;
            string tmpString = theLine;
            theWriter.Write(tmpString);
            theWriter.Flush();
        }

        public String readSocket()
        {                        
            // function to read data in
            if (!socketReady)
                return "";
            if (theStream.DataAvailable)
                return theReader.ReadLine();
            return "NoData";
        }

        public void closeSocket()
        {                            // function to close the socket
            if (!socketReady)
                return;
            theWriter.Close();
            theReader.Close();
            s.Close();
            socketReady = false;
        }

        public void maintainConnection()
        {
            if (!theStream.CanRead)
            {
                setupSocket();
            }
        }

    }
}
*/