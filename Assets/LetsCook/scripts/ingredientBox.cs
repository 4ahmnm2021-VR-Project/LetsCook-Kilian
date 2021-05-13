using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingredientBox : MonoBehaviour
{
    private GameObject spawnPoint;
    public GameObject suply;
    void Start()
    {
        spawnPoint = this.gameObject.transform.Find("spawnPoint").gameObject;
    }

    void Update()
    {
        if(spawnPoint.transform.childCount < 1) {
            var entity = Instantiate(suply, spawnPoint.transform.position, spawnPoint.transform.rotation);
            entity.transform.parent = spawnPoint.transform;
        }
        
    }
}
