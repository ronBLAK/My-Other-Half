using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalTime : MonoBehaviour
{
    public bool timerOn;
    public float timeRemaining;
    public TextMeshProUGUI totalTimerText;

    void Start()
    {
        if(PlayerPrefs.HasKey("TimerValue"))
        {
            timeRemaining = PlayerPrefs.GetFloat("TimerValue");
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

            UpdateTimer(timeRemaining);
        } else
        {
            timerOn = false;
        }
    }

    private void UpdateTimer(float timer)
    {
        timer += 1;

        // sets the minutes and seconds of the clock
        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);

        totalTimerText.text = string.Format("{00} : {1:00}", minutes, seconds);
    }
}
