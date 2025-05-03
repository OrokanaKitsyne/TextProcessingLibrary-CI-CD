using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TextProcessingLibrary
{
    public class TextProcessor
    {
        // Поиск количества вхождений подстроки в тексте
        public int CountSubstringOccurrences(string text, string substring, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(substring))
            {
                return 0;
            }

            int count = 0;
            int index = 0;

            while ((index = text.IndexOf(substring, index, comparison)) != -1)
            {
                index += substring.Length;
                count++;
            }

            return count;
        }

        // Замена подстроки с учетом регистра
        public string ReplaceSubstring(string text, string oldValue, string newValue, bool ignoreCase = false)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (oldValue == null)
            {
                throw new ArgumentNullException(nameof(oldValue));
            }

            if (oldValue.Length == 0)
            {
                throw new ArgumentException("Old value cannot be empty", nameof(oldValue));
            }

            StringComparison comparison = ignoreCase ?
                StringComparison.OrdinalIgnoreCase :
                StringComparison.Ordinal;

            int index = 0;
            while ((index = text.IndexOf(oldValue, index, comparison)) != -1)
            {
                text = text.Remove(index, oldValue.Length).Insert(index, newValue);
                index += newValue.Length;
            }

            return text;
        }

        // Обратный порядок слов в строке
        public string ReverseWords(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            string[] words = Regex.Split(text, @"(\s+)");
            Array.Reverse(words);
            return string.Concat(words);
        }

        // Удаление лишних пробелов
        public string RemoveExtraSpaces(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            return Regex.Replace(text.Trim(), @"\s+", " ");
        }

        // Подсчет количества слов
        public int CountWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return 0;
            }

            string trimmedText = RemoveExtraSpaces(text);
            return trimmedText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
