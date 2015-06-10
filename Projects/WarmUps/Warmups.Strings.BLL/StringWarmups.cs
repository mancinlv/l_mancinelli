using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Warmups.Strings.BLL
{
   public class StringWarmups
    {
       // string 1
        public string SayHi(string name)
        {
            return "Hello" + " " + name + "!";
        }

       // string 2
        public string Abba(string a, string b)
        {
            return a + b + b + a;
        }

       // string 3
        public string MakeTags(string tag, string content)
        {
            return string.Format("<{0}>{1}</{0}>", tag, content);
        }

       // string 4
        public string InsertWord(string container, string word)
        {
            string start = container.Substring(0, 2);
            string end = container.Substring(2);
            return start + word + end;
        }

       // string 5
        public string MultipleEndings(string str)
        {
            string end = str.Substring(str.Length - 2);
            return end+end+end;
        }

       // string 6
        public string FirstHalf(string str)
        {
            string firstHalf = str.Substring(0,str.Length/2);
            return firstHalf;
        }

       // string 7
        public string TrimOne(string str)
        {
            string middle = str.Substring(1, str.Length-2);
            return middle;
        }

       // string 8
        public string LongInMiddle(string a, string b)
        {
            if (a.Length < b.Length)
            {
                return a + b + a;
            }
            else
            {
                return b + a + b;
            }
        }

       // string 9
        public string Rotateleft2(string str)
        {
            string front = str.Substring(0,2);
            string end = str.Substring(2);
            return end + front;
        }


       // string 10
       public string RotateRight2(string str)
       {
           string end = str.Substring(str.Length - 2);
           string front = str.Substring(0, str.Length - 2);
           return end + front;
       }

       // string 11
       public string TakeOne(string str, bool fromFront)
       {
           if (fromFront == true)
           {
               return str.Substring(0,1);
           }
           else 
           {
              return str.Substring(str.Length - 1); 
           }
           
       }

       //string 12
       public string MiddleTwo(string str)
       {
           int half = str.Length/ 2;
           return str.Substring(half - 1, 2);
           
       }
       
       //string 13
       public bool EndsWithLy(string str)
       {
           
           if (str.EndsWith("ly") == true )
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       //string 14
       public string FrontAndBack(string str, int n)
       {
           string front = str.Substring(0, n);
           string back = str.Substring(str.Length - n);
           return front + back;
       }

       /*string 15 Given a string and an index, return a string length 2 starting at the given index. 
If the index is too big or too small to define a string length 2, use the first 2 chars.
 The string length will be at least 2. TakeTwoFromPosition("java", 0) -> "ja" */

       public string TakeTwoFromPosition(string str, int n)
       {
           string result = "";
           if (n + 2 > str.Length)
           {
               result = str.Substring(0, 2);
               return result;
           }
           else
           {
               result = str.Substring(n, 2);
               return result;
           }
       }

       /* string 16   Given a string, return true if "bad" appears starting at index 0 or 1 in the string, 
such as with "badxxx" or "xbadxx" but not "xxbadxx". The string may be any length, including 0. */
       public bool HasBad(string str)
       {
           if (str.Substring(0, 3) == "bad")
           {
               return true;
           }
           else if (str.Substring(1, 3) == "bad")
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       /* string 17  Given a string, return a string length 2 made of its first 2 chars. 
        * If the string length is less than 2, use '@' for the missing chars. */
       public string AtFirst(string str)
       {
           if (str.Length >= 2)
           {
               return str.Substring(0, 2);
           }
           else
           {
               return str + "@";
           }
       }

       /* string 18  Given 2 strings, a and b, return a new string made of the first char of a and the last char of b, so "yo" and "java"
        * yields "ya".
        * If either string is length 0, use '@' for its missing char. */
       public string LastChars(string a, string b)
       {
           if (a.Length == 0)
           {
               return "@" + b.Substring(b.Length - 1);
           }
           else if (b.Length == 0)
           {
               return a.Substring(0, 1) + "@";
           }
           else
           {
               return a.Substring(0, 1) + b.Substring(b.Length - 1);
           }
       }

       /* string 19 Given two strings, append them together (known as "concatenation") and return the result. However, 
        * if the concatenation creates a double-char, then omit one of the chars, so "abc" and "cat" yields "abcat". */
       public string ConCat(string a, string b)
       {
           if (b.Length == 0) return a;
           if (a.Length == 0) return b;
           if (a[a.Length - 1] == b[0])
           {
               return a.Substring(0, a.Length - 1) + b;
           }
           return a + b;
       }

       //Given a string of any length, return a new string where the last 2 chars, if present, are swapped, so "coding" yields "codign". //
       public string SwapLast(string str)
       {
           if (str.Length < 2) return str;
           string first = str.Substring(0, str.Length - 2);
           string lastTwo = str.Substring(str.Length - 2);
           lastTwo = string.Concat(lastTwo.Reverse());

           return first + lastTwo;
       }

       /* string 21 Given a string, return true if the 
        * first 2 chars in the string also appear at the end of the string, such as with "edited". */
       public bool FrontAgain(string str)
       {
           string first = str.Substring(0, 2);
           string last = str.Substring(str.Length - 2, 2);
           return first == last;
       }

       /* string 22 Given two strings, append them together (known as "concatenation") and return the result.
        * However, if the strings are different lengths, omit chars from the longer string so it is the same length as the shorter string.
        * So "Hello" and "Hi" yield "loHi". The strings may be any length. */
       public string MinCat(string a, string b)
       {
           if (a.Length > b.Length)
           {
               return a.Substring(a.Length - b.Length) + b;
           }
           else if (b.Length > a.Length)
           {
               return a + b.Substring(b.Length - a.Length);
           }
           return a + b;
       }

       /* string 23 Given a string, return a version without the first 2 chars. 
        * Except keep the first char if it is 'a' and keep the second char if it is 'b'. The string may be any length. */
       public string TweakFront(string str)
       {
           string a = str.Substring(0, 1);
           string b = str.Substring(1, 1);

           if (str.Substring(0, 2) == "ab")
           {
               return str;
           }
           else if (str[0] == 'a')
           {
               return a + str.Substring(2);
           }
           else if (str[1] == 'b')
           {
               return str.Substring(1);
           }
          
           return str.Substring(2);
       }

       /*string 24 Given a string, if the first or last chars are 'x',
        * return the string without those 'x' chars, and otherwise return the string unchanged. */
       public string StripX(string str)
       {
           char firstChar = str[0];
           char lastChar = str[str.Length - 1];

           if (lastChar == 'x' && firstChar == 'x')
           {
               return str.Substring(1, str.Length - 2);
           }
           else if (firstChar == 'x')
           {
               return str.Substring(1);
           }
           else if (lastChar == 'x')
           {
               return str.Substring(0, str.Length - 1);
           }
           return str;

       }
    }
}


