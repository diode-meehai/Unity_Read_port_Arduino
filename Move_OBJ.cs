using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO.Ports;

public class Move_OBJ : MonoBehaviour {

    int Check_Value = 0; // Variable check volume (VR) 
    SerialPort Arduino_Port = new SerialPort("COM4", 9600); //Variable = port number,baudrate

    // Use this for initialization
    void Start()
    {
        Arduino_Port.Open(); // Open port
        Arduino_Port.ReadTimeout = 1; // Time Rate Read port

    }

    // Update is called once per frame
    void Update()
    {
        if (Arduino_Port.IsOpen) // Check port TURE
        {
            try
            {
                string Read_P = Arduino_Port.ReadLine(); // Read port
                //print(Read_P); // print console read port
                int X = int.Parse(Read_P); // strint to int


                //===================Limit Move scale=====X=Y=Z========================//
                Vector3 _limit = transform.position;
                _limit.x = Mathf.Clamp(_limit.x, -3.0f, 3);
                // _limit.y = Mathf.Clamp(_limit.y, -2.7f, 2.3f);
                // _limit.z = Mathf.Clamp(_limit.y, 0, 0.1f);
                transform.position = _limit;
                //=================================================================//

                //=================Check changes===VR============================//
                if (X > 511 && X > Check_Value)
                {
                    Check_Value = X;
                    int Move_R = 0;
                    Move_R += 1;
                    transform.Translate(1 * Move_R, 0, 0 * Time.deltaTime);  // Move object right
                }
                else if (X < 511 && X < Check_Value)
                {
                    Check_Value = X;
                    int Move_R = 0;
                    Move_R -= 1;
                    transform.Translate(1 * Move_R, 0, 0 * Time.deltaTime); // Move object left
                }
                //=============================================================//

            }
            catch (System.Exception) { }
        }

    }
}