using System;
using UnityEngine;

public class Health : IDamagable, IHealable
{
	public event Action ZeroHPValue;
	public event Action<float> HealthValueChange;

	public float MaxHealth { get; private set; }
	public float CurrentHealth { get; private set; }
	
	public Health(float maxHealth)
	{
		MaxHealth = maxHealth;
		CurrentHealth = maxHealth;
	}
	
	public void Heal(float healAmount)
	{
		if(healAmount < 0)
		{
			throw new ArgumentOutOfRangeException("Heal amount cannot be negative");
		}

        CurrentHealth = Mathf.Clamp(CurrentHealth += healAmount, 0, MaxHealth);
        HealthValueChange?.Invoke(CurrentHealth);
    }

	public void TakeDamage(float damage)
	{
		if(damage < 0)
		{
			throw new ArgumentOutOfRangeException("Damage amount cannot be negative");
		}

        CurrentHealth = Mathf.Clamp(CurrentHealth -= damage, 0, MaxHealth);
        HealthValueChange?.Invoke(CurrentHealth);


        if (CurrentHealth <= 0)
		{
			ZeroHPValue?.Invoke();
		}
	}
}
