using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TotalTime : MonoBehaviour
{
    public bool timerOn; // boolean to track whether the forwards timer is turned on
    public static float timeRemaining; // float var to track the time remaining (in seconds)
    public TextMeshProUGUI totalTimerText; // reference to the total timer text in the scene

    // referecnce to the restart button
    public Button restartButton;
    private bool isRestartButtonPressed = false;

    // holds don't save and quit button
    public Button dontSaveQuitButton;
    private bool isDontSaveQuitButtonPressed = false;

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

        restartButton.onClick.AddListener(() => isRestartButtonPressed = true);
        dontSaveQuitButton.onClick.AddListener(() => isDontSaveQuitButtonPressed = true);
    }

    void Update()
    {
        if(timeRemaining >= 0 && timerOn)
        {
            timeRemaining += Time.deltaTime;

            // set player pref value for time
            if(isRestartButtonPressed || isDontSaveQuitButtonPressed)
            {
                return;
            }

            // if the restart button is not pressed, the retain the timer value
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
