using UnityEngine;
using System;
using ThornClient.Managers;
using ThornClient.System;
using ThornClient.Core;
using ThornClient.Core.ConfigurableElements;

namespace ThornExamples;

// We're subclass a Module...
public class Bleeding : Module {
    // Replace this with your own icon...
    // AssetManager in this case is from ThornClient.Managers
    public override Sprite Icon => AssetManager.Get<Sprite>(ClickGUI.BundleKey, "cube");

    // Tags for searching in the menu.
    // Use related keywords that are not already present in the module name
    public override string[] Tags => ["hurt", "hp"];

    // Getter for cheat reason. A non-empty string means it's cheaty. You should declare any module that alters the mechanics as cheaty.
    // It's necessary to call `CheatManager.UpdateCheatiness();` when this becomes true
    //   - In this case, it's when the module gets enabled, which we will see below...
    public override string CheatReason => IsEnabled ? "Enables non-standard gameplay" : "";

    // We declare settings to allow customization of the bleeding
    // Setting is from the ThornClient.Core namespace
    public Setting<int> DamagePerTick;
    public Setting<float> DamageTickInterval;

    // This is the constructor, passing the GUID, name, and description to the base Module class.
    // The GUID should be unique. it's recommended to use a yourPluginName.yourModuleName
    //   syntax, but as long as you are absolutely sure it's unique, it's fine.
    public Bleeding() : base("thornExamples.bleeding", "Bleeding", "Makes you constantly bleed",
        ModuleCategory.Gameplay) {
        DamagePerTick = CreateSetting(
            "dmgPerTick", "Damage per tick", "How much to bleed each tick", 5
        );
        DamageTickInterval = CreateSetting(
            "dmgTickInterval", "Damage tick interval", "Duration between damage ticks", 2f
        );
    }

    // This method runs once when the module is enabled. Here you should add any setup or event subscribing...
    // If it's enabled from a previous session, this will also trigger on game launch.
    protected override void OnEnable() {
        CheatManager.UpdateCheatiness(); // As we discussed earlier...
        Console.WriteLine("Bleeding module ENABLED");
    }

    // This runs once when the module is disabled. Unsubscribe events here...
    protected override void OnDisable() {
        Console.WriteLine("Bleeding module DISABLED");
    }

    // Just for convenience
    private static NewMovement? nm => NewMovement.Instance;
    private static StatsManager? sman => StatsManager.Instance;

    // Here's the plan: we constantly poll in the update loop. If the time since last
    //   damage tick is greater than the interval, we damage. The below variable is to
    //   track that time since last damage tick
    private float _cumulatedTime = 0;

    // This is run every frame, similar to MonoBehaviour.Update()
    public override void OnUpdate() {
        // Null check
        if (nm == null || sman == null) return;

        // Skip damaging if the run hasn't started
        if (!sman.timer) return;

        // Keep track of the time since last damage tick
        _cumulatedTime += Time.deltaTime;

        // If it's been long enough, we damage
        if (_cumulatedTime >= DamageTickInterval.Value) {
            TickDamage();
            _cumulatedTime %= DamageTickInterval.Value;
        }
    }

    private void TickDamage() {
        if (nm == null) return;
        nm.GetHurt(DamagePerTick.Value, false, 1);
    }
}
