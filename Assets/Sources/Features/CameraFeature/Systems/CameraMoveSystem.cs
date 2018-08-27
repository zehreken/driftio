using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class CameraMoveSystem : IInitializeSystem, IExecuteSystem
    {
        private readonly IContext<GameEntity> _context;
        private Transform _cameraTransform;
        private GameEntity _carEntity;

        public CameraMoveSystem(IContext<GameEntity> context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _cameraTransform = Camera.main.transform;
            _carEntity = _context.GetGroup(GameMatcher.Player).GetSingleEntity();
            _cameraTransform.localPosition = _carEntity.position.value;
        }

        public void Execute()
        {
            var diff = new Vector3(_carEntity.position.value.x, _carEntity.position.value.y, -27f) +
                       8f * GameConfig.DirectionVectors[(int) _carEntity.direction.value] -
                       _cameraTransform.position;

            _cameraTransform.Translate(diff * 1f * Time.deltaTime);
        }
    }
}