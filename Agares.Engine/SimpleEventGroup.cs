using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Agares.Engine.Events;

namespace Agares.Engine
{
	public class SimpleEventGroup : IEventGroup
	{
		private readonly IDictionary<Type, ICollection<IEventHandler>> _eventHandlers = new Dictionary<Type, ICollection<IEventHandler>>();

		public IReadOnlyDictionary<Type, ICollection<IEventHandler>> EventHandlersForEventTypes
		{
			get { return new ReadOnlyDictionary<Type, ICollection<IEventHandler>>(_eventHandlers); }
		}

		public void AddEventHandler(IEventHandler handler)
		{
			var handlerType = handler.GetType();
			var eventTypes = FindEventTypesForHandler(handlerType);

			foreach (var eventType in eventTypes)
			{
				AddHandlerForEventType(handler, eventType);
			}
		}

		private void AddHandlerForEventType(IEventHandler handler, Type eventType)
		{
			if (!_eventHandlers.ContainsKey(eventType))
			{
				_eventHandlers[eventType] = new List<IEventHandler>();
			}

			_eventHandlers[eventType].Add(handler);
		}

		private IEnumerable<Type> FindEventTypesForHandler(Type handlerType)
		{
			return handlerType
				.GetInterfaces()
				.Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEventHandler<>))
				.Select(x => x.GenericTypeArguments.First());
		}
	}
}