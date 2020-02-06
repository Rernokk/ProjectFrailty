using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteANode : WorldNetworkNode
{
	public RouteANode(WorldNetworkNode back) : base ("Route A", back)
	{
		base.neighborNodes.Add(new RouteCNode(this));
		base.neighborNodes.Add(new RouteCNode(this));
		base.neighborNodes.Add(new RouteBNode(this));
		base.neighborNodes.Add(new RouteCNode(this));
		base.neighborNodes.Add(new RouteCNode(this));
	}
}
