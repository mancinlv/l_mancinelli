using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.Logic.BLL
{
    public class LogicWarmups
    {
        // Logic 1
        public bool GreatParty(int cigars, bool isWeekend)
        {
            
            if (cigars >= 40 && cigars <= 60 && isWeekend == false)
            {
                return true;
            }
            else if (isWeekend)
            {
                return true;
            }
            return false;
        }

        // Logic 2
        public int CanHazTable(int yourStyle, int dateStyle)
        {
            if(yourStyle >= 8 || dateStyle >=8)
            {
                return 2;
            }
            else if (yourStyle <= 2 || dateStyle <= 2)
            {
                return 0;
            }
            else return 1;
        }
        // Logic 3
        public bool PlayOutside(int temp, bool isSummer)
        {
            if (temp >= 60 && temp <= 90 && isSummer == false)
            {
                return true;
            }
            else if (temp <= 100 && isSummer == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Logic 4
        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            if (speed <= 60 && (isBirthday == false || speed <= 65))
            {
                return 0;
            }
            else if ((speed >= 61 && speed <= 80 && isBirthday == false) || (speed > 65 && speed <= 85))
            {
                return 1;
            }
            else if (speed >= 85 || (speed >= 81 && isBirthday == false))
            {
                return 2;
            }

            return 0;
        }


        // Logic 5
        public int SkipSum(int a, int b)
        {
            int sum = a + b;
            if (sum >= 10 && sum <= 20)
            {
                return 20;
            }
            return sum;
        }

        // Logic 6

        public string AlarmClock(int day, bool vacation)
        {
            string time = "";
            if(vacation == false && day >= 1 && day <=5)
            {
                return "7:00";
            }
            else if (vacation == false && day == 0 || vacation == false && day == 6)
            {
                return "10:00";
            }
            else if(vacation == true && day >= 1 && day <=5)
            {
                return "10:00";
            }
            return "off";
        }

        // Logic 7

        public bool LoveSix(int a, int b)
        {
            if (a == 6 || b == 6)
            {
                return true;
            }
            else if ((a - b) == 6 || (b - a) == 6 || (a+b) == 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Logic 8

        public bool InRange(int n, bool outsideMode)
        {
            if (n >= 1 && n <= 10)
            {
                return true;
            }
            else if ((outsideMode == true) && (n <= 1 || n >= 10))
            {
                return true;
            }
            
            else
            {
                return false;
            }
        }

        // Logic 9

        public bool SpecialEleven(int n)
        {
            if (n%11 == 0 || n%11 == 1)
            {
                return true;
            }
            else return false;
        }

        // Logic 10

        public bool Mod20(int n)
        {
            if (n%20 == 1 || n%20 == 2)
            {
                return true;
            }
            else return false;
        }

        // Logic 11
        public bool Mod35(int n)
        {
            if (n%3 == 0 && n%5 == 0)
            {
                return false;
            }
            else if (n%3 == 0 || n%5 == 0)
            {
                return true;
            }
            else return false;
        }

        // Logic 12

        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            if (isMorning == true && isMom == false && isAsleep == false)
            {
                return false;
            }
            else if (isMorning == true && isMom == true && isAsleep == false)
            {
                return true;
            }
            else if (isAsleep == true)
            {
                return false;
            }
            else if (isMorning == false && isMom == false && isAsleep == false)
            {
                return true;
            }
            else return false;

        }

        // Logic 13
        public bool TwoIsOne(int a, int b, int c)
        {
            if (a + b == c || b + c == a || c + a == b)
            {
                return true;
            }
            else return false;
        }

        // Logic 14
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            if (bOk == true && c > b)
            {
                return true;
            }

            else if (b > a && c > b && bOk == false)
            {
                return true;
            }

            else return false;
        }

        // Logic 15
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {

            if (c >= b && b >= a)
            {
                return true;
            }

            else if (c > b && b > a && equalOk == false)
            {
                return true;
            }
            else return false;
        }

        // Logic 16
        public bool LastDigit(int a, int b, int c)
        {
            int lasta = a % 10;
            int lastb = b % 10;
            int lastc = c % 10;

            if (lasta == lastb || lastb == lastc || lastc == lasta)
            {
                return true;
            }
            else return false;
        }

        //  Logic 17
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            int sum = die1 + die2;

            if (noDoubles == true && die1 == die2 && sum != 12)
            {
                return sum + 1;
            }
            else if (noDoubles == true & die1 == die2 && sum == 12)
            {
                return 1;
            }
            else
            {
                return sum;
            }
        }
    }
}
