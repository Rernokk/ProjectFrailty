using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteCNode : WorldNetworkNode
{
	public RouteCNode(WorldNetworkNode back) : base("Route C", back)
	{
		neighborNodes.Add(new RouteDNode(this));
		neighborNodes.Add(new RouteDNode(this));
		neighborNodes.Add(new RouteDNode(this));
	}
}
