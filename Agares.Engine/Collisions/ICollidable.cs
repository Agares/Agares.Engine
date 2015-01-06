using Agares.Engine.Geometry;

namespace Agares.Engine.Collisions
{
	public interface ICollidable
	{
		Rectangle BoundingRectangle { get; }
	}
}