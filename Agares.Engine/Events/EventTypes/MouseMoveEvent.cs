using Agares.Engine.Geometry;

namespace Agares.Engine.Events.EventTypes
{
	public struct MouseMoveEvent : IEvent
	{
		public Point Position { get; private set; }

		public MouseMoveEvent(Point position) : this()
		{
			Position = position;
		}
	}
}