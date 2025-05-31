using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class Character : MonoBehaviour
{
    // Health stats
    public string CharacterName { get; protected set; }
    public int MaxHealth { get; protected set; }
    public int CurrentHealth { get; protected set; }
    public int AttackPower { get; protected set; }
    public int Defense { get; protected set; }

    // UI References
    [Header("UI References")]
    [SerializeField] protected TextMeshProUGUI healthDisplayText;
    [SerializeField] protected Slider healthSlider;
    [SerializeField] private GameObject floatingTextPrefab; // For damage numbers

    protected virtual void Awake()
    {
        // Initialize health display
        UpdateHealthUI();
    }

    public virtual void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        CurrentHealth = Mathf.Max(0, CurrentHealth);
        
        // Show damage numbers
        ShowDamageText(damage);
        
        UpdateHealthUI();
    }

    protected virtual void UpdateHealthUI()
    {
        // Update health slider
        if (healthSlider != null)
        {
            healthSlider.maxValue = MaxHealth;
            healthSlider.value = CurrentHealth;
        }

        // Update health text
        if (healthDisplayText != null)
        {
            healthDisplayText.text = $"{CharacterName}: {CurrentHealth}/{MaxHealth}";
            healthDisplayText.color = GetHealthColor();
        }
    }

    private Color GetHealthColor()
    {
        float healthPercent = (float)CurrentHealth / MaxHealth;
        return Color.Lerp(Color.red, Color.green, healthPercent);
    }

    private void ShowDamageText(int damage)
    {
        if (floatingTextPrefab != null)
        {
            var textObj = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            TextMeshPro textMesh = textObj.GetComponent<TextMeshPro>();
            textMesh.text = $"-{damage}";
            textMesh.color = Color.red;
            Destroy(textObj, 1f);
        }
    }

    public virtual bool IsDead()
    {
        return CurrentHealth <= 0;
    }
}