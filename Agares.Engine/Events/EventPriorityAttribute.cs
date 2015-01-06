using System;

namespace Agares.Engine.Events
{
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
	public class EventPriorityAttribute : Attribute
	{
		public EventPriority Priority { get; private set; }

		public EventPriorityAttribute(EventPriority priority)
		{
			Priority = priority;
		}
	}
}