using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    // Start is called before the first frame update
    public float time;
    public float trueTime;

    private int pretime = 15;
    public float timeRemaining;
    private Text counterTxt;

    public Text scoreMin;
    public Text scoreSec;
    public Text scoreZent;
    private GameObject CounterText;

    public GameObject OrdersScreen;

    public GameObject ScoreText;

    public bool gameStarted = false;

    public int trueMinutes;
    public int trueSeconds;

    public double trueZehntel; 

    public Text Minutes;
    public Text Seconds;

    public Text Zehntel;

    public bool IntroDone = false;
    void Start()
    {
        timeRemaining = pretime;
        counterTxt = GameObject.Find("CounterTxt").GetComponent<Text>();
        CounterText = GameObject.Find("CounterTxt");
    }

    // Update is called once per frame
    void Update()
    {
        if(IntroDone) {
            timeRemaining -= Time.deltaTime;
            time += Time.deltaTime;
            trueTime = time - pretime;
            var timeConv = (int)timeRemaining;
            counterTxt.text = timeConv.ToString();
            if(timeRemaining < 0 && gameStarted == false) {
                OrdersScreen.SetActive(true);
                CounterText.SetActive(false);
                gameStarted = true;
            }

            if(trueTime > 0) {
                trueSeconds = (int)trueTime;
                trueZehntel = trueTime - (int)trueTime;
                trueZehntel = trueZehntel * 100;
                if(trueSeconds > 60) {
                    trueMinutes = Mathf.RoundToInt(trueSeconds / 60);
                    trueSeconds = trueSeconds - trueMinutes * 60;
                    var outputMinutes = trueMinutes.ToString("00");
                    Minutes.text = outputMinutes;
                }
                var outputSeconds = trueSeconds.ToString("00");
                Seconds.text = outputSeconds;
                var outputZehntel = trueZehntel.ToString("00");
                Zehntel.text = outputZehntel;
            }
        }
    }

    public void ShowScore() {
        Debug.Log(trueTime);
        ScoreText.SetActive(true);
        OrdersScreen.SetActive(false);
            trueSeconds = (int)trueTime;
            trueZehntel = trueTime - (int)trueTime;
            trueZehntel = trueZehntel * 100;
            if(trueSeconds > 60) {
                trueMinutes = Mathf.RoundToInt(trueSeconds / 60);
                trueSeconds = trueSeconds - trueMinutes * 60;
                var outputMinutes = trueMinutes.ToString("00");
                scoreMin.text = outputMinutes;
            }
            var outputSeconds = trueSeconds.ToString("00");
            scoreSec.text = outputSeconds;
            var outputZehntel = trueZehntel.ToString("00");
            scoreZent.text = outputZehntel;
    }
}
