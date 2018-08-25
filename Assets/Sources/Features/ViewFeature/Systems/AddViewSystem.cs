using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using zehreken.i_cheat.MiniPool;

namespace cln
{
    public sealed class AddViewSystem : ReactiveSystem<GameEntity>, ITearDownSystem
    {
        private readonly Transform _gameContainer;
        private PrefabDictionary _prefabDictionary;

        public AddViewSystem(IContext<GameEntity> context) : base(context)
        {
            _gameContainer = new GameObject("GameContainer").transform;
            _prefabDictionary = Resources.Load<PrefabDictionary>("PrefabDictionary");
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Prefab);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                gameEntity.AddView(MiniPool.Create(gameEntity.prefab.name, gameEntity.position.value));
                gameEntity.view.value.transform.SetParent(_gameContainer);

                if (gameEntity.isPlayer)
                {
                    gameEntity.view.value.AddComponent<EntityLink>().Link(gameEntity, Contexts.sharedInstance.game);
                    gameEntity.view.value.AddComponent<CubeCollisionEmitter>();
                }
                else if (gameEntity.isObstacle)
                {
                    gameEntity.view.value.transform.GetChild(0).GetComponent<MeshRenderer>().material =
                        Resources.Load<MaterialDictionary>("Materials").GetRandomMaterial();
                }
            }
        }

        public void TearDown()
        {
            Object.Destroy(_gameContainer.gameObject);
        }
    }
}