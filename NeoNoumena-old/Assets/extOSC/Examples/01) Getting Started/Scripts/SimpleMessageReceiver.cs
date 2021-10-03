
/* Copyright (c) 2019 ExT (V.Sigalkin) */

using UnityEngine;

namespace extOSC.Examples
{

    public class SimpleMessageReceiver : MonoBehaviour
    {
        #region Public Vars
        //ParticleSystem ps;
        //public Rigidbody rb;
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
            //avatar1.gameObject.SetActive(true);
            Receiver.Bind(Address, ReceivedMessage);
        }

        #endregion

        #region Private Methods

        public void ReceivedMessage(OSCMessage message)
        {
            char temp;
            Renderer rend = GetComponent<Renderer>();

            temp = message.ToString()[46];
            var settings1 = GetComponent<ParticleSystem>();
            Debug.Log("here");
            Debug.Log(temp);
            if (temp == 'H')
            {
                //rb.AddForce(0, 0, 2);
                avatar1.gameObject.SetActive(true);
                avatar2.gameObject.SetActive(false);
                avatar3.gameObject.SetActive(false);
                avatar4.gameObject.SetActive(false);
                
                //settings 
                if (settings1 != null)
                {
                    var main = settings1.main;
                    main.startColor = new Color(1, 0.92f, 0.016f, 1f);
                }
            }
            if (temp == 'P')
            {
                //rb.AddForce(0, 0, 2);

                avatar1.gameObject.SetActive(false);
                avatar2.gameObject.SetActive(true);
                avatar3.gameObject.SetActive(false);
                avatar4.gameObject.SetActive(false);
                //settings 
                if (settings1 != null)
                {
                    var main = settings1.main;
                    main.startColor = new Color(0, 1, 0, .5f);
                }
            }
            if (temp == 'A')
            {
                //rb.AddForce(0, 0, -10);
                avatar1.gameObject.SetActive(false);
                avatar2.gameObject.SetActive(false);
                avatar3.gameObject.SetActive(true);
                avatar4.gameObject.SetActive(false);
                // settings 

                if (settings1 != null)
                {
                    var main = settings1.main;
                    main.startColor = new Color(1, 0, 0, .5f);
                }
            }
            if (temp == 'S')
            {
                //rb.AddForce(0, 0, 2);
                avatar1.gameObject.SetActive(false);
                avatar2.gameObject.SetActive(false);
                avatar3.gameObject.SetActive(false);
                avatar4.gameObject.SetActive(true);
                //settings 
                if (settings1 != null)
                {
                    var main = settings1.main;
                    main.startColor = new Color(0, 0, 1, 1);
                }
            }
            Debug.LogFormat("Received: {0}", message);
            //Debug.LogFormat("brahmi");
        }

        #endregion
    }
}

///* Copyright (c) 2019 ExT (V.Sigalkin) */

//using UnityEngine;

//namespace extOSC.Examples
//{

//    public class SimpleMessageReceiver : MonoBehaviour
//    {
//        #region Public Vars
//        //ParticleSystem ps;

//        public GameObject avatar1, avatar2, avatar3, avatar4;
//        public string Address = "/unity1";
//        //ParticleSystem.MainModule settings;


//        Gradient grad = new Gradient();

//        [Header("OSC Settings")]
//        public OSCReceiver Receiver;

//        #endregion

//        #region Unity Methods
//        //public ParticleSystem settings1;// = GetComponent<ParticleSystem>().main;
//        public virtual void Awake()
//        {
//            Receiver.Bind(Address, ReceivedMessage);
//        }

//        #endregion

//        #region Private Methods


//        public void ReceivedMessage(OSCMessage message)
//        {
//            char temp;
//            Renderer rend = GetComponent<Renderer>();

//            temp = message.ToString()[46];

//            //Debug.Log("here");
//            //Debug.Log(temp);
//            if (temp == 'H')
//            {

//                avatar1.gameObject.SetActive(true);
//                avatar2.gameObject.SetActive(false);
//                avatar3.gameObject.SetActive(false);
//                avatar4.gameObject.SetActive(false);


//            }
//            if (temp == 'P')
//            {
//                avatar1.gameObject.SetActive(false);
//                avatar2.gameObject.SetActive(true);
//                avatar3.gameObject.SetActive(false);
//                avatar4.gameObject.SetActive(false);


//            }
//            if (temp == 'A')
//            {
//                avatar1.gameObject.SetActive(false);
//                avatar2.gameObject.SetActive(false);
//                avatar3.gameObject.SetActive(true);
//                avatar4.gameObject.SetActive(false);

//            }
//            if (temp == 'S')
//            {
//                avatar1.gameObject.SetActive(false);
//                avatar2.gameObject.SetActive(false);
//                avatar3.gameObject.SetActive(false);
//                avatar4.gameObject.SetActive(true);

//            }
//            //Debug.LogFormat("Received: {0}", message);
//            //Debug.LogFormat("brahmi is cool");
//        }

//        #endregion
//    }
//}