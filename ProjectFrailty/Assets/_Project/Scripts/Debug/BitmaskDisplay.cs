using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitmaskDisplay : MonoBehaviour
{
	[SerializeField]
	private int bitValue = 0, spriteIndex = 0;
	
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
