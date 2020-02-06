using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
	private WeaponBase activeWeapon;
	private string offensiveAction = "OffensiveAction";
	private string defensiveAction = "DefensiveAction";
	private string consumableAction = "ConsumableAction";

	private float maxHealth = 1;
	private float currentHealth;

	[SerializeField]
	private bool hasControl = true;
	private bool isInvulnerable = false;

	#region Properties
	public bool HasControl
	{
		get
		{
			return hasControl;
		}

		set
		{
			hasControl = value;
		}
	}

	public bool IsInvulnerable
	{
		get
		{
			return isInvulnerable;
		}

		set
		{
			isInvulnerable = value;
		}
	}

	public WeaponBase ActiveWeapon
	{
		get
		{
			return activeWeapon;
		}

		set
		{
			activeWeapon = value;
			PlayerUIController.Instance.UpdateActiveWeaponDisplay(activeWeapon);
			PlayerUIController.Instance.UpdateHealthDisplay(this);
		}
	}

	public int CurrentConsumableCharges { get => ActiveWeapon.CurrentConsumableCharges; set => ActiveWeapon.CurrentConsumableCharges = value; }
	public int MaxConsumableCharges { get => ActiveWeapon.MaxConsumableCharges; set => ActiveWeapon.MaxConsumableCharges = value; }
	public float MaxHealth { get => maxHealth; set => maxHealth = value; }
	public float CurrentHealth
	{
		get => currentHealth; set
		{
			currentHealth = value;
			PlayerUIController.Instance.UpdateHealthDisplay(this);
		}
	}
	#endregion Properties

	void Start()
	{
		if (ActiveWeapon == null)
		{
			ActiveWeapon = new SimplePistol();
		}
		MaxHealth = Constants.PlayerAttributes.PlayerBaseHealth;
		CurrentHealth = MaxHealth * .1f;
	}

	void Update()
	{
		ActiveWeapon.Update();

		if (!hasControl)
		{
			return;
		}

		if (Input.GetAxis(offensiveAction) > 0)
		{
			ActiveWeapon.OffensiveAction(transform.position + transform.right * 1.5f, transform.rotation);
			Debug.DrawRay(transform.position, transform.right * 3f, Color.green);
		}

		if (Input.GetAxis(defensiveAction) > 0)
		{
			ActiveWeapon.DefensiveAction(transform.position, transform.rotation, this);
		}

		if (Input.GetButtonDown(consumableAction))
		{
			ActiveWeapon.ConsumptionAction(this);
		}


		// Debug Commands
		#region Debug
		if (Input.GetKeyDown(KeyCode.G))
		{
			ActiveWeapon = new SimplePistol();
		}

		if (Input.GetKeyDown(KeyCode.H))
		{
			ActiveWeapon = new AmmoPistol();
		}
		#endregion Debug
	}


	#region Basic FX
	public void StartInvulnWindow(int duration)
	{
		StartCoroutine(InvulnTimer(duration));
	}

	public void StartLossOfControlWindow(int duration)
	{
		StartCoroutine(LossOfControlTimer(duration));
	}

	protected IEnumerator InvulnTimer(int frameInvuln)
	{
		IsInvulnerable = true;
		for (int i = 0; i < frameInvuln; i++)
		{
			yield return null;
		}
		IsInvulnerable = false;
	}

	protected IEnumerator LossOfControlTimer(int frameControlLoss)
	{
		HasControl = false;
		for (int i = 0; i < frameControlLoss; i++)
		{
			yield return null;
		}
		HasControl = true;
	}
	#endregion Basic FX

	#region Combat-Oriented Methods
	public void TakeDamage(float amnt)
	{
		CurrentHealth -= amnt;
		if (CurrentHealth <= 0f)
		{
			Die();
		}
	}

	public void Heal(float amnt)
	{
		CurrentHealth += amnt;
		CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
	}

	public void Die()
	{
		print("Player Died!");
		HasControl = false;
	}
	#endregion Combat-Oriented Methods
}
