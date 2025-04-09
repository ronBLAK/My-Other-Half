using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("HusbandMaze");
    }

    public void Home()
    {
        HusbandEndPortalLogic.hasHusbandEnteredPortal = false;
        WifeEndPortalLogic.hasWifeEnteredPortal = false;

        // deletes the global saved data (like the timer value and seed)
        PlayerPrefs.DeleteKey("TimerValue");
        PlayerPrefs.DeleteKey("Seed");
        PlayerPrefs.Save();

        SceneManager.LoadScene("HomeScene");
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PauseOnOff.gamePaused = false;
        
        GameObject pauseMenu = GameObject.Find("pause menu");
        pauseMenu.SetActive(false);
    }

    // restart the game in the same maze seed, but with the postition and rotation of both characters reset
    public void Restart()
    {
        // deletes all the saved data positional and rotational data to restart the game in the same maze, but from the start of the maze
        // husband deletion
        if(PlayerPrefs.HasKey("SavedPosXHusband"))
        {
            Debug.Log("key does exist and is about to be deleted");

            PlayerPrefs.DeleteKey("SavedPosXHusband");
            PlayerPrefs.DeleteKey("SavedPosYHusband");
            PlayerPrefs.DeleteKey("SavedPosZHusband");

            // deletes all saved husband rotation data
            PlayerPrefs.DeleteKey("SavedRotXHusband");
            PlayerPrefs.DeleteKey("SavedRotYHusband");
            PlayerPrefs.DeleteKey("SavedRotZHusband");
            PlayerPrefs.DeleteKey("SavedRotWHusband");

            PlayerPrefs.Save();
            Debug.Log("husband keys deleted successfully");
        } else
        {
            Debug.Log("husband key does not exist");
        }

        // wife deletion
        if(PlayerPrefs.HasKey("SavedPosXWife"))
        {
            Debug.Log("key does exist and is about to be deleted");

            // deletes all saved wife position data
            PlayerPrefs.DeleteKey("SavedPosXWife");
            PlayerPrefs.DeleteKey("SavedPosYWife");
            PlayerPrefs.DeleteKey("SavedPosZWife");

            // deletes all saved wife rotation data
            PlayerPrefs.DeleteKey("SavedRotXWife");
            PlayerPrefs.DeleteKey("SavedRotYWife");
            PlayerPrefs.DeleteKey("SavedRotZWife");
            PlayerPrefs.DeleteKey("SavedRotWWife");

            PlayerPrefs.Save();
            Debug.Log("wife keys deleted successfully");
        } else
        {
            Debug.Log("wife key does not exist");
        }

        // key deletetion
        if(PlayerPrefs.HasKey("SavedBlueKeyPositionX"))
        {
            // blue key
            PlayerPrefs.DeleteKey("SavedBlueKeyPositionX");
            PlayerPrefs.DeleteKey("SavedBlueKeyPositionY");
            PlayerPrefs.DeleteKey("SavedBlueKeyPositionZ");

            PlayerPrefs.DeleteKey("SavedBlueKeyRotationX");
            PlayerPrefs.DeleteKey("SavedBlueKeyRotationY");
            PlayerPrefs.DeleteKey("SavedBlueKeyRotationZ");
            PlayerPrefs.DeleteKey("SavedBlueKeyRotationW");
            PlayerPrefs.Save();

            // green key
            PlayerPrefs.DeleteKey("SavedGreenKeyPositionX");
            PlayerPrefs.DeleteKey("SavedGreenKeyPositionY");
            PlayerPrefs.DeleteKey("SavedGreenKeyPositionZ");

            PlayerPrefs.DeleteKey("SavedGreenKeyRotationX");
            PlayerPrefs.DeleteKey("SavedGreenKeyRotationY");
            PlayerPrefs.DeleteKey("SavedGreenKeyRotationZ");
            PlayerPrefs.DeleteKey("SavedGreenKeyRotationW");
            PlayerPrefs.Save();

            // red key
            PlayerPrefs.DeleteKey("SavedRedKeyPositionX");
            PlayerPrefs.DeleteKey("SavedRedKeyPositionY");
            PlayerPrefs.DeleteKey("SavedRedKeyPositionZ");

            PlayerPrefs.DeleteKey("SavedRedKeyRotationX");
            PlayerPrefs.DeleteKey("SavedRedKeyRotationY");
            PlayerPrefs.DeleteKey("SavedRedKeyRotationZ");
            PlayerPrefs.DeleteKey("SavedRedKeyRotationW");
            PlayerPrefs.Save();
        }

        // timer value deletion
        if(PlayerPrefs.HasKey("TimerValue"))
        {
            PlayerPrefs.DeleteKey("TimerValue");
            PlayerPrefs.Save();
        }

        SceneManager.LoadScene("HusbandMaze");
        Time.timeScale = 1;
    }

    public void Quit()
    {
        // activates the popup for whether to save and quit or quit without saving
        Transform quitPopupParent = GameObject.Find("pause menu").transform;
        Transform quitPopup = quitPopupParent.Find("quit popup");

        quitPopup.gameObject.SetActive(true);
    }

    public void SaveAndQuit()
    {
        // saves and loads the home scene
        SceneManager.LoadScene("HomeScene");
    }

    public void QuitWithoutSaving()
    {
        // quits the game without saving
        // husband deletion
        if(PlayerPrefs.HasKey("SavedPosXHusband"))
        {
            Debug.Log("key does exist and is about to be deleted");

            PlayerPrefs.DeleteKey("SavedPosXHusband");
            PlayerPrefs.DeleteKey("SavedPosYHusband");
            PlayerPrefs.DeleteKey("SavedPosZHusband");

            // deletes all saved husband rotation data
            PlayerPrefs.DeleteKey("SavedRotXHusband");
            PlayerPrefs.DeleteKey("SavedRotYHusband");
            PlayerPrefs.DeleteKey("SavedRotZHusband");
            PlayerPrefs.DeleteKey("SavedRotWHusband");

            PlayerPrefs.Save();
            Debug.Log("keys deleted successfully");
        } else
        {
            Debug.Log("key does not exist");
        }

        // wife deletion
        if(PlayerPrefs.HasKey("SavedPosXWife"))
        {
            Debug.Log("key does exist and is about to be deleted");

            // deletes all saved wife position data
            PlayerPrefs.DeleteKey("SavedPosXWife");
            PlayerPrefs.DeleteKey("SavedPosYWife");
            PlayerPrefs.DeleteKey("SavedPosZWife");

            // deletes all saved wife rotation data
            PlayerPrefs.DeleteKey("SavedRotXWife");
            PlayerPrefs.DeleteKey("SavedRotYWife");
            PlayerPrefs.DeleteKey("SavedRotZWife");
            PlayerPrefs.DeleteKey("SavedRotWWife");

            PlayerPrefs.Save();
            Debug.Log("keys deleted successfully");
        } else
        {
            Debug.Log("key does not exist");
        }

        // seed deletion
        if(PlayerPrefs.HasKey("Seed"))
        {
            PlayerPrefs.DeleteKey("Seed");
            PlayerPrefs.Save();
        }

        // forwards timer deletion
        if(PlayerPrefs.HasKey("TimerValue"))
        {
            PlayerPrefs.DeleteKey("TimerValue");
            PlayerPrefs.Save();
        }

        // load the home scene
        SceneManager.LoadScene("HomeScene");
    }

    public void CancelQuit()
    {
        // deactivates the quit popup menu
        GameObject quitPopup = GameObject.Find("quit popup");
        quitPopup.SetActive(false);
    }
}
