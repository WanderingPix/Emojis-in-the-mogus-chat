using Reactor.Utilities;

namespace Emojis;

public static class Utils
{
    public static string ReformatForEmojis(string text, out bool isSticker)
    {
        var final = text;
        isSticker = final.Contains("#Sticker");
        if (isSticker)
        {
            if (PluginSingleton<EmojisPlugin>.Instance.EnableStickersRendering.Value)
                final = final.Replace("#Sticker", "<size=32>");
            else final = final.Replace("#Sticker", "");
        }
        foreach (var emoji in Assets.GetEmojiIndex().spriteCharacterTable)
            if (final.Contains($":{emoji.name}:"))
                final = final.Replace($":{emoji.name}:", $"<sprite name={emoji.name}>");

        return final;
    }
}
