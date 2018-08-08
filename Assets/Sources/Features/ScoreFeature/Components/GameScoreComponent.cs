using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace cln
{
	[Game, Event(false)]
	public sealed class GameScoreComponent : IComponent
	{
		public int value;
	}
}
