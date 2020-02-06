using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour
{
	[SerializeField]
	private Image healthbarReference;

	public void UpdateHealthValue(float amnt)
	{
		healthbarReference.fillAmount = amnt;
	}
}
