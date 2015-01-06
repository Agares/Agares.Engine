namespace Agares.Engine.Stages
{
	public interface IStageManager
	{
		void AddStage(IStage stage);
		void TransitionTo<TStage>() where TStage : IStage;
	}
}