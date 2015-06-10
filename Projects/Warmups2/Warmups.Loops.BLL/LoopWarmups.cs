using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.Loops.BLL
{
    public class LoopWarmups
    {
        // loops 1
        public string StringTimes(string str, int n)
        {

            string result = "";
            for (int i = 0; i < n; i++)
            {
                result += str;
            }
            return result;
        }
        // loops 2
        public string FrontTimes(string str, int n)
        {
            string result = "";
            for (int i = 0; i < n; i++)
            {
                result += str.Substring(0,3);
            }
            return result;
        }

        // loops 3
        public int CountXX(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length-1; i++)
            {
                if (str.Substring(i, 2) == "xx")
                {
                    count ++;
                }
            }
            return count;
        }

        // loops 4

        public bool DoubleX(string str)
        {
            int i;
            for (i = 0; i < str.Length - 1; i++)
            {
                if (str.Substring(i, 2) == "xx")
                {
                    return true;
                }
                else if(str.Substring(i,1) == "x" && str.Substring(i+1,1)!= "x")
                {
                    return false;
                }

            }
            return false;
        }

        // loops 5
        public string EveryOther(string str)
        {
            string result = "";
;           for (int i = 0; i < str.Length; i +=2)
            {
                result += str[i];
            }
            return result;


        }

        // loops 6
        public string StringSplosion(string str)
        {
            string result = "";
            for (int i = 1; i <= str.Length; i++)
            {
                result += str.Substring(0,i);
            }
            return result;
        }

        // loops 7
         public int CountLast2(string str)
         {
             int count = 0;
             string end = str.Substring(str.Length - 2,2);
             for (int i = 0; i < str.Length - 2; i++)
             {
                 if (str.Substring(i, 2) == end)
                 {
                     count ++;
                 }
             }
             return count;

         }

         // loops 8
         public int Count9(int[] numbers)
         {
             int count = 0;
            
             for (int i = 0; i<numbers.Length; i++)
             {
                 if (numbers[i] == 9)
                 {
                     count++;
                 }
             }
             return count;
         }

        // loops 9

        public bool ArrayFront9(int[] numbers)
        {
           
            int firstFour = numbers[3];
            for (int i = 0; i < firstFour-1; i++)
            {
                if (i == 9)
                {
                    return true;
                }
            }
            return false;
        }

        // loops 10

        public bool Array123(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if ((numbers[i] == 1) && (numbers[i + 1] == 2) && (numbers[i + 2] == 3))
                {
                    return true;
                }
                
            }
            return false;

        }

        // loops 11

        public int SubStringMatch(string a, string b)
        {
            int counter = 0;
            for (int i = 0; i < b.Length - 1; i++)
            {
                
                if (a.Substring(i, 2) == b.Substring(i, 2))
                {
                    counter++;
                }
            }
            return counter;
        }

        // loops 12

        /* didn't write a loop, but this works. Tried this before but couldn't get it to test out: 
         * string first = str.Substring(0,1);
            string last = str.Substring(str.Length-1,1);
            string middle = str.Substring(1,str.Length -1);
            string result = "";

            for(int i = 0; i<middle.Length -1; i++)
            {
                if(middle.Substring(i) == "x")
                {
                    result = middle.Replace("x", "");
                }
                
            }
            return first + result + last;*/

        public string StringX(string str)
        {
            string first = str.Substring(0, 1);
            string last = str.Substring(str.Length - 1, 1);
            string middle = str.Substring(1, str.Length - 2);

            string result = middle.Replace("x", "");

            return first + result + last;
        }

        // loops 13
        // failed for ("chocolate" --> "chole") expected length 5 but was 4

        public string AltPairs(string str)
        {

            string result = "";
            for (int i = 0; i < str.Length; i += 2)
            {
                result = result + str[i] + str[i+1];
                
            }
            return result;
        }

        // loops 14


        public string DoNotYak(string str)
        {
            string result = "";

            for (int i = 0; i < str.Length-2; i++)
            {
                if ((str.Substring(i, 1) == "y") && (str.Substring(i+2, 1) == "k"))
                {
                    result = str.Substring(i, 3);
                }

            }
            return str.Replace(result, "");
        }

        // loops 15

        public int Array667(int[] numbers)
        {
            int count = 0;

            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if ((numbers[i] == 6 && numbers[i + 1] == 6) || (numbers[i] == 6 && numbers[i + 1] == 7))
                {
                    count++;
                }
            }
            return count;
        }

        // loops 16

        public bool NoTriples(int[] numbers)
        {
            for (int i = 1; i < numbers.Length - 2; i++)
            {
                if (numbers[i] == numbers[i + 1] && numbers[i + 1] == numbers[i + 2])
                {
                    return false;
                }
                
            }
            return true;

        }

        // loops 17

        public bool Pattern51(int[] numbers)
        {
            for (int i = 0; i<numbers.Length -2; i++)
            {
                if((numbers[i]+5 == numbers[i+1]) && (numbers[i]-1 == numbers[i+2] ))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
