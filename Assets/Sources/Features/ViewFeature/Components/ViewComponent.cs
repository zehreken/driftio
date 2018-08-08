using Entitas;
using UnityEngine;

namespace cln
{
    [Game]
    public sealed class ViewComponent : IComponent
    {
        public GameObject value;
    }
}