using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace Test {
    [TestClass]
    public class DataValidationsTest {
        [TestMethod]
        public void AssignStringTest() {
            string testString = "Hello";
            DataValidations.AssignStringIfNotNull(out testString, "World!");
            Assert.AreEqual("World!", testString);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssignNullStringTest() {
            string testString = "Hello";
            DataValidations.AssignStringIfNotNull(out testString, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssignEmptyStringTest() {
            string testString = "Hello";
            DataValidations.AssignStringIfNotNull(out testString, "");
        }

        [TestMethod]
        public void ValidPhoneNumberTest() {
            string testPhone = "2400-38-85";
            Assert.IsTrue(DataValidations.IsValidPhoneNumber(testPhone));
        }

        [TestMethod]
        public void InvalidPhoneNumberTest() {
            string testPhone = "1-555-5555";
            Assert.IsFalse(DataValidations.IsValidPhoneNumber(testPhone));
        }

        [TestMethod]
        public void ValidIDTest() {
            string testID = "4.972.519-2";
            Assert.IsTrue(DataValidations.IsValidID(testID));
        }

        [TestMethod]
        public void InvalidIDTest() {
            string testID = "1-555-5555";
            Assert.IsFalse(DataValidations.IsValidID(testID));
        }

        [TestMethod]
        public void IsNumberTest() {
            string testNumber = "99";
            Assert.IsTrue(DataValidations.IsNumberGreaterThanZero(testNumber));
        }

        [TestMethod]
        public void IsValidNumberZeroTest() {
            string testNumber = "0";
            Assert.IsFalse(DataValidations.IsNumberGreaterThanZero(testNumber));
        }

        [TestMethod]
        public void IsValidNegativeNumberTest() {
            string testNumber = "-5";
            Assert.IsFalse(DataValidations.IsNumberGreaterThanZero(testNumber));
        }

        [TestMethod]
        public void IsNaNTest() {
            string testNumber = "0";
            Assert.IsFalse(DataValidations.IsNumberGreaterThanZero(testNumber));
        }

    }
}
