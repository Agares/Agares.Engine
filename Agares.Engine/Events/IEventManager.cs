using System.Collections.Generic;

namespace Agares.Engine.Events
{
	public interface IEventManager
	{
		void Emit<TEvent>(TEvent @event) where TEvent : IEvent;
		void EmitMany<TEvent>(IEnumerable<TEvent> events) where TEvent : IEvent;
		void RemoveGroup(IEventGroup eventGroup);
		void AddGroup(IEventGroup eventGroup);
	}
}