using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Agares.Engine.Utilities;

namespace Agares.Engine.Events
{
	public class EventManager : IEventManager
	{
		private readonly ICollection<IEventGroup> _eventGroups = new List<IEventGroup>();

		public void Emit<TEvent>(TEvent @event) where TEvent : IEvent
		{
			var allEventHandlers = _eventGroups
				.SelectMany(x => x.EventHandlersForEventTypes)
				.GroupBy(x => x.Key)
				.ToDictionary(x => x.Key, x => x.SelectMany(y => y.Value));

			if (!allEventHandlers.ContainsKey(typeof (TEvent)))
			{
				return;
			}

			var currentTypeEventHandlers = allEventHandlers[typeof (TEvent)].Cast<IEventHandler<TEvent>>();
			var orderdEventHandlers = currentTypeEventHandlers.OrderBy(x => GetPriorityForHandlerMethod(GetHandlerMethod<TEvent>(x.GetType())));

			foreach (var eventHandler in orderdEventHandlers)
			{
				eventHandler.HandleEvent(@event);
			}
		}

		private static MethodInfo GetHandlerMethod<TEvent>(Type handlerType) where TEvent : IEvent
		{
			return handlerType
				.GetInterfaceMap(typeof(IEventHandler<TEvent>))
				.TargetMethods
				.Single();
		}

		private static int GetPriorityForHandlerMethod(MethodInfo method)
		{
			if (method.HasCustomAttribute<EventPriorityAttribute>())
			{
				return (int) method.GetCustomAttribute<EventPriorityAttribute>().Priority;
			}

			return (int) EventPriority.Normal;
		}

		public void EmitMany<TEvent>(IEnumerable<TEvent> events) where TEvent : IEvent
		{
			foreach (var @event in events)
			{
				Emit(@event);
			}
		}

		public void RemoveGroup(IEventGroup eventGroup)
		{
			_eventGroups.Remove(eventGroup);
		}

		public void AddGroup(IEventGroup eventGroup)
		{
			_eventGroups.Add(eventGroup);
		}
	}
}
