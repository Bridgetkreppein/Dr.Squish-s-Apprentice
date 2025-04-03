using UnityEngine;

public class ChargedBallProjectile : MonoBehaviour, IProjectileBehavior
{
    [Header("Super Charge Mode Settings")]
    [SerializeField] private Material chargeAmmoMaterial;  // Material for charge ammo
    [SerializeField] private AudioClip chargeSFX;          // Sound effect for charge ammo
    [SerializeField] private AudioSource audioSource;      // AudioSource to play sound effects
    [SerializeField] private GameObject chargeButton;      // Reference to the ChargeButton object

    private bool isSuperChargeActive = false;              // Flag to check if supercharge mode is active

    private void Start()
    {
        // Check if AudioSource is assigned
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    // Call this method to activate supercharge mode when charge ammo is collected
    public void ActivateSuperCharge()
    {
        if (!isSuperChargeActive)
        {
            isSuperChargeActive = true;
            ChangeProjectileAppearance();
            Debug.Log("Super Charge mode activated.");
        }
    }

    // Change the appearance and sound of the projectile when in supercharge mode
    private void ChangeProjectileAppearance()
    {
        // Change the material to the charge ammo material
        if (chargeAmmoMaterial != null)
        {
            GetComponent<Renderer>().material = chargeAmmoMaterial;
            Debug.Log("Projectile material changed to charge ammo.");
        }

        // Play the charge sound effect
        if (chargeSFX != null && audioSource != null)
        {
            audioSource.PlayOneShot(chargeSFX);
            Debug.Log("Charge SFX played.");
        }
    }

    // Handle ball-specific behavior
    public void OnCollision(Collision collision)
    {
        Debug.Log("Charged Ball projectile collided!");

        // Check if collided with a ChargeButton and if supercharge mode is active
        if (isSuperChargeActive && collision.gameObject.CompareTag("ChargeButton"))
        {
            // Activate the ChargeButton functionality (e.g., trigger some event)
            Debug.Log("ChargeButton activated!");
            // Implement button activation logic here
        }

        // Destroy the projectile after collision
        Destroy(gameObject);
    }

    // This could be triggered by another script or event
    private void OnTriggerEnter(Collider other)
    {
        // Detects if this is a ChargeAmmo object
        if (other.CompareTag("ChargeAmmo"))
        {
            // Activate supercharge when ChargeAmmo is collected
            ActivateSuperCharge();
            Destroy(other.gameObject); // Destroy the ChargeAmmo object
            Debug.Log("ChargeAmmo collected.");
        }
    }
}
