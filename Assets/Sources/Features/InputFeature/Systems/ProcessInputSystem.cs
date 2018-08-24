﻿using System.Collections.Generic;
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
                if (carEntity.hasTargetDirection)
                {
                    inputEntity.Destroy();
                    return;
                }

                if (inputEntity.input.type == InputType.Left)
                {
                    switch (carEntity.direction.value)
                    {
                        case Direction.North:
                            carEntity.AddTargetDirection(Direction.West);
                            break;
                        case Direction.East:
                            carEntity.AddTargetDirection(Direction.North);
                            break;
                        case Direction.South:
                            carEntity.AddTargetDirection(Direction.East);
                            break;
                        case Direction.West:
                            carEntity.AddTargetDirection(Direction.South);
                            break;
                    }
                }
                else if (inputEntity.input.type == InputType.Right)
                {
                    switch (carEntity.direction.value)
                    {
                        case Direction.North:
                            carEntity.AddTargetDirection(Direction.East);
                            break;
                        case Direction.East:
                            carEntity.AddTargetDirection(Direction.South);
                            break;
                        case Direction.South:
                            carEntity.AddTargetDirection(Direction.West);
                            break;
                        case Direction.West:
                            carEntity.AddTargetDirection(Direction.North);
                            break;
                    }
                }
                
                carEntity.AddTimer(GameConfig.RotationDuration);
                carEntity.AddOnComplete(() =>
                {
                    carEntity.ReplaceDirection(carEntity.targetDirection.value);
                    carEntity.RemoveTargetDirection();
                });

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