using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class MoveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _moveGroup;
        private IContext<GameEntity> _context;

        public MoveSystem(IContext<GameEntity> context)
        {
            _context = context;
            _moveGroup = context.GetGroup(GameMatcher.Velocity);
        }

        public void Execute()
        {
            foreach (var moveEntity in _moveGroup.GetEntities())
            {
                moveEntity.ReplacePosition(moveEntity.position.value + moveEntity.velocity.value * Time.deltaTime);
                if (moveEntity.isCube)
                    moveEntity.ReplaceGameScore((int) -moveEntity.position.value.y);
            }
        }
    }
}