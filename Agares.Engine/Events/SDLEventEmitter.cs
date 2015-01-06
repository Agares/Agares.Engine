using Agares.Engine.Events.EventTypes;
using Agares.Engine.Geometry;
using SDL2;

namespace Agares.Engine.Events
{
	public class SDLEventEmitter : IEventHandler<LoopEvent>
	{
		private readonly IEventManager _eventManager;

		public SDLEventEmitter(IEventManager eventManager)
		{
			_eventManager = eventManager;
		}

		// Resharper says this function is to complex, probably beacause of PollEvent, nothing I can do about that
		// ReSharper disable once FunctionComplexityOverflow
		public void EmitEvents()
		{
			SDL.SDL_Event eventStructure;
			while (SDL.SDL_PollEvent(out eventStructure) > 0)
			{
				SDL.SDL_Event eventStructure1 = eventStructure;
				switch (eventStructure1.type)
				{
					case SDL.SDL_EventType.SDL_MOUSEMOTION:
						_eventManager.Emit(new MouseMoveEvent(new Point(eventStructure1.motion.x, eventStructure1.motion.y)));
						break;
				}
			}
		}

		public void HandleEvent(LoopEvent @event)
		{
			EmitEvents();
		}
	}
}