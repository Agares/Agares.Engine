﻿using System;

namespace Agares.Engine.Geometry
{
	[Flags]
	public enum Direction
	{
		None = 0,
		Top = 1,
		Right = 2,
		Bottom = 4,
		Left = 8
	}
}