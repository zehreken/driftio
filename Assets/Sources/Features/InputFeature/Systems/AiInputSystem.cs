﻿using Entitas;
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
            foreach (var ai in _aiGroup.GetEntities())
            {
                if (ai.DetectFront())
                {
                    var rnd = Random.Range(0, 2);
                    if (ai.hasInput)
                        ai.RemoveInput();
                    
                    if (ai.DetectLeft())
                        ai.AddInput(InputType.Right);
                    else if (ai.DetectRight())
                        ai.AddInput(InputType.Left);
                    else
                        ai.AddInput(rnd == 0 ? InputType.Left : InputType.Right);
                }
                else if (_timer >= 3f)
                {
                    _timer = 0f;
                    var rnd = Random.Range(0, 2);
                    var targetDirection = Direction.North;

                    if (!ai.hasInput)
                        ai.AddInput(rnd == 0 ? InputType.Left : InputType.Right);
                }
            }
        }
    }
}