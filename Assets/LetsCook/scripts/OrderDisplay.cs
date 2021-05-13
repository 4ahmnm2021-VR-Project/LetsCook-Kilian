using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class OrderDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Order0;
    public GameObject Order1;
    public GameObject Order2;

    public Text OrdersCompletd;
    [SerializeField] List<GameObject> ingredientIMGS = new List<GameObject>(); 

    public void DisplayOrder(string orderName, List<string> order) {
        var counter = 0;
        if(orderName == "Order0") {
            ClearOrder("Order0");
            foreach(var item in order) {
                var ingredient = GetIngredient(item);
                // Debug.Log("Order0: " + ingredient);
                StartCoroutine(SpawnImage(Order0, ingredient, counter));
                counter ++;   
            } 
        }
        if(orderName == "Order1") {
            ClearOrder("Order1");
            foreach(var item in order) {
                var ingredient = GetIngredient(item);
                // Debug.Log("Order1: " + ingredient);
                StartCoroutine(SpawnImage(Order1, ingredient, counter));
                counter ++;    
            } 
        }
        if(orderName == "Order2") {
            ClearOrder("Order2");
     
            foreach(var item in order) {
                var ingredient = GetIngredient(item);
                // Debug.Log("Order2: " + ingredient);
                 StartCoroutine(SpawnImage(Order2, ingredient, counter));
                counter ++;  

            } 
      
        }
    }

    IEnumerator SpawnImage(GameObject OrderOBJ, GameObject prefap, int counter) {
        yield return new WaitForSeconds(0.05f);
        bool spawnLock = false;
 

        foreach(Transform child in OrderOBJ.transform) {
            if(child.childCount == 0) {
                var pref = Instantiate(prefap, new Vector3(0f, 0f, 0f), Quaternion.identity);
                var rect = pref.GetComponent<RectTransform>();
                pref.transform.parent = child.transform;
                rect.localPosition = new Vector3(0,0,0);
                rect.localScale = new Vector3(17f,17f,17f);
                rect.localRotation = Quaternion.Euler(0, 0, 0);
                pref.transform.GetComponent<SpriteRenderer>().sortingOrder = counter;
                break;
            }
        }
    }

    public GameObject GetIngredient(string ingredientName) {
        string name = "img_" + ingredientName;
        // Debug.Log("#######################" + name + "############################");
        return ingredientIMGS.Where(obj => obj.name == name).SingleOrDefault();
    }

    public void ClearOrder(string orderName) {
        if(orderName == "Order0") {
            foreach(Transform child in Order0.transform) {
                if(child.childCount > 0) {
                   Destroy(child.transform.GetChild(0).gameObject); 
                }
            } 
        }
        if(orderName == "Order1") {
            foreach(Transform child in Order1.transform) {
                if(child.childCount > 0) {
                   Destroy(child.transform.GetChild(0).gameObject); 
                }
            } 
        }
        if(orderName == "Order2") {
            foreach(Transform child in Order2.transform) {
                 if(child.childCount > 0) {
                   Destroy(child.transform.GetChild(0).gameObject); 
                }
            } 
        }
    }

    public void SetScore(int score) {
        OrdersCompletd.text = score.ToString();
    }
}
