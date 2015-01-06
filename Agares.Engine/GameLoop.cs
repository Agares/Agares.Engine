using System;
using System.Diagnostics;
using Agares.Engine.Events;
using Agares.Engine.Events.EventTypes;

namespace Agares.Engine
{
	public class GameLoop
	{
		private bool _running = true;
		private readonly IEventManager _eventManager;

		public GameLoop(IEventManager eventManager)
		{
			_eventManager = eventManager;
		}

		public void Run()
		{
			var stopwatch = new Stopwatch();
			var lastDelta = TimeSpan.Zero;

			while (_running)
			{
				stopwatch.Restart();

				_eventManager.Emit(new LoopEvent(lastDelta));

				stopwatch.Stop();
				lastDelta = stopwatch.Elapsed;
			}
		}

		public void Stop()
		{
			_running = false;
		}
	}
}
