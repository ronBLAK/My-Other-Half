using UnityEngine;

public class DoNotDestroyOnLoad : MonoBehaviour
{
    [SerializeField]
    private GameObject totalTimer;

    private void Awake()
    {
        DontDestroyOnLoad(totalTimer);
    }
}
