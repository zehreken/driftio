using UnityEngine;

namespace cln
{
    public static class AiUtils
    {
        static AiUtils()
        {
        }

        public static bool DetectBorder(this GameEntity entity)
        {
            var hasBorder = Physics.Linecast(entity.position.value, entity.position.value + entity.velocity.value);
            if (hasBorder)
            {
                Debug.DrawLine(entity.position.value, entity.position.value + entity.velocity.value, Color.red);
            }
            else
            {
                Debug.DrawLine(entity.position.value, entity.position.value + entity.velocity.value);
            }

            return hasBorder;
        }
    }
}