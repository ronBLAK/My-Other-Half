using UnityEngine;

public class HomeButtonsMPositionManager : MonoBehaviour
{
    public GameObject playButton;

    public GameObject thisButton;
    public GameObject thisButtonNewPosGO;
    public GameObject thisButtonOldPosGO;

    // [SerializeField] private Vector3 newButtonPos;
    // [SerializeField] private Vector3 oldButtonPos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!PlayerPrefs.HasKey("Seed"))
        {
            if (playButton.activeInHierarchy)
            {
                playButton.SetActive(false); // sets the play button to inactive, if it's active
            }

            thisButton.transform.position = thisButtonNewPosGO.transform.position;
        }
        else
        {
            if (!playButton.activeInHierarchy)
            {
                playButton.SetActive(true); // sets the play button to active, if it's inactive
            }

            thisButton.transform.position = thisButtonOldPosGO.transform.position;
        }
    }
}
