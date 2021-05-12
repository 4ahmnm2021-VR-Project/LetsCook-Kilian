using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Order0;
    public GameObject Order1;
    public GameObject Order2;
    [SerializeField] List<GameObject> ingredientIMGS = new List<GameObject>(); 

    public void DisplayOrder(string orderName, List<string> order) {

        var counter = 0;
        foreach(var item in order) {

        }
        if(orderName == "Order0") {
            foreach(Transform child in Order0.transform) {
                if(child.childCount == 0) {
                    
                    SpawnImage(Order0, ingredientIMGS[0], counter);
                }
                counter ++;
            }
        }
    }

    public void SpawnImage(GameObject OrderOBJ, GameObject prefap, int counter) {
  
        foreach(Transform child in OrderOBJ.transform) {
                if(child.childCount == 0) {
                    var pref = Instantiate(prefap, new Vector3(0f, 0f, 0f), Quaternion.identity);
                    var rect = pref.GetComponent<RectTransform>();
                    pref.transform.parent = child.transform;
                    rect.localPosition = new Vector3(0,0,0);
                    rect.localScale = new Vector3(17f,17f,17f);
                    rect.localRotation = Quaternion.Euler(0, 0, 0);
                    pref.transform.GetComponent<SpriteRenderer>().sortingOrder = counter;
                    Debug.Log(child.name);
                }
                counter ++;
            }
    }
}
