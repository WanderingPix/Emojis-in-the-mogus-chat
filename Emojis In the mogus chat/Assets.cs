using Reactor.Utilities;
using TMPro;
using UnityEngine;
using Reactor.Utilities.Extensions;

namespace Emojis;

public static class Assets
{
    public static AssetBundle Bundle = AssetBundleManager.Load("emojibundle");
    public static TMP_SpriteAsset EmojiIndex { get; } = Bundle.LoadAsset<TMPro.TMP_SpriteAsset>("index.asset");
}