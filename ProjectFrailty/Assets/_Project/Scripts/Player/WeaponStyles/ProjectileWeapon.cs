using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileWeapon : WeaponBase
{
	protected GameObject projectileObject;
	protected float firingRateMax, defensiveMax, offensiveTimer, defensiveTimer;
	protected List<GameObject> activeProjectiles = new List<GameObject>();

	protected float projectileSpeed = 10f;
	protected float projectileDamage = 10f;

	public ProjectileWeapon() : base()
	{

	}

	public override void OffensiveAction(Vector3 spawnPos, Quaternion spawnRot)
	{
		FireWeapon(spawnPos, spawnRot);
	}

	public override void DefensiveAction(Vector3 spawnPos, Quaternion spawnRot, PlayerCombatController cmbtCtrl)
	{
		Debug.Log("Defensive Action Dash!");
		cmbtCtrl.StartInvulnWindow(ProjectileWeapons.SimplePistol.DodgeIFrames);
		cmbtCtrl.StartLossOfControlWindow(ProjectileWeapons.SimplePistol.DodgeLOCFrames);
		cmbtCtrl.GetComponent<Rigidbody2D>().velocity = ProjectileWeapons.SimplePistol.DodgeSpeed * cmbtCtrl.transform.right;
	}

	public virtual bool FireWeapon(Vector3 spawnPos, Quaternion spawnRot)
	{
		if (!CanFire())
		{
			return false;
		}

		offensiveTimer = 60f / firingRateMax;
		GameObject obj = Instantiate(projectileObject, spawnPos, spawnRot);
		obj.GetComponent<Rigidbody2D>().velocity = obj.transform.right * projectileSpeed;
		obj.GetComponent<SimpleBulletProjectile>().DmgAmount = projectileDamage;
		activeProjectiles.Add(obj);
		Destroy(obj, Constants.GeneralProjectileProperties.DecayTime);
		return true;
	}

	protected bool CanFire()
	{
		return offensiveTimer <= 0f;
	}

	public override void Update()
	{
		offensiveTimer -= Time.deltaTime;
	}
}
