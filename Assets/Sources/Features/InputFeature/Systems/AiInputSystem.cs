using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class AiInputSystem : IExecuteSystem
    {
        private float _timer = 0f;
        private IGroup<GameEntity> _aiGroup;
        public AiInputSystem(IContext<GameEntity> context)
        {
            _aiGroup = context.GetGroup(GameMatcher.Ai);
        }

        public void Execute()
        {
            _timer += Time.deltaTime;
            if (_timer >= 3f)
            {
                _timer = 0f;
                foreach (var ai in _aiGroup.GetEntities())
                {
                    switch (ai.direction.value)
                    {
                        case Direction.North:
                            ai.AddTargetDirection(Direction.West);
                            break;
                        case Direction.East:
                            ai.AddTargetDirection(Direction.North);
                            break;
                        case Direction.South:
                            ai.AddTargetDirection(Direction.East);
                            break;
                        case Direction.West:
                            ai.AddTargetDirection(Direction.South);
                            break;
                    }
                    
                    ai.AddTimer(GameConfig.RotationDuration);
                    ai.AddOnComplete(() =>
                    {
                        ai.ReplaceDirection(ai.targetDirection.value);
                        ai.RemoveTargetDirection();
                    });
                }
            }
        }
    }
}