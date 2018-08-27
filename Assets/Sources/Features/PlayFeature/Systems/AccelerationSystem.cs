using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class AccelerationSystem : IInitializeSystem, IExecuteSystem
    {
        private readonly IContext<GameEntity> _context;
        private IGroup<GameEntity> _carGroup;

        public AccelerationSystem(IContext<GameEntity> context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _carGroup = _context.GetGroup(GameMatcher.Speed);
        }

        public void Execute()
        {
            foreach (var gameEntity in _carGroup.GetEntities())
            {
                if (gameEntity.hasTargetDirection)
                    gameEntity.ReplaceSpeed(GameConfig.MoveSpeed);

                if (gameEntity.speed.value < 10f)
                {
                    gameEntity.speed.value += Time.deltaTime * 2f;
                }
            }
        }
    }
}