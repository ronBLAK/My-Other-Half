using UnityEngine;
using UnityEngine.SceneManagement;


public class WifeEndPortalLogic : MonoBehaviour
{
    public static bool hasWifeEnteredPortal; // boolean to track if wife has entered portal
    
    [SerializeField]
    private GameObject sceneSwitchTimer, timerScriptGO; // references to scene switch timer and timer script

    private SceneSwitchTimer timerScript; // reference to timer script
    private void Start()
    {
        timerScript = timerScriptGO.GetComponent<SceneSwitchTimer>();

        // disables the scene switching timer on the wife maze (disabling scene switching mechanic), if the husband has entered the portal (husband finishes level)
        if (sceneSwitchTimer != null)
        {
            if(HusbandEndPortalLogic.hasHusbandEnteredPortal){
                sceneSwitchTimer.SetActive(false);
                timerScript.enabled = false;
            } else
            {
                Debug.Log("husband has not yet entered his portal, so scene will keep switching");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("wife entered the trigger");

        hasWifeEnteredPortal = true; // sets the wife portal entered state to true (wife has entered the collider of the portal)

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
        
        // loads the husband scene if it has not yet been completed (husband has not yet entered his portal)
        // loads the end scene if husband maze has been completed
        if(!HusbandEndPortalLogic.hasHusbandEnteredPortal)
        {
            SceneManager.LoadScene("HusbandMaze");
        } else
        {
            Cursor.lockState = CursorLockMode.None;

            SceneManager.LoadScene("EndScene");
        }
    }
}
