using UnityEngine;
using TMPro;

public class TotalTime : MonoBehaviour
{
    public bool timerOn; // boolean to track whether the forwards timer is turned on
    public static float timeRemaining; // float var to track the time remaining (in seconds)
    public TextMeshProUGUI totalTimerText; // reference to the total timer text in the scene

    void Start()
    {
        if(PlayerPrefs.HasKey("TimerValue"))
        {
            timeRemaining = PlayerPrefs.GetFloat("TimerValue");
            UpdateTimer(timeRemaining);
        } else
        {
            timeRemaining = 0;
        }
    }

    void Update()
    {
        if(timeRemaining >= 0 && timerOn)
        {
            timeRemaining += Time.deltaTime;

            // set player pref value for time
            PlayerPrefs.SetFloat("TimerValue", timeRemaining);
            PlayerPrefs.Save();

            UpdateTimer(timeRemaining);
        } else
        {
            timerOn = false;
        }
    }

    public void UpdateTimer(float timer)
    {
        timer += 1;

        // sets the minutes and seconds of the clock
        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);

        totalTimerText.text = string.Format("{00} : {1:00}", minutes, seconds);
    }
}
