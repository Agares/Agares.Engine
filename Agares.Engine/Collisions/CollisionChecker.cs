using System.Collections.Generic;
using System.Linq;
using Agares.Engine.Events;
using Agares.Engine.Events.EventTypes;

namespace Agares.Engine.Collisions
{
	public class CollisionChecker : IEventHandler<LoopEvent>
	{
		private readonly IDictionary<ICollidable, IList<ICollidable>> _collidablesCollidingWith = new Dictionary<ICollidable, IList<ICollidable>>();
		private readonly IEventManager _eventManager;

		public CollisionChecker(IEventManager eventManager)
		{
			_eventManager = eventManager;
		}

		public void AddCollisionToHandle(ICollidable first, ICollidable second)
		{
			if (!_collidablesCollidingWith.ContainsKey(first))
			{
				_collidablesCollidingWith[first] = new List<ICollidable>();
			}

			_collidablesCollidingWith[first].Add(second);
		}

		public void HandleEvent(LoopEvent @event)
		{
			var events = _collidablesCollidingWith
				.SelectMany(x => GetAllCollisionEventsFor(x.Key, x.Value))
				.ToList();

			_eventManager.EmitMany(events);
		}

		private IEnumerable<CollisionEvent> GetAllCollisionEventsFor(ICollidable collidable, IEnumerable<ICollidable> collidables)
		{
			return collidables
				.Where(y => AreColliding(y, collidable))
				.Select(y => new CollisionEvent(y, collidable));
		}

		private static bool AreColliding(ICollidable first, ICollidable second)
		{
			return first.BoundingRectangle.IntersectsWith(second.BoundingRectangle);
		}

		public void RemoveAllCollisionsWith(ICollidable block)
		{
			_collidablesCollidingWith.Remove(block);

			var collideWith = _collidablesCollidingWith.Where(x => x.Value.Contains(block));
			foreach (var toRemove in collideWith)
			{
				toRemove.Value.Remove(block);
			}
		}
	}
}