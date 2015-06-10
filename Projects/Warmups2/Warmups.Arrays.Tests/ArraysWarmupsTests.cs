using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Warmups.Arrays.BLL;

namespace Warmups.Arrays.Tests
{
    public class ArraysWarmupsTests
    {
        // 1
        [TestCase(new[]{1, 2, 6}, true)]
        [TestCase(new[]{6, 1, 2, 3}, true)]
        [TestCase(new[]{13, 6, 1, 2, 3}, false)]

        public void FirstLast6(int[] numbers, bool expectedResult)
        {
            ArraysWarmups Arrays = new ArraysWarmups();
            bool actualResult = Arrays.FirstLast6(numbers);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 2
        [TestCase(new[] {1, 2, 3}, false)]
        [TestCase(new[] {1, 2, 3, 1}, true)]
        [TestCase(new[] {1, 2, 1}, true)]

        public void SameFirstLast(int[] numbers, bool expectedResult)
        {
            ArraysWarmups Arrays = new ArraysWarmups();
            bool actualResult = Arrays.SameFirstLast(numbers);
            Assert.AreEqual(expectedResult, actualResult);
        }

        /*//3
        [TestCase(3, new[]{3, 1, 4})]

        public void MakePi(int n, new[] expectedResult)
        {
            ArraysWarmups Arrays = new ArraysWarmups();
            array actualResult = Arrays.MakePi(n);
            Assert.AreEqual(expectedResult, actualResult);
        }*/

        //4
        [TestCase(new[] {1, 2, 3}, new[]{7, 3}, true)]
        [TestCase(new[] {1, 2, 3}, new []{7, 3, 2}, false)]
        [TestCase(new[] {1, 2, 3}, new[]{1, 3}, true)]

        public void CommonEnd(int[] a, int[] b, bool expectedResult)
        {
            ArraysWarmups Arrays = new ArraysWarmups();
            bool actualResult = Arrays.CommonEnd(a, b);
            Assert.AreEqual(expectedResult, actualResult);
        }

        //5

        [TestCase(new[] {1, 2, 3}, 6)]
        [TestCase(new[] {5, 11, 2}, 18)]
        [TestCase(new[] {7, 0, 0}, 7)]

        public void Sum(int[] numbers, int expectedResult)
        {
            ArraysWarmups Arrays = new ArraysWarmups();
            int actualResult = Arrays.Sum(numbers);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 6

        [TestCase(new[] {1, 2, 3}, new[] {2, 3, 1})]
        [TestCase(new[] {5, 11, 9}, new[]{11, 9, 5})]
        [TestCase(new[] {7, 0, 0}, new[] {0, 0, 7})]

        public void RotateLeft(int[] numbers, int[] expectedResult)
        {
            ArraysWarmups Arrays = new ArraysWarmups();
            int[] actualResult = Arrays.RotateLeft(numbers);
            Assert.AreEqual(expectedResult, actualResult);
        }

         // 7

        [TestCase(new[] {1, 2, 3}, new[] {3,2,1})]
        

        public void Reverse(int[] numbers, int[] expectedResult)
        {
            ArraysWarmups Arrays = new ArraysWarmups();
            int[] actualResult = Arrays.Reverse(numbers);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 8

        [TestCase(new[] { 1, 2, 3 }, new[] { 3, 3, 3 })]
        [TestCase(new[] { 11, 5, 9 }, new[] { 11, 11, 11 })]
        [TestCase(new[] { 2, 11, 3 }, new[] { 3, 3, 3 })]

        public void HigherWins(int[] numbers, int[] expectedResult)
        {
            ArraysWarmups Arrays = new ArraysWarmups();
            int[] actualResult = Arrays.HigherWins(numbers);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 9

        [TestCase(new[] {1, 2, 3}, new[]{4, 5, 6}, new[] {2, 5})]
        [TestCase(new[] {7, 7, 7}, new[]{3, 8, 0}, new[] {7, 8})]
        [TestCase(new[] {5, 2, 9}, new []{1, 4, 5}, new[] {2, 4})]

        public void GetMiddle(int[] a, int[] b, int[] expectedResult)
        {
            ArraysWarmups Arrays = new ArraysWarmups();
            int[] actualResult = Arrays.GetMiddle(a, b);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 10

        [TestCase(new[] {2, 5}, true)]
        [TestCase(new[] {4, 3}, true)]
        [TestCase(new[] {7, 5}, false)]

        public void HasEven(int[] numbers, bool expectedResult)
        {
            ArraysWarmups Arrays = new ArraysWarmups();
            bool actualResult = Arrays.HasEven(numbers);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 11

        [TestCase(new[] { 4, 5, 6 }, new[] { 0, 0, 0, 0, 0, 6 })]
        [TestCase(new[] { 1, 2 }, new[] { 0, 0, 0, 2 })]
        [TestCase(new[] { 3 }, new[] { 0, 3 })]

        public void KeepLast(int[] numbers, int[] expectedResult)
        {
            ArraysWarmups Arrays = new ArraysWarmups();
            int[] actualResult = Arrays.KeepLast(numbers);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 12

        [TestCase(new[] { 2, 2, 3 }, true)]
        [TestCase(new[] {3, 4, 5, 3}, true)]
        [TestCase(new[] {2, 3, 2, 2}, false)]

        public void Double23(int[] numbers, bool expectedResult)
        {
            ArraysWarmups Arrays = new ArraysWarmups();
            bool actualResult = Arrays.Double23(numbers);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 13

        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 0 })]
        [TestCase(new[] { 2, 3, 5 }, new[] { 2, 0, 5 })]
        [TestCase(new[] { 1, 2, 1 }, new[] { 1, 2, 1 })]

        public void Fix23(int[] numbers, int[] expectedResult)
        {
            ArraysWarmups Arrays = new ArraysWarmups();
            int[] actualResult = Arrays.Fix23(numbers);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 14

        [TestCase(new[] { 1, 3, 4, 5 }, true)]
        [TestCase(new[] { 2, 1, 3, 4, 5 }, true)]
        [TestCase(new[] { 1, 1, 1 }, false)]

        public void Unlucky1(int[] numbers, bool expectedResult)
        {
            ArraysWarmups Arrays = new ArraysWarmups();
            bool actualResult = Arrays.Unlucky1(numbers);
            Assert.AreEqual(expectedResult, actualResult);
        }

        // 15
        [TestCase(new[] { 4, 5 }, new[] { 1, 2, 3 }, new[] { 4, 5 })]
        [TestCase(new[] {4}, new[] {1, 2, 3}, new[] { 4,1 })]
        [TestCase(new int[] {}, new[] {1, 2}, new[] { 1,2 })]

        public void make2(int[] a, int[] b, int[] expectedResult)
        {
            ArraysWarmups Arrays = new ArraysWarmups();
            int[] actualResult = Arrays.make2(a, b);
            Assert.AreEqual(expectedResult, actualResult);
        }
    } 
}
