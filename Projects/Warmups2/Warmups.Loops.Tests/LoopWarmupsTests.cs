using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Warmups.Loops.BLL;


namespace Warmups.Loops.Tests
{
    
    public class LoopWarmupsTests
  {
    // 1
    [TestCase("Hi", 2, "HiHi")]
    [TestCase("Hi", 3, "HiHiHi")]
    [TestCase("Hi", 1, "Hi")]

    
    public void StringTimesTest(string str, int n, string expectedResult)
    {
        LoopWarmups Loops = new LoopWarmups();
        string actualResult = Loops.StringTimes(str, n);
        Assert.AreEqual(expectedResult, actualResult);

    }
    // 2
    [TestCase("Chocolate", 2, "ChoCho")]
    [TestCase("Chocolate", 3, "ChoChoCho")]
    [TestCase("Abc", 3, "AbcAbcAbc")]

    public void FrontTimes(string str, int n, string expectedResult)
    {
        LoopWarmups Loops = new LoopWarmups();
        string actualResult = Loops.FrontTimes(str, n);
        Assert.AreEqual(expectedResult, actualResult);

    }
    // 3
    [TestCase("abcxx", 1)]
    [TestCase("xxx", 2)]
    [TestCase("xxxx", 3)]

    public void CountXX(string str, int expectedResult)
    {
        LoopWarmups Loops = new LoopWarmups();
        int actualResult = Loops.CountXX(str);
        Assert.AreEqual(expectedResult, actualResult);

    }
    // 4
    [TestCase("axxbb", true)]
    [TestCase("axaxxax", false)]
    [TestCase("xxxxx", true)]

    public void DoubleX(string str, bool expectedResult)
    {
        LoopWarmups Loops = new LoopWarmups();
        bool actualResult = Loops.DoubleX(str);
        Assert.AreEqual(expectedResult, actualResult);

    }
    // 5
    [TestCase("Hello", "Hlo")]
    [TestCase("Hi", "H")]
    [TestCase("Heeololeo", "Hello")]

    public void EveryOther(string str, string expectedResult)
    {
        LoopWarmups Loops = new LoopWarmups();
        string actualResult = Loops.EveryOther(str);
        Assert.AreEqual(expectedResult, actualResult);

    }
    // 6
    [TestCase("Code", "CCoCodCode")]
    [TestCase("abc", "aababc")]
    [TestCase("ab", "aab")]

    public void StringSplosion(string str, string expectedResult)
    {
        LoopWarmups Loops = new LoopWarmups();
        string actualResult = Loops.StringSplosion(str);
        Assert.AreEqual(expectedResult, actualResult);

    }

    // 7
    [TestCase("hixxhi", 1)]
    [TestCase("xaxxaxaxx", 1)]
    [TestCase("axxxaaxx", 2)]

    public void CountLast2(string str, int expectedResult)
    {
        LoopWarmups Loops = new LoopWarmups();
        int actualResult = Loops.CountLast2(str);
        Assert.AreEqual(expectedResult, actualResult);

    }

    // 8
    [TestCase(new[]{1, 2, 9}, 1)]
    [TestCase(new[]{1, 9, 9}, 2)]
    [TestCase(new[]{1, 9, 9, 3, 9}, 3)]

    public void Count9 (int[] numbers, int expectedResult)
    {
        LoopWarmups Loops = new LoopWarmups();
        int actualResult = Loops.Count9(numbers);
        Assert.AreEqual(expectedResult, actualResult);

    }
    // 9
    [TestCase(new[] { 1, 2, 9, 3, 4 }, true)]
    [TestCase(new[] { 1, 2, 3, 4, 9 }, false)]
    [TestCase(new[] { 1, 2, 3, 4, 5 }, false)]

    public void ArrayFront9(int[] numbers, bool expectedResult)
    {
        LoopWarmups Loops = new LoopWarmups();
        bool actualResult = Loops.ArrayFront9(numbers);
        Assert.AreEqual(expectedResult, actualResult);
    }

    // 10
    [TestCase(new[] { 1, 1, 2, 3, 1 }, true)]
    [TestCase(new[] { 1, 1, 2, 4, 1 }, false)]
    [TestCase(new[] { 1, 1, 2, 1, 2, 3 }, true)]

    public void Array123(int[] numbers, bool expectedResult)
    {
        LoopWarmups Loops = new LoopWarmups();
        bool actualResult = Loops.Array123(numbers);
        Assert.AreEqual(expectedResult, actualResult);
    }

    // 11
    [TestCase("xxcaazz", "xxbaaz", 3)]
    [TestCase("abc", "abc", 2)]
    [TestCase("abc", "axc", 0)]

    public void SubStringMatch(string a, string b, int expectedResult)
    {
        LoopWarmups Loops = new LoopWarmups();
        int actualResult = Loops.SubStringMatch(a, b);
        Assert.AreEqual(expectedResult, actualResult);
    }

    // 12
    [TestCase("xxHxix", "xHix")]
    [TestCase("abxxxcd", "abcd")]
    [TestCase("xabxxxcdx", "xabcdx")]

    public void StringX(string str, string expectedResult)
    {
        LoopWarmups Loops = new LoopWarmups();
        string actualResult = Loops.StringX(str);
        Assert.AreEqual(expectedResult, actualResult);
    }

    // 13
    [TestCase("kitten", "kien")]
    [TestCase("Chocolate", "Chole")]
    [TestCase("CodingHorror", "Congrr")]

    public void AltPairs(string str, string expectedResult)
    {
        LoopWarmups Loops = new LoopWarmups();
        string actualResult = Loops.AltPairs(str);
        Assert.AreEqual(expectedResult, actualResult);
    }

    // 14
    [TestCase("yakpak", "pak")]
    [TestCase("pakyak", "pak")]
    [TestCase("yak123ya", "123ya")]

    public void DoNotYak(string str, string expectedResult)
    {
        LoopWarmups Loops = new LoopWarmups();
        string actualResult = Loops.DoNotYak(str);
        Assert.AreEqual(expectedResult, actualResult);
    }

    // 15
    [TestCase(new []{6, 6, 2}, 1)]
    [TestCase(new []{6, 6, 2, 6}, 1)]
    [TestCase(new []{6, 7, 2, 6}, 1)]

    public void Array667(int[] numbers, int expectedResult)
    {
        LoopWarmups Loops = new LoopWarmups();
        int actualResult = Loops.Array667(numbers);
        Assert.AreEqual(expectedResult, actualResult);
    }

    // 16
    [TestCase(new[] {1, 1, 2, 2, 1}, true)]
    [TestCase(new[] {1, 1, 2, 2, 2, 1}, false)]
    [TestCase(new[] {1, 1, 1, 2, 2, 2, 1}, false)]

    public void NoTriples(int[] numbers, bool expectedResult)
    {
        LoopWarmups Loops = new LoopWarmups();
        bool actualResult = Loops.NoTriples(numbers);
        Assert.AreEqual(expectedResult, actualResult);
    }

    // 17
    [TestCase(new[] { 1, 2, 7, 1 }, true)]
    [TestCase(new[] { 1, 2, 8, 1 }, false)]
    [TestCase(new[] { 2, 7, 1 }, true)]

    public void Pattern51(int[] numbers, bool expectedResult)
    {
        LoopWarmups Loops = new LoopWarmups();
        bool actualResult = Loops.Pattern51(numbers);
        Assert.AreEqual(expectedResult, actualResult);
    }

  }
    
}
