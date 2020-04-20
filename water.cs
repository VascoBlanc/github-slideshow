﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class water : MonoBehaviour

{



    SerialPort sp = new SerialPort("/dev/tty.usbmodem14101", 9600); // set port of your arduino connected to computer

    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;





    }

    void Update()
    {
        if (sp.IsOpen)

        {
            try
            {
                if (sp.ReadByte() == 1)
                {
                    ParticleSystem particle = (ParticleSystem)gameObject.GetComponent("ParticleSystem");

                    particle.Play();



                }
                if (sp.ReadByte() == 2)
                {
                    ParticleSystem particle = (ParticleSystem)gameObject.GetComponent("ParticleSystem");

                    particle.Stop();

                }
            }
            catch (System.Exception)
            {
            }

        }
    }
}