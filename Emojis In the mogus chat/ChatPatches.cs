using HarmonyLib;
using Reactor.Utilities;
using TMPro;

namespace Emojis
{
    [HarmonyPatch]
    public class ChatPatches
    {
        [HarmonyPatch(typeof(ChatBubble), nameof(ChatBubble.SetText))]
        public static void Postfix(ChatBubble __instance, ref string chatText)
        {
            __instance.TextArea.m_spriteAsset = Assets.EmojiIndex;
            __instance.TextArea.text = Utils.ReformatForEmojis(chatText);
        }
    }
}
