using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private float timeRemainingForScoreCalculation; // tracks the time remaining, but from a different variable to that from the total time.cs script
    private float finalPlayerScore; // stores the calculated player score (final)
    private float score;

    [SerializeField]
    private TextMeshProUGUI scoreText; // reference to the score text in the end scene

    void Start()
    {
        // get the time remaining value from the TotalTime.cs script
        timeRemainingForScoreCalculation = TotalTime.timeRemaining;

        // calculate the score
        score = CalculateScore();

        // sets the score text to the calculated score
        scoreText.text = "score: " + score.ToString();
    }

    // method to carry out calculation of player score based on the time remaining
    public float CalculateScore()
    {
        // creates a temporary variable to hold the score (to check inside the if checks), and floors the calculated score to the nearest whole number
        float calculatedPlayerScore = Mathf.FloorToInt(500000 / (1 + timeRemainingForScoreCalculation));

        if(calculatedPlayerScore < 100)
        {
            finalPlayerScore = 100;   
        } else
        {
            finalPlayerScore = calculatedPlayerScore;
        }
        return finalPlayerScore;
    }
}
