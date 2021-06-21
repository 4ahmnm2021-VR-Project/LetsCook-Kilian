using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using Valve.VR.InteractionSystem;
  using Valve.VR;

public class ingredientBox : MonoBehaviour
{
    private GameObject spawnPoint;
    public GameObject suply;

    public Countdown CLOCK;

    private bool started = false;
    void Start()
    {
        spawnPoint = this.gameObject.transform.Find("spawnPoint").gameObject;
        CLOCK = GameObject.Find("CLOCK").GetComponent<Countdown>();
    }

    void Update()
    {
        if(spawnPoint.transform.childCount < 1) {
            var entity = Instantiate(suply, spawnPoint.transform.position, spawnPoint.transform.rotation);
            entity.transform.parent = spawnPoint.transform;
            if(CLOCK.IntroDone == false) {
                entity.gameObject.AddComponent<IgnoreHovering>();
            }
            entity.name = entity.name.Replace("(Clone)", "");
        }

        if(CLOCK.IntroDone == true && started == false) {
            Destroy(spawnPoint.transform.GetChild(0).GetComponent<IgnoreHovering>());
            started = true;
        }
        
    }
}
