using System;
using HarmonyLib;
using Reactor.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Emojis;

[HarmonyPatch]
public static class ChatPatches
{
    public static EmojiSelectMenu EmojiSelectMenu;
    public static PassiveButton EmojiButton;
    public static PassiveButton EmojiButtonAlt; //TODO
    public static void CreateButton()
    {
        var chat = HudManager.Instance.Chat;
        EmojiButton = Object.Instantiate(chat.openKeyboardButton, chat.openKeyboardButton.transform.parent)
            .GetComponent<PassiveButton>();
        var rolloverRend = EmojiButton.GetComponent<SpriteRenderer>();
        rolloverRend.sprite = Assets.GetEmojiButtonHover();
        rolloverRend.size = Vector3.one;
        EmojiButton.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Assets.GetEmojiButton();
        EmojiButton.gameObject.SetActive(true);
        EmojiButton.name = "EmojiButton";
        var pos = chat.openKeyboardButton.transform.localPosition;
        pos.y += 2;
        EmojiButton.transform.localPosition = pos;
        EmojiButton.OnClick = new Button.ButtonClickedEvent();
        EmojiButton.OnClick.AddListener(new Action(() =>
        {
            if (EmojiSelectMenu.Instance) return;
            EmojiSelectMenu = Object.Instantiate(Assets.GetEmojiSelector(), chat.chatScreen.transform)
                .GetComponent<EmojiSelectMenu>();
            HudManager.Instance.Chat.chatScreen.transform.FindChild("CloseBackground").gameObject.SetActive(false);
        }));
    }

    public static void SetTheme(this ChatController chat, EmojisPlugin.ChatThemes theme)
    {
        Color color;
        switch (theme)
        {
            case  EmojisPlugin.ChatThemes.Light:
                color = Color.white;
                break;
            case  EmojisPlugin.ChatThemes.Dark:
                color = new(0.15f, 0.15f, 0.25f, 1);
                break;
            case EmojisPlugin.ChatThemes.PlayerColored:
                color = PlayerControl.LocalPlayer.Data.Color;
                break;
            default:
                color = Color.white;
                break;
        }
        chat.freeChatField.background.color = color;
        chat.backgroundImage.color = color;
        chat.backgroundImage.GetComponent<ButtonRolloverHandler>().OutColor = color;
        chat.quickChatButton.transform.GetChild(0).GetComponent<SpriteRenderer>().color = color;
        chat.banButton.MenuButton.transform.GetChild(0).GetComponent<SpriteRenderer>().color = color;
        chat.chatNotifyDot.color = color;
        chat.openKeyboardButton.transform.GetChild(0).GetComponent<SpriteRenderer>().color = color;
        EmojiButton.transform.GetChild(0).GetComponent<SpriteRenderer>().color = color;
    }

    [HarmonyPatch(typeof(ChatBubble), nameof(ChatBubble.SetText))]
    [HarmonyPostfix]
    public static void SetTextPostfix(ChatBubble __instance, ref string chatText)
    {
        //Emojis
        __instance.TextArea.m_spriteAsset = Assets.GetEmojiIndex();
        __instance.TextArea.text = Utils.ReformatForEmojis(chatText, out bool isSticker);
        if (isSticker)
        {
            __instance.TextArea.ForceMeshUpdate(true, true);
            __instance.Background.size = new Vector2(5.52f, 0.2f + __instance.NameText.GetNotDumbRenderedHeight() + __instance.TextArea.GetNotDumbRenderedHeight());
            __instance.MaskArea.size = __instance.Background.size - new Vector2(0f, 0.03f);
        }
        
        //Chat Bubble Colors
        __instance.Background.color = Color.white;
        __instance.Background.material = new(Shader.Find("Sprites/Default"));
        if (PluginSingleton<EmojisPlugin>.Instance.EnableColorfulBubbles.Value) __instance.Background.color = __instance.playerInfo.Color;
        
        //Timestamps
        var timestampObj = __instance.transform.FindChild("TimestampText");
        if (!timestampObj)
        {
            timestampObj = Object.Instantiate(__instance.NameText, __instance.transform).transform;
            timestampObj.name = "TimestampText";
            timestampObj.transform.localPosition = new(__instance.NameText.transform.localPosition.x * -1,  __instance.NameText.transform.localPosition.y, __instance.transform.localPosition.z);
        }
        var timestampTMP = timestampObj.GetComponent<TextMeshPro>();
        timestampTMP.text = DateTime.Now.ToString("hh:mm:ss tt");
        timestampTMP.ForceMeshUpdate(false, true);
    }

    [HarmonyPatch(typeof(FreeChatInputField), nameof(FreeChatInputField.Awake))]
    [HarmonyPostfix]
    public static void FreeChatInputFieldAwakePostfix(FreeChatInputField __instance)
    {
        __instance.textArea.outputText.m_spriteAsset = Assets.GetEmojiIndex();
    }

    [HarmonyPatch(typeof(ChatController), nameof(ChatController.Awake))]
    [HarmonyPostfix]
    public static void ChatController_Awake_Postfix(ChatController __instance)
    {
        __instance.freeChatField.textArea.allowAllCharacters = true;
        __instance.freeChatField.textArea.AllowSymbols = true;
        __instance.freeChatField.textArea.outputText.m_spriteAsset = Assets.GetEmojiIndex();
        if (PluginSingleton<EmojisPlugin>.Instance.EnableAutoGg.Value && EndGameResult.CachedWinners.Count > 0)
        {
            __instance.StartCoroutine(Effects.ActionAfterDelay(0.4f, new Action(() =>
            {
                __instance.freeChatField.textArea.SetText("GG");
                __instance.SendChat();
            })));
        }
        CreateButton();
        __instance.SetTheme(PluginSingleton<EmojisPlugin>.Instance.ChatTheme.Value);
    }

    [HarmonyPatch(typeof(ChatNotification), nameof(ChatNotification.SetUp))]
    [HarmonyPostfix]
    public static void ChatNotification_SetUp_Postfix(ChatNotification __instance, ref PlayerControl sender)
    {
        if (PluginSingleton<EmojisPlugin>.Instance.EnableColorfulBubbles.Value) __instance.background.color = sender.Data.Color;
    }
}