using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EventCateringProjectTests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }


        [Test]
        [TestCaseSource(nameof(DataGenerator), new Object[] { 3 })]
        [TestCase(1, TestName ="ValueOfOne", Author ="Jason")]
        [TestCase(2, TestName ="ValueOfTwo")]
        [TestCase(3, TestName ="ValueOfThree", IgnoreReason = "Because this will make all the testcases fail")]
        public void Test1(int a)
        {
            //  ARRANGE
            //  ACT
            int value = a;
            //  ASSERT
            Assert.That(value, Is.Not.EqualTo(3));
        }

        static IEnumerable<int> DataGenerator(int counter) {
            while(counter > 0)
            {
                Console.WriteLine(counter);
                yield return counter;
                counter--;
            }
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Tear Down Test");
        }
    }
}