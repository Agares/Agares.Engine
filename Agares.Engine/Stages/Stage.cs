using Agares.Engine.Events;

namespace Agares.Engine.Stages
{
	public abstract class Stage : IStage
	{
		private readonly IEventGroup _eventGroup;

		public IEventGroup EventGroup
		{
			get { return _eventGroup; }
		}

		protected Stage()
		{
			_eventGroup = new SimpleEventGroup();
		}

		protected void AddObject(IStageObject stageObject)
		{
			var eventHandler = stageObject as IEventHandler;
			if (eventHandler != null)
			{
				_eventGroup.AddEventHandler(eventHandler);
			}
		}
	}
}