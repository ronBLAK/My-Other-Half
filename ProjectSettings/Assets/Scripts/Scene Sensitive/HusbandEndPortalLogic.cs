using UnityEngine;
using UnityEngine.SceneManagement;

public class HusbandEndPortalLogic : MonoBehaviour
{
    public static bool hasHusbandEnteredPortal; // boolean to track if husband has entered his portal

    [SerializeField]
    private GameObject sceneSwitchTimer, timerScriptGO; // references to the scene switch timer game object and timer script

    private SceneSwitchTimer timerScript; // reference to the timer script

    private void Start()
    {
        timerScript = timerScriptGO.GetComponent<SceneSwitchTimer>();

        // disables the scene switching timer on the husband maze (disabling scene switching mechanic), if the wife has entered the portal (wife finishes level)
        if(sceneSwitchTimer != null)
        {
            if(WifeEndPortalLogic.hasWifeEnteredPortal)
            {
                sceneSwitchTimer.SetActive(false);
                timerScript.enabled = false;
            } else
            {
                Debug.Log("wife has not yet entered her portal, scene will continue to switch");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("husband entered the trigger");

        hasHusbandEnteredPortal = true; // sets the husband portal entered state to true (husband has entered his portal)

        // deletes all saved husband position data
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
        
        // loads the wife scene if it has not yet been completed (wife has not yet entered her portal collider)
        // loads the end scene if the wife has completed her maze
        if(!WifeEndPortalLogic.hasWifeEnteredPortal)
        {
            SceneManager.LoadScene("WifeMaze");
        } else
        {
            Cursor.lockState = CursorLockMode.None;

            SceneManager.LoadScene("EndScene");
        }
    }
}