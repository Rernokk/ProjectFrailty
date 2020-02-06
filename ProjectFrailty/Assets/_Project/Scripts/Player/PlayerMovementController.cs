using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
	PlayerCombatController combatController;

	private string xMovementAxis = "Horizontal", yMovementAxis = "Vertical";
	private string xAimingAxis = "View Joystick X", yAimingAxis = "View Joystick Y";
	private string interactionAxis = "Submit";

	private void Start()
	{
		combatController = GetComponent<PlayerCombatController>();
	}

	void Update()
	{
		// Aiming reticle.
		if (Mathf.Abs(Input.GetAxis(xAimingAxis)) + Mathf.Abs(Input.GetAxis(yAimingAxis)) > .05f)
		{
			transform.right = new Vector2(Input.GetAxis(xAimingAxis), Input.GetAxis(yAimingAxis));
		}

		// Is the player able to take action?
		if (!combatController.HasControl)
		{
			return;
		}

		// Console controller for motion.
		transform.position += new Vector3(Input.GetAxis(xMovementAxis), Input.GetAxis(yMovementAxis)) * Time.deltaTime * Constants.PlayerAttributes.PlayerBaseSpeed;

		// Interact with nearby interactable.
		if (Input.GetAxis(interactionAxis) > 0)
		{
			Collider2D interactObj = Physics2D.OverlapCircle(transform.position, 3f, LayerMask.GetMask("Interactable"));
			if (interactObj != null)
			{
				interactObj.transform.root.GetComponent<InteractableObject>().Interact();
			}
		}
	}
}
