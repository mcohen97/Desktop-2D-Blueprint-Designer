using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Test {
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
            string testPhone = "4.972.519-2";
            Assert.IsFalse(DataValidations.IsValidID(testPhone));
        }

        [TestMethod]
        public void InvalidIDTest() {
            string testPhone = "1-555-5555";
            Assert.IsFalse(DataValidations.IsValidID(testPhone));
        }

    }
}
