//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public cln.TargetDirectionComponent targetDirection { get { return (cln.TargetDirectionComponent)GetComponent(GameComponentsLookup.TargetDirection); } }
    public bool hasTargetDirection { get { return HasComponent(GameComponentsLookup.TargetDirection); } }

    public void AddTargetDirection(cln.Direction newValue) {
        var index = GameComponentsLookup.TargetDirection;
        var component = CreateComponent<cln.TargetDirectionComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTargetDirection(cln.Direction newValue) {
        var index = GameComponentsLookup.TargetDirection;
        var component = CreateComponent<cln.TargetDirectionComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTargetDirection() {
        RemoveComponent(GameComponentsLookup.TargetDirection);
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

    static Entitas.IMatcher<GameEntity> _matcherTargetDirection;

    public static Entitas.IMatcher<GameEntity> TargetDirection {
        get {
            if (_matcherTargetDirection == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TargetDirection);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTargetDirection = matcher;
            }

            return _matcherTargetDirection;
        }
    }
}
