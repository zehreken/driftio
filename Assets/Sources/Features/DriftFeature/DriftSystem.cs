using Entitas;

namespace cln
{
    public sealed class DriftSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _carGroup;
        
        public DriftSystem(IContext<GameEntity> context)
        {
            _carGroup = context.GetGroup(GameMatcher.AllOf(GameMatcher.Cube, GameMatcher.View));
        }

        public void Execute()
        {
            
        }
    }
}