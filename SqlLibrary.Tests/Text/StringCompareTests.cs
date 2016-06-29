using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SqlLibrary.Text;

namespace SqlLibrary.Tests.Text
{
    [TestClass]
    public class StringCompareTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetTextSimilarity_ShouldThrowArgumentNullException_WhenInputOneIsNull()
        {
            // Arrange
            string inputOne = null;
            string inputTwo = "test";

            // Act
            double actualSimilarity = StringCompare.GetTextSimilarity(inputOne, inputTwo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetTextSimilarity_ShouldThrowArgumentNullException_WhenInputTwoIsNull()
        {
            // Arrange
            string inputOne = "test";
            string inputTwo = null;

            // Act
            double actualSimilarity = StringCompare.GetTextSimilarity(inputOne, inputTwo);
        }

        [TestMethod]
        public void GetTextSimilarity_ShouldReturnOne_WhenBothInputsEqual()
        {
            // Arrange
            string inputOne = "test";
            string inputTwo = "test";

            // Act
            double actualSimilarity = StringCompare.GetTextSimilarity(inputOne, inputTwo);

            // Assert
            Assert.AreEqual<double>(expected: 1, actual: actualSimilarity);
        }

        [TestMethod]
        public void GetTextSimilarity_ShouldReturnPointFive_WhenInputsHalfSimilar()
        {
            // Arrange
            string inputOne = "te";
            string inputTwo = "test";

            // Act
            double actualSimilarity = StringCompare.GetTextSimilarity(inputOne, inputTwo);

            // Assert
            Assert.AreEqual<double>(expected: 0.5, actual: actualSimilarity);
        }

        [TestMethod]
        public void GetTextSimilarity_ShouldReturnHalf_WhenInputsHalfSimilarAndSameLength()
        {
            // Arrange
            string inputOne = "tear";
            string inputTwo = "test";

            // Act
            double actualSimilarity = StringCompare.GetTextSimilarity(inputOne, inputTwo);

            // Assert
            Assert.AreEqual<double>(expected: 0.5, actual: actualSimilarity);
        }

        [TestMethod]
        public void GetTextSimilarity_ShouldReturnQuarter_WhenInputsQuarterSame()
        {
            // Arrange
            string inputOne = "test";
            string inputTwo = "txyz";

            // Act
            double actualSimilarity = StringCompare.GetTextSimilarity(inputOne, inputTwo);

            // Assert
            Assert.AreEqual<double>(expected: 0.25, actual: actualSimilarity);
        }

        [TestMethod]
        public void GetTextSimilarity_ShouldReturnOne_WhenBothInputsEmpty()
        {
            // Arrange
            string inputOne = "";
            string inputTwo = "";

            // Act
            double actualSimilarity = StringCompare.GetTextSimilarity(inputOne, inputTwo);

            // Assert
            Assert.AreEqual<double>(expected: 1, actual: actualSimilarity);
        }
    }
}
