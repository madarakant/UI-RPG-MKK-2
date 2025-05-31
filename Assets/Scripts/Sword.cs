public class Sword : Weapon
{
    private void Awake()
    {
        weaponName = "Sword";
    }
    
    public override int GetDamage()
    {
        // Sword has consistent damage (18)
        return 18;
    }
}