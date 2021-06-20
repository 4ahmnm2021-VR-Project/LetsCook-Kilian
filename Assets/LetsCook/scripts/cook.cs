using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cook : MonoBehaviour
{
    public ParticleSystem smoke;
    public int cookgrade; 
    public bool cooked = false;
    public bool burned = false;
    public Material pattyCooked;
    public Material pattyBurned;
    private bool switchlock = false;
    private bool switchlockBurn = false;
    private bool stay = false;


    void Start() {
        smoke.Stop();
    }

    void Update() 
    {
        if(stay == true) {
            Debug.Log("onStove");
            if(cookgrade > 500 && switchlock == false) {
                SetCooked();
            }
            if(cookgrade > 1000 &&  switchlockBurn == false) {
                SetBurned();
            }
            cookgrade ++;
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if(coll.transform.name == "stove") {
            smoke.Play();
            stay = true;
        }
    }

    void OnCollisionExit(Collision coll)
    {
        if(coll.transform.name == "stove") {
            smoke.Stop();
            stay = false;
        }
    }

    // private void OnTriggerStay(Collider other)  {
    // private void OnCollisionEnter(Collision collisionInfo)  {  

 
    //     if(collisionInfo.gameObject.name == "stove") {
    //         smoke.Play();
    //         stay = true;
    //     } 
    // }

    // private void OnCollisionExit(Collision collisionInfo)  {  
    //     smoke.Stop();
    //     stay = false;
    // }

    private void SetCooked() {
        switchlock = true;
        cooked = true;
        this.gameObject.GetComponent<MeshRenderer> ().material = pattyCooked;

    }
    private void SetBurned() {
        switchlockBurn = true;
        cooked = false;
        burned = true;
        this.gameObject.GetComponent<MeshRenderer> ().material = pattyBurned;

    }
    
}
