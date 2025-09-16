using UnityEngine;

public class HusbandPortalEnable : MonoBehaviour
{
    private BoxCollider husbandEndPortalBoxCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        husbandEndPortalBoxCollider = this.GetComponent<BoxCollider>();
        if (husbandEndPortalBoxCollider.enabled)
        {
            Debug.LogWarning("-- end portal logic in husband scene is active -- deactivate it to play");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (BlueLockHusband.instance.isBlueLockHusbandOpened && GreenLockHusband.instance.isGreenLockHusbandOpened && RedLockHusband.instance.isRedLockHusbandOpened)
        {
            husbandEndPortalBoxCollider.enabled = true;
        }
    }
}
