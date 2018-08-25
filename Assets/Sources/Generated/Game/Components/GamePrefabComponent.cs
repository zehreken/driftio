//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public cln.PrefabComponent prefab { get { return (cln.PrefabComponent)GetComponent(GameComponentsLookup.Prefab); } }
    public bool hasPrefab { get { return HasComponent(GameComponentsLookup.Prefab); } }

    public void AddPrefab(zehreken.i_cheat.MiniPool.PrefabName newName) {
        var index = GameComponentsLookup.Prefab;
        var component = CreateComponent<cln.PrefabComponent>(index);
        component.name = newName;
        AddComponent(index, component);
    }

    public void ReplacePrefab(zehreken.i_cheat.MiniPool.PrefabName newName) {
        var index = GameComponentsLookup.Prefab;
        var component = CreateComponent<cln.PrefabComponent>(index);
        component.name = newName;
        ReplaceComponent(index, component);
    }

    public void RemovePrefab() {
        RemoveComponent(GameComponentsLookup.Prefab);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherPrefab;

    public static Entitas.IMatcher<GameEntity> Prefab {
        get {
            if (_matcherPrefab == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Prefab);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPrefab = matcher;
            }

            return _matcherPrefab;
        }
    }
}
