using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.util
{
   public interface IFormattingString
    {
       string FormattingDescription(char[] symbols, string desc, int descLength = 10);
    }
}
