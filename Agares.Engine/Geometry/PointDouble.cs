using Agares.Engine.Utilities;

namespace Agares.Engine.Geometry
{
	public struct PointDouble
	{
		public double X { get; private set; }
		public double Y { get; private set; }

		public PointDouble(double x, double y)
			: this()
		{
			X = x;
			Y = y;
		}

		public static PointDouble operator +(PointDouble point, VectorDouble vector)
		{
			return new PointDouble(point.X + vector.X, point.Y + vector.Y);
		}

		public PointDouble EnsureInside(Rectangle rectangle)
		{
			var x = X.Clamp(rectangle.Left, rectangle.Right);
			var y = Y.Clamp(rectangle.Top, rectangle.Bottom);

			return new PointDouble(x, y);
		}
	}
}