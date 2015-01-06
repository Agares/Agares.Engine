using System;
using System.Collections.Generic;

namespace Agares.Engine.Events
{
	public interface IEventGroup
	{
		IReadOnlyDictionary<Type, ICollection<IEventHandler>> EventHandlersForEventTypes { get; }
		void AddEventHandler(IEventHandler handler);
	}
}