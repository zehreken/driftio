using Entitas;
using UnityEngine;

namespace cln
{
    public class RotateSystem : IInitializeSystem, IExecuteSystem
    {
        private readonly IContext<GameEntity> _context;
        private GameEntity _cube;
        private Transform _carTransform;

        public RotateSystem(IContext<GameEntity> context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _cube = _context.GetGroup(GameMatcher.Cube).GetSingleEntity();
//            _carTransform = _cube.view.value.transform.GetChild(1);
        }

        public void Execute()
        {
            _cube.view.value.transform.GetChild(1).eulerAngles = new Vector3(
                Mathf.Atan2(_cube.velocity.value.y, _cube.velocity.value.x) * Mathf.Rad2Deg + 90f,
                -90f, 90f);
        }
    }
}