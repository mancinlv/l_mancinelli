using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.Conditionals.BLL
{
    public class ConditionalsWarmups
    {

        // conditionals 1

        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            if ((aSmile == true && bSmile == true) || (aSmile == false && bSmile == false))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Conditionals 2

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            if (isWeekday == false && isVacation == true)
            {
                return true;
            }
            else if (isWeekday == true && isVacation == false)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        // Conditionals 3

        public bool PlayOutside(int temp, bool isSummer)
        {
            if (temp >= 60 && temp <= 90)
            {
                return true;
            }
            else if (temp >= 60 && temp <= 100 && isSummer == true)
            {
                return true;
            }
            else return false;
        }

        // Conditionals 4

        public int Diff21(int n)
        {
            if (n > 21)
            {
                return ((n - 21)*2);
            }
            else
            {
                return 21 - n;
            }
        }

        // Conditionals 5

        public bool ParrotTrouble(bool isTalking, int hour)
        {
            if ((hour < 7 && isTalking == true) || (hour > 20 && isTalking == true))
            {
                return true;
            }
            else if (hour <= 7 || hour >= 20 && isTalking == false)
            {
                return false;
            }
            else
            {
                return false;
            } 
        }

        // Conditionals 6

        public bool Makes10(int a, int b)
        {
            if (a + b == 10)
            {
                return true;
            }
            else if (a == 10 || b == 10)
            {
                return true;
            }
            else
            {
                return false;
            } 
        }

        // Conditionals 7
        public bool NearHundred(int n)
        {
            if ((Math.Abs(n-100) <= 10) || (Math.Abs(n-200) <= 10))
            {
                return true;
            }
            else return false;
        }

        // Conditionals 8

        public bool PosNeg(int a, int b, bool negative)
        {
            if ((a < 0) && (b < 0) && negative == true)
            {
                return true;
            }

            else if (a < 0 || b < 0 && negative == false)
            {
                return true;
            }

            else return false;
        }

        // Conditionals 9

        public string NotString(string s)
        {
            if (s.Length >= 3 && s.Substring(0, 3) == "not")
            {
                return s;
            }
            return "not" + " " + s;
        }

        // Conditionals 10

        public string MissingChar(string str, int n)
        {
            return str.Remove(n, 1);
        }

        // Conditionals 11

        public string FrontBack(string str)
        {
            string front = str.Substring(0, 1);
            string back = str.Substring(str.Length - 1, 1);
            
            
            if (str.Length == 1)
            {
                return str;
            }
            else if (str.Length == 2)
            {
                return back + front;
            }
            else
            {
                string middle = str.Substring(1, str.Length - 2);
                return back + middle + front;
            }
        }

        // Conditionals 12

        public string Front3(string str)
        {

            if (str.Length <= 2)
            {
                return str + str + str;
            }
            else 
            {
                string front = str.Substring(0, 3);
                return front + front + front;
            }
            
        }

        // Conditionals 13

        public string BackAround(string str)
        {
            string last = str.Substring(str.Length - 1, 1);
            
            
            return last + str + last;
        }

        // Conditionals 14

        public bool Multiple3or5(int number)
        {
            if (number % 3 == 0 || number % 5 == 0)
            {
                return true;
            }
            else return false;
        }

        // Conditionals 15

        public bool StartHi(string str)
        {
            string hi = "hi ";

            if(str.Length <= 2 && str.Contains("hi"))
            {
                return true;
            }
            else if(str.Substring(0,3) == hi)
            {
                return true;
            }
            else return false; 
            }

        // Conditional 16
        public bool IcyHot(int temp1, int temp2)
        {
            if (temp1 < 0 && temp2 > 100)  
            {
                return true;
            }
            else if (temp2 < 0 && temp1 > 100)
            {
                return true;
            }
            else if (temp1 > 100 && temp2 < 0)
            {
                return true;
            }

            else return false;
        }

        // Conditionals 17
        public bool Between10and20(int a, int b)
        {
            if (a >= 10 && a <= 20 || b >= 10 && b <= 20)
            {
                return true;
            }
            else return false;
        }

        // Conditionals 18
        public bool HasTeen(int a, int b, int c)
        {
            if ((a >= 13 && a <= 19) || (b >= 13 && b <= 19) || (c >= 13 && c <= 19))
            {
                return true;
            }
            else return false;
        }

        // Conditionals 19
        public bool SoAlone(int a, int b)
        {
            if ((a >= 13 && a <= 19) && (b >= 13 && b <= 19))
            {
                return false;
            }
            else if ((a >= 13 && a <= 19) || (b >= 13 && b <= 19))
            {
                return true;
            }
            else
                return false;
        }

        // Conditionals 20
        public string RemoveDel(string str)
        {
            string first = str.Substring(0, 1);

            if(str.Substring(1,3) == "del")
            {
                return first + str.Substring(4);
            }
            else return str;
        }

        // Conditionals 21
        public bool IxStart(string str)
        {
            if (str.Length >= 3 && str.Substring(1, 2) == "ix")
            {
                return true;
            }
            else return false;
        }

        // Conditionals 22
        public string StartOz(string str)
        {
            if (str.Substring(0, 2) == "oz")
            {
                return "oz";
            }
            else if (str.Substring(0, 1) == "o")
            {
                return "o";
            }
            else if (str.Substring(1, 1) == "z")
            {
                return "z";
            }
            else return "";
        }

        // Conditionals 23
        public int Max(int a, int b, int c)
        {
            if (a > b && a > b)
            {
                return a;
            }
            else if (b > a && b > c)
            {
                return b;
            }
            else return c;
        }

        // Conditionals 24
        public int Closer(int a, int b)
        {
            if (Math.Abs(a - 10) < Math.Abs(b - 10))
            {
                return a;
            }
            else if (Math.Abs(b - 10) < Math.Abs(a - 10))
            {
                return b;
            }
            else return 0;
        }

        // Conditionals 25
        public bool GotE(string str)
        {
            int j = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str.Substring(i) == "e")
                {
                    j++;
                }
            }
            if (j > 3)
            {
                return false;
            }
            else return true;
            
        }

        // Conditionals 26
        public string EndUp(string str)
        {
            

            if (str.Length <= 2)
            {
                return str.ToUpper();
            }
            else if(str.Length >= 3)
            {
                string front = str.Substring(0, str.Length - 3);
                string up = str.Substring(str.Length - 3, 3);
                return front + up.ToUpper();
            }
            else
            {
                return str;
            }
        }

        // Conditionals 27
        public string EveryNth(string str, int n)
        {
            string result = "";
            for (int i = 0; i <= str.Length-n; i += n)
            {
                result = result + i;
            }
            return result;
        }
    }
    
}
