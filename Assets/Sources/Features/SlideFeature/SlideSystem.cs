using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class SlideSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _cubeGroup;

        public SlideSystem(IContext<GameEntity> context)
        {
            _cubeGroup = context.GetGroup(GameMatcher.AllOf(GameMatcher.Cube, GameMatcher.View));
        }

        public void Execute()
        {
            foreach (var cubeEntity in _cubeGroup.GetEntities())
            {
                if (cubeEntity.slide.direction == -1 && cubeEntity.velocity.value.x < -10f)
                    return;
                if (cubeEntity.slide.direction == 1 && cubeEntity.velocity.value.x > 10f)
                    return;

                cubeEntity.ReplaceVelocity(cubeEntity.velocity.value +
                                           GameConfig.CubeSlideVelocity * cubeEntity.slide.direction * Time.deltaTime);
            }
        }
    }
}