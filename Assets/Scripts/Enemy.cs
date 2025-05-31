using UnityEngine;

public abstract class Enemy : Character
{
    public abstract int GetExperienceReward();  // Required implementation
    
    protected override void Awake()
    {
        base.Awake();
        // Common enemy initialization can go here
    }

    protected virtual void OnDeath()
    {
        // Can be overridden by specific enemies
        Debug.Log($"{CharacterName} has been defeated!");
    }
}