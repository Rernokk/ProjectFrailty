using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBase : MonoBehaviour
{
	[SerializeField]
	private float currentHealth, maxHealth;

	#region Properties
	public float CurrentHealth
	{
		get => currentHealth;
		set
		{
			currentHealth = value;
			if (currentHealth <= 0f)
			{
				Die();
			}
			currentHealth = Mathf.Clamp(currentHealth, 0, MaxHealth);
		}
	}
	public float MaxHealth { get => maxHealth; set => maxHealth = value; }
	#endregion Properties

	#region Protected Methods
	protected virtual void Die()
	{
		Destroy(gameObject);
	}
	protected void Start()
	{
		CurrentHealth = MaxHealth;
	}
	#endregion Protected Methods

	#region Public Methods
	public virtual void TakeDamage(float amnt)
	{
		CurrentHealth -= amnt;
	}

	public virtual void Heal(float amnt)
	{
		CurrentHealth += amnt;
	}
	#endregion Public Methods
}
