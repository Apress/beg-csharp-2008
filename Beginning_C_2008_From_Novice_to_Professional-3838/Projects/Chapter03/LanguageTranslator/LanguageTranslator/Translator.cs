using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageTranslator {
	public class Translator {
	    public static string TranslateHello(string input) {
	        string temp = input.ToLower().Trim();
	        if (temp.CompareTo("hello") == 0) {
	            return "hallo";
	        }
	        else if (temp.CompareTo("allo") == 0) {
	            return "hallo";
	        }
	        return "";
	    }
	}
}
