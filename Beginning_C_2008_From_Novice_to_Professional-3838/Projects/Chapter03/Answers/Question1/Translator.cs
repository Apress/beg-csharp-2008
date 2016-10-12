using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Threading;

namespace LanguageTranslator {
public class Translator {
	// In this example I use constants to determine the language direction
	// Though a better solution is to use an enum. I did not use an enum because you 
	// have as of yet not learned what an enum is. What this example is meant to illustrate
	// is that you can define constant numeric values
	public const int EnglishToGerman = 1;
	public const int FrenchToGerman = 2;
	
    public static string TranslateHello( int language, string input) {
        string temp = input.ToLower().Trim();
        if (temp.CompareTo("hello") == 0 && EnglishToGerman == language) {
            return "hallo";
        }
        else if (temp.CompareTo("allo") == 0 && FrenchToGerman == language) {
            return "hallo";
        }
        return "";
    }
}
}
