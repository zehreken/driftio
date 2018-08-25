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

                    ai.AddInput(rnd == 0 ? InputType.Left : InputType.Right);
                }
            }
        }
    }
}