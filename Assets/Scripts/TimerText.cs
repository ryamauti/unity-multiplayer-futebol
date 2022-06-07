using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerText : MonoBehaviour
{
    public GameObject GameHub;
    private float gameTime;
    private TMPro.TextMeshProUGUI timer;

    // Start is called before the first frame update
    void Start()
    {        
        timer = GetComponent<TMPro.TextMeshProUGUI>();
        timer.SetText("Ready");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();        
    }

    void UpdateTimer()
    {
        gameTime = GameHub.GetComponent<GameVariables>().gameTime;
        int minutes = (int)gameTime / 60;
        int seconds = (int)gameTime % 60;
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timer.SetText(timeString);
    }
}
