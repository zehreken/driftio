using Entitas;
using UnityEngine;

namespace cln
{
    [Game]
    public sealed class VelocityComponent : IComponent
    {
        public Vector3 value;
    }
}