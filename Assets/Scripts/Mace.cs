using UnityEngine;  // Add this line at the top

public class Mace : Weapon
{
    private void Awake()
    {
        weaponName = "Mace";
    }
    
    public override int GetDamage()
    {
        // Mace has moderate damage with chance for critical (15 + 0-10)
        return 15 + UnityEngine.Random.Range(0, 10);
    }
}