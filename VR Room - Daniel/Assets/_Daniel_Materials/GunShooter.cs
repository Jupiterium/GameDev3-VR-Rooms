using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem; // Needed for reading action state

public class GunShooter : MonoBehaviour
{
    // --- Editor-Configurable Variables ---

    [Header("Bullet/Projectile")]
    public GameObject bulletPrefab;
    public Transform launchPoint;
    public float launchForce = 20f;

    [Header("Input Setup")]
    [Tooltip("Reference to the input action used for 'Activate'.")]
    public InputActionProperty activateAction; 

    // --- Private Variables ---
    private XRGrabInteractable grabInteractable;
    private bool isHeld = false;

    // --- Unity Life Cycle ---

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable == null)
        {
            Debug.LogError("GunShooter requires an XRGrabInteractable component.");
            return;
        }

        // Subscribe to grab events
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);

        // Enable the input action when the script wakes up
        if (activateAction.action != null)
        {
            activateAction.action.Enable();
        }
    }

    void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
            grabInteractable.selectExited.RemoveListener(OnRelease);
        }

        // Disable the input action when the script is destroyed
        if (activateAction.action != null)
        {
            activateAction.action.Disable();
        }
    }

    void Update()
    {
        // Only check for shooting if the gun is currently held AND the action is triggered
        // 'wasPerformedThisFrame' for a single press event
        if (isHeld && activateAction.action.WasPerformedThisFrame())
        {
            // Optional: You could check a threshold if you want a full pull, e.g.,
            // if (activateAction.action.ReadValue<float>() > 0.9f) { ... }

            Shoot();
        }
    }

    // --- Custom Methods ---

    private void OnGrab(SelectEnterEventArgs args)
    {
        isHeld = true;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isHeld = false;
    }

    private void Shoot()
    {
        if (bulletPrefab == null || launchPoint == null)
        {
            Debug.LogError("Bullet Prefab or Launch Point is not set up.");
            return;
        }

        // 1. Instantiate the bullet
        GameObject newBullet = Instantiate(bulletPrefab, launchPoint.position, launchPoint.rotation);

        // 2. Add force to launch the bullet
        Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            // Apply force forward relative to the gun's launch point
            bulletRb.AddForce(launchPoint.forward * launchForce, ForceMode.VelocityChange);
        }

        // TODO: Add haptic feedback

        Destroy(newBullet, 5f);
    }
}