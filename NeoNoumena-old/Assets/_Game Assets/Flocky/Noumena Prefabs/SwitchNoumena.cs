using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC.Examples;

public class SwitchNoumena : MonoBehaviour
{
    public SimpleMessageReceiver temp;

    // referenses to controlled game objects
    public GameObject avatar1, avatar2, avatar3, avatar4;

    // variable contains which avatar is on and active
    int whichAvatarIsOn = 1;

    // Use this for initialization
    void Start()
    {
        Debug.Log("start");
        Debug.Log(temp);
        // anable first avatar and disable another one
        avatar1.gameObject.SetActive(true);
        avatar2.gameObject.SetActive(false);
        avatar3.gameObject.SetActive(false);
        avatar4.gameObject.SetActive(false);
    }



    void Update()
    {
        //if (temp != null)
        //{
        //    Debug.Log("update" + temp);
        //}
            
        //if (temp == 'H')
        {
            avatar1.gameObject.SetActive(true);
            avatar2.gameObject.SetActive(false);
            avatar3.gameObject.SetActive(false);
            avatar4.gameObject.SetActive(false);
        }
        if (Input.GetButtonDown("2key"))
        {
            avatar1.gameObject.SetActive(false);
            avatar2.gameObject.SetActive(true);
            avatar3.gameObject.SetActive(false);
            avatar4.gameObject.SetActive(false);
        }
        if (Input.GetButtonDown("3key"))
        {
            avatar1.gameObject.SetActive(false);
            avatar2.gameObject.SetActive(false);
            avatar3.gameObject.SetActive(true);
            avatar4.gameObject.SetActive(false);
        }
        if (Input.GetButtonDown("4key"))
        {
            avatar1.gameObject.SetActive(false);
            avatar2.gameObject.SetActive(false);
            avatar3.gameObject.SetActive(false);
            avatar4.gameObject.SetActive(true);
        }
    }







    //// public method to switch avatars by pressing UI button
    //public void SwitchAvatar()
    //{

    //    // processing whichAvatarIsOn variable
    //    switch (whichAvatarIsOn)
    //    {

    //        // if the first avatar is on
    //        case 1:

    //            // then the second avatar is on now
    //            whichAvatarIsOn = 2;

    //            // disable the first one and anable the second one
    //            avatar1.gameObject.SetActive(false);
    //            avatar2.gameObject.SetActive(true);
    //            break;

    //        // if the second avatar is on
    //        case 2:

    //            // then the first avatar is on now
    //            whichAvatarIsOn = 1;

    //            // disable the second one and anable the first one
    //            avatar1.gameObject.SetActive(true);
    //            avatar2.gameObject.SetActive(false);
    //            break;
    //    }

    //}
}