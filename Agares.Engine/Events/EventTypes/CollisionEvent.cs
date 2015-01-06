using System.Collections.Generic;
using System.Linq;
using Agares.Engine.Collisions;

namespace Agares.Engine.Events.EventTypes
{
	public struct CollisionEvent : IEvent
	{
		private readonly IList<ICollidable> _colliding;

		public CollisionEvent(ICollidable first, ICollidable second) : this()
		{
			_colliding = new List<ICollidable> {first, second};
		}

		public bool Has<T>()
		{
			return _colliding.OfType<T>().Any();
		}

		public T Get<T>()
		{
			return _colliding.OfType<T>().Single();
		}
	}
}