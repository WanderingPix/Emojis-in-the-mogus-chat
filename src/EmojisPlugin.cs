using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Reactor;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using Reactor.Utilities;

namespace Emojis;

[BepInAutoPlugin("MissingPixel.EmojisMod", "Emojis In The Chat", "v2.1.0")]
[BepInProcess("Among Us.exe")]
[BepInDependency(ReactorPlugin.Id)]
[ReactorModFlags(ModFlags.None)]
public partial class EmojisPlugin : BasePlugin
{
    public Harmony Harmony { get; } = new(Id);
    public ConfigEntry<bool> EnableStickersRendering;
    public ConfigEntry<bool> EnableTalkingIndicators; //TODO
    public ConfigEntry<bool> EnableAutoGg;
    public ConfigEntry<bool> EnableMessageTimestamps; //TODO
    public ConfigEntry<bool> EnableColorfulBubbles;
    public ConfigEntry<ChatThemes> ChatTheme;
    public override void Load()
    {
        Harmony.PatchAll();
        EnableStickersRendering = Config.Bind("Emojis", "Enable Stickers Rendering", true);
        EnableTalkingIndicators = Config.Bind("Chatting", "Enable Player Talking Indicators", true);
        EnableMessageTimestamps = Config.Bind("Chatting", "Enable Message Timestamps", true);
        EnableColorfulBubbles = Config.Bind("Chatting", "Enable Colorful Bubbles", true);
        EnableAutoGg = Config.Bind("Chatting", "Enable Auto GG", true);
        ChatTheme = Config.Bind("Chatting", "Chat Theme", ChatThemes.Light);
        ChatTheme.SettingChanged += (sender, args) =>
        {
            HudManager.Instance?.Chat?.SetTheme(PluginSingleton<EmojisPlugin>.Instance.ChatTheme.Value);
            ChatPatches.EmojiSelectMenu?.UpdateTheme();
        };
        ReactorCredits.Register<EmojisPlugin>(ReactorCredits.AlwaysShow);
        Assets.Initialize();
    }

    public enum ChatThemes
    {
        Light,
        Dark,
        PlayerColored
    }
}