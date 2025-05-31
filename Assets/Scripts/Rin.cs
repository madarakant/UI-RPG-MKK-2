public class Rin : Enemy
{
    private void Awake()
    {
        CharacterName = "Rin";
        MaxHealth = 60;
        CurrentHealth = MaxHealth;
        AttackPower = 7;
        Defense = 5;
    }
    
    public override int GetExperienceReward()
    {
        return 25;
    }
}