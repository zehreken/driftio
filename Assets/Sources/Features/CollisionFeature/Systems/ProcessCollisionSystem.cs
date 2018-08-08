using System.Collections.Generic;
using cln.Sources.Services;
using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class ProcessCollisionSystem : ReactiveSystem<GameEntity>
    {
        private readonly IContext<GameEntity> _context;

        public ProcessCollisionSystem(IContext<GameEntity> context) : base(context)
        {
            _context = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Collision);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var cubeEntity in entities)
            {
                if (cubeEntity.collision.other.CompareTag(GameConfig.ObstacleTag))
                {
                    var endGameEntity = _context.CreateEntity().isEndGame = true;
                    Services.GetAudioService().Play(Clip.Die);
                    Services.GetAdService().ShowInterstitial();
                }
                else if (cubeEntity.collision.other.CompareTag(GameConfig.PlatformTag))
                {
                    cubeEntity.ReplacePosition(new Vector3(cubeEntity.position.value.x,
                        cubeEntity.collision.other.transform.position.y + 20f, cubeEntity.position.value.z));
                    cubeEntity.ReplaceVelocity(
                        new Vector3(cubeEntity.velocity.value.x, 0f, cubeEntity.velocity.value.z));
                }

                cubeEntity.RemoveCollision();
            }
        }
    }
}