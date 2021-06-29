﻿using UnityEngine;
using System.Collections;

public class TextureScroller : MonoBehaviour {
	public int materialIndex = 0;
	public Vector2 uvAnimationRate = new Vector2( 1.0f, 0.0f );
	public string textureName = "_BaseColorMap";
	
	Vector2 uvOffset = Vector2.zero;
	
	void LateUpdate() 
	{
		uvOffset += ( uvAnimationRate * Time.deltaTime );
		if( GetComponent<Renderer>().enabled )
		{
			GetComponent<Renderer>().materials[ materialIndex ].SetTextureOffset( textureName, uvOffset );
		}
	}
}