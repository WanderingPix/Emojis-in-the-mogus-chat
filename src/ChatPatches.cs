using System;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Emojis;

[HarmonyPatch]
public class ChatPatches
{
    public static EmojiSelectMenu EmojiSelectMenu;

    public static void CreateButton()
    {
        var chat = HudManager.Instance.Chat;
        var button = Object.Instantiate(chat.openKeyboardButton, chat.openKeyboardButton.transform.parent)
            .GetComponent<PassiveButton>();
        var rolloverRend = button.GetComponent<SpriteRenderer>();
        rolloverRend.sprite = Assets.GetEmojiButtonHover();
        rolloverRend.size = Vector3.one;
        button.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Assets.GetEmojiButton();
        button.gameObject.SetActive(true);
        button.name = "EmojiButton";
        var pos = chat.openKeyboardButton.transform.localPosition;
        pos.y += 2;
        button.transform.localPosition = pos;
        button.OnClick = new Button.ButtonClickedEvent();
        button.OnClick.AddListener(new Action(() =>
        {
            if (EmojiSelectMenu.Instance) return;
            EmojiSelectMenu = Object.Instantiate(Assets.GetEmojiSelector(), chat.chatScreen.transform)
                .GetComponent<EmojiSelectMenu>();
            HudManager.Instance.Chat.chatScreen.transform.FindChild("CloseBackground").gameObject.SetActive(false);
        }));
    }

    [HarmonyPatch(typeof(ChatBubble), nameof(ChatBubble.SetText))]
    [HarmonyPostfix]
    public static void SetTextPostfix(ChatBubble __instance, ref string chatText)
    {
        __instance.TextArea.m_spriteAsset = Assets.GetEmojiIndex();
        __instance.TextArea.text = Utils.ReformatForEmojis(chatText);
    }

    [HarmonyPatch(typeof(FreeChatInputField), nameof(FreeChatInputField.Awake))]
    [HarmonyPostfix]
    public static void FreeChatInputFieldAwakePostfix(FreeChatInputField __instance)
    {
        __instance.textArea.outputText.m_spriteAsset = Assets.GetEmojiIndex();
    }

    [HarmonyPatch(typeof(ChatController), nameof(ChatController.Awake))]
    [HarmonyPostfix]
    public static void SetTextPostfix(ChatController __instance)
    {
        __instance.freeChatField.textArea.allowAllCharacters = true;
        __instance.freeChatField.textArea.AllowSymbols = true;
        __instance.freeChatField.textArea.outputText.m_spriteAsset = Assets.GetEmojiIndex();

        CreateButton();
    }
}