using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Kaito : Enemy
{
    [Header("UI References")]
    [SerializeField] private Slider _enemyHealthSlider;
    [SerializeField] private TextMeshProUGUI _enemyHealthText;

    protected override void Awake()
    {
        base.Awake();
        CharacterName = "Kaito";
        // Initialize UI references
        healthSlider = _enemyHealthSlider;
        healthDisplayText = _enemyHealthText;
        
        // Initialize stats
        CharacterName = "Kaito";
        MaxHealth = 50;
        CurrentHealth = MaxHealth;
        AttackPower = 8;
        Defense = 3;
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