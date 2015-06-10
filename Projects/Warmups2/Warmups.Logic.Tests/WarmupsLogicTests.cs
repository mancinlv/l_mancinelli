using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Warmups.Logic.BLL;

namespace Warmups.Logic.Tests
{
    public class WarmupsLogicTests
    {
        //1
        [TestCase(30, false, false)]
        [TestCase(50, false, true)]
        [TestCase(70, true, true)]

        public void GreatParty(int cigars, bool isWeekend, bool expectedResult)
        {
            LogicWarmups logicTests = new LogicWarmups();
            bool actualResult = logicTests.GreatParty(cigars, isWeekend);
            Assert.AreEqual(expectedResult, actualResult);

        }

        //2
        [TestCase(5,10,2)]
        [TestCase(5,2,0)]
        [TestCase(5,5,1)]

        public void CanHazTable(int yourStyle, int dateStyle, int expectedResult)
        {
            LogicWarmups logicTests = new LogicWarmups();
            int actualResult = logicTests.CanHazTable(yourStyle, dateStyle);
            Assert.AreEqual(expectedResult, actualResult);

        }

        //3
        [TestCase(70, false, true)]
        [TestCase(95, false, false)]
        [TestCase(95, true, true)]

        public void PlayOutside(int temp, bool isSummer, bool expectedResult)
        {
            LogicWarmups logicTests = new LogicWarmups();
            bool actualResult = logicTests.PlayOutside(temp, isSummer);
            Assert.AreEqual(expectedResult, actualResult);

        }

        //4
        [TestCase(60, false, 0)]
        [TestCase(65, false, 1)]
        [TestCase(65, true, 0)]

        public void CaughtSpeeding(int speed, bool isBirthday, int expectedResult)
        {
            LogicWarmups logicTests = new LogicWarmups();
            int actualResult = logicTests.CaughtSpeeding(speed, isBirthday);
            Assert.AreEqual(expectedResult, actualResult);

        }

        //5
        [TestCase(3,4,7)]
        [TestCase(9,4,20)]
        [TestCase(10,11,21)]

        public void SkipSum(int a, int b, int expectedResult)
        {
            LogicWarmups logicTests = new LogicWarmups();
            int actualResult = logicTests.SkipSum(a, b);
            Assert.AreEqual(expectedResult, actualResult);

        }

        // 6
        [TestCase(1, false, "7:00")]
        [TestCase(5, false, "7:00")]
        [TestCase(0, false, "10:00")]

        public void AlarmClock(int day, bool vacation, string expectedResult)
        {
            LogicWarmups logicTests = new LogicWarmups();
            string actualResult = logicTests.AlarmClock(day, vacation);
            Assert.AreEqual(expectedResult, actualResult);

        }

        //7
        [TestCase(6, 4, true)]
        [TestCase(4, 5, false)]
        [TestCase(1, 5, true)]

        public void LoveSix(int a, int b, bool expectedResult)
        {
            LogicWarmups logicTests = new LogicWarmups();
            bool actualResult = logicTests.LoveSix(a, b);
            Assert.AreEqual(expectedResult, actualResult);

        }

        // 8
        [TestCase(5, false, true)]
        [TestCase(11, false, false)]
        [TestCase(11, true, true)]

        public void InRange(int n, bool outsideMode, bool expectedResult)
        {
            LogicWarmups logicTests = new LogicWarmups();
            bool actualResult = logicTests.InRange(n, outsideMode);
            Assert.AreEqual(expectedResult, actualResult);

        }

        // 9
        [TestCase(22, true)]
        [TestCase(23, true)]
        [TestCase(24, false)]

        public void SpecialEleven(int n, bool expectedResult)
        {
            LogicWarmups logicTests = new LogicWarmups();
            bool actualResult = logicTests.SpecialEleven(n);
            Assert.AreEqual(expectedResult, actualResult);

        }

        // 10

        [TestCase(20, false)]
        [TestCase(21, true)]
        [TestCase(22, true)]

        public void Mod20(int n, bool expectedResult)
        {
            LogicWarmups logicTests = new LogicWarmups();
            bool actualResult = logicTests.Mod20(n);
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestCase(3, true)]
        [TestCase(10, true)]
        [TestCase(15, false)]

        public void Mod35(int n, bool expectedResult)
        {
            LogicWarmups logicTests = new LogicWarmups();
            bool actualResult = logicTests.Mod35(n);
            Assert.AreEqual(expectedResult, actualResult);

        }

        // 12
        [TestCase(false, false, false, true)]
        [TestCase(false, false, true, false)]
        [TestCase(true, false, false, false)]

        public void AnswerCell(bool isMorning, bool isMom, bool isAsleep, bool expectedResult)
        {
            LogicWarmups logicTests = new LogicWarmups();
            bool actualResult = logicTests.AnswerCell(isMorning, isMom, isAsleep);
            Assert.AreEqual(expectedResult, actualResult);

        }

        // 13
        [TestCase(1, 2, 3, true)]
        [TestCase(3, 1, 2, true)]
        [TestCase(3, 2, 2, false)]

        public void TwoIsOne(int a, int b, int c, bool expectedResult)
        {
            LogicWarmups logicTests = new LogicWarmups();
            bool actualResult = logicTests.TwoIsOne(a,b,c);
            Assert.AreEqual(expectedResult, actualResult);

        }

        // 14
        [TestCase(1, 2, 4, false, true)]
        [TestCase(1, 2, 1, false, false)]
        [TestCase(1, 1, 2, true, true)]

        public void AreInOrder(int a, int b, int c, bool bOk, bool expectedResult)
        {
            LogicWarmups logicTests = new LogicWarmups();
            bool actualResult = logicTests.AreInOrder(a, b, c, bOk);
            Assert.AreEqual(expectedResult, actualResult);

        }

        // 15
        [TestCase(2, 5, 11, false, true)]
        [TestCase(5, 7, 6, false, false)]
        [TestCase(5, 5, 7, true, true)]

        public void InOrderEqual(int a, int b, int c, bool equalOk, bool expectedResult)
        {
            LogicWarmups logicTests = new LogicWarmups();
            bool actualResult = logicTests.InOrderEqual(a, b, c, equalOk);
            Assert.AreEqual(expectedResult, actualResult);

        }

        // 16
        [TestCase(23, 19, 13, true)]
        [TestCase(23, 19, 12, false)]
        [TestCase(23, 19, 3, true)]

        public void LastDigit(int a, int b, int c, bool expectedResult)
        {
            LogicWarmups logicTests = new LogicWarmups();
            bool actualResult = logicTests.LastDigit(a, b, c);
            Assert.AreEqual(expectedResult, actualResult);

        }

        // 17
        [TestCase(2, 3, true, 5)]
        [TestCase(3, 3, true, 7)]
        [TestCase(3, 3, false, 6)]

        public void RollDice(int die1, int die2, bool noDoubles, int expectedResult)
        {
            LogicWarmups logicTests = new LogicWarmups();
            int actualResult = logicTests.RollDice(die1, die2, noDoubles);
            Assert.AreEqual(expectedResult, actualResult);

        }


    }
    
}
