using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : EntityBase
{
	protected override void Start()
	{
		healthbarAsset = "SimpleEnemyHealthBar";
		base.Start();
	}
}
