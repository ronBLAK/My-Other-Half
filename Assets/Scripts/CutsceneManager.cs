using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.name == "storyline start trigger")
            {
                // write logic to start the part of the cutscene where the wife is taken away from the husband
            }
            else if (gameObject.name == "cutscene end trigger")
            {
                Debug.Log("spawning keys");

                // since active camera is common camera for cutscene, when cutscene ends, switch to husband camera tpc and fpc
                husbandFirstPersonCameraForGame.SetActive(true);
                commonCamera.SetActive(false);

                // spawn all three keys at set spawn point
                Instantiate(blueKey, blueKeySpawnPoint.transform.position, Quaternion.identity);
                Instantiate(GreenKey, greenKeySpawnPoint.transform.position, Quaternion.identity);
                Instantiate(redKey, redKeySpawnPoint.transform.position, Quaternion.identity);

                guidancePanel.SetActive(true);
                guidanceText.text = "\n\nUse the WASD or Arrow keys to move the player, Shift to run, and use your mouse or trackpad to look around the map";
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                Time.timeScale = 0; // stop time - pause the game when the instructions are displayed

                Destroy(gameObject); // destroys the trigger so the cutscene cannot be played again in the same run
            }
            else if (gameObject.name == "camera help trigger")
            {
                // show camera controls
                guidancePanel.SetActive(true);
                guidanceText.text = "\n\n\nPress the E key twice to switch camera view between first person and third person";
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                Time.timeScale = 0; // stop time - pause the game when the instructions are displayed

                Destroy(gameObject); // destroys the trigger so that part of the scene cannot be played again in a single run of the playable help section
            }
            else if (gameObject.name == "add to inventory trigger")
            {
                // show how to pick up keys to inventory
                guidancePanel.SetActive(true);
                guidanceText.text = "\n\n\nPoint the crosshair on the key, and left click to pick up and add to inventory";
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                Time.timeScale = 0; // stop time - pause the game when the instructions are displayed

                Destroy(gameObject); // destroys the trigger so that part of the scene cannot be played again in the same run of the playable help section
            }
            else if (gameObject.name == "pickup key trigger")
            {
                // spawn all three keys at set spawn point
                Instantiate(blueKey, blueKeySpawnPointSecond.transform.position, Quaternion.identity);
                Instantiate(GreenKey, greenKeySpawnPointSecond.transform.position, Quaternion.identity);
                Instantiate(redKey, redKeySpawnPointSecond.transform.position, Quaternion.identity);

                // show key pickup controls
                guidancePanel.SetActive(true);
                guidanceText.text = "Point the crosshair on the key, and right to pick it up to move it around.\n Right click again to drop the key. \n BEWARE: THE KEYS ARE SLIPPERY, AND IF YOU ACCIDENTALY DROP THE KEYS ON THE GROUND, YOU WILL BE TRAPPED IN THE MAZE FOREVER";
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                Time.timeScale = 0; // stop time - pause the game when the instructions are displayed

                Destroy(gameObject); // destroys the trigger so that part of the scene cannot be played again in the same run of the playable help section
            }
        }
    }
}
