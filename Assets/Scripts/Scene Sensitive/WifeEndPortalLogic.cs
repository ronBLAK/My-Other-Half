using UnityEngine;
using UnityEngine.SceneManagement;


public class WifeEndPortalLogic : MonoBehaviour
{
    public static bool hasWifeEnteredPortal;
    
    [SerializeField]
    private GameObject sceneSwitchTimer, timerScript;


    private void Start()
    {
        if (sceneSwitchTimer != null)
        {
            if(HusbandEndPortalLogic.hasHusbandEnteredPortal){
                sceneSwitchTimer.SetActive(false);
                timerScript.SetActive(false);
            } else
            {
                Debug.Log("husband has not yet entered his portal, so scene will keep switching");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("wife entered the trigger");

        hasWifeEnteredPortal = true;
        
        if(!HusbandEndPortalLogic.hasHusbandEnteredPortal)
        {
            SceneManager.LoadScene("HusbandMaze");
        } else
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
