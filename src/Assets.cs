using System.Reflection;
using Emojis.Utilities;
using Reactor.Utilities;
using Reactor.Utilities.Extensions;
using Rewired.Utils;
using TMPro;
using UnityEngine;

namespace Emojis;

public static class Assets
{
    public static AssetBundle Bundle;
    private static TMP_SpriteAsset EmojiIndex;
    private static GameObject EmojiSelector;
    private static Sprite EmojiButton;
    private static Sprite EmojiButtonHover;

    public static void Initialize()
    {
        Bundle = AssetBundleManager.Load("emojibundle").DontDestroy();
    }

    public static TMP_SpriteAsset GetEmojiIndex()
    {
        if (EmojiIndex.IsNullOrDestroyed())
            EmojiIndex = Bundle.LoadAsset<TMP_SpriteAsset>("Index.asset").DontDestroy().DontUnload();

        if (EmojiIndex.IsNullOrDestroyed())
        {
            PluginSingleton<EmojisPlugin>.Instance.Log.LogError($"Could not load emoji index!");
            return null;
        }

        return EmojiIndex;
    }

    public static GameObject GetEmojiSelector()
    {
        if (EmojiSelector.IsNullOrDestroyed()) EmojiSelector = Bundle.LoadAsset<GameObject>("EmojiSelector.prefab");

        if (EmojiSelector.IsNullOrDestroyed())
        {
            PluginSingleton<EmojisPlugin>.Instance.Log.LogError($"Could not load emoji selector!");
            return null;
        }

        return EmojiSelector;
    }

    public static Sprite GetEmojiButton()
    {
        if (EmojiButton.IsNullOrDestroyed())
            EmojiButton =
                SpriteTools.LoadSpriteFromPath("Emojis.Resources.EmojiButton.png", Assembly.GetCallingAssembly(), 128);

        if (EmojiButton.IsNullOrDestroyed())
        {
            PluginSingleton<EmojisPlugin>.Instance.Log.LogError($"Could not load emoji button sprite!");
            return null;
        }

        return EmojiButton;
    }

    public static Sprite GetEmojiButtonHover()
    {
        if (EmojiButtonHover.IsNullOrDestroyed())
            EmojiButtonHover = SpriteTools.LoadSpriteFromPath("Emojis.Resources.EmojiButtonHover.png",
                Assembly.GetCallingAssembly(), 82);

        if (EmojiButtonHover.IsNullOrDestroyed())
        {
            PluginSingleton<EmojisPlugin>.Instance.Log.LogError($"Could not load emoji button hover sprite!");
            return null;
        }

        return EmojiButtonHover;
    }
}