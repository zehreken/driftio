using Entitas;
using UnityEngine;

namespace cln
{
    [Game]
    public sealed class CollisionComponent : IComponent
    {
        public GameObject other;
    }
}