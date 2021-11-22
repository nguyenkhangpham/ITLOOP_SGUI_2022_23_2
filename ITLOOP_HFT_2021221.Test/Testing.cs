using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITLOOP_HFT_2021221.Models;

namespace ITLOOP_HFT_2021221.Test
{
    [TestFixture]
    public class Tesing
    {
        [TestCase("Test1", "Test1")]
        [TestCase("Test2", "Test2")]
        public void GetDisplayNameSuccessfullyTest(string propName, string expectedName)
        {
            // Arrange

            // Act
            var dispName = Tesing.GetPropertyDisplayName<TestClass>(propName);

            // Assert
            Assert.That(dispName, Is.EqualTo(expectedName));
        }

        private static object GetPropertyDisplayName<T>(string propName)
        {
            throw new NotImplementedException();
        }
        [Test]
        public void GetNewDisplayNameOnNull()
        {
            // Arrange

            // Act - Assert
            //var exception = Assert.Throws(typeof(ArgumentNullException), () => AttributeHelper.GetPropertyDisplayName<TestClass>(null));
        }
        [Test]
        public void GetDisplayNameOnNull()
        {
            // Arrange

            // Act - Assert
            //var exception = Assert.Throws(typeof(ArgumentNullException), () => AttributeHelper.GetPropertyDisplayName<TestClass>(null));
        }
        [Test]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            CarStore account = new CarStore() { CarStoreID = 1, Category = "Electric", Infor = "Rental Electric car", ViewCount = 275 };

            // Act
            try
            {

            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
            }
        }
        [Test]
        public void Remove_ASubstring_RemovesThatSubstring()
        {
            string str = "Hello, world!";

            string transformed = str.Remove(1);

            var position = str.IndexOf("Hello");
            var expected = str.Substring(position + 5);
            Assert.AreEqual(expected, transformed);
        }
        [Test]
        public void Adding_4_And_3_Should_Return_7()
        {
            var calculator = new CarStore() { CarStoreID = 1, Category = "Electric", Infor = "Rental Electric car", ViewCount = 275 };

            int result = calculator.CarStoreID;

            Assert.AreEqual(7, result);
        }

    }

    class TestClass
    {
        public int Test1 { get; set; }

        public string Test2 { get; set; }
    }
}
