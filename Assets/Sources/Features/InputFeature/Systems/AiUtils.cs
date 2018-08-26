using System.Security.Policy;
using UnityEngine;

namespace cln
{
    public static class AiUtils
    {
        static AiUtils()
        {
        }

        public static bool DetectFront(this GameEntity entity)
        {
            var hasBorder = Physics.Linecast(entity.position.value, entity.position.value + entity.velocity.value);
#if UNITY_EDITOR
            if (hasBorder)
            {
                Debug.DrawLine(entity.position.value, entity.position.value + entity.velocity.value, Color.yellow);
            }
            else
            {
                Debug.DrawLine(entity.position.value, entity.position.value + entity.velocity.value);
            }
#endif

            return hasBorder;
        }

        public static bool DetectLeft(this GameEntity entity)
        {
            RaycastHit hit;
            var direction = entity.view.value.transform.GetChild(1).TransformDirection(Vector3.left);
            if (Physics.Raycast(entity.position.value, direction, out hit, 5f))
            {
                Debug.DrawRay(entity.position.value, direction * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
                return true;
            }
            else
            {
                Debug.DrawRay(entity.position.value, direction * 5f, Color.white);
                Debug.Log("Did not Hit");
                return false;
            }
        }

        public static bool DetectRight(this GameEntity entity)
        {
            RaycastHit hit;
            var direction = entity.view.value.transform.GetChild(1).TransformDirection(Vector3.right);
            if (Physics.Raycast(entity.position.value, direction, out hit, 5f))
            {
                Debug.DrawRay(entity.position.value, direction * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
                return true;
            }
            else
            {
                Debug.DrawRay(entity.position.value, direction * 5f, Color.white);
                Debug.Log("Did not Hit");
                return false;
            }
        }

        private static Vector3 GetDirectionLeft(Vector3 velocity)
        {
            Vector3 result;
            if (velocity.x > 0f && velocity.y > 0f)
            {
                result = velocity + GameConfig.MoveSpeed * GameConfig.DirectionVectors[(int) Direction.West];
            }
            else if (velocity.x > 0f && velocity.y < 0f)
            {
                result = velocity + GameConfig.MoveSpeed * GameConfig.DirectionVectors[(int) Direction.North];
//                result = new Vector3(velocity.x, velocity.y * -1f, velocity.z);
            }
            else if (velocity.x < 0f && velocity.y > 0f)
            {
                result = velocity + GameConfig.MoveSpeed * GameConfig.DirectionVectors[(int) Direction.South];
//                result = new Vector3(velocity.x, velocity.y * -1f, velocity.z);
            }
            else // velocity.x < 0f && velocity.y < 0f
            {
                result = velocity + GameConfig.MoveSpeed * GameConfig.DirectionVectors[(int) Direction.East];
//                result = new Vector3(velocity.x * -1f, velocity.y, velocity.z);
            }

            return result.normalized;
        }
    }
}