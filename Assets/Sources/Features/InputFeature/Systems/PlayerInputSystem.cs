using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class PlayerInputSystem : IExecuteSystem
    {
        private IContext<GameEntity> _context;
        private GameEntity _playerCarEntity;

        public PlayerInputSystem(IContext<GameEntity> context)
        {
            _context = context;
        }

#if UNITY_EDITOR
        public void Execute()
        {
            if (_playerCarEntity == null)
                _playerCarEntity = _context.GetGroup(GameMatcher.Player).GetSingleEntity();

            if (Input.GetMouseButtonDown(0))
            {
                _playerCarEntity.AddInput(InputType.Left);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                _playerCarEntity.AddInput(InputType.Right);
            }
        }
#elif UNITY_ANDROID
        public void Execute()
        {
            if (_playerCarEntity == null)
                _playerCarEntity = _context.GetGroup(GameMatcher.Player).GetSingleEntity();

            if (Input.touchCount <= 0)
                return;

            if (Input.GetTouch(0).phase != TouchPhase.Began)
                return;

            if (Input.GetTouch(0).position.x <= Screen.width / 2f)
            {
                _playerCarEntity.AddInput(InputType.Left);
            }
            else
            {
                _playerCarEntity.AddInput(InputType.Right);
            }
        }
#endif
    }
}