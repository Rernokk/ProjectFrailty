using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoHub : WorldNetworkHub
{

	public DemoHub() : base("Demo Hub")
	{
		base.neighborNodes.Add(new RouteANode(this));
		base.neighborNodes.Add(new RouteBNode(this));
		base.neighborNodes.Add(new RouteANode(this));
		base.neighborNodes.Add(new RouteCNode(this));
	}
}
