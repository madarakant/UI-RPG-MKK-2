public class Len : Enemy
{
    private void Awake()
    {
        CharacterName = "Len";
        MaxHealth = 40;
        CurrentHealth = MaxHealth;
        AttackPower = 10;
        Defense = 2;
    }
    
    public override int GetExperienceReward()
    {
        return 15;
    }
}