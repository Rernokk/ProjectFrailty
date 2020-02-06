using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePistol : ProjectileWeapon
{
	public SimplePistol() : base()
	{
		weaponName = ProjectileWeapons.SimplePistol.WeaponName;
		projectileObject = Resources.Load<GameObject>(ProjectileWeapons.SimplePistol.GameObjectResourceLocation);
		firingRateMax = ProjectileWeapons.SimplePistol.FiringMaxRate;
		projectileSpeed = ProjectileWeapons.SimplePistol.ProjectileMaxSpeed;
		MaxConsumableCharges = ProjectileWeapons.SimplePistol.MaxConsumableCharges;
		base.UpdateConsumableCharges();
	}

	public override bool FireWeapon(Vector3 spawnPos, Quaternion spawnRot)
	{
		return base.FireWeapon(spawnPos, spawnRot);
	}
}
