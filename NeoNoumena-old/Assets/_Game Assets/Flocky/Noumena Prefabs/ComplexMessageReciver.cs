using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace extOSC.Examples
{
    public class ComplexMessageReciver : MonoBehaviour
    {
        #region Public Vars
        //ParticleSystem ps;
        public char temp;
        public GameObject avatar1, avatar2, avatar3, avatar4;
        public string Address = "/unity1";
        //ParticleSystem.MainModule settings;


        Gradient grad = new Gradient();

        [Header("OSC Settings")]
        public OSCReceiver Receiver;

        #endregion

        #region Unity Methods
        //public ParticleSystem settings1;// = GetComponent<ParticleSystem>().main;
        public virtual void Awake()
        {
            Receiver.Bind(Address, ReceivedMessage);
        }

        #endregion

        #region Private Methods


        public void ReceivedMessage(OSCMessage message)
        {
            
            
            Renderer rend = GetComponent<Renderer>();

            temp = message.ToString()[46];

            //Debug.Log("here");
            //Debug.Log(temp);
            if (temp == 'H')
            {

                avatar1.gameObject.SetActive(true);
                avatar2.gameObject.SetActive(false);
                avatar3.gameObject.SetActive(false);
                avatar4.gameObject.SetActive(false);


            }
            if (temp == 'P')
            {
                avatar1.gameObject.SetActive(false);
                avatar2.gameObject.SetActive(true);
                avatar3.gameObject.SetActive(false);
                avatar4.gameObject.SetActive(false);


            }
            if (temp == 'A')
            {
                avatar1.gameObject.SetActive(false);
                avatar2.gameObject.SetActive(false);
                avatar3.gameObject.SetActive(true);
                avatar4.gameObject.SetActive(false);

            }
            if (temp == 'S')
            {
                avatar1.gameObject.SetActive(false);
                avatar2.gameObject.SetActive(false);
                avatar3.gameObject.SetActive(false);
                avatar4.gameObject.SetActive(true);

            }
            //Debug.LogFormat("Received: {0}", message);
            //Debug.LogFormat("brahmi is cool");
        }

        #endregion
    }
}


