using Agares.Engine.Events;

namespace Agares.Engine.Stages
{
	public interface IStage
	{
		IEventGroup EventGroup { get; }
	}
}