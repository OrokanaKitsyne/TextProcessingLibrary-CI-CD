using Xunit;
using TextProcessingLibrary;
using System;


namespace TestProject1
{
        public class TextProcessorTests
        {
            private readonly TextProcessor _processor = new TextProcessor();

            [Theory]
            [InlineData("hello world hello", "hello", 2)]
            [InlineData("Hello world hello", "hello", 1)]
            [InlineData("Hello world hello", "HELLO", 0)]
            [InlineData("", "hello", 0)]
            [InlineData("hello world", "", 0)]
            public void CountSubstringOccurrences_ReturnsCorrectCount(string text, string substring, int expected)
            {
                int actual = _processor.CountSubstringOccurrences(text, substring);
                Assert.Equal(expected, actual);
            }

        [Theory]
        [InlineData("hello world", "hello", "hi", false, "hi world")]
        [InlineData("Hello world", "hello", "hi", false, "Hello world")]
        [InlineData("Hello world", "hello", "hi", true, "hi world")]
        [InlineData("", "hello", "hi", false, "")]
        public void ReplaceSubstring_ReturnsCorrectString(
           string text, string oldValue, string newValue, bool ignoreCase, string expected)
        {
            
            if (expected == null)
            {
                expected = text;
            }

            string actual = _processor.ReplaceSubstring(text, oldValue, newValue, ignoreCase);
            Assert.Equal(expected, actual);
        }

        [Fact]
            public void ReplaceSubstring_ThrowsOnNullText()
            {
                Assert.Throws<ArgumentNullException>(() => _processor.ReplaceSubstring(null, "a", "b"));
            }

            [Fact]
            public void ReplaceSubstring_ThrowsOnNullOldValue()
            {
                Assert.Throws<ArgumentNullException>(() => _processor.ReplaceSubstring("text", null, "b"));
            }

            
        
        }
   
}