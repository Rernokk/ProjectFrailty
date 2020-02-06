using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
	public virtual void Interact()
	{
		print($"Interacting with object: {gameObject.name}");
	}
}
