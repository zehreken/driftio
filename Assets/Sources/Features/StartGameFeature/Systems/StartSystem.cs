﻿using Entitas;
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
            cubeEntity.AddPrefab("Prefabs/Game/CubeVan");
            cubeEntity.AddPosition(new Vector3(0f, -5f, 0f));
            cubeEntity.AddVelocity(GameConfig.MoveVelocity);
//            cubeEntity.AddSlide(1);
            cubeEntity.AddDirection(Direction.North);
            cubeEntity.isCube = true;
        }
    }
}