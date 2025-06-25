using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emojis
{
    public static class Utils
    {
        public static string ReformatForEmojis(string text)
        {
            string final = text; 
            
            if (final.Contains($":shrug:")) final = final.Replace($":shrug:", $"<sprite name=shrug>");
            
            if (final.Contains($":star:")) final = final.Replace($":star:", $"<sprite name=star>");
            
            if (final.Contains($":ihateithere:")) final = final.Replace($":ihateithere:", $"<sprite name=ihateithere>");
            
            if (final.Contains($":hehcry:")) final = final.Replace($":hehcry:", $"<sprite name=hehcry>");
            
            if (final.Contains($":heh:")) final = final.Replace($":heh:", $"<sprite name=heh>");
            
            if (final.Contains($":hehsip:")) final = final.Replace($":hehsip:", $"<sprite name=hehsip>");
            
            if (final.Contains($":uhh:")) final = final.Replace($":uhh:", $"<sprite name=uhh>");
            
            if (final.Contains($":thinking:")) final = final.Replace($":thinking:", $"<sprite name=thinking>");

            if (final.Contains($":blush:")) final = final.Replace($":blush:", $"<sprite name=blush>");
            
            if (final.Contains($":sus:")) final = final.Replace($":sus:", $"<sprite name=sus>");

            if (final.Contains($":sob:")) final = final.Replace($":sob:", $"<sprite name=sob>");
            
            return final;
        }
    }
}