using System.Diagnostics.Contracts;

namespace Agares.Engine.Geometry
{
	public struct Rectangle
	{
		public int Top { get; private set; }
		public int Right { get; private set; }
		public int Bottom { get; private set; }
		public int Left { get; private set; }

		public int Width
		{
			[Pure] get { return Right - Left; }
		}

		public int Height
		{
			[Pure] get { return Bottom - Top; }
		}

		public static Rectangle FromTRBL(int top, int right, int bottom, int left)
		{
			return new Rectangle
			{
				Top = top,
				Right = right,
				Bottom = bottom,
				Left = left
			};
		}

		public static Rectangle FromPositionAndSize(Point position, Vector size)
		{
			return FromPositionAndSize(position.X, position.Y, size.X, size.Y);
		}

		public static Rectangle FromPositionAndSize(int x, int y, int width, int height)
		{
			int top = y;
			int right = x + width;
			int bottom = y + height;
			int left = x;

			return FromTRBL(top, right, bottom, left);
		}

		[Pure]
		public bool Contains(Rectangle other)
		{
			return other.Left >= Left
				   && other.Right <= Right
				   && other.Top >= Top
				   && other.Bottom <= Bottom;
		}

		[Pure]
		public bool IntersectsWith(Rectangle other)
		{
			return Left < other.Right
			       && Right > other.Left
			       && Top < other.Bottom
			       && Bottom > other.Top;
		}

		[Pure]
		public Direction GetDirectionTo(Rectangle other)
		{
			var finalDirection = Direction.None;

			if (Left > other.Left)
			{
				finalDirection |= Direction.Left;
			}

			if (Right < other.Right)
			{
				finalDirection |= Direction.Right;
			}

			if (Top > other.Top)
			{
				finalDirection |= Direction.Top;
			}

			if (Bottom < other.Bottom)
			{
				finalDirection |= Direction.Bottom;
			}

			return finalDirection;
		}
	}
}