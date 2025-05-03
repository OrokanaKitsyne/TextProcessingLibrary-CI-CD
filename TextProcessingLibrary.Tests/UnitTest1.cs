using Xunit;
using TextProcessingLibrary;

namespace TextProcessingLibrary.Tests
{
    public class TextProcessorTests
    {
        [Fact]
        public void CountWords_SimpleText_Returns2()
        {
            // Arrange
            var processor = new TextProcessor();

            // Act
            int result = processor.CountWords("Hello world");

            // Assert
            Assert.Equal(2, result);
        }

        [Theory]
        [InlineData("Hello world", "hello", "hi", true, "hi world")]
        public void ReplaceSubstring_IgnoreCase_ReplacesCorrectly(
            string input, string oldValue, string newValue, bool ignoreCase, string expected)
        {
            // Arrange
            var processor = new TextProcessor();

            // Act
            string result = processor.ReplaceSubstring(input, oldValue, newValue, ignoreCase);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}