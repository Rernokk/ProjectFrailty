using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : ScriptableObject
{
	protected string weaponName = "N/A";
	private int currentConsumableCharges = 1;
	private int maxConsumableCharges = 1;

	public string WeaponName
	{
		get
		{
			return weaponName;
		}

		set
		{
			weaponName = value;
		}
	}

	public int MaxConsumableCharges
	{
		get => maxConsumableCharges;
		set {
			maxConsumableCharges = value;
		}
	}
	public int CurrentConsumableCharges
	{
		get => currentConsumableCharges;
		set
		{
			currentConsumableCharges = value;
			currentConsumableCharges = Mathf.Clamp(currentConsumableCharges, 0, maxConsumableCharges);
		}
	}

	protected WeaponBase()
	{

	}

	public virtual void OffensiveAction(Vector3 spawnPos, Quaternion spawnRot)
	{

	}

	public virtual void DefensiveAction(Vector3 spawnPos, Quaternion spawnRot, PlayerCombatController cmbtCtrl)
	{

	}

	public virtual void ConsumptionAction(PlayerCombatController cmbtCtrl)
	{
		if (cmbtCtrl.CurrentConsumableCharges <= 0)
		{
			return;
		}

		cmbtCtrl.CurrentConsumableCharges--;
		cmbtCtrl.Heal(cmbtCtrl.MaxHealth * Constants.PlayerAttributes.PlayerHealPercentage);
	}

	protected void UpdateConsumableCharges()
	{
		CurrentConsumableCharges = MaxConsumableCharges;
	}

	public virtual void Update()
	{

	}

	public override string ToString()
	{
		return WeaponName;
	}
}
