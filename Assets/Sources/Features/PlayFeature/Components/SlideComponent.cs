using System;
using Entitas;

namespace cln
{
    [Game]
    [Obsolete]
    public class SlideComponent : IComponent
    {
        public int direction; // -1 = left, 1 = right
    }
}