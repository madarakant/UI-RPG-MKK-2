using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    // Encapsulation through properties
    public string CharacterName { get; protected set; }
    public int MaxHealth { get; protected set; }
    public int CurrentHealth { get; protected set; }
    public int AttackPower { get; protected set; }
    public int Defense { get; protected set; }
    
    [SerializeField] protected Image healthBar;
    [SerializeField] protected Text healthText;
    
    // Polymorphism through virtual methods
    public virtual void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        CurrentHealth = Mathf.Max(0, CurrentHealth);
        UpdateHealthUI();
    }
    
    public virtual void Heal(int amount)
    {
        CurrentHealth = Mathf.Min(CurrentHealth + amount, MaxHealth);
        UpdateHealthUI();
    }
    
    protected virtual void UpdateHealthUI()
    {
        if (healthBar != null)
            healthBar.fillAmount = (float)CurrentHealth / MaxHealth;
        
        if (healthText != null)
            healthText.text = $"{CurrentHealth}/{MaxHealth}";
    }
    
    public virtual bool IsDead()
    {
        return CurrentHealth <= 0;
    }
}