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
        HusbandEndPortalLogic.hasHusbandEnteredPortal = false;
        WifeEndPortalLogic.hasWifeEnteredPortal = false;
        PlayerPrefs.DeleteKey("TimerValue");
        PlayerPrefs.DeleteKey("Seed");
        SceneManager.LoadScene("HomeScene");
    }
}
