using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBulletProjectile : MonoBehaviour
{

	[SerializeField]
	private GameObject deathFX;

	private float dmgAmount;

	public float DmgAmount { get => dmgAmount; set => dmgAmount = value; }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		EntityBase other = collision.GetComponent<EntityBase>();
		if (other != null)
		{
			other.TakeDamage(dmgAmount);
		}
		Instantiate(deathFX, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
