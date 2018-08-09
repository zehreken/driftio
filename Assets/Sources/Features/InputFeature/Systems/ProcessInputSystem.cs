using System.Collections.Generic;
using cln.Sources.Services;
using Entitas;

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
                var carEntity = _context.GetGroup(GameMatcher.Cube).GetSingleEntity();
                if (inputEntity.input.type == InputType.Left)
                {
                    switch (carEntity.direction.value)
                    {
                        case Direction.North:
                            carEntity.ReplaceDirection(Direction.West);
                            break;
                        case Direction.East:
                            carEntity.ReplaceDirection(Direction.North);
                            break;
                        case Direction.South:
                            carEntity.ReplaceDirection(Direction.East);
                            break;
                        case Direction.West:
                            carEntity.ReplaceDirection(Direction.South);
                            break;
                    }
                }
                else if (inputEntity.input.type == InputType.Right)
                {
                    switch (carEntity.direction.value)
                    {
                        case Direction.North:
                            carEntity.ReplaceDirection(Direction.East);
                            break;
                        case Direction.East:
                            carEntity.ReplaceDirection(Direction.South);
                            break;
                        case Direction.South:
                            carEntity.ReplaceDirection(Direction.West);
                            break;
                        case Direction.West:
                            carEntity.ReplaceDirection(Direction.North);
                            break;
                    }
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