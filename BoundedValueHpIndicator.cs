using UnityEngine;
using ThornClient.HUD;
using ThornClient.Managers;

namespace ThornExamples;

public class BoundedValueHpIndicator : BoundedValueHudModule {
    public override string[] Tags => ["health", "hit points", "blood", "fuel"];
    public override Sprite Icon => AssetManager.Get<Sprite>(HudManager.BundleKey, "plus_thick");

    // We supply a bound and display name in the constructor
    public BoundedValueHpIndicator() : base("thornExamples.boundedValueHp", "Example Bounded-value HP",
        "Shows current health", bound: 100, decimalPlaces: 0, displayName: "Health") {
    }

    public override void OnUpdate() {
        var nm = NewMovement.Instance;
        if (nm == null) return;

        // Update the main value bar
        Value = nm.hp;

        // Bound reduction indicates a temporary decrease. We use it for showing hard damage
        BoundReduction = nm.antiHp;
    }
}
