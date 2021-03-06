﻿namespace cln
{
    public sealed class GameSystems : Feature
    {
        public GameSystems(Contexts contexts)
        {
            Add(new GameEventSystems(contexts));

            Add(new StartSystem(contexts.game));

            Add(new AddViewSystem(contexts.game));

            Add(new PlayerInputSystem(contexts.game));

            Add(new AiInputSystem(contexts.game));

            Add(new ProcessInputSystem(contexts.game));

//            Add(new GenerateObstacleSystem(contexts.game));

            Add(new AccelerationSystem(contexts.game));

            Add(new DriftSystem(contexts.game));

//            Add(new SlideSystem(contexts.game));

            Add(new MoveSystem(contexts.game));

            Add(new ProcessCollisionSystem(contexts.game));

            Add(new SetPositionSystem(contexts.game));

            Add(new CameraMoveSystem(contexts.game));

            Add(new RotateSystem(contexts.game));

            Add(new ScoreSystem(contexts.game));

            Add(new TimerSystem(contexts.game));

            Add(new OnCompleteSystem(contexts.game));

            Add(new EndSystem(contexts.game));
        }
    }
}