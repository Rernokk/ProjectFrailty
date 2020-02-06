using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyBase : EnemyBase
{
	protected override void Start()
	{
		healthbarAsset = "BasicBossHealthBar";
	}
}
