using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteBNode : WorldNetworkNode
{
	public RouteBNode(WorldNetworkNode back) : base("Route B", back)
	{
		base.neighborNodes.Add(new RouteCNode(this));
		base.neighborNodes.Add(new RouteCNode(this));
		base.neighborNodes.Add(new RouteCNode(this));
		base.neighborNodes.Add(new RouteCNode(this));
	}
}
