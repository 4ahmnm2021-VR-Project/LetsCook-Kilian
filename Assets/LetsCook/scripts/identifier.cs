using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class identifier : MonoBehaviour
{
    public string ingredient;

    private bool SpawnLock = false;

    void Start()
    {
        this.gameObject.tag = "ingredient";
        Debug.Log("Identifier " + this.gameObject.tag);
    }


    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) 
    {

        var colObj = collision.gameObject; 
        Debug.Log("######################## " + collision.gameObject.tag + " ######################");
        if(collision.gameObject.tag == "stacking" && SpawnLock == false) {
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
            SpawnLock = true;
            StartCoroutine(ResetLock());
            // return ingredientIMGS.Where(obj => obj.name == name).SingleOrDefault();
            var Entity = this.gameObject;
            Entity.GetComponent<Rigidbody>().isKinematic = true;
            var spawn = Instantiate(Entity, target.transform.position, target.transform.rotation);
            // spawn.GetComponent<Rigidbody>().isKinematic = true;
            spawn.transform.parent = ingredientStack.transform;
            spawn.name = spawn.name.Replace("(Clone)", "");
            Destroy(this.gameObject);
    }

    private IEnumerator ResetLock() {
        yield return new WaitForSeconds(1f);
        SpawnLock = false;
    }



}


