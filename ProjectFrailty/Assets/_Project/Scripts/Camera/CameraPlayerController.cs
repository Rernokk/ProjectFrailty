using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerController : MonoBehaviour
{
	private Transform target;
	// Start is called before the first frame update
	void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	// Update is called once per frame
	void LateUpdate()
	{
		transform.position = Vector3.Lerp(transform.position, target.position, Constants.CameraAttributes.CameraLerpValue);
		if (Vector3.Distance(transform.position, target.position) < .05f)
		{
			transform.position = target.position;
		}
	}
}
