using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitmaskDisplay : MonoBehaviour
{
	[SerializeField]
	private int bitValue = 0, spriteIndex = 0;

	public static Dictionary<int, int> spriteIndexer = new Dictionary<int, int>();
	
	public int BitValue
	{
		get
		{
			return bitValue;
		}

		set
		{
			bitValue = value;
			transform.name = bitValue.ToString();
			spriteIndex = GenerateBaseMap.MaskValuePairs[BitValue];

			if (!spriteIndexer.ContainsKey(spriteIndex))
			{
				spriteIndexer.Add(spriteIndex, 0);
			}
			spriteIndexer[spriteIndex]++;
		}
	}

	public int SpriteIndex
	{
		get
		{
			return spriteIndex;
		}
	}
}
