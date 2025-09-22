using UnityEngine;

public class WifePortalEnable : MonoBehaviour
{
    private BoxCollider wifeEndPortalBoxCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wifeEndPortalBoxCollider = this.GetComponent<BoxCollider>();
        if (wifeEndPortalBoxCollider.enabled)
        {
            Debug.LogWarning("-- end portal logic in wife scene is active -- deactivate it to play");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (BlueLockWife.instance.isBlueLockWifeOpened && GreenLockWife.instance.isGreenLockWifeOpened && RedLockWife.instance.isRedLockWifeOpened)
        {
            wifeEndPortalBoxCollider.enabled = true;
        }
    }
}
