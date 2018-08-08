﻿using Entitas;
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
    }
}