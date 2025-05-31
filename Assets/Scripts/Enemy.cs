using UnityEngine;

public abstract class Enemy : Character
{
    public abstract int GetExperienceReward();
    
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        
        if (IsDead())
        {
            OnDeath();
        }
    }
    
    protected virtual void OnDeath()
    {
        // Can be overridden by specific enemies
        Debug.Log($"{CharacterName} has been defeated!");
    }
}