using System;
using ThornClient.Core;
using ThornClient.Core.ConfigurableElements;

namespace ThornExamples;

// We subclass a Module...
public class ConfigOrganization : Module {
    public ConfigOrganization() : base(
        "thornExamples.configOrganization",
        "Config Organization",
        "An example module to show how you can nicely organize your settings",
        ModuleCategory.Misc
    ) {
        // Fruits
        CreateHeader("headerId", "Fruits", "Section containing fruit items");
        CreateHeader("subheaderId", "100% fruits", "", headerType: HeaderType.H2);
        CreateSetting("apple", "Apple", "I'm an enjoyer of apple products, such as apple pie", false);
        CreateSetting("banana", "Banana", "studios", false);
        CreateSetting("coco", "Coconut", "-nut is a giant nut...", false);
        CreateHeader("subheaderId2", "Not fruit in Freedom Land", "", headerType: HeaderType.H2);
        CreateSetting("tomato", "Tomato", "Love me some pasta", false);

        // Groups
        CreateHeader(
            "headerId2", "Thorn HUD module classes hierarchy",
            "This shows the class hierarchy of HUD modules"
        );

        // # HudModule
        var hudModuleGroup = CreateGroup(
            "hudModuleGroup", "HudModule",
            "The base class for draggable HUD modules"
        );

        // ## FramedHudModule
        var framedHudModuleGroup = CreateGroup(
            "framedHudModuleGroup", "FramedHudModule",
            "Class for modules with a background", hudModuleGroup
        );
        CreateSetting(
            "framedHudModuleOption", "Option 0",
            "Nested visually, flat in the config file.",
            false, framedHudModuleGroup
        );

        // ### TextHudModule
        var textHudModuleGroup = CreateGroup(
            "textHudModuleGroup", "TextHudModule",
            "Class for simple text modules", framedHudModuleGroup
        );
        CreateSetting(
            "textHudModuleOption", "Option 1",
            "Very nesty visually. Flat in the config file.",
            false, textHudModuleGroup
        );

        // ### BoundedValueHudModule
        var boundedValueHudModuleGroup = CreateGroup(
            "boundedValueHudModuleGroup", "BoundedValueHudModule",
            "Class for things that have a upper limit: HP, stamina, railcannon charge, etc.", framedHudModuleGroup
        );
        CreateSetting(
            "boundedValueHudModuleOption2", "Option 2",
            "Very nesty visually. Flat in the config file.",
            false, boundedValueHudModuleGroup
        );
    }
}
