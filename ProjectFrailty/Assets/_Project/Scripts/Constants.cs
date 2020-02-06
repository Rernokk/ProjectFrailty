using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Constants
{

	public static class PlayerAttributes
	{
		public const float
			PlayerHealPercentage = .3f,
			PlayerBaseHealth = 100f,
			PlayerBaseSpeed = 20f;
	}

	public static class CameraAttributes
	{
		public const float CameraLerpValue = .225f;
	}

	public class ResourceDirectories
	{
		public const string
			ProjectileLocation = "Player/Projectiles/",
			MaskPairCSV = "Develop/MaskPairs";
	}

	public class GeneralProjectileProperties
	{
		public const float DecayTime = 5f;
	}
}

namespace ProjectileWeapons
{
	public static class SimplePistol
	{
		public const float
			DodgeSpeed = 45f,
			ProjectileMaxSpeed = 30f,
			FiringMaxRate = 600f;

		public const int
			DodgeIFrames = 15,
			MaxConsumableCharges = 1,
			DodgeLOCFrames = 45;

		public const string
			WeaponName = "Simple Pistol",
			GameObjectResourceLocation = Constants.ResourceDirectories.ProjectileLocation + "SimpleBullet";
	}

	public static class AmmoPistol
	{
		public const string
			WeaponName = "Ammo Pistol";

		public const int
			MaxAmmo = 10;

		public const float
			ReloadTime = 2f;
	}
}
