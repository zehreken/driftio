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
                    var rnd = Random.Range(0, 2);
                    var targetDirection = Direction.North;
                    switch (ai.direction.value)
                    {
                        case Direction.North:
                            targetDirection = rnd == 0 ? Direction.West : Direction.East;
                            ai.AddTargetDirection(targetDirection);
                            break;
                        case Direction.East:
                            targetDirection = rnd == 0 ? Direction.North : Direction.South;
                            ai.AddTargetDirection(targetDirection);
                            break;
                        case Direction.South:
                            targetDirection = rnd == 0 ? Direction.West : Direction.East;
                            ai.AddTargetDirection(targetDirection);
                            break;
                        case Direction.West:
                            targetDirection = rnd == 0 ? Direction.North : Direction.South;
                            ai.AddTargetDirection(targetDirection);
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