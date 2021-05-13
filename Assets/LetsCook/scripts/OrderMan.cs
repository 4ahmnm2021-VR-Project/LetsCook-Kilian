using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderMan : MonoBehaviour
{
    [SerializeField] List<string> ingredients = new List<string>(); 

    public GameObject OrderDisplay;
    
    List<string> Order0 = new List<string>(); 
    List<string> Order1 = new List<string>();
    List<string> Order2 = new List<string>(); 

    public int difficulty;

    private string DebugTxt;

    public float Order0TimeLeft = 40f;
    public float Order1TimeLeft = 40f;
    public float Order2TimeLeft = 40f;

    public Slider SliderOrder0;
    public Slider SliderOrder1;
    public Slider SliderOrder2;
    
    
    void Start()
    {
        PlaceOrder("Order0");
        PlaceOrder("Order1");
        PlaceOrder("Order2");
        // StartCoroutine(DoCheck());
    }


    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
    
            PlaceOrder("Order0");
        }


        Order0TimeLeft -= Time.deltaTime;
        Order1TimeLeft -= Time.deltaTime;
        Order2TimeLeft -= Time.deltaTime;
        SliderOrder0.value = ValueConverter(Order0TimeLeft, 40f);
        SliderOrder1.value = ValueConverter(Order1TimeLeft, 40f);
        SliderOrder2.value = ValueConverter(Order2TimeLeft, 40f);

        if(Order0TimeLeft < 0) {

        }
        if(Order1TimeLeft < 0) {
            
        }
        if(Order2TimeLeft < 0) {
            
        }
        
    }

    
    public float ValueConverter(float time, float startTime) {
        float a = startTime / 100;
        float b = time / a;
        float result = b / 100;
        return result;
    }

    private void PlaceOrder(string OrderName) {
        if(OrderName == "Order0") 
        {
            Order0.Clear();
            Order0.Add("bun_bottom");
            Order0.Add("patty");
            for(var x = 0; x < difficulty; x++) 
            {
                Order0.Add(ingredients[Random.Range(0, ingredients.Count)]);
            } 
            Order0.Add("bun_top");
            DebugTxt = "";
            foreach( var x in Order0) {
                // Debug.Log( x.ToString());
                DebugTxt = DebugTxt + x.ToString();
                DebugTxt = DebugTxt + "\n";
            }
            // OrderDisplay.GetComponent<UnityEngine.UI.Text>().text = DebugTxt;
            OrderDisplay.GetComponent<OrderDisplay>().DisplayOrder("Order0", Order0);
        }
        if(OrderName == "Order1") 
        {
            Order1.Add("bun_bottom");
            Order1.Add("patty");
            for(var x = 0; x < difficulty; x++) 
            {
                Order1.Add(ingredients[Random.Range(0, ingredients.Count)]);
            } 
            Order1.Add("bun_top");
            OrderDisplay.GetComponent<OrderDisplay>().DisplayOrder("Order1", Order1);
        }
        if(OrderName == "Order2") 
        {
            Order2.Add("bun_bottom");
            Order2.Add("patty");
            for(var x = 0; x < difficulty; x++) 
            {
                Order2.Add(ingredients[Random.Range(0, ingredients.Count)]);
            } 
            Order2.Add("bun_top");
            OrderDisplay.GetComponent<OrderDisplay>().DisplayOrder("Order2", Order2);
        }

    }



    void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.name == "plate") {
            var ingredientStack = other.gameObject.transform.Find("ingredientStack").gameObject;
            if(ingredientStack.transform.childCount > 0) 
            {
                var x = 0;
                var Order0Complete = true;
                var Order1Complete = true;
                var Order2Complete = true;
                Debug.Log("ingredient count of Order: " + Order0.Count + " | DeliveryCount: " + ingredientStack.transform.childCount);
                if(Order0.Count != ingredientStack.transform.childCount) {
                    Order0Complete = false;
                } else {
                    foreach(Transform child in ingredientStack.transform)
                    {
                        Debug.Log("Child: " + child.transform.GetComponent<identifier>().ingredient + " | ingredient: " + Order0[x]);
                        if(Order0[x] != child.transform.GetComponent<identifier>().ingredient) 
                        {
                            Debug.Log("false");
                            Order0Complete = false;
                        } else {
                            Debug.Log("true");
                        }
                        x++;
                    }
                }
                
               
                
                // x = 0;
     
                // foreach(Transform child in ingredientStack.transform)
                // {
                //     if(Order1[x] != child.transform.GetComponent<identifier>().ingredient) 
                //     {
                //         Order1Complete = false;
                //     }
                //     x++;
                // }
                
                // x = 0;
    
                // foreach(Transform child in ingredientStack.transform)
                // {
                //     if(Order2[x] != child.transform.GetComponent<identifier>().ingredient) 
                //     {
                //         Order2Complete = false;
                //     }
                //     x++;
                // }

                if(Order0Complete == true)
                {
                    Debug.Log("Order 0 is Right!");
                } else {
                    Debug.Log("Oder 0 is Wrong!");
                    Destroy(other.gameObject);
                }
                // if(Order1Complete == true)
                // {
                    
                // } else {
                //     Debug.Log("Oder 1 is Wrong!");
                //     Destroy(other.gameObject);
                // }
                // if(Order2Complete == true)
                // {
                    
                // } else {
                //     Debug.Log("Oder 2 is Wrong!");
                //     Destroy(other.gameObject);
                // }



            }
        }

    }
}
        // Order Original

        // if(Order2.Count == 0) 
        // {
        //     Order2.Add("bun_bottom");
        //     Order2.Add("patty");
        //     for(var x = 0; x < difficulty; x++) 
        //     {
        //         Order2.Add(ingredients[Random.Range(0, ingredients.Count)]);
        //     } 
        //     Order2.Add("bun_top");
        // }