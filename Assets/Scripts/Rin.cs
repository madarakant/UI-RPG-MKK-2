using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Rin : Enemy
{
    [Header("UI References")]
    [SerializeField] private Slider _enemyHealthSlider;
    [SerializeField] private TextMeshProUGUI _enemyHealthText;

    protected override void Awake()
    {
        base.Awake();
        CharacterName = "Rin";
        // Initialize UI references
        healthSlider = _enemyHealthSlider;
        healthDisplayText = _enemyHealthText;
        
        // Initialize stats
        CharacterName = "Rin";
        MaxHealth = 40;
        CurrentHealth = MaxHealth;
        AttackPower = 6;
        Defense = 2;
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