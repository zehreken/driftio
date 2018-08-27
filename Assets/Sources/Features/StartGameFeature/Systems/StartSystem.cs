using Entitas;
using UnityEngine;
using zehreken.i_cheat.MiniPool;

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

            var carEntity = _context.CreateEntity();
            carEntity.AddPrefab(PrefabName.Car);
            carEntity.AddPosition(new Vector3(0f, -5f, 0f));
            carEntity.AddSpeed(GameConfig.MoveSpeed);
            carEntity.AddVelocity(Vector3.zero);
            carEntity.AddDirection(Direction.North);
            carEntity.isPlayer = true;

            for (int i = 0; i < 10; i++)
            {
                var aiEntity = _context.CreateEntity();
                aiEntity.AddAi("Ai" + i);
                aiEntity.AddPrefab((PrefabName) Random.Range(2, 8));
                aiEntity.AddPosition(Vector3.left * i);
                aiEntity.AddSpeed(GameConfig.MoveSpeed);
                aiEntity.AddVelocity(GameConfig.MoveVelocity);
                aiEntity.AddDirection(Direction.North);
            }
        }
    }
}