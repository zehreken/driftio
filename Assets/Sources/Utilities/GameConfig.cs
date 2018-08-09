using UnityEngine;

namespace cln
{
    public static class GameConfig
    {
        public static readonly Vector3 MoveSpeed = new Vector3(5f, 5f, 0);
        public static readonly Vector3 CubeMoveVelocity = new Vector3(0f, -5f, 0f);
        public static readonly Vector3 CubeVelocityStep = new Vector3(0f, -1f, 0f);
        public static readonly Vector3 CubeSlideVelocity = new Vector3(20f, 0f, 0f);
        public static readonly Vector3 ObstacleMoveVelocity = new Vector3(0f, -2f, 0f);
        public const float CubeVelocityStepTimer = 5f;

        public const string ObstacleTag = "Obstacle";
        public const string PlatformTag = "Platform";

        public static readonly Vector3[] DirectionVectors =
        {
            new Vector3(1f, 1f, 0f),
            new Vector3(1f, -1f, 0f),
            new Vector3(-1f, -1f, 0f), 
            new Vector3(-1f, 1f, 0f), 
        };

        public static readonly Color[] Colors = {Color.blue, Color.green, Color.red, Color.cyan};
    }

    public enum Direction
    {
        North,
        East,
        South,
        West,
    }

    public static class Consts
    {
        public const string HighScoreKey = "high_score";
        public const string MuteKey = "is_muted";
    }
}