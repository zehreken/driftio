using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class GenerateObstacleSystem : IInitializeSystem, IExecuteSystem
    {
        private readonly IContext<GameEntity> _context;
        private const float TimerStart = 1f;
        private float _timer = 0;
        private int _obstacleIndex = 0;

        public GenerateObstacleSystem(IContext<GameEntity> context)
        {
            _context = context;
        }

        public void Initialize()
        {
            for (int i = 0; i < 2; i++)
            {
                CreateBorder();
                _obstacleIndex++;
            }
        }

        public void Execute()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0f)
            {
                _timer += TimerStart;

                CreateBorder();
                CreateObstacles();

                _obstacleIndex++;
            }
        }

        private void CreateBorder()
        {
//            var fieldEntity = _context.CreateEntity();
//            fieldEntity.AddPrefab("Prefabs/Game/Field");
//            fieldEntity.AddPosition(new Vector3(0f, _obstacleIndex * -20f, -0.4f));
        }

        private void CreateObstacles()
        {
            for (int i = 0; i < 10; i++)
            {
//                var obstacleEntity = _context.CreateEntity();
//                obstacleEntity.AddPrefab("Prefabs/Game/Obstacle");
//                obstacleEntity.AddPosition(new Vector3(Random.Range(-10, 10),
//                    _obstacleIndex * -20f - Random.Range(0, 20), 0f));
//                obstacleEntity.AddVelocity(GameConfig.ObstacleMoveVelocity);
//                obstacleEntity.isObstacle = true;
            }
        }
    }
}