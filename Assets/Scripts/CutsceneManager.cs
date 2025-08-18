using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    // reference to the keys that need to be spawned
    public GameObject blueKey;
    public GameObject GreenKey;
    public GameObject redKey;

    // reference to the positions that the keys need to be spawned at
    public Transform blueKeySpawnPoint;
    public Transform greenKeySpawnPoint;
    public Transform redKeySpawnPoint;

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
                // spawn all three keys at set spawn point
                Instantiate(blueKey, blueKeySpawnPoint.transform.position, Quaternion.identity);
                Instantiate(GreenKey, greenKeySpawnPoint.transform.position, Quaternion.identity);
                Instantiate(redKey, redKeySpawnPoint.transform.position, Quaternion.identity);

                gameObject.SetActive(false); // disables the trigger so the cutscene cannot be played again in the same run
            }
        }
    }
}
