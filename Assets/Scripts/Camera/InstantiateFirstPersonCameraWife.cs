using UnityEngine;
using UnityEngine.UI;

public class InstantiateFirstPersonCameraWife : MonoBehaviour
{
    public static InstantiateFirstPersonCameraWife instance;

    // prefabs of cameras to spawn
    public GameObject firstPersonCamera;

    // spawned instances of above referenced prefabs are stored here
    private GameObject spawnedFirstPersonCamera;

    public GameObject firstPersonCameraSpawnPoint; // The spawn point for the first person camera

    // the position for the third person camera will be calculated using the first person camera position.

    // variables regarding saving and deletion of first person cam save pos and rot
    private Vector3 savedPositionHusbandFirstPersonCamera;
    private Quaternion savedRotationHusbandFirstPersonCamera;

    // holds the restart button
    public Button restartButton;
    private bool isRestartButtonPressed = false;

    // holds don't save and quit button
    public Button dontSaveQuitButton;
    private bool isDontSaveQuitButtonPressed = false;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        if (PlayerPrefs.HasKey("SavedPosXFirstPersonCameraWife"))
        {
            savedPositionHusbandFirstPersonCamera = new Vector3(
                PlayerPrefs.GetFloat("SavedPosXFirstPersonCameraWife"),
                PlayerPrefs.GetFloat("SavedPosYFirstPersonCameraWife"),
                PlayerPrefs.GetFloat("SavedPosZFirstPersonCameraWife")
            );

            savedRotationHusbandFirstPersonCamera = new Quaternion(
                PlayerPrefs.GetFloat("SavedRotXFirstPersonCameraWife"),
                PlayerPrefs.GetFloat("SavedRotYFirstPersonCameraWife"),
                PlayerPrefs.GetFloat("SavedRotZFirstPersonCameraWife"),
                PlayerPrefs.GetFloat("SavedRotWFirstPersonCameraWife")
            );
        }
        else
        {
            savedPositionHusbandFirstPersonCamera = firstPersonCameraSpawnPoint.transform.position;
            savedRotationHusbandFirstPersonCamera = Quaternion.identity;
        }

        spawnedFirstPersonCamera = Instantiate(firstPersonCamera, savedPositionHusbandFirstPersonCamera, savedRotationHusbandFirstPersonCamera);

        // add a listener for for the restart and dontSaveQuitButton button
        restartButton.onClick.AddListener(() => isRestartButtonPressed = true);
        dontSaveQuitButton.onClick.AddListener(() => isDontSaveQuitButtonPressed = true);
    }

    public void Update()
    {
        if (HusbandEndPortalLogic.hasHusbandEnteredPortal || isRestartButtonPressed || isDontSaveQuitButtonPressed)
        {
            return;
        }

        savedPositionHusbandFirstPersonCamera = spawnedFirstPersonCamera.transform.position;
        savedRotationHusbandFirstPersonCamera = spawnedFirstPersonCamera.transform.rotation;

        // save the fpc position on 3 axes
        PlayerPrefs.SetFloat("SavedPosXFirstPersonCameraWife", savedPositionHusbandFirstPersonCamera.x);
        PlayerPrefs.SetFloat("SavedPosYFirstPersonCameraWife", savedPositionHusbandFirstPersonCamera.y);
        PlayerPrefs.SetFloat("SavedPosZFirstPersonCameraWife", savedPositionHusbandFirstPersonCamera.z);

        // save the fpc rotation on 4 axes
        PlayerPrefs.SetFloat("SavedRotXFirstPersonCameraWife", savedRotationHusbandFirstPersonCamera.x);
        PlayerPrefs.SetFloat("SavedRotYFirstPersonCameraWife", savedRotationHusbandFirstPersonCamera.y);
        PlayerPrefs.SetFloat("SavedRotZFirstPersonCameraWife", savedRotationHusbandFirstPersonCamera.z);
        PlayerPrefs.SetFloat("SavedRotWFirstPersonCameraWife", savedRotationHusbandFirstPersonCamera.w);
        PlayerPrefs.Save();
    }

    public GameObject GetSpawnedFirstPersonCamera()
    {
        return spawnedFirstPersonCamera;
    }
}
