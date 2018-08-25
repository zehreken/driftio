using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class StartSystem : IInitializeSystem
    {
        private readonly IContext<GameEntity> _context;

        public StartSystem(IContext<GameEntity> context)
        {
            _context = context;
        }

        public void Initialize()
        {
            Debug.Log("Initialize");

            var cubeEntity = _context.CreateEntity();
            cubeEntity.AddPrefab("Prefabs/Game/CubePickup");
            cubeEntity.AddPosition(new Vector3(0f, -5f, 0f));
            cubeEntity.AddVelocity(GameConfig.MoveVelocity);
//            cubeEntity.AddSlide(1);
            cubeEntity.AddDirection(Direction.North);
            cubeEntity.isCube = true;

            var aiEntity = _context.CreateEntity();
            aiEntity.AddAi("test");
            aiEntity.AddPrefab("Prefabs/Game/CubeVan");
            aiEntity.AddVelocity(GameConfig.MoveVelocity);
            aiEntity.AddDirection(Direction.North);
            aiEntity.AddPosition(Vector3.left * 3f);
        }
    }
}