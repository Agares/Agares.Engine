namespace Agares.Engine.Geometry
{
	public struct VectorDouble
	{
		public double X { get; private set; }
		public double Y { get; private set; }

		public VectorDouble(double x, double y) : this()
		{
			X = x;
			Y = y;
		}

		public static VectorDouble operator*(VectorDouble vector, double multiplier)
		{
			return new VectorDouble(vector.X*multiplier, vector.Y*multiplier);
		}

		public VectorDouble NegateY()
		{
			return new VectorDouble(X, -Y);
		}

		public VectorDouble NegateX()
		{
			return new VectorDouble(-X, Y);
		}
	}
}