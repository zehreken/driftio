using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace cln
{
    [Game, Event(false)]
    public sealed class HighScoreComponent : IComponent
    {
        public int value;
    }
}