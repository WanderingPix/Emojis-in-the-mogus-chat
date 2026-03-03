namespace Emojis;

public static class Utils
{
    public static string ReformatForEmojis(string text, out bool isSticker)
    {
        var final = text;
        isSticker = final.Contains("#Sticker");
        if (isSticker) final = final.Replace("#Sticker", "<size=32>");
        foreach (var emoji in Assets.GetEmojiIndex().spriteCharacterTable)
            if (final.Contains($":{emoji.name}:"))
                final = final.Replace($":{emoji.name}:", $"<sprite name={emoji.name}>");

        return final;
    }
}
