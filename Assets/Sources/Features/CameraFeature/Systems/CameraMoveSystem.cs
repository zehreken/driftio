﻿using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class CameraMoveSystem : IInitializeSystem, IExecuteSystem
    {
        private readonly IContext<GameEntity> _context;
        private Transform _cameraTransform;
        private GameEntity _cubeEntity;

        public CameraMoveSystem(IContext<GameEntity> context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _cameraTransform = Camera.main.transform;
            _cubeEntity = _context.GetGroup(GameMatcher.Cube).GetSingleEntity();
            _cameraTransform.localPosition = _cubeEntity.position.value;
        }

        public void Execute()
        {
            var clampedX = Mathf.Clamp(_cubeEntity.position.value.x, -4f, 4f);
            var diff = new Vector3(clampedX, _cubeEntity.position.value.y - 13f, -27f) -
                       _cameraTransform.position;
            _cameraTransform.Translate(diff * 2f * Time.deltaTime);
        }
    }
}