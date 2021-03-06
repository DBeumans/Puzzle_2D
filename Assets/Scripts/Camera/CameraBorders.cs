﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBorders
{
	private float leftBorder;
	public float getLeftBorder(float distance, float offset)
	{
		leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance)).x - offset;
		return leftBorder;
	}

	private float rightBorder;
	public float getRightBorder(float distance, float offset)
	{
		rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance)).x- offset;
		return rightBorder;
	}

	private float topBorder;
	public float getTopBorder(float distance)
	{
		topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance)).y;
		return topBorder;
	}

	private float bottomBorder;
	public float getBottomBorder(float distance, float offset)
	{
		bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,1,distance)).y - offset;
		return bottomBorder;
	}

	public CameraBorders()
	{
		leftBorder = 0;
		rightBorder = 0;
		topBorder = 0;
		bottomBorder = 0;
	}
}
