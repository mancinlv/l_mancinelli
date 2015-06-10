using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.SqlServer.Server;
using NUnit.Framework;
using WarmUps.Strings;
using Warmups.Strings.BLL;


namespace WarmUps.Strings.Tests
{
    [TestFixture]
    public class StringWarmupsTest
    {
        [TestCase("Bob", "Hello Bob!")]
        [TestCase("Alice", "Hello Alice!")]
        [TestCase("X", "Hello X!")]

        public void SayHi(string name, string expectedResult)
        {
            StringWarmups warmupString = new StringWarmups();
            string actualResult = warmupString.SayHi(name);
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestCase("Hi", "Bye", "HiByeByeHi")]
        [TestCase("Yo", "Alice", "YoAliceAliceYo")]
        [TestCase("What", "Up", "WhatUpUpWhat")]

        public void Abba(string a, string b, string expectedResult)
        {
            StringWarmups warmupString = new StringWarmups();
            string actualResult = warmupString.Abba(a, b);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("i", "Yay", "<i>Yay</i>")]
        [TestCase("i", "Hello", "<i>Hello</i>")]
        [TestCase("cite", "Yay", "<cite>Yay</cite>")]

        public void MakeTags(string tag, string content, string expectedResult)
        {
            StringWarmups warmupString = new StringWarmups();
            string actualResult = warmupString.MakeTags(tag, content);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("<<>>", "Yay", "<<Yay>>")]
        [TestCase("<<>>", "WooHoo", "<<WooHoo>>")]
        [TestCase("[[]]", "word", "[[word]]")]

        public void InsertWord(string container, string word, string expectedResult)
        {
            StringWarmups warmupString = new StringWarmups();
            string actualResult = warmupString.InsertWord(container, word);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("Hello", "lololo")]
        [TestCase("ab", "ababab")]
        [TestCase("Hi", "HiHiHi")]

        public void MultipleEndings(string str, string expectedResult)
        {
            StringWarmups warmupString = new StringWarmups();
            string actualResult = warmupString.MultipleEndings(str);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("WooHoo", "Woo")]
        [TestCase("HelloThere", "Hello")]
        [TestCase("abcdef", "abc")]

        public void FirstHalf(string str, string expectedResult)
        {
            StringWarmups warmupString = new StringWarmups();
            string actualResult = warmupString.FirstHalf(str);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("Hello", "ell")]
        [TestCase("java", "av")]
        [TestCase("coding", "odin")]

        public void TrimOne(string str, string expectedResult)
        {
            StringWarmups warmupString = new StringWarmups();
            string actualResult = warmupString.TrimOne(str);
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestCase("Hello", "hi", "hiHellohi")]
        [TestCase("hi", "Hello", "hiHellohi")]
        [TestCase("aaa", "b", "baaab")]

        public void LongInMiddle(string a, string b, string expectedResult)
        {
            StringWarmups warmupString = new StringWarmups();
            string actualResult = warmupString.LongInMiddle(a, b);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("Hello", "lloHe")]
        [TestCase("java", "vaja")]
        [TestCase("Hi", "Hi")]

        public void Rotateleft2(string str, string expectedResult)
        {
            StringWarmups warmupsString = new StringWarmups();
            string actualResult = warmupsString.Rotateleft2(str);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("Hello", "loHel")]
        [TestCase("java", "vaja")]
        [TestCase("Hi", "Hi")]

        public void RotateRight2(string str, string expectedResult)
        {
            StringWarmups warmupsString = new StringWarmups();
            string actualResult = warmupsString.RotateRight2(str);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("Hello", true, "H")]
        [TestCase("Hello", false, "o")]
        [TestCase("oh", true, "o")]

        public void TakeOne(string str, bool fromFront, string expectedResult)
        {
            StringWarmups warmupsString = new StringWarmups();
            string actualResult = warmupsString.TakeOne(str, fromFront);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("string", "ri")]
        [TestCase("code", "od")]
        [TestCase("Practice", "ct")]

        public void MiddleTwo(string str, string expectedResult)
        {
            StringWarmups warmupsString = new StringWarmups();
            string actualResult = warmupsString.MiddleTwo(str);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("oddly", true)]
        [TestCase("y", false)]
        [TestCase("oddy", false)]

        public void EndsWithLy(string str, bool expectedResult)
        {
            StringWarmups warmupsString = new StringWarmups();
            bool actualResult = warmupsString.EndsWithLy(str);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // string 14

        [TestCase("Hello", 2, "Helo")]
        [TestCase("Chocolate", 3, "Choate")]
        [TestCase("Chocolate", 1, "Ce")]

        public void FrontAndBack(string str, int n, string expectedResult)
        {
            StringWarmups warmupsString = new StringWarmups();
            string actualResult = warmupsString.FrontAndBack(str, n);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("java", 0, "ja")]
        [TestCase("java", 2, "va")]
        [TestCase("java", 3, "ja")]
        public void TakeTwoFromPosition(string str, int n, string expectedResult)
        {
            StringWarmups warmupsString = new StringWarmups();
            string actualResult = warmupsString.TakeTwoFromPosition(str, n);
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestCase("badxx", true)]
        [TestCase("xbadxx", true)]
        [TestCase("xxbadxx", false)]

        public void HasBad(string str, bool expectedResult)
        {
            StringWarmups warmupsString = new StringWarmups();
            bool actualResult = warmupsString.HasBad(str);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("hello", "he")]
        [TestCase("hi", "hi")]
        [TestCase("h", "h@")]
        public void AtFirst(string str, string expectedResult)
        {
            StringWarmups warmupsString = new StringWarmups();
            string actualResult = warmupsString.AtFirst(str);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("last", "chars", "ls")]
        [TestCase("yo", "mama", "ya")]
        [TestCase("hi", "", "h@")]
        public void LastChars(string a, string b, string expectedResult)
        {
            StringWarmups warmupsString = new StringWarmups();
            string actualResult = warmupsString.LastChars(a, b);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("abc", "cat", "abcat")]
        [TestCase("dog", "cat", "dogcat")]
        [TestCase("abc", "", "abc")]
        public void ConCat(string a, string b, string expectedResult)
        {
            StringWarmups warmupsString = new StringWarmups();
            string actualResult = warmupsString.ConCat(a, b);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("coding", "codign")]
        [TestCase("cat", "cta")]
        [TestCase("ab", "ba")]
        public void SwapLast(string str, string expectedResult)
        {
            StringWarmups warmupsString = new StringWarmups();
            string actualResult = warmupsString.SwapLast(str);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("edited", true)]
        [TestCase("edit", false)]
        [TestCase("ed", true)]
        public void FrontAgain(string str, bool expectedResult)
        {
            StringWarmups warmupsString = new StringWarmups();
            bool actualResult = warmupsString.FrontAgain(str);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestCase("Hello", "Hi", "loHi")]
        [TestCase("Hello", "java", "ellojava")]
        [TestCase("java", "Hello", "javaello")]
        public void MinCat(string a, string b, string expectedResult)
        {
            StringWarmups warmupsString = new StringWarmups();
            string actualResult = warmupsString.MinCat(a, b);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("Hello", "llo")]
        [TestCase("away", "aay")]
        [TestCase("abed", "abed")]
        public void TweakFront(string str, string expectedResult)
        {
            StringWarmups warmupsString = new StringWarmups();
            string actualResult = warmupsString.TweakFront(str);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("xHix", "Hi")]
        [TestCase("xHi", "Hi")]
        [TestCase("Hxix", "Hxi")]
        public void StripX(string str, string expectedResult)
        {
            StringWarmups warmupsString = new StringWarmups();
            string actualResult = warmupsString.StripX(str);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }

}
