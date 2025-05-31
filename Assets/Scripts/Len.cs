using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Len : Enemy
{
    [Header("UI References")]
    [SerializeField] private Slider _enemyHealthSlider;
    [SerializeField] private TextMeshProUGUI _enemyHealthText;

    protected override void Awake()
    {
        base.Awake();
        CharacterName = "Len";
        // Initialize UI references
        healthSlider = _enemyHealthSlider;
        healthDisplayText = _enemyHealthText;
        
        // Initialize stats
        CharacterName = "Len";
        MaxHealth = 70;
        CurrentHealth = MaxHealth;
        AttackPower = 9;
        Defense = 4;
    }

    public override int GetExperienceReward()
    {
        return 20; // Kaito gives 20 XP when defeated
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        // Kaito-specific death behavior
    }
}