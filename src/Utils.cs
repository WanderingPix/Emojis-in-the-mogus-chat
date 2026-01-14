namespace Emojis
{
    public static class Utils
    {
        public static string ReformatForEmojis(string text)
        {
            string final = text;

            foreach (var emoji in Assets.GetEmojiIndex().spriteCharacterTable)
            {
                if (final.Contains($":{emoji.name}:"))
                    final = final.Replace($":{emoji.name}:", $"<sprite name={emoji.name}>");
            }
            
            return final;
        }
    }
}