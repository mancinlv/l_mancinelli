using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Warmups.Conditionals.BLL;

namespace Warmups.Conditionals.Tests
{
    public class ConditionalWarmupsTests
    {
        // 1
        [TestCase(true, true, true)]
        [TestCase(false, false, true)]
        [TestCase(true, false, false)]

        public void AreWeInTrouble(bool aSmile, bool bSmile, bool expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            bool actualResult = Conds.AreWeInTrouble(aSmile, bSmile);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 2

        [TestCase(false, false, true)]
        [TestCase(true, false, false)]
        [TestCase(false, true, true)]

        public void CanSleepIn(bool isWeekday, bool isVacation, bool expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            bool actualResult = Conds.CanSleepIn(isWeekday, isVacation);
            Assert.AreEqual(expectedResult, actualResult);
        }


        // 3
        [TestCase(70, false, true)]
        [TestCase(95, false, false)]
        [TestCase(95, true, true)]

        public void PlayOutside(int temp, bool isSummer, bool expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            bool actualResult = Conds.PlayOutside(temp, isSummer);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 4
        [TestCase(23, 4)]
        [TestCase(10, 11)]
        [TestCase(21, 0)]

        public void Diff21(int n, int expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            int actualResult = Conds.Diff21(n);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 5

        [TestCase(true, 6, true)]
        [TestCase(true, 7, false)]
        [TestCase(false, 6, false)]

        public void ParrotTrouble(bool isTalking, int hour, bool expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            bool actualResult = Conds.ParrotTrouble(isTalking, hour);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 6
        [TestCase(9, 10, true)]
        [TestCase(9, 9, false)]
        [TestCase(1, 9, true)]

        public void Makes10(int a, int b, bool expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            bool actualResult = Conds.Makes10(a, b);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 7
        [TestCase(103, true)]
        [TestCase(90, true)]
        [TestCase(89, false)]

        public void NearHundred(int n, bool expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            bool actualResult = Conds.NearHundred(n);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 8
        [TestCase(1, -1, false, true)]
        [TestCase(-1, 1, false, true)]
        [TestCase(-4, -5, true, true)]

        public void PosNeg(int a, int b, bool negative, bool expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            bool actualResult = Conds.PosNeg(a, b, negative);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 9
        [TestCase("candy", "not candy")]
        [TestCase("x", "not x")]
        [TestCase("not bad", "not bad")]

        public void NotString(string s, string expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            string actualResult = Conds.NotString(s);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 10
        [TestCase("kitten", 1, "ktten")]
        [TestCase("kitten", 0, "itten")]
        [TestCase("kitten", 4, "kittn")]

        public void MissingChar(string str, int n, string expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            string actualResult = Conds.MissingChar(str, n);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 11
        [TestCase("code", "eodc")]
        [TestCase("a", "a")]
        [TestCase("ab", "ba")]

        public void FrontBack(string str, string expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            string actualResult = Conds.FrontBack(str);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 12
        [TestCase("Microsoft", "MicMicMic")]
        [TestCase("Chocolate", "ChoChoCho")]
        [TestCase("at", "atatat")]

        public void Front3(string str, string expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            string actualResult = Conds.Front3(str);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 13
        [TestCase("cat", "tcatt")]
        [TestCase("Hello", "oHelloo")]
        [TestCase("a", "aaa")]

        public void BackAround(string str, string expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            string actualResult = Conds.BackAround(str);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 14
        [TestCase(3, true)]
        [TestCase(10, true)]
        [TestCase(8, false)]

        public void Multiple3or5(int number, bool expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            bool actualResult = Conds.Multiple3or5(number);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 15
        [TestCase("hi there", true)]
        [TestCase("hi", true)]
        [TestCase("high up", false)]

        public void StartHi(string str, bool expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            bool actualResult = Conds.StartHi(str);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 16
        [TestCase(120, -1, true)]
        [TestCase(-1, 120, true)]
        [TestCase(2, 120, false)]

        public void IcyHot(int temp1, int temp2, bool expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            bool actualResult = Conds.IcyHot(temp1, temp2);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 17
        [TestCase(12, 99, true)]
        [TestCase(21, 12, true)]
        [TestCase(8, 99, false)]

        public void Between10and20(int a, int b, bool expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            bool actualResult = Conds.Between10and20(a, b);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 18
        [TestCase(13, 20, 10, true)]
        [TestCase(20, 19, 10, true)]
        [TestCase(20, 10, 12, false)]

        public void HasTeen(int a, int b, int c, bool expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            bool actualResult = Conds.HasTeen(a, b, c);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 19
        [TestCase(13, 99, true)]
        [TestCase(21, 19, true)]
        [TestCase(13, 13, false)]

        public void SoAlone(int a, int b, bool expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            bool actualResult = Conds.SoAlone(a, b);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 20
        [TestCase("adelbc", "abc")]
        [TestCase("adelHello", "aHello")]
        [TestCase("adedbc", "adedbc")]

        public void RemoveDel(string str, string expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            string actualResult = Conds.RemoveDel(str);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 21
        [TestCase("mix snacks", true)]
        [TestCase("pix snacks", true)]
        [TestCase("piz snacks", false)]

        public void IxStart(string str, bool expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            bool actualResult = Conds.IxStart(str);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 22
        [TestCase("ozymandias", "oz")]
        [TestCase("bzoo", "z")]
        [TestCase("oxx", "o")]

        public void StartOz(string str, string expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            string actualResult = Conds.StartOz(str);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 23
        [TestCase(1, 2, 3, 3)]
        [TestCase(1, 3, 2, 3)]
        [TestCase(3, 2, 1, 3)]

        public void Max(int a, int b, int c, int expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            int actualResult = Conds.Max(a, b, c);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 24
        [TestCase(8, 13, 8)]
        [TestCase(13, 8, 8)]
        [TestCase(13, 7, 0)]

        public void Closer(int a, int b, int expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            int actualResult = Conds.Closer(a, b);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 25
        [TestCase("Hello", true)]
        [TestCase("Heelle", true)]
        [TestCase("Heelele", false)]

        public void GotE(string str, bool expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            bool actualResult = Conds.GotE(str);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 26
        [TestCase("Hello", "HeLLO")]
        [TestCase("hi there", "hi thERE")]
        [TestCase("hi", "HI")]

        public void EndUp(string str, string expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            string actualResult = Conds.EndUp(str);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 27
        [TestCase("Miracle", 2, "Mrce")]
        [TestCase("abcdefg", 2, "aceg")]
        [TestCase("abcdefg", 3, "adg")]

        public void EveryNth(string str, int n, string expectedResult)
        {
            ConditionalsWarmups Conds = new ConditionalsWarmups();
            string actualResult = Conds.EveryNth(str, n);
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}
