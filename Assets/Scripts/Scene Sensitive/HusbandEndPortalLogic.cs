using UnityEngine;
using UnityEngine.SceneManagement;

public class HusbandEndPortalLogic : MonoBehaviour
{
    public static bool hasHusbandEnteredPortal;

    [SerializeField]
    private GameObject sceneSwitchTimer, timerScript;

    private void Start()
    {
        if(sceneSwitchTimer != null)
        {
            if(WifeEndPortalLogic.hasWifeEnteredPortal)
            {
                sceneSwitchTimer.SetActive(false);
                timerScript.SetActive(false);
            } else
            {
                Debug.Log("wife has not yet entered her portal, scene will continue to switch");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("husband entered the trigger");

        hasHusbandEnteredPortal = true;
        
        if(!WifeEndPortalLogic.hasWifeEnteredPortal)
        {
            SceneManager.LoadScene("WifeMaze");
        } else
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}


// change logic to check if the husband and wife has entered their respective colliders to activate end scene (using booleans to track their entry)