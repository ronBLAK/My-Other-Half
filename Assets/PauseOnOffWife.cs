
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOnOffWife : MonoBehaviour
{
    public GameObject inventoryScrollView;

    // Reference to the pause menu GameObject
    public GameObject pauseMenu;

    public static bool gamePaused = false; // Flag to track if the game is currently paused

    public void Start()
    {
        //
    }

    // Update is called once per frame
    public void Update()
    {
        // Check for the space key press to toggle pause state
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gamePaused)
            {
                // Pause the game
                pauseMenu.SetActive(true); // Show the pause menu
                inventoryScrollView.SetActive(true);
                InventoryManagerWife.instance.ListItems();
                Time.timeScale = 0f; // Freeze game time
                gamePaused = true; // set flag to true

                // Make the cursor visible and unlock it
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                // Resume the game
                inventoryScrollView.SetActive(false);
                pauseMenu.SetActive(false); // Hide the pause menu
                Time.timeScale = 1f; // Resume game time
                gamePaused = false;

                // Hide the cursor and lock it
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
