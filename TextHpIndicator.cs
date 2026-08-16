using UnityEngine;
using ThornClient.HUD;
using ThornClient.Managers;

namespace ThornExamples;

// Subclassing TextHudModule...
public class TextHpIndicator : TextHudModule {
    // Search tags and icon like a normal Module...
    public override string[] Tags => ["health", "hit points", "blood", "fuel"];
    public override Sprite Icon => AssetManager.Get<Sprite>(HudManager.BundleKey, "plus_thick");

    // Constructor. You can put setting initializations here...
    public TextHpIndicator() : base("thornExamples.textHp", "Example text HP", "Shows current health") {
    }

    public override void OnUpdate() {
        var nm = NewMovement.Instance;
        if (nm == null) return;
        Text = $"{nm.hp}/100";
    }
}
