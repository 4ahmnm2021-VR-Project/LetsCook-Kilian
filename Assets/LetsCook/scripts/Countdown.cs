using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    // Start is called before the first frame update
    public float time;
    public float timeRemaining = 10f;
    private Text counterTxt;
    private GameObject CounterText;

    public GameObject OrdersScreen;
    void Start()
    {
        counterTxt = GameObject.Find("CounterTxt").GetComponent<Text>();
        CounterText = GameObject.Find("CounterTxt");
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        time += Time.deltaTime;
        var timeConv = (int)timeRemaining;
        counterTxt.text = timeConv.ToString();
        if(timeRemaining < 0 && OrdersScreen.active == false) {
            OrdersScreen.SetActive(true);
            CounterText.SetActive(false);
        }
    }
}
