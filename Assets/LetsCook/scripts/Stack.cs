using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // void Update() {
        // CheckIngredients();
    // }
}
