using Entitas;

namespace cln
{
    [Game]
    public class SlideComponent : IComponent
    {
        public int direction; // -1 = left, 1 = right
    }
}