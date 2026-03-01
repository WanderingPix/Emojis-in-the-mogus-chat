namespace Emojis;

public static class Utils
{
    public static string ReformatForEmojis(string text)
    {
        var final = text;
        if (final.Contains("[Sticker]")) final = final.Replace("[Stickers]", "<size=32>");
        foreach (var emoji in Assets.GetEmojiIndex().spriteCharacterTable)
            if (final.Contains($":{emoji.name}:"))
                final = final.Replace($":{emoji.name}:", $"<sprite name={emoji.name}>");

        return final;
    }
}
