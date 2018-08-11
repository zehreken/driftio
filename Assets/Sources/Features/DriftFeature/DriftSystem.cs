using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class DriftSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _carGroup;

        public DriftSystem(IContext<GameEntity> context)
        {
            _carGroup = context.GetGroup(GameMatcher.AllOf(GameMatcher.Cube, GameMatcher.View, GameMatcher.TargetDirection));
        }

        public void Execute()
        {
            foreach (var gameEntity in _carGroup.GetEntities())
            {
                gameEntity.ReplaceVelocity(GameConfig.MoveSpeed *
                                           GameConfig.DirectionVectors[(int) gameEntity.direction.value]);
            }
        }
    }
}