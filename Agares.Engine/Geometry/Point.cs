namespace Agares.Engine.Geometry
{
	public struct Point
	{
		public int X { get; private set; }
		public int Y { get; private set; }

		public Point(int x, int y) : this()
		{
			X = x;
			Y = y;
		}

		public static bool operator ==(Point self, Point other)
		{
			return self.Equals(other);
		}

		public static bool operator !=(Point self, Point other)
		{
			return !(self.Equals(other));
		}

		public bool Equals(Point other)
		{
			return X == other.X && Y == other.Y;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			return obj is Point && Equals((Point) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (X*397) ^ Y;
			}
		}
	}
}