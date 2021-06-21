using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
 using Valve.VR.InteractionSystem;

public class ViveInputs : MonoBehaviour
{
    public SteamVR_Input_Sources hand;

    public GameObject IntroPanel; 

    public Countdown CLOCK;
    void Update()
    {
        if(SteamVR_Actions._default.Squeeze.GetAxis(hand) == 1) {
            CLOCK.IntroDone = true;
            IntroPanel.SetActive(false);
        }
        if (Input.GetKeyDown("space"))
        {
            CLOCK.IntroDone = true;
            IntroPanel.SetActive(false);
        }

        
    }
}
