using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
//using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    [Header("Game objects to spawn")]
    // reference to the keys that need to be spawned
    public GameObject blueKey;
    public GameObject GreenKey;
    public GameObject redKey;

    [Header("Spawn point for first set of keys - to be added to inventory")]
    // reference to the positions that the keys need to be spawned at
    public Transform blueKeySpawnPoint;
    public Transform greenKeySpawnPoint;
    public Transform redKeySpawnPoint;


    [Header("Spawn point for second set of keys - to be picked up and moved around the map")]
    // reference to the positions that the second set of keys should spawn
    public Transform blueKeySpawnPointSecond;
    public Transform greenKeySpawnPointSecond;
    public Transform redKeySpawnPointSecond;

    [Header("Instructions panel object references")]
    public GameObject guidancePanel; // reference to the panel that holds all the instructions and back button
    public TextMeshProUGUI guidanceText; // reference to the text attribute added in the panel, that needs to be manipulated

    [Header("Cameras")]
    public GameObject commonCamera;
    public GameObject husbandFirstPersonCameraForGame;

    [Header("Required animator components to swap out the animator controllers on the husband during runtime")]
    public Animator husbandAnimator; // holds the animator component attached to the husband
    public RuntimeAnimatorController inGameHusbandAnimator; // holds the animator that needs to be swapped into the husband animator controller when the cutscene ends
    public Avatar inGameHusbandAnimatorAvatar;

    [Header("Scripts that need to be manipulated for the cutscene to work")]
    // game objects
    public GameObject HusbandGO;

    [Header("Entry message planes to guide the user into the next stage of the help section")]
    public GameObject entryOne; // reference to the camera controls section guide
    public GameObject entryTwo; // reference to the add to inventory controls section guide
    public GameObject entryThree; // reference to the pickup key controls guide
    public GameObject entryFour; // reference to the help end guide

    [Header("Portal")]
    public GameObject suckingPortal;

    [Header("Scripts")]
    private PlayerMovement playerMovement;

    // [Header("Playable Director")]
    // public PlayableDirector director;

    void Awake()
    {
        husbandAnimator = HusbandGO.GetComponent<Animator>();
        playerMovement = HusbandGO.GetComponent<PlayerMovement>();
    }

    void Start()
    {
        Time.timeScale = 1;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.name == "cutscene end trigger")
            {
                Debug.LogWarning("spawning keys");

                // since active camera is common camera for cutscene, when cutscene ends, switch to husband camera tpc and fpc
                husbandFirstPersonCameraForGame.SetActive(true);
                Destroy(commonCamera);

                // swap out the controllers and avatars for the husband to the playable version, when the cutscene ends
                husbandAnimator.runtimeAnimatorController = inGameHusbandAnimator;
                husbandAnimator.avatar = inGameHusbandAnimatorAvatar;

                playerMovement.enabled = true;

                // set up the guidance panel to show the movement controls
                guidancePanel.SetActive(true);
                guidanceText.text = "\n\nUse the WASD or Arrow keys to move the player, Shift to run, and use your mouse or trackpad to look around the map\n\n Move Forward Towards Next Gate";
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;

                entryOne.SetActive(true); // enable entry 1

                Destroy(gameObject); // destroys the trigger so the cutscene cannot be played again in the same run
                Destroy(other.gameObject); // destroys the player tagged object that collided with the trigger - wife
                Destroy(suckingPortal);
            }
            else if (gameObject.name == "camera help trigger")
            {
                // show camera controls
                guidancePanel.SetActive(true);
                guidanceText.text = "\n\n\nPress the E key twice to switch camera view between first person and third person\n\n Try and Move Forward Towards Next Gate";
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;

                entryTwo.SetActive(true); // enable entry 2

                Destroy(gameObject); // destroys the trigger so that part of the scene cannot be played again in a single run of the playable help section
                Destroy(entryOne); // destroy entry 1
            }
            else if (gameObject.name == "add to inventory trigger")
            {
                // show how to pick up keys to inventory
                guidancePanel.SetActive(true);
                guidanceText.text = "\n\n\nPoint the crosshair on the key, and left click to pick up and add to inventory\n\n Try and Move Forward Towards Next Gate";
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;

                entryThree.SetActive(true); // enables entry 3

                // spawn all three keys at set spawn point
                Instantiate(blueKey, blueKeySpawnPoint.transform.position, Quaternion.identity);
                Instantiate(GreenKey, greenKeySpawnPoint.transform.position, Quaternion.identity);
                Instantiate(redKey, redKeySpawnPoint.transform.position, Quaternion.identity);

                Destroy(gameObject); // destroys the trigger so that part of the scene cannot be played again in the same run of the playable help section
                Destroy(entryTwo); // destroy entry 2
            }
            else if (gameObject.name == "pickup key trigger")
            {
                // spawn all three keys at set spawn point
                Instantiate(blueKey, blueKeySpawnPointSecond.transform.position, Quaternion.identity);
                Instantiate(GreenKey, greenKeySpawnPointSecond.transform.position, Quaternion.identity);
                Instantiate(redKey, redKeySpawnPointSecond.transform.position, Quaternion.identity);

                // show key pickup controls
                guidancePanel.SetActive(true);
                guidanceText.text = "Point the crosshair on the key, and right to pick it up to move it around.\n Right click again to drop the key. \n Try and Move Forward Towards Next Gate";
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;

                entryFour.SetActive(true);

                Destroy(gameObject); // destroys the trigger so that part of the scene cannot be played again in the same run of the playable help section
                Destroy(entryThree); // destroy entry 3
            }
            else if (gameObject.name == "help end gate")
            {
                SceneManager.LoadScene("HomeScene"); // load the home scene after ending                
                Destroy(entryFour); // destroy entry 4
            }
        }
    }
}
