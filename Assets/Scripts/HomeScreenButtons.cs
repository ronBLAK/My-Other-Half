using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenButtons : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("HusbandMaze");
    }

    public void Home()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
