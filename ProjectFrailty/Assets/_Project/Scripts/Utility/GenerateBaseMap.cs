using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.IO;

[ExecuteInEditMode]
public class GenerateBaseMap : MonoBehaviour
{
	public static List<int> MaskValuePairs = new List<int>();

	[SerializeField]
	private Transform mapRoot;

	[SerializeField]
	private Texture2D pixelMap;

	[SerializeField]
	private GameObject tileObjectBase;

	private byte[][] mapArray;
	private GameObject[][] mapArrayGO;

	[SerializeField]
	private Sprite[] tileMap;


	[Button("Generate Map Base")]
	public void Generate()
	{
		if (MaskValuePairs == null)
		{
			MaskValuePairs = new List<int>();
		}
		LoadMaskValues();

		if (mapRoot == null)
		{
			mapRoot = new GameObject("Map Root").transform;
		}

		for (int i = mapRoot.childCount - 1; i >= 0; i--)
		{
			DestroyImmediate(mapRoot.GetChild(i).gameObject);
		}

		if (pixelMap == null)
			return;

		pixelMap.filterMode = FilterMode.Point;

		mapArray = new byte[pixelMap.width][];
		mapArrayGO = new GameObject[pixelMap.width][];
		for (int i = 0; i < pixelMap.width; i++)
		{
			mapArray[i] = new byte[pixelMap.height];
			mapArrayGO[i] = new GameObject[pixelMap.height];
			for (int j = 0; j < pixelMap.height; j++)
			{
				mapArray[i][j] = 0;
				mapArrayGO[i][j] = null;
			}
		}

		for (int i = 0; i < pixelMap.width; i++)
		{
			for (int j = 0; j < pixelMap.height; j++)
			{
				Color col = pixelMap.GetPixel(i, j);
				if (col == Color.black)
				{
					GameObject obj = Instantiate(tileObjectBase, new Vector3(i,j,0), Quaternion.identity);
					obj.transform.parent = mapRoot;
					mapArray[i][j] = 1;
					mapArrayGO[i][j] = obj;
				}
			}
		}
		//CompositeCollider2D mapRootComp = mapRoot.gameObject.GetComponent<CompositeCollider2D>();
		//if (mapRootComp == null)
		//	mapRoot.gameObject.AddComponent<CompositeCollider2D>();
		//else
		//{
		//	mapRootComp.GenerateGeometry();
		//}

		//mapRoot.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
		GenerateBitmapValues();
	}

	private void GenerateBitmapValues()
	{
		List<int> spriteCounter = new List<int>();
		for (int i = 0; i < pixelMap.width; i++)
		{
			for (int j = 0; j < pixelMap.height; j++)
			{
				int bitVal = 0;
				List<int> neighbors = new List<int>();
				for (int x = -1; x <= 1; x++)
				{
					for (int y = -1; y <= 1; y++)
					{
						int checkX = i + x;
						int checkY = j + y;
						if (x != 0 || y != 0)
						{
							if (checkX >= 0 && checkX < pixelMap.width && checkY >= 0 && checkY < pixelMap.height)
							{
								neighbors.Add(mapArray[i + x][j + y]);
							} else
							{
								neighbors.Add(1);
							}
						}
					}
				}
				for (int v = 0; v < neighbors.Count; v++)
				{
					bitVal += (int) Mathf.Pow(2, v) * neighbors[v];
				}

				if (mapArrayGO[i][j] != null)
				{
					BitmaskDisplay display = mapArrayGO[i][j].GetComponent<BitmaskDisplay>();
					display.BitValue = bitVal;
					mapArrayGO[i][j].GetComponent<SpriteRenderer>().sprite = tileMap[display.SpriteIndex];
					if (!spriteCounter.Contains(display.SpriteIndex))
					{
						spriteCounter.Add(display.SpriteIndex);
					}
				}
			}
		}

		//spriteCounter.Sort();
		//foreach (int i in spriteCounter)
		//{
		//	print($"Sprite index {i} is present.");
		//}
		print("Operation Complete...");
	}

	private void LoadMaskValues()
	{
		MaskValuePairs.Clear();
		TextAsset txt = Resources.Load<TextAsset>(Constants.ResourceDirectories.MaskPairCSV);
		string result = txt.text;
		string[] splitRes = result.Split('\n');
		foreach (string str in splitRes)
		{
			MaskValuePairs.Add(int.Parse(str));
		}
	}
}
