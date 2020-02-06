using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldNetworkHub : WorldNetworkNode
{
	public WorldNetworkHub(string name) : base(name)
	{

	}

	public override void SpreadNeighbors()
	{
		float angle = 2 * Mathf.PI / neighborNodes.Count;
		for (int i = 0; i < neighborNodes.Count; i++)
		{
			neighborNodes[i].Position = (Vector2) Position + new Vector2(Mathf.Cos(angle * i), Mathf.Sin(angle * i)) * 50f;
			neighborNodes[i].SpreadNeighbors();
		}
		DrawConnections();
	}

	public override void DrawConnections()
	{
		drawColor = Color.green;
		base.DrawConnections();
	}
}
