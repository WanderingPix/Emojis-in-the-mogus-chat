using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Reactor;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using Reactor.Utilities;

namespace Emojis;

[BepInAutoPlugin("MissingPixel.EmojisMod", "Emojis In The Chat", "v2.0.0")]
[BepInProcess("Among Us.exe")]
[BepInDependency(ReactorPlugin.Id)]
[ReactorModFlags(ModFlags.None)]
public partial class EmojisPlugin : BasePlugin
{
    public Harmony Harmony { get; } = new(Id);
    public ConfigFile GetConfigFile() => Config;
    public override void Load()
    {
        Harmony.PatchAll();
        ReactorCredits.Register<EmojisPlugin>(ReactorCredits.AlwaysShow);
        Assets.Initialize();
    }
}
