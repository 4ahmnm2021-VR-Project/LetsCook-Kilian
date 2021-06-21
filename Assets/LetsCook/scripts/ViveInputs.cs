using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
 using Valve.VR.InteractionSystem;

public class ViveInputs : MonoBehaviour
{
    public SteamVR_Input_Sources hand;
    void Update()
    {
        if(SteamVR_Actions._default.Teleport.GetStateDown(hand)) {
            Debug.Log("Telepot Pressed");
        }
        
    }
}
