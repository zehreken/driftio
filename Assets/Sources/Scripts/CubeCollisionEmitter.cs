using Entitas.Unity;
using UnityEngine;

namespace cln
{
    public class CubeCollisionEmitter : MonoBehaviour
    {
        private GameEntity _cubeEntity;

        private void Start()
        {
            _cubeEntity = (GameEntity) GetComponent<EntityLink>().entity;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!_cubeEntity.hasCollision)
            {
                _cubeEntity.AddCollision(other.gameObject);
            }
        }
    }
}