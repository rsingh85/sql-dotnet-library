using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlLibrary.Text;

namespace SqlLibrary.Tests.Text
{
    [TestClass]
    public class LevenshteinDistanceTests
    {
        private LevenshteinDistance _levenshteinDistance;

        [TestInitialize]
        public void Initialise()
        {
            _levenshteinDistance = new LevenshteinDistance();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Compute_ShouldThrowArgumentNullException_WhenInputOneIsNull()
        {
            // Arrange
            string inputOne = null;
            string inputTwo = "test";

            // Act
            double distance = _levenshteinDistance.Compute(inputOne, inputTwo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Compute_ShouldThrowArgumentNullException_WhenInputTwoIsNull()
        {
            // Arrange
            string inputOne = "test";
            string inputTwo = null;

            // Act
            double distance = _levenshteinDistance.Compute(inputOne, inputTwo);
        }

        [TestMethod]
        public void Compute_ShouldReturnZero_WhenBothInputsEqual()
        {
            // Arrange
            string inputOne = "test";
            string inputTwo = "test";

            // Act
            double distance = _levenshteinDistance.Compute(inputOne, inputTwo);

            // Assert
            Assert.AreEqual<double>(expected: 0, actual: distance);
        }

        [TestMethod]
        public void Compute_ShouldReturnTwo_WhenDistanceIsTwoAndInputsOfDifferentLength()
        {
            // Arrange
            string inputOne = "te";
            string inputTwo = "test";

            // Act
            double distance = _levenshteinDistance.Compute(inputOne, inputTwo);

            // Assert
            Assert.AreEqual<double>(expected: 2, actual: distance);
        }

        [TestMethod]
        public void Compute_ShouldReturnTwo_WhenDistanceIsTwoAndInputsOfSameLength()
        {
            // Arrange
            string inputOne = "tear";
            string inputTwo = "test";

            // Act
            double distance = _levenshteinDistance.Compute(inputOne, inputTwo);

            // Assert
            Assert.AreEqual<double>(expected: 2, actual: distance);
        }

        [TestMethod]
        public void Compute_ShouldReturnThree_WhenDistanceIsThree()
        {
            // Arrange
            string inputOne = "test";
            string inputTwo = "txyz";

            // Act
            double distance = _levenshteinDistance.Compute(inputOne, inputTwo);

            // Assert
            Assert.AreEqual<double>(expected: 3, actual: distance);
        }

        [TestMethod]
        public void Compute_ShouldReturnZero_WhenBothInputsEmpty()
        {
            // Arrange
            string inputOne = "";
            string inputTwo = "";


            // Act
            double distance = _levenshteinDistance.Compute(inputOne, inputTwo);

            // Assert
            Assert.AreEqual<double>(expected: 0, actual: distance);
        }
    }
}
