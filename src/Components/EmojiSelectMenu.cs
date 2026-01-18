using System;
using System.Collections.Generic;
using Il2CppInterop.Runtime.InteropTypes.Fields;
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

    public void Start()
    {
        Instance = this;
        searchBox.Value.onValueChanged.AddListener(new Action<string>(OnSearchBoxChanged));
        PopulateEmojis();
    }

    public void PopulateEmojis()
    {
        Debug.Log("Populating Emojis");
        foreach (var emoji in emojiAsset.Value.spriteCharacterTable)
        {
            var button = Instantiate(emojiButtonPrefab.Value, emojisParent.Value);
            button.name = "EmojiButton_" + emoji.name;
            var b = button.GetComponent<Button>();
            b.transform.GetChild(0).GetComponent<TMP_Text>().text = $"<sprite name=\"{emoji.name}\">";
            b.onClick.AddListener(new Action(() =>
            {
                Debug.Log("Selected Emoji: " + emoji.name);
                var textBox = HudManager.Instance.Chat.freeChatField.textArea;
                textBox.SetText(textBox.text + ":" + emoji.name + ": ");
            }));
            emojiButtons.Add(b);
        }

        Debug.Log($"Finished Populating Emojis. {emojiButtons.Count} emojis added.");
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
}