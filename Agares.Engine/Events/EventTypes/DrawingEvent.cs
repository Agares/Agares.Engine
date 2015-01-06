namespace Agares.Engine.Events.EventTypes
{
	public struct DrawingEvent : IEvent
	{
		public IRenderer Renderer { get; private set; }

		public DrawingEvent(IRenderer renderer) : this()
		{
			Renderer = renderer;
		}
	}
}