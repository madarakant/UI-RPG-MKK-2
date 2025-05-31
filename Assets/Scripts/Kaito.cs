public class Kaito : Enemy
{
    private void Awake()
    {
        CharacterName = "Kaito";
        MaxHealth = 50;
        CurrentHealth = MaxHealth;
        AttackPower = 8;
        Defense = 3;
    }
    
    public override int GetExperienceReward()
    {
        return 20;
    }
    
    protected override void OnDeath()
    {
        base.OnDeath();
        // Kaito-specific death behavior
    }
}