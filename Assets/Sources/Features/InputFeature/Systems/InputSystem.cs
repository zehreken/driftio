using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class InputSystem : IExecuteSystem
    {
        private IContext<GameEntity> _context;

        public InputSystem(IContext<GameEntity> context)
        {
            _context = context;
        }

#if UNITY_EDITOR
        public void Execute()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _context.CreateEntity().AddInput(InputType.Left);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                _context.CreateEntity().AddInput(InputType.Right);
            }
        }
#elif UNITY_ANDROID
        public void Execute()
        {
            if (Input.touchCount <= 0)
                return;

            if (Input.GetTouch(0).phase != TouchPhase.Began)
                return;

            if (Input.GetTouch(0).position.x <= Screen.width / 2f)
            {
                _context.CreateEntity().AddInput(InputType.Left);
            }
            else
            {
                _context.CreateEntity().AddInput(InputType.Right);
            }
        }
#endif
    }
}