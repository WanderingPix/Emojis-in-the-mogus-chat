using System;
using System.Collections.Generic;
using System.Linq;
using Emojis;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.InteropTypes.Fields;
using Reactor.Utilities;
using Reactor.Utilities.Attributes;
using Reactor.Utilities.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RegisterInIl2Cpp]
public class EmojiSelectMenu(IntPtr ptr) : MonoBehaviour(ptr)
{
    public static EmojiSelectMenu Instance;
    public List<Button> emojiButtons = new();
    public Il2CppReferenceField<TMP_SpriteAsset> emojiAsset;
    public Il2CppReferenceField<GameObject> emojiButtonPrefab;
    public Il2CppReferenceField<Transform> emojisParent;
    public Il2CppReferenceField<TMP_InputField> searchBox;
    public Il2CppReferenceField<TMP_Dropdown> themeDropdown;
    public string CurrentCategory { get; private set; }

    public void SetCurrentCategory(string category)
    {
        CurrentCategory = category;
        ResetEmojis();
        PopulateEmojis();
    }

    public void UpdateTheme()
    {
        var theme = PluginSingleton<EmojisPlugin>.Instance.ChatTheme.Value;
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
        foreach (var image in gameObject.GetComponentsInChildren<Image>())
        {
            image.color = color;
        }
    }
    public void Start()
    {
        SwitchTab(0);
        SetCurrentCategory("");
        Instance = this;
        searchBox.Value.onValueChanged.AddListener(new Action<string>(OnSearchBoxChanged));
        
        foreach (var toggle in Toggles.Value)
        {
            var plugin = PluginSingleton<EmojisPlugin>.Instance;
            bool state = false;
            switch (toggle.gameObject.name)
            {
                case "ColorfulBubblesToggle":
                    state = plugin.EnableColorfulBubbles.Value;
                    break;
                case "TimestampsToggle":
                    state = plugin.EnableMessageTimestamps.Value;
                    break;
                case "StickersRenderingToggle":
                    state = plugin.EnableStickersRendering.Value;
                    break;
                case "AutoGGToggle":
                    state = plugin.EnableAutoGg.Value;
                    break;
            }
            toggle.SetIsOnWithoutNotify(state);
        }
        themeDropdown.Value.SetValueWithoutNotify((int)PluginSingleton<EmojisPlugin>.Instance.ChatTheme.Value);
        UpdateTheme();
    }

    public void PopulateEmojis()
    {
        Debug.Log("Populating Emojis");
        foreach (var emoji in emojiAsset.Value.spriteCharacterTable.ToArray().Where(x => x.name.StartsWith(CurrentCategory)))
        {
            var button = Instantiate(emojiButtonPrefab.Value, emojisParent.Value);
            button.name = "EmojiButton_" + emoji.name;
            var b = button.GetComponent<Button>();
            b.transform.GetChild(1).GetComponent<TMP_Text>().text = $"<sprite name=\"{emoji.name}\">";
            b.onClick.AddListener(new Action(() =>
            {
                Debug.Log("Selected Emoji: " + emoji.name);
                var textBox = HudManager.Instance.Chat.freeChatField.textArea;
                if (textBox.text == "")
                {
                    textBox.SetText("#Sticker" + ":" + emoji.name + ":");
                    HudManager.Instance.Chat.SendChat();
                    return;
                }
                textBox.SetText(textBox.text + ":" + emoji.name + ": ");
            }));
            emojiButtons.Add(b);
        }

        Debug.Log($"Finished Populating Emojis. {emojiButtons.Count} emojis added.");
        
        UpdateTheme();
    }

    public void OnSearchBoxChanged(string searchText)
    {
        foreach (var button in emojiButtons)
        {
            var emojiName = button.transform.GetChild(0).GetComponent<TMP_Text>().text;
            if (emojiName.ToLower().Contains(searchText.ToLower()))
                button.gameObject.SetActive(true);
            else
                button.gameObject.SetActive(false);
        }
    }

    public void Close()
    {
        HudManager.Instance.Chat.chatScreen.transform.FindChild("CloseBackground").gameObject.SetActive(true);
        gameObject.Destroy();
    }

    public void ResetEmojis()
    {
        foreach (var button in emojiButtons)
        {
            button.gameObject.Destroy();
        }
        emojiButtons.Clear();
        
        searchBox.Value.SetText("", false);
    }
    
    public void OnClickDiscordButton()
    {
        Application.OpenURL("https://discord.gg/PURVHdvnaU");
    }
    
    public Il2CppReferenceField<Il2CppReferenceArray<GameObject>> Tabs;

    public void SwitchTab(int id)
    {
        foreach (var tab in Tabs.Value)
        {
            tab.SetActive(false);
        }
        Tabs.Value[id].SetActive(true);
    }
    
    public Il2CppReferenceField<Il2CppReferenceArray<Toggle>> Toggles;
    public void onToggleOption(Toggle toggle)
    {
        var plugin = PluginSingleton<EmojisPlugin>.Instance;
        switch (toggle.gameObject.name)
        {
            case "ColorfulBubblesToggle":
                plugin.EnableColorfulBubbles.Value = toggle.isOn;
                break;
            case "TimestampsToggle":
                plugin.EnableMessageTimestamps.Value = toggle.isOn;
                break;
            default:
                break;
        }
        plugin.Config.Save();
    }

    public void OnSetTheme(int theme)
    {
        PluginSingleton<EmojisPlugin>.Instance.ChatTheme.Value = (EmojisPlugin.ChatThemes) theme;
        PluginSingleton<EmojisPlugin>.Instance.Config.Save();
    }
}
