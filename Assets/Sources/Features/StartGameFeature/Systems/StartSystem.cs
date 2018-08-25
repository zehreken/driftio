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
            cubeEntity.AddDirection(Direction.North);
            cubeEntity.isPlayer = true;

            var aiEntity = _context.CreateEntity();
            aiEntity.AddAi("test");
            aiEntity.AddPrefab("Prefabs/Game/CubeVan");
            aiEntity.AddVelocity(GameConfig.MoveVelocity);
            aiEntity.AddDirection(Direction.North);
            aiEntity.AddPosition(Vector3.left * 3f);

            var aiEntity2 = _context.CreateEntity();
            aiEntity2.AddAi("test2");
            aiEntity2.AddPrefab("Prefabs/Game/CubeJeep");
            aiEntity2.AddVelocity(GameConfig.MoveVelocity);
            aiEntity2.AddDirection(Direction.North);
            aiEntity2.AddPosition(Vector3.right * 4f);
        }
    }
}