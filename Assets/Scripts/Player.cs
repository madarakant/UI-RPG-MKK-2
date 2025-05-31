using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : Character
{
    [Header("UI References")]
    [SerializeField] private Slider _playerHealthSlider;
    [SerializeField] private TextMeshProUGUI _playerHealthText;

    [Header("Shield Settings")]
    [SerializeField] private Image shieldIndicator;
    [SerializeField] private float shieldBreakChance = 0.3f;
    
    private bool shieldActive = false;
    private Weapon currentWeapon;

    protected override void Awake()
    {
        
        base.Awake();
        CharacterName = "Miku";
        
        // Initialize UI references
        healthSlider = _playerHealthSlider;
        healthDisplayText = _playerHealthText;
        
        // Initialize stats
        MaxHealth = 100;
        CurrentHealth = MaxHealth;
        AttackPower = 10;
        Defense = 5;
    }

    // ... rest of your Player methods ...


    // ... rest of your Player methods ...


    public void ToggleShield()
    {
        shieldActive = !shieldActive;
        if (shieldIndicator != null)
            shieldIndicator.gameObject.SetActive(shieldActive);
        Debug.Log($"Shield {(shieldActive ? "ON" : "OFF")}");
    }

    public override void TakeDamage(int damage)
    {
        if (shieldActive)
        {
            damage = Mathf.Max(1, damage / 2);
            if (Random.value < shieldBreakChance)
            {
                shieldActive = false;
                if (shieldIndicator != null)
                    shieldIndicator.gameObject.SetActive(false);
                Debug.Log("Shield broke!");
            }
        }
        base.TakeDamage(damage);
    }

    public int Attack()
    {
        return currentWeapon?.GetDamage() ?? AttackPower;
    }

    public void EquipWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
        AttackPower = weapon.GetDamage();
    }
}