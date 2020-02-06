using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPistol : ProjectileWeapon
{
	private float reloadTimer = 0f;
	private int currentAmmo = 0;

	public AmmoPistol() : base()
	{
		weaponName = ProjectileWeapons.AmmoPistol.WeaponName;
		projectileObject = Resources.Load<GameObject>(ProjectileWeapons.SimplePistol.GameObjectResourceLocation);
		firingRateMax = ProjectileWeapons.SimplePistol.FiringMaxRate;
		projectileSpeed = ProjectileWeapons.SimplePistol.ProjectileMaxSpeed;
		currentAmmo = ProjectileWeapons.AmmoPistol.MaxAmmo;
		MaxConsumableCharges = 3;
		base.UpdateConsumableCharges();
	}

	public override bool FireWeapon(Vector3 spawnPos, Quaternion spawnRot)
	{
		if (currentAmmo <= 0)
			return false;

		if (base.FireWeapon(spawnPos, spawnRot))
		{
			currentAmmo--;

			if (currentAmmo == 0)
			{
				reloadTimer = ProjectileWeapons.AmmoPistol.ReloadTime;
			}
		}
		return true;
	}

	public override void Update()
	{
		if (reloadTimer > 0f)
		{
			reloadTimer -= Time.deltaTime;
			if (reloadTimer <= 0f)
			{
				currentAmmo = ProjectileWeapons.AmmoPistol.MaxAmmo;
				reloadTimer = 0;
			}
		}
		PlayerUIController.Instance.UpdateActiveWeaponDisplay(this);
		base.Update();
	}

	public override string ToString()
	{
		return base.ToString()
			+ $"\nCurrentAmmo: {currentAmmo} / {ProjectileWeapons.AmmoPistol.MaxAmmo}"
			+ $"\nReloading: {reloadTimer.ToString("0.00")}s";
	}
}
