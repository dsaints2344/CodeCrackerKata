using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BreakTheCaesar;

namespace CodeCrackerTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ReturnNumberOfLetter()
        {
            string input = "A";

            int[] expected = { 0 };

            CipherSolver c = new CipherSolver();

            var actualOutput = c.ConvertStringToNumbers(input);

            CollectionAssert.AreEqual(expected, actualOutput);

        }

        [TestMethod]
        public void ReturnNumberOfLowerLetter()
        {
            string input = "a";
            int[] expected = { 0 };

            CipherSolver c = new CipherSolver();

            var actualOutput = c.ConvertStringToNumbers(input);
            CollectionAssert.AreEqual(expected, actualOutput);

        }

        [TestMethod]
        public void ReturnNumbersOfWord()
        {
            string input = "hola";
            int[] expected = { 7, 14, 11, 0 };

            CipherSolver c = new CipherSolver();
            var actualOutput = c.ConvertStringToNumbers(input);

            CollectionAssert.AreEqual(expected, actualOutput);
        }

        [TestMethod]
        public void ReturnNumberOfWordsWithSpace()
        {
            string input = "hola a";
            int[] expected = { 7, 14, 11, 0, 0 };

            CipherSolver c = new CipherSolver();
            var actualOutput = c.ConvertStringToNumbers(input);

            CollectionAssert.AreEqual(expected, actualOutput);
        }

        [TestMethod]
        public void ReturnNumbersOfWordsWithSpecialChar()
        {
            string input = "hola a.";
            int[] expected = { 7, 14, 11, 0, 0 };

            CipherSolver c = new CipherSolver();
            var actualOutput = c.ConvertStringToNumbers(input);

            CollectionAssert.AreEqual(expected, actualOutput);
        }

        [TestMethod]
        public void EncodeNumbers()
        {
            //word: hello
            int[] input = { 7, 4, 11, 11, 14 };

            int[] expected = { 10, 7, 14, 14, 17 };
            // Amount of letter's shift
            int shiftKey = 3;
            CipherSolver c = new CipherSolver();

            var actualOutput = c.EncodeNumbers(input, shiftKey);

            CollectionAssert.AreEqual(expected, actualOutput);
        }

        [TestMethod]
        public void EncodeNumbersGreaterTwentyFive()
        {
            //letters: XYZ
            int[] input = { 23, 24, 25 };

            //letter's shift
            int shift = 6;

            int[] expected = { 3, 4, 5 };
            CipherSolver c = new CipherSolver();
            var actualOutput = c.EncodeNumbers(input, shift);

            CollectionAssert.AreEqual(expected, actualOutput);
        }

        [TestMethod]
        public void ReturnEncryptedWord()
        {
            string input = "hello";
            String expected = "IFMMP";

            int shift = 1;

            CipherSolver c = new CipherSolver();
            var actualOutput = c.EncryptedWords(input, shift);

            Assert.AreEqual(expected, actualOutput);


        }

        [TestMethod]
        public void ReturnEncryptedWords()
        {
            string input = "hello Sir";
            string expected = "IFMMP TJS";

            int shift = 1;
            CipherSolver c = new CipherSolver();
            var actualOutput = c.EncryptedWords(input, shift);

            Assert.AreEqual(expected, actualOutput);
        }

        [TestMethod]
        public void ReturnEncryptedWordsWithPunctuation()
        {
            string input = "Hello There.";
            string resultWithNoPunctuation = "IFMMP UIFSF";

            string expected = "IFMMP UIFSF.";

            CipherSolver c = new CipherSolver();
            var actualOutput = c.CheckingPunctuations(resultWithNoPunctuation, input);

            Assert.AreEqual(expected, actualOutput);
        }

    }
}
