using System.Collections.Generic;
using Entitas;

namespace cln
{
    public class OnCompleteSystem : ReactiveSystem<GameEntity>
    {
        private IContext<GameEntity> _context;

        public OnCompleteSystem(IContext<GameEntity> context) : base(context)
        {
            _context = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Timer.Removed());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasOnComplete;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                gameEntity.onComplete.act();
                gameEntity.RemoveOnComplete();
            }
        }
    }
}