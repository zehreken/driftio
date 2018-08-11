using Entitas;
using UnityEngine;

namespace cln
{
    public class TimerSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _timerGroup;

        public TimerSystem(IContext<GameEntity> context)
        {
            _timerGroup = context.GetGroup(GameMatcher.Timer);
        }

        public void Execute()
        {
            foreach (var gameEntity in _timerGroup.GetEntities())
            {
                gameEntity.timer.remaining -= Time.deltaTime;
                if (gameEntity.timer.remaining < 0f)
                {
                    gameEntity.RemoveTimer();
                }
            }
        }
    }
}