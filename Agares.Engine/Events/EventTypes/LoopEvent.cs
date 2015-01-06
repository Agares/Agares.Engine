using System;

namespace Agares.Engine.Events.EventTypes
{
	public struct LoopEvent : IEvent
	{
		public TimeSpan Delta { get; private set; }

		public LoopEvent(TimeSpan delta) : this()
		{
			Delta = delta;
		}
	}
}