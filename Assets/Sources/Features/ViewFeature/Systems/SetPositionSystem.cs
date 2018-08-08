using System.Collections.Generic;
using Entitas;

namespace cln
{
    public sealed class SetPositionSystem : ReactiveSystem<GameEntity>
    {
        public SetPositionSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Position.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                gameEntity.view.value.transform.localPosition = gameEntity.position.value;
            }
        }
    }
}