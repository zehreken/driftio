using Entitas;
using UnityEngine;

namespace cln
{
    public class RotateSystem : IInitializeSystem, IExecuteSystem
    {
        private readonly IContext<GameEntity> _context;
        private IGroup<GameEntity> _vehicles;
        private Transform _carTransform;

        public RotateSystem(IContext<GameEntity> context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _vehicles = _context.GetGroup(GameMatcher.Velocity);
//            _carTransform = _cube.view.value.transform.GetChild(1);
        }

        public void Execute()
        {
            foreach (var vehicle in _vehicles.GetEntities())
            {
                vehicle.view.value.transform.GetChild(1).eulerAngles = new Vector3(
                    Mathf.Atan2(vehicle.velocity.value.y, vehicle.velocity.value.x) * Mathf.Rad2Deg + 180f,
                    -90f, 90f);
            }
        }
    }
}