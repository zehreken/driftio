using Entitas;
using zehreken.i_cheat;

namespace cln
{
    public sealed class GameController
    {
        private Systems _systems;

        public GameController()
        {
            _systems = new GameSystems(Contexts.sharedInstance);
            _systems.Initialize();
        }

        public void Update(float deltaTime)
        {
            _systems.Execute();
            _systems.Cleanup();
        }

        public void Destroy()
        {
            Dbg.Log("End game");
            _systems.Cleanup();
            _systems.ClearReactiveSystems();
            _systems.DeactivateReactiveSystems();
            _systems.TearDown();
        }
    }
}