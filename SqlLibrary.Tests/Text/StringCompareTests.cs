using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlLibrary.Text;

namespace SqlLibrary.Tests.Text
{
    [TestClass]
    public class StringCompareTests
    {
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
        public void GetTextSimilarity_ShouldReturnOne_WhenInputsEmpty()
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
