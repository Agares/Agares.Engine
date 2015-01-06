namespace Agares.Engine.Geometry
{
	public struct Vector
	{
		public int X { get; private set; }
		public int Y { get; private set; }

		public Vector(int x, int y) : this()
		{
			X = x;
			Y = y;
		}
	}
}