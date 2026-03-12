using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EmojiSelectMenu : MonoBehaviour
{
    public GameObject emojiButtonPrefab;
    public Transform emojisParent;
    public List<Button> emojiButtons;
    public TMP_SpriteAsset emojiAsset;
    public TMP_InputField searchBox;
    public TMP_Dropdown themeDropdown;
    public string CurrentCategory { get; private set; }

    public void SetCurrentCategory(string category)
    {
        CurrentCategory = category;
        ResetEmojis();
        PopulateEmojis();
    }
    public void Start()
    {
        //Instance = this;
        searchBox.onValueChanged.AddListener(new UnityAction<string>(OnSearchBoxChanged));
        PopulateEmojis();
    }

    public void PopulateEmojis()
    {
        Debug.Log("Populating Emojis");
        foreach (var emoji in emojiAsset.spriteCharacterTable.ToArray().Where(x => x.name.StartsWith(CurrentCategory)))
        {
            var button = Instantiate(emojiButtonPrefab, emojisParent);
            button.name = "EmojiButton_" + emoji.name;
            var b = button.GetComponent<Button>();
            b.transform.GetChild(1).GetComponent<TMP_Text>().text = $"<sprite name=\"{emoji.name}\">";
            b.onClick.AddListener(new UnityAction(() =>
            {
                Debug.Log("Selected Emoji: " + emoji.name);
                //var textBox = HudManager.Instance.Chat.freeChatField.textArea;
                //textBox.SetText(textBox.text + ":" + emoji.name + ": ");
            }));
            emojiButtons.Add(b);
        }

        Debug.Log($"Finished Populating Emojis. {emojiButtons.Count} emojis added.");
    }

    public void OnSearchBoxChanged(string searchText)
    {
        foreach (var button in emojiButtons)
        {
            var emojiName = button.transform.GetChild(1).GetComponent<TMP_Text>().text;
            if (emojiName.ToLower().Contains(searchText.ToLower()))
                button.gameObject.SetActive(true);
            else
                button.gameObject.SetActive(false);
        }
    }

    public void Close()
    {
        //HudManager.Instance.Chat.chatScreen.transform.FindChild("CloseBackground").gameObject.SetActive(true);
        //gameObject.Destroy();
    }

    public void ResetEmojis()
    {
        foreach (var button in emojiButtons)
        {
            Destroy(button.gameObject);
        }

        emojiButtons.Clear();
    }
    
    public void OnClickDiscordButton()
    {
        Application.OpenURL("https://discord.gg/PURVHdvnaU");
    }

    public List<GameObject> Tabs;

    public void SwitchTab(int id)
    {
        foreach (var tab in Tabs)
        {
            tab.SetActive(false);
        }
        Tabs[id].SetActive(true);
    }

    public List<Toggle> Toggles;

    public void onToggleOption(Toggle toggle)
    {
    }

    public void OnSetTheme(int theme)
    {
    }
}
