using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class DriftSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _carGroup;

        public DriftSystem(IContext<GameEntity> context)
        {
            _carGroup = context.GetGroup(GameMatcher.View);
        }

        public void Execute()
        {
            foreach (var gameEntity in _carGroup.GetEntities())
            {
                if (gameEntity.hasTargetDirection)
                {
                    // Lerping from target to current because timer is decreasing
                    gameEntity.ReplaceVelocity(gameEntity.speed.value * Vector3.Lerp(
                                                   GameConfig.DirectionVectors[(int) gameEntity.targetDirection.value],
                                                   GameConfig.DirectionVectors[(int) gameEntity.direction.value],
                                                   gameEntity.timer.remaining / GameConfig.RotationDuration));
                }
                else
                {
                    gameEntity.ReplaceVelocity(gameEntity.speed.value *
                                               GameConfig.DirectionVectors[(int) gameEntity.direction.value]);
                }
            }
        }
    }
}