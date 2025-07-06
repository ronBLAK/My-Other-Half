using UnityEngine;
using UnityEngine.UI;

public class InstantiateFirstPersonCameraHusband : MonoBehaviour
{
    public static InstantiateFirstPersonCameraHusband instance;

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
        if (PlayerPrefs.HasKey("SavedPosXFirstPersonCameraHusband"))
        {
            savedPositionHusbandFirstPersonCamera = new Vector3(
                PlayerPrefs.GetFloat("SavedPosXFirstPersonCameraHusband"),
                PlayerPrefs.GetFloat("SavedPosYFirstPersonCameraHusband"),
                PlayerPrefs.GetFloat("SavedPosZFirstPersonCameraHusband")
            );

            savedRotationHusbandFirstPersonCamera = new Quaternion(
                PlayerPrefs.GetFloat("SavedRotXFirstPersonCameraHusband"),
                PlayerPrefs.GetFloat("SavedRotYFirstPersonCameraHusband"),
                PlayerPrefs.GetFloat("SavedRotZFirstPersonCameraHusband"),
                PlayerPrefs.GetFloat("SavedRotWFirstPersonCameraHusband")
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
        PlayerPrefs.SetFloat("SavedPosXFirstPersonCameraHusband", savedPositionHusbandFirstPersonCamera.x);
        PlayerPrefs.SetFloat("SavedPosYFirstPersonCameraHusband", savedPositionHusbandFirstPersonCamera.y);
        PlayerPrefs.SetFloat("SavedPosZFirstPersonCameraHusband", savedPositionHusbandFirstPersonCamera.z);

        // save the fpc rotation on 4 axes
        PlayerPrefs.SetFloat("SavedRotXFirstPersonCameraHusband", savedRotationHusbandFirstPersonCamera.x);
        PlayerPrefs.SetFloat("SavedRotYFirstPersonCameraHusband", savedRotationHusbandFirstPersonCamera.y);
        PlayerPrefs.SetFloat("SavedRotZFirstPersonCameraHusband", savedRotationHusbandFirstPersonCamera.z);
        PlayerPrefs.SetFloat("SavedRotWFirstPersonCameraHusband", savedRotationHusbandFirstPersonCamera.w);
        PlayerPrefs.Save();
    }

    public GameObject GetSpawnedFirstPersonCamera()
    {
        return spawnedFirstPersonCamera;
    }
}
