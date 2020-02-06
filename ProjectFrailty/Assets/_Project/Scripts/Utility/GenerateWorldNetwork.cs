using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorldNetwork : MonoBehaviour
{
	WorldNetworkHub origin;

	private void Start()
	{
		origin = new DemoHub();
		origin.SpreadNeighbors();
	}
}
