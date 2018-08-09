using System.Collections.Generic;
using cln.Sources.Services;
using Entitas;
using zehreken.i_cheat;

namespace cln
{
    public sealed class ProcessInputSystem : ReactiveSystem<GameEntity>
    {
        private readonly IContext<GameEntity> _context;

        public ProcessInputSystem(IContext<GameEntity> context) : base(context)
        {
            _context = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Input);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var inputEntity in entities)
            {
                var cubeEntity = _context.GetGroup(GameMatcher.Cube).GetSingleEntity();
                if (cubeEntity.slide.direction == 1)
                {
                    cubeEntity.ReplaceSlide(-1);
                }
                else
                {
                    cubeEntity.ReplaceSlide(1);
                }

                inputEntity.Destroy();
                Services.GetAudioService().Play(Clip.Jump);
            }
        }
    }

    public enum InputType
    {
        Left,
        Right,
    }
}