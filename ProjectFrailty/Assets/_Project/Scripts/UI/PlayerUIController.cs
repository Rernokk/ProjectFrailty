using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
	[SerializeField]
	private Text currentWeaponTextElement, currentStatsTextElement;

	private static PlayerUIController instance;

	public static PlayerUIController Instance
	{
		get
		{
			return instance;
		}

		private set
		{
			instance = value;
		}
	}

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		} else if (instance != this)
		{
			Destroy(this);
			return;
		}
	}

	public void UpdateHealthDisplay(PlayerCombatController cmbtCtrl)
	{
		currentStatsTextElement.text = 
			$"Health: {cmbtCtrl.CurrentHealth.ToString("0")}/{cmbtCtrl.MaxHealth.ToString("0")}\n" +
			$"Consumable Charges: {cmbtCtrl.CurrentConsumableCharges}/{cmbtCtrl.MaxConsumableCharges}";
	}

	public void UpdateActiveWeaponDisplay(WeaponBase weapon)
	{
		currentWeaponTextElement.text = $"Current Weapon:\n{weapon}";
	}
}
