using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class Player : Character
{
    [Header("Shield Settings")]
    [SerializeField] private Image shieldIndicator; // Reference to the shield UI image
    [SerializeField] private float shieldBreakChance = 0.3f;
    
    private bool shieldActive = false;
    private Weapon currentWeapon;

    public void ToggleShield()
    {
        shieldActive = !shieldActive;
        
        // Update the shield indicator visibility
        if (shieldIndicator != null)
            shieldIndicator.gameObject.SetActive(shieldActive);
        
        Debug.Log($"Shield {(shieldActive ? "ON" : "OFF")}");
    }

    public override void TakeDamage(int damage)
    {
        if (shieldActive)
        {
            damage = Mathf.Max(1, damage / 2); // Reduce damage by half
            
            // Check if shield breaks
            if (Random.value < shieldBreakChance)
            {
                shieldActive = false;
                if (shieldIndicator != null)
                    shieldIndicator.gameObject.SetActive(false);
                Debug.Log("Shield broke!");
            }
        }
        
        base.TakeDamage(damage); // Apply remaining damage
    }

    public int Attack()
    {
        return (currentWeapon != null) ? currentWeapon.GetDamage() : AttackPower;
    }

    public void EquipWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
    }
}