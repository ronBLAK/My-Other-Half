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

    public void ResumeHusband()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PauseOnOffHusband.gamePaused = false;
        
        GameObject pauseMenu = GameObject.Find("pause menu");
        pauseMenu.SetActive(false);
    }
    
    public void ResumeWife()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PauseOnOffWife.gamePaused = false;
        
        GameObject pauseMenu = GameObject.Find("pause menu");
        pauseMenu.SetActive(false);
    }

    // restart the game in the same maze seed, but with the postition and rotation of both characters reset
    public void Restart()
    {
        // deletes all the saved data positional and rotational data to restart the game in the same maze, but from the start of the maze
        // husband deletion
        if (PlayerPrefs.HasKey("SavedPosXHusband"))
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
        }
        else
        {
            Debug.Log("husband key does not exist");
        }

        // wife deletion
        if (PlayerPrefs.HasKey("SavedPosXWife"))
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
        }
        else
        {
            Debug.Log("wife key does not exist");
        }

        // key deletetion
        // husband maze keys deletion
        if (PlayerPrefs.HasKey("SavedHusbandBlueKeyPositionX"))
        {
            // blue key
            PlayerPrefs.DeleteKey("SavedHusbandBlueKeyPositionX");
            PlayerPrefs.DeleteKey("SavedHusbandBlueKeyPositionY");
            PlayerPrefs.DeleteKey("SavedHusbandBlueKeyPositionZ");

            PlayerPrefs.DeleteKey("SavedHusbandBlueKeyRotationX");
            PlayerPrefs.DeleteKey("SavedHusbandBlueKeyRotationY");
            PlayerPrefs.DeleteKey("SavedHusbandBlueKeyRotationZ");
            PlayerPrefs.DeleteKey("SavedHusbandBlueKeyRotationW");
            PlayerPrefs.Save();

            // green key
            PlayerPrefs.DeleteKey("SavedHusbandGreenKeyPositionX");
            PlayerPrefs.DeleteKey("SavedHusbandGreenKeyPositionY");
            PlayerPrefs.DeleteKey("SavedHusbandGreenKeyPositionZ");

            PlayerPrefs.DeleteKey("SavedHusbandGreenKeyRotationX");
            PlayerPrefs.DeleteKey("SavedHusbandGreenKeyRotationY");
            PlayerPrefs.DeleteKey("SavedHusbandGreenKeyRotationZ");
            PlayerPrefs.DeleteKey("SavedHusbandGreenKeyRotationW");
            PlayerPrefs.Save();

            // red key
            PlayerPrefs.DeleteKey("SavedHusbandRedKeyPositionX");
            PlayerPrefs.DeleteKey("SavedHusbandRedKeyPositionY");
            PlayerPrefs.DeleteKey("SavedHusbandRedKeyPositionZ");

            PlayerPrefs.DeleteKey("SavedHusbandRedKeyRotationX");
            PlayerPrefs.DeleteKey("SavedHusbandRedKeyRotationY");
            PlayerPrefs.DeleteKey("SavedHusbandRedKeyRotationZ");
            PlayerPrefs.DeleteKey("SavedHusbandRedKeyRotationW");
            PlayerPrefs.Save();
        }

        // wife maze keys deletion

        if (PlayerPrefs.HasKey("SavedWifeBlueKeyPositionX"))
        {
            // blue key
            PlayerPrefs.DeleteKey("SavedWifeBlueKeyPositionX");
            PlayerPrefs.DeleteKey("SavedWifeBlueKeyPositionY");
            PlayerPrefs.DeleteKey("SavedWifeBlueKeyPositionZ");

            PlayerPrefs.DeleteKey("SavedWifeBlueKeyRotationX");
            PlayerPrefs.DeleteKey("SavedWifeBlueKeyRotationY");
            PlayerPrefs.DeleteKey("SavedWifeBlueKeyRotationZ");
            PlayerPrefs.DeleteKey("SavedWifeBlueKeyRotationW");
            PlayerPrefs.Save();

            // green key
            PlayerPrefs.DeleteKey("SavedWifeGreenKeyPositionX");
            PlayerPrefs.DeleteKey("SavedWifeGreenKeyPositionY");
            PlayerPrefs.DeleteKey("SavedWifeGreenKeyPositionZ");

            PlayerPrefs.DeleteKey("SavedWifeGreenKeyRotationX");
            PlayerPrefs.DeleteKey("SavedWifeGreenKeyRotationY");
            PlayerPrefs.DeleteKey("SavedWifeGreenKeyRotationZ");
            PlayerPrefs.DeleteKey("SavedWifeGreenKeyRotationW");
            PlayerPrefs.Save();

            // red key
            PlayerPrefs.DeleteKey("SavedWifeRedKeyPositionX");
            PlayerPrefs.DeleteKey("SavedWifeRedKeyPositionY");
            PlayerPrefs.DeleteKey("SavedWifeRedKeyPositionZ");

            PlayerPrefs.DeleteKey("SavedWifeRedKeyRotationX");
            PlayerPrefs.DeleteKey("SavedWifeRedKeyRotationY");
            PlayerPrefs.DeleteKey("SavedWifeRedKeyRotationZ");
            PlayerPrefs.DeleteKey("SavedWifeRedKeyRotationW");
            PlayerPrefs.Save();
        }

        // husband first person camera keys deletion
        if (PlayerPrefs.HasKey("SavedPosXFirstPersonCameraHusband"))
        {
            // position
            PlayerPrefs.DeleteKey("SavedPosXFirstPersonCameraHusband");
            PlayerPrefs.DeleteKey("SavedPosYFirstPersonCameraHusband");
            PlayerPrefs.DeleteKey("SavedPosZFirstPersonCameraHusband");

            // rotation
            PlayerPrefs.DeleteKey("SavedRotXFirstPersonCameraHusband");
            PlayerPrefs.DeleteKey("SavedRotYFirstPersonCameraHusband");
            PlayerPrefs.DeleteKey("SavedRotZFirstPersonCameraHusband");
            PlayerPrefs.DeleteKey("SavedRotWFirstPersonCameraHusband");
            PlayerPrefs.Save();
        }

        // wife first person camera keys deletion
        if (PlayerPrefs.HasKey("SavedPosXFirstPersonCameraWife"))
        {
            // position
            PlayerPrefs.DeleteKey("SavedPosXFirstPersonCameraWife");
            PlayerPrefs.DeleteKey("SavedPosYFirstPersonCameraWife");
            PlayerPrefs.DeleteKey("SavedPosZFirstPersonCameraWife");

            // rotation
            PlayerPrefs.DeleteKey("SavedRotXFirstPersonCameraWife");
            PlayerPrefs.DeleteKey("SavedRotYFirstPersonCameraWife");
            PlayerPrefs.DeleteKey("SavedRotZFirstPersonCameraWife");
            PlayerPrefs.DeleteKey("SavedRotWFirstPersonCameraWife");
            PlayerPrefs.Save();
        }

        // delete husband inventory save data
        if (PlayerPrefs.HasKey("SavedInventoryHusband"))
        {
            PlayerPrefs.DeleteKey("SavedInventoryHusband");
            PlayerPrefs.Save();
        }

        // delete wife inventory save data
        if (PlayerPrefs.HasKey("SavedInventoryWife"))
        {
            PlayerPrefs.DeleteKey("SavedInventoryWife");
            PlayerPrefs.Save();
        }

        // timer value deletion
        if (PlayerPrefs.HasKey("TimerValue"))
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
        
        // key deletetion
        // husband maze keys deletion
        if(PlayerPrefs.HasKey("SavedHusbandBlueKeyPositionX"))
        {
            // blue key
            PlayerPrefs.DeleteKey("SavedHusbandBlueKeyPositionX");
            PlayerPrefs.DeleteKey("SavedHusbandBlueKeyPositionY");
            PlayerPrefs.DeleteKey("SavedHusbandBlueKeyPositionZ");

            PlayerPrefs.DeleteKey("SavedHusbandBlueKeyRotationX");
            PlayerPrefs.DeleteKey("SavedHusbandBlueKeyRotationY");
            PlayerPrefs.DeleteKey("SavedHusbandBlueKeyRotationZ");
            PlayerPrefs.DeleteKey("SavedHusbandBlueKeyRotationW");
            PlayerPrefs.Save();

            // green key
            PlayerPrefs.DeleteKey("SavedHusbandGreenKeyPositionX");
            PlayerPrefs.DeleteKey("SavedHusbandGreenKeyPositionY");
            PlayerPrefs.DeleteKey("SavedHusbandGreenKeyPositionZ");

            PlayerPrefs.DeleteKey("SavedHusbandGreenKeyRotationX");
            PlayerPrefs.DeleteKey("SavedHusbandGreenKeyRotationY");
            PlayerPrefs.DeleteKey("SavedHusbandGreenKeyRotationZ");
            PlayerPrefs.DeleteKey("SavedHusbandGreenKeyRotationW");
            PlayerPrefs.Save();

            // red key
            PlayerPrefs.DeleteKey("SavedHusbandRedKeyPositionX");
            PlayerPrefs.DeleteKey("SavedHusbandRedKeyPositionY");
            PlayerPrefs.DeleteKey("SavedHusbandRedKeyPositionZ");

            PlayerPrefs.DeleteKey("SavedHusbandRedKeyRotationX");
            PlayerPrefs.DeleteKey("SavedHusbandRedKeyRotationY");
            PlayerPrefs.DeleteKey("SavedHusbandRedKeyRotationZ");
            PlayerPrefs.DeleteKey("SavedHusbandRedKeyRotationW");
            PlayerPrefs.Save();
        }

        // wife maze keys deletion
        
        if(PlayerPrefs.HasKey("SavedWifeBlueKeyPositionX"))
        {
            // blue key
            PlayerPrefs.DeleteKey("SavedWifeBlueKeyPositionX");
            PlayerPrefs.DeleteKey("SavedWifeBlueKeyPositionY");
            PlayerPrefs.DeleteKey("SavedWifeBlueKeyPositionZ");

            PlayerPrefs.DeleteKey("SavedWifeBlueKeyRotationX");
            PlayerPrefs.DeleteKey("SavedWifeBlueKeyRotationY");
            PlayerPrefs.DeleteKey("SavedWifeBlueKeyRotationZ");
            PlayerPrefs.DeleteKey("SavedWifeBlueKeyRotationW");
            PlayerPrefs.Save();

            // green key
            PlayerPrefs.DeleteKey("SavedWifeGreenKeyPositionX");
            PlayerPrefs.DeleteKey("SavedWifeGreenKeyPositionY");
            PlayerPrefs.DeleteKey("SavedWifeGreenKeyPositionZ");

            PlayerPrefs.DeleteKey("SavedWifeGreenKeyRotationX");
            PlayerPrefs.DeleteKey("SavedWifeGreenKeyRotationY");
            PlayerPrefs.DeleteKey("SavedWifeGreenKeyRotationZ");
            PlayerPrefs.DeleteKey("SavedWifeGreenKeyRotationW");
            PlayerPrefs.Save();

            // red key
            PlayerPrefs.DeleteKey("SavedWifeRedKeyPositionX");
            PlayerPrefs.DeleteKey("SavedWifeRedKeyPositionY");
            PlayerPrefs.DeleteKey("SavedWifeRedKeyPositionZ");

            PlayerPrefs.DeleteKey("SavedWifeRedKeyRotationX");
            PlayerPrefs.DeleteKey("SavedWifeRedKeyRotationY");
            PlayerPrefs.DeleteKey("SavedWifeRedKeyRotationZ");
            PlayerPrefs.DeleteKey("SavedWifeRedKeyRotationW");
            PlayerPrefs.Save();
        }

        // husband first person camera keys deletion
        if (PlayerPrefs.HasKey("SavedPosXFirstPersonCameraHusband"))
        {
            // position
            PlayerPrefs.DeleteKey("SavedPosXFirstPersonCameraHusband");
            PlayerPrefs.DeleteKey("SavedPosYFirstPersonCameraHusband");
            PlayerPrefs.DeleteKey("SavedPosZFirstPersonCameraHusband");

            // rotation
            PlayerPrefs.DeleteKey("SavedRotXFirstPersonCameraHusband");
            PlayerPrefs.DeleteKey("SavedRotYFirstPersonCameraHusband");
            PlayerPrefs.DeleteKey("SavedRotZFirstPersonCameraHusband");
            PlayerPrefs.DeleteKey("SavedRotWFirstPersonCameraHusband");
            PlayerPrefs.Save();
        }

        // wife first person camera keys deletion
        if (PlayerPrefs.HasKey("SavedPosXFirstPersonCameraWife"))
        {
            // position
            PlayerPrefs.DeleteKey("SavedPosXFirstPersonCameraWife");
            PlayerPrefs.DeleteKey("SavedPosYFirstPersonCameraWife");
            PlayerPrefs.DeleteKey("SavedPosZFirstPersonCameraWife");

            // rotation
            PlayerPrefs.DeleteKey("SavedRotXFirstPersonCameraWife");
            PlayerPrefs.DeleteKey("SavedRotYFirstPersonCameraWife");
            PlayerPrefs.DeleteKey("SavedRotZFirstPersonCameraWife");
            PlayerPrefs.DeleteKey("SavedRotWFirstPersonCameraWife");
            PlayerPrefs.Save();
        }

        // husband inventory save data deletion
        if (PlayerPrefs.HasKey("SavedInventoryHusband"))
        {
            PlayerPrefs.DeleteKey("SavedInventoryHusband");
            PlayerPrefs.Save();
        }

        // wife inventory save data deletion
        if (PlayerPrefs.HasKey("SavedInventoryWife"))
        {
            PlayerPrefs.DeleteKey("SavedInventoryWife");
            PlayerPrefs.Save();
        }

        // seed deletion
        if (PlayerPrefs.HasKey("Seed"))
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
