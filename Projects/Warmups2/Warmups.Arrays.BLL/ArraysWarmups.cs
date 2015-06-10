using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.Arrays.BLL
{
    public class ArraysWarmups
    {
        // 1
        public bool FirstLast6(int[] numbers)
        {
            if (numbers[0] == 6 || numbers[numbers.Length - 1] == 6)
            {
                return true;
            }

            else 
                return false;
        }

        // 2
        public bool SameFirstLast(int[] numbers)
        {
            if(numbers[0] == numbers[numbers.Length-1])
            {
                return true;
            }
            else 
                return false;
        }

        // 3
        public int[] MakePi(int n)
        {
            int[] pi = new int[]{3,1,4};
            return pi;
        }

        // 4
        public bool CommonEnd(int[] a, int[] b)
        {
            int endA = a[a.Length - 1];
            int endB = b[b.Length - 1]; 

            if(a[0] == b[0] || endA == endB)
            {
                return true;
            }
            else
                return false;
        }

        // 5

        public int Sum(int[] numbers)
        {
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }

        // 6
        public int[] RotateLeft(int[] numbers)
        {
            int first = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                numbers[i-1] = numbers[i];
                
            }
            numbers[numbers.Length - 1] = first;
            return numbers;
            

        }

         // 7
        public int[] Reverse(int[] numbers)
        {
            int[] reverse = new int[3];
            int reverseCounter = numbers.Length - 1;
            for (int i = 0; i < numbers.Length; i++)
            {
                reverse[reverseCounter] = numbers[i];
                reverseCounter--;
            }
            return reverse;
        }

        // 8
        public int[] HigherWins(int[] numbers)
        {
            int first  =  numbers[0];
            int last = numbers[numbers.Length - 1];
            int [] result = new int[numbers.Length];
            int newNum = 0;

            if(first >= last)
            {
                newNum = first;
            }
            else 
            {
                newNum = last;
            }
            for (int i = 0; i < numbers.Length; i++)
                result[i] = newNum;


            return result;

        }

        // 9

        public int[] GetMiddle(int[] a, int[] b)
        {

            int middleA = a[1];
            int middleB = b[1];
            int[] middles = new int[] { middleA, middleB };
            return middles;
        }

        // 10

        public bool HasEven(int[] numbers)
        {
            
            for(int i = 0; i<numbers.Length; i++)
            {
                if (numbers[i] %2 == 0)
                {
                    return true;
                }

            }
            return false;
        }

        // 11
        public int[] KeepLast(int[] numbers)
        {
            int arrayLength = numbers.Length*2;
            int[] array2 = new int[arrayLength];
            array2[array2.Length - 1] = numbers[numbers.Length - 1];
            return array2;
        }

        // 12
        public bool Double23(int[] numbers)
        {
           
            int count2 = 0;
            int count3 = 0;
            for(int i = 0; i<numbers.Length; i++)
            {
                if (numbers[i] == 2)
                {
                    count2++;
                    
                }
                else if (numbers[i] == 3)
                {
                    count3++;                  
                }
            }
            
                if (count2 == 2 || count3 == 2)
                {
                    return true;
                }
            
                return false;
        }

        // 13
        public int[] Fix23(int[] numbers)
        {
            int[] result = {numbers[0], numbers[1], numbers[2]};

                    if(numbers[0] == 2 && numbers[1]==3)
                    {
                        result[1] = 0;
                    }
                    else if (numbers[1] == 2 && numbers[2] == 3)
                    {
                        result[2] =0;
                    }

                    return result;
        }

        // 14
        public bool Unlucky1(int[] numbers)
        {

            
                if ((numbers[0] == 1 && numbers[1] == 3) || (numbers[1] == 1 && numbers[2] == 3))
                {
                    return true;
                }
                else if (numbers[numbers.Length - 2] == 1 && numbers[numbers.Length - 1] == 3)
                {
                    return true;
                }
            
            return false;
        }

         // 15
        public int[] make2(int[] a, int[] b)
        {
            int[] array = new int[2];

            if(a.Length >= 2)
            {
                array[0] = a[0];
                array[1] = a[1];
                return array;
            }

            else if(a.Length == 1)
            {
                array[0] = a[0];
                array[1] = b[0];
                return array;
            }    

            else if (a.Length == 0)
            {
                array[0] = b[0];
                array[1] = b[1];
                return array;
            }
            return array;

        }

    }
}
