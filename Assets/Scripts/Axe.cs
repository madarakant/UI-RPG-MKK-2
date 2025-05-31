using UnityEngine;  // Add this at the top of the file

public class Axe : Weapon
{
    private void Awake()
    {
        weaponName = "Axe";
    }
    
    public override int GetDamage()
    {
        // Axe has high damage but random (15-25)
        return Random.Range(15, 25);
    }
}