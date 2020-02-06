using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldNetworkNode : ScriptableObject
{
	protected WorldNetworkNode backNode;
	protected GameObject myNodeObject;
	protected string worldNodeName;
	protected Vector2 myPosition;
	protected List<WorldNetworkNode> neighborNodes = new List<WorldNetworkNode>();
	protected List<GameObject> connectionObjects = new List<GameObject>();
	protected Color drawColor = Color.red;
	protected int tier = 0;

	#region Properties
	public WorldNetworkNode BackNode
	{
		get
		{
			return backNode;
		}

		set
		{
			backNode = value;
		}
	}

	public GameObject NodeObject
	{
		get
		{
			return myNodeObject;
		}

		set
		{
			myNodeObject = value;
		}
	}

	public Vector2 Position
	{
		get
		{
			return myPosition;
		}

		set
		{
			myPosition = value;
			myNodeObject.transform.position = myPosition;
		}
	}

	public int Tier
	{
		get
		{
			return tier;
		}

		set
		{
			tier = value;
		}
	}
	#endregion

	public WorldNetworkNode(string name, WorldNetworkNode backNode = null)
	{
		worldNodeName = name;
		this.backNode = backNode;
		if (backNode != null)
		{
			tier = backNode.Tier + 1;
		}
		CreateNodeObject();
	}

	private void CreateNodeObject()
	{
		myNodeObject = Instantiate(Resources.Load<GameObject>("Utility/WorldNode"), myPosition, Quaternion.identity);
		myNodeObject.transform.Find("Background/Canvas/Name").GetComponent<Text>().text = worldNodeName;
		myNodeObject.transform.name = worldNodeName;
		if (backNode != null)
			myNodeObject.transform.parent = backNode.myNodeObject.transform;
	}

	public virtual void SpreadNeighbors()
	{
		float angle = Mathf.PI / neighborNodes.Count;
		float backAngle = 0f;
		if (backNode != null)
		{
			backAngle = Vector2.SignedAngle(Vector2.right, (Position - backNode.Position).normalized) * Mathf.Deg2Rad + Mathf.PI + angle * ((neighborNodes.Count - 1) / 2.0f);
		}
		for (int i = 0; i < neighborNodes.Count; i++)
		{
			neighborNodes[i].Position = (Vector2)Position + new Vector2(Mathf.Cos(backAngle + angle * (1 + i)), Mathf.Sin(backAngle + angle * (i + 1))) * 100f / Mathf.Pow(3, tier);
			neighborNodes[i].SpreadNeighbors();
		}
		DrawConnections();
	}

	public virtual void DrawConnections()
	{
		foreach (WorldNetworkNode node in neighborNodes)
		{
			GameObject connection = Instantiate(Resources.Load<GameObject>("Utility/WorldConnection"), Position, Quaternion.identity);
			connection.GetComponent<LineRenderer>().SetPositions(new Vector3[] { Vector3.zero, node.Position - Position});
			connectionObjects.Add(connection);
		}
	}
}
