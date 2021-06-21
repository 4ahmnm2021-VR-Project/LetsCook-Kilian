using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OrderMan : MonoBehaviour
{
    [SerializeField] List<string> ingredients = new List<string>(); 

    [SerializeField] List<GameObject> ingredientsOBJ = new List<GameObject>(); 

    public Text DebugText;
    public string DebugMSG;
    public GameObject OrderDisplay;
    
    public List<string> Order0 = new List<string>(); 
    public List<string> Order1 = new List<string>();
    public List<string> Order2 = new List<string>(); 

    public int difficulty;

    private string DebugTxt;

    private float GeneralOrderTime = 50f;

    private float TimeMultiplicator = 1.3f;
    private float Order0TimeLeft;
    private float Order1TimeLeft;
    private float Order2TimeLeft;

    public Slider SliderOrder0;
    public Slider SliderOrder1;
    public Slider SliderOrder2;

    public int CompletedOrders = 0;

    public Countdown CLOCK;
    
    public Material defaultMat;
    public Material errorMat;
    
    void Start()
    {
   
        Order0TimeLeft = GeneralOrderTime;
        Order1TimeLeft = GeneralOrderTime;
        Order2TimeLeft = GeneralOrderTime;
        PlaceOrder("Order0");
        PlaceOrder("Order1");
        PlaceOrder("Order2");
    }


    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            PlaceOrder("Order0");
            IncreseDifficulty();
            CompletedOrders ++;
            OrderDisplay.GetComponent<OrderDisplay>().SetScore(CompletedOrders);
            if(CompletedOrders > 5) {
                  StartCoroutine(RestartGame()); 
            }
        }

        if(CLOCK.timeRemaining < 0) {
        Order0TimeLeft -= Time.deltaTime;
        Order1TimeLeft -= Time.deltaTime;
        Order2TimeLeft -= Time.deltaTime;
        }
        SliderOrder0.value = ValueConverter(Order0TimeLeft, GeneralOrderTime);
        SliderOrder1.value = ValueConverter(Order1TimeLeft, GeneralOrderTime);
        SliderOrder2.value = ValueConverter(Order2TimeLeft, GeneralOrderTime);

        if(Order0TimeLeft < 0) {
            PlaceOrder("Order0");
            OrderExpired();
        }
        if(Order1TimeLeft < 0) {
            PlaceOrder("Order1");
            OrderExpired();
        }
        if(Order2TimeLeft < 0) {
            PlaceOrder("Order2");
            OrderExpired();
        }
        
    }

    private void OrderExpired() {
        CompletedOrders--;
        OrderDisplay.GetComponent<OrderDisplay>().SetScore(CompletedOrders);
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
            Order0TimeLeft = GeneralOrderTime;
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
            Order1TimeLeft = GeneralOrderTime;
            Order1.Clear();
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
            Order2TimeLeft = GeneralOrderTime;
            Order2.Clear();
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
                
                var Order0Complete = CheckOrder(ingredientStack, Order0);
              
                var Order1Complete = CheckOrder(ingredientStack, Order1);
                var Order2Complete = CheckOrder(ingredientStack, Order2);
                
               
            
                if(Order0Complete == true)
                {
                    OrderCompleted(other.gameObject);
                    PlaceOrder("Order0");
                } 
                
                else if(Order1Complete == true) 
                {
                    OrderCompleted(other.gameObject);
                    PlaceOrder("Order1");
                } 
                else if(Order2Complete == true) 
                {
                    OrderCompleted(other.gameObject);
                    PlaceOrder("Order2");
                }
                else {
                    Destroy(other.gameObject);
                    CompletedOrders--;
                    StartCoroutine(ColorFlash());
                }
    


            }
        }

    }


    bool CheckOrder(GameObject ingredientStack, List<string> Order) {
        DebugMSG = "";
        var x = 0;
        var OrderComplete = true;
        // Debug.Log("ingredient count of Order: " + Order0.Count + " | DeliveryCount: " + ingredientStack.transform.childCount);
        if(Order.Count != ingredientStack.transform.childCount) {
            OrderComplete = false;
        } else {
        foreach(Transform child in ingredientStack.transform)
        {
            // Debug.Log("Child: " + child.transform.GetComponent<identifier>().ingredient + " | ingredient: " + Order0[x]);
            CanvasDebug(child.transform.GetComponent<identifier>().ingredient.ToString() + "  | " + Order0[x].ToString());
            if(Order[x] == "patty") {
                if(child.transform.name == "patty") {
                    if(child.transform.GetComponent<cook>().cooked != true) {
                        OrderComplete = false;
                    }
                } else {OrderComplete = false;}
            } else {
                Debug.Log(Order[x] + " | " + child.transform.GetComponent<identifier>().ingredient);
                if(Order[x] != child.transform.GetComponent<identifier>().ingredient) 
                {
                    OrderComplete = false;
                } 
            }
            x++;
            }
        }
        
        return OrderComplete;
    }

    void OrderCompleted(GameObject other) {
        CompletedOrders ++;
        OrderDisplay.GetComponent<OrderDisplay>().SetScore(CompletedOrders);
        Destroy(other.gameObject);
        IncreseDifficulty();
        if(CompletedOrders > 19) {
            StartCoroutine(RestartGame()); 
        }
    }

    void CanvasDebug(string log) {
        DebugMSG = DebugMSG + "\n" + log;
        DebugText.text = DebugMSG;
    }

    public void IncreseDifficulty() {
        if(CompletedOrders == 5) {
            difficulty++;
            GeneralOrderTime = GeneralOrderTime * TimeMultiplicator;
        } 
        if(CompletedOrders == 10) {
            difficulty++;
            GeneralOrderTime = GeneralOrderTime * TimeMultiplicator;
        }
        if(CompletedOrders == 15) {
            difficulty++;
            GeneralOrderTime = GeneralOrderTime * TimeMultiplicator;
        }
    }

    private IEnumerator ColorFlash()
    {
        var rend = this.gameObject.GetComponent<Renderer>();
        rend.material = errorMat;
        yield return new WaitForSeconds(0.08f);
        rend.material = defaultMat;
    }

    public IEnumerator  RestartGame() {
        CLOCK.ShowScore();
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }
}
