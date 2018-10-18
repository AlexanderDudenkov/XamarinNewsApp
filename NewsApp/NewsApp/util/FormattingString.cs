using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.util
{
    public class FormattingString : IFormattingString
    {
        public string FormattingDescription(char[] symbols, string desc, int descLength = 20)
        {
            int size = descLength + 1;

            if (size > 0 && desc != null)
            {
                if (desc.Length >= size)
                {
                    var cuttedDesc = desc.Substring(0, size);
                    for (; size > 0; size--)
                    {
                        foreach (var symbol in symbols)
                        {
                            if (cuttedDesc[size - 1] == symbol)
                            {
                                var newDesc = cuttedDesc.Substring(0, size - 1);
                                return newDesc + "...";
                            }
                        }
                    }
                    return "...";
                }
                else
                {
                    return desc;
                }
            }
            return "";
        }
    }
}
