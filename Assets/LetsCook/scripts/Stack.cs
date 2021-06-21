using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
public class Stack : MonoBehaviour
{
    private GameObject IngredientStack;
    List<string> ingredients = new List<string>(); 
    void Start() {

        IngredientStack = this.gameObject.transform.Find("ingredientStack").gameObject;
    }
    private void CheckIngredients() {
  
        foreach(Transform Ingredient in IngredientStack.transform) {
            ingredients.Add(Ingredient.gameObject.transform.GetComponent<identifier>().ingredient);
   
        }
    }

    void Update() {
        if(IngredientStack.transform.childCount != 0) {
            var igh = IngredientStack.transform.GetChild(IngredientStack.transform.childCount - 1).GetComponent<IgnoreHovering>();
            if(igh != null) {
                Destroy(igh);
                if(IngredientStack.transform.childCount > 1) {
                    var seccondChild = IngredientStack.transform.GetChild(IngredientStack.transform.childCount - 2); 
                    // Debug.Log(seccondChild.name);
                    if(seccondChild.GetComponent<IgnoreHovering>() == null) {
                        seccondChild.gameObject.AddComponent<IgnoreHovering>();
                    }

                }

                // if(IngredientStack.transform.GetChild(IngredientStack.transform.childCount - 1))
                //  spawn.gameObject.AddComponent<IgnoreHovering>();
            }
        }
    }

    // void Update() {
        // CheckIngredients();
    // }
}
