using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class identifier : MonoBehaviour
{
    public string ingredient;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) 
    {

        var colObj = collision.gameObject; 
        if(collision.gameObject.tag == "stacking") {
            var ingredientStack = colObj;
            var childs = 5;
            var target = colObj;
     

            
            if(collision.gameObject.name.Contains("plate")) {
                ingredientStack = colObj.transform.Find("ingredientStack").gameObject;
                childs = ingredientStack.transform.childCount;
                target = colObj.transform.Find("target").gameObject;
                if(childs > 0) {
                    target = ingredientStack.transform.GetChild(childs - 1).transform.Find("target").gameObject;
                }
                SpawnEntity(target, ingredientStack);
         
            } else {
                if(colObj.transform.parent.gameObject.name == "ingredientStack") {
                    Debug.Log(colObj.transform.parent.gameObject.name);
                    ingredientStack = colObj.transform.parent.gameObject;
                    childs = ingredientStack.transform.childCount;
                    target = ingredientStack.transform.GetChild(childs - 1).transform.Find("target").gameObject;
                    SpawnEntity(target, ingredientStack);
                }
            }
        }
    }

    private void SpawnEntity(GameObject target, GameObject ingredientStack) {
            var Entity = this.gameObject;
            Entity.GetComponent<Rigidbody>().isKinematic = true;
            var spawn = Instantiate(Entity, target.transform.position, target.transform.rotation);
            // spawn.GetComponent<Rigidbody>().isKinematic = true;
            spawn.transform.parent = ingredientStack.transform;
            Destroy(this.gameObject);
    }



}


