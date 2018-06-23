using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BreakTheCaesar
{

    public class CipherSolver
    {
        public Dictionary<String, int> alphabetValues = new Dictionary<string, int>
        {
            {"A", 0 }, {"B", 1 }, {"C", 2 }, {"D", 3 }, {"E", 4 }, {"F", 5}, {"G", 6 },
            {"H", 7 }, {"I", 8 }, {"J", 9}, {"K", 10}, {"L", 11 }, {"M", 12 }, {"N", 13 },
            {"O", 14 }, {"P", 15 }, {"Q", 16 }, {"R", 17 }, {"S", 18 }, {"T", 19 }, {"U", 20 },
            {"V", 21 }, {"W", 22 }, {"X", 23 }, {"Y", 24 }, {"Z", 25 }
        };

        public Dictionary<int, char> integersValues = new Dictionary<int, char>
        {
            {0, 'A' }, {1, 'B'}, {2, 'C'}, {3, 'D'}, {4, 'E'}, {5, 'F'}, {6, 'G'}, {7, 'H'},
            {8, 'I' }, {9, 'J'}, {10, 'K'}, {11, 'L'}, {12, 'M'}, {13, 'N'}, {14, 'O'}, {15, 'P'},
            {16, 'Q'}, {17, 'R'}, {18, 'S'}, {19, 'T'}, {20, 'U'}, {21, 'V'}, {22, 'W'}, {23, 'X'},
            {24, 'Y' }, {25, 'Z'}
        };

        public int[] ConvertStringToNumbers(string input)
        {

            int[] in_numbers;
            char[] in_letter;

            string[] wordsNoSpecialChar = Regex.Split(input.ToUpper(), @"\W+");
            in_letter = String.Join(String.Empty, wordsNoSpecialChar).ToCharArray();
            in_numbers = new int[in_letter.Length];

            for (int i = 0; i < in_letter.Length; i++)
            {
                string letter = Convert.ToString(in_letter[i]);
                in_numbers[i] = alphabetValues[letter];
            }

            return in_numbers;



        }

        public int[] EncodeNumbers(int[] numbers, int shift)
        {
            int[] codedNumbers = new int[numbers.Length];
            var t = numbers.Length;
            for (int i = 0; i < t; i++)
            {
                codedNumbers[i] = (numbers[i] + shift) % 26;
            }
            return codedNumbers;
        }

        public String EncryptedWords(string input, int shift)
        {
            int[] numbersToEncrypt = ConvertStringToNumbers(input);
            int[] encodedNumbers = EncodeNumbers(numbersToEncrypt, shift);

            char[] word = new char[numbersToEncrypt.Length];

            string temp = "";
            LooPEncryptingWords(encodedNumbers, word);
            temp = new string(word);

            string result = temp;
            result = CheckingWhiteSpace(input, temp, result);
            String finalResult = CheckingPunctuations(result, input);
            return finalResult;
        }

        private static string CheckingWhiteSpace(string input, string temp, string result)
        {
            for (int j = 0; j < input.Length; j++)
            {
                result = AddingWhiteSpace(input, temp, result, j);
            }

            return result;
        }

        private static string AddingWhiteSpace(string input, string temp, string result, int j)
        {
            if (char.IsWhiteSpace(input[j]))
            {
                result = temp.Insert(j, " ");
            }

            return result;
        }

        private void LooPEncryptingWords(int[] encodedNumbers, char[] word)
        {
            for (int i = 0; i < encodedNumbers.Length; i++)
            {
                word[i] = integersValues[encodedNumbers[i]];
            }
        }

        public String CheckingPunctuations(string input, string original)
        {
            String result = "";
            result = PunctuationsPositive(input, original, result);
            if (result.Length == 0)
            {
                result = input;
            }

            return result;
        }

        private static string PunctuationsPositive(string input, string original, string result)
        {
            for (int i = 0; i < original.Length; i++)
            {
                bool condition = char.IsPunctuation(original[i]);
                result = AddingPunctuation(input, original, result, i, condition);
            }

            return result;
        }

        private static string AddingPunctuation(string input, string original, string result, int i, bool condition)
        {
            if (condition)
            {
                result = input.Insert(i, char.ToString(original[i]));
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CipherSolver c = new CipherSolver();
        }
    }
}
