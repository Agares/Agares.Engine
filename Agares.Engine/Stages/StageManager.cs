using System.Collections.Generic;
using System.Linq;
using Agares.Engine.Events;

namespace Agares.Engine.Stages
{
	public class StageManager : IStageManager
	{
		private readonly IList<IStage> _stages = new List<IStage>();
		private readonly IEventManager _eventManager;
		private IStage _currentStage;

		public StageManager(IEventManager eventManager)
		{
			_eventManager = eventManager;
		}

		public void AddStage(IStage stage)
		{
			_stages.Add(stage);
		}
		
		public void TransitionTo<TStage>() where TStage : IStage
		{
			if (_currentStage != null)
			{
				_eventManager.RemoveGroup(_currentStage.EventGroup);
			}

			var stage = _stages.Single(x => x.GetType() == typeof (TStage));
			_eventManager.AddGroup(stage.EventGroup);
			_currentStage = stage;
		}
	}
}