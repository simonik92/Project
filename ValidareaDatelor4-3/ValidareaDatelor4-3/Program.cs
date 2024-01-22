using System;

class Program
{
    public static void Main(string[] args)
    {
        string phrase = Console.ReadLine();
        int numberOfWords = NumberValidation();
        string[] listOfWords = CreateAListOfWords(numberOfWords);
        string[] secondListOfWords = CreateASecondListOfWordsFromPhrase(phrase);
        if (IsCorrect(secondListOfWords, listOfWords))
        {
            Console.WriteLine("Text corect!");
        }
        else
        {
            CheckAll(secondListOfWords, listOfWords);
        }
    }

    public static int NumberValidation()
    {
        string stringNumber = Console.ReadLine();
        if (int.TryParse(stringNumber, out int value))
        {
            return value;
        }

        return 0;
    }

    public static string[] CreateAListOfWords(int numberOfWords)
    {
        string[] listOfWords = new string[numberOfWords];
        for (int i = 0; i < numberOfWords; i++)
        {
            listOfWords[i] = Console.ReadLine();
        }

        return listOfWords;
    }

    public static string[] CreateASecondListOfWordsFromPhrase(string phrase)
    {
        string lowerCasePhrase = phrase.ToLower();
        int count = 1;
        for (int i = 0; i < lowerCasePhrase.Length; i++)
        {
            if (lowerCasePhrase[i] == ' ')
            {
                count++;
            }
        }

        string[] listOfWords = new string[count];
        count = 0;

        for (int i = 0; i < lowerCasePhrase.Length; i++)
        {
            if (phrase[i] != ' ')
            {
                listOfWords[count] += lowerCasePhrase[i];
            }
            else
            {
                count++;
            }
        }

        return listOfWords;
    }

    public static string[] TheWordsFromTheListHasSameLength(string wordOfThePhrase, string[] listOfWords)
    {
        int count = 0;
        for (int j = 0; j < listOfWords.Length; j++)
        {
            if (wordOfThePhrase.Length == listOfWords[j].Length)
            {
                count++;
            }
        }

        string[] result = new string[count];
        count = 0;
        for (int j = 0; j < listOfWords.Length; j++)
        {
            if (wordOfThePhrase.Length == listOfWords[j].Length)
            {
                result[count] = listOfWords[j];
                count++;
            }
        }

        return result;
    }

    public static string[] TheWordsFromTheListHasLessLetters(string[] list, string theWord)
    {
        int count = 0;
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i].Length + 1 == theWord.Length)
            {
                count++;
            }
        }

        string[] wordOfTheListWithLessLetters = new string[count];
        count = 0;
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i].Length + 1 == theWord.Length)
            {
                wordOfTheListWithLessLetters[count] = list[i];
                count++;
            }
        }

        return wordOfTheListWithLessLetters;
    }

    public static int CountingLessLetterList(string[] list, string theWord)
    {
        int contor = 0;
        for (int i = 0; i < list.Length; i++)
        {
            int count = 0;
            int differentLetter = 0;
            for (int j = 0; j < list[i].Length; j++)
            {
                if (theWord[count] == list[i][j])
                {
                    count++;
                }
                else
                {
                    differentLetter++;
                }
            }

            if (differentLetter <= 1)
            {
                contor++;
            }
        }

        return contor;
    }

    public static string[] CheckOneLessLetterList(string[] list, string theWord, int number)
    {
        string[] oneLetterLessList = new string[number];
        int contor = 0;
        for (int i = 0; i < list.Length; i++)
        {
            int count = 0;
            int differentLetter = 0;
            for (int j = 0; j < list[i].Length; j++)
            {
                if (theWord[count] == list[i][j])
                {
                    count++;
                }
                else
                {
                    differentLetter++;
                }
            }

            if (differentLetter <= 1)
            {
                oneLetterLessList[contor] = list[i];
                contor++;
            }
        }

        return oneLetterLessList;
    }

    public static string[] TheWordsFromTheListHasMoreLetters(string[] list, string theWord)
    {
        int count = 0;
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i].Length - 1 == theWord.Length)
            {
                count++;
            }
        }

        string[] wordOfTheListWithMoreLetters = new string[count];
        count = 0;
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i].Length - 1 == theWord.Length)
            {
                wordOfTheListWithMoreLetters[count] = list[i];
                count++;
            }
        }

        return wordOfTheListWithMoreLetters;
    }

    public static int CountingMoreLetterList(string[] list, string theWord)
    {
        int contor = 0;
        for (int i = 0; i < list.Length; i++)
        {
            int count = 0;
            int differentLetter = 0;
            for (int j = 0; j < theWord.Length; j++)
            {
                if (theWord[count] == list[i][j])
                {
                    count++;
                }
                else
                {
                    differentLetter++;
                }
            }

            if (differentLetter <= 1)
            {
                contor++;
            }
        }

        return contor;
    }

    public static string[] CheckOneMoreLetterList(string[] list, string theWord, int number)
    {
        string[] oneLetterMoreList = new string[number];
        int contor = 0;
        for (int i = 0; i < list.Length; i++)
        {
            int count = 0;
            int differentLetter = 0;
            for (int j = 0; j < theWord.Length; j++)
            {
                if (theWord[count] == list[i][j])
                {
                    count++;
                }
                else
                {
                    differentLetter++;
                }
            }

            if (differentLetter <= 1)
            {
                oneLetterMoreList[contor] = list[i];
                contor++;
            }
        }

        return oneLetterMoreList;
    }

    public static int CountingWrongLetters(string word, string[] secondList)
    {
        int counter = 0;
        for (int i = 0; i < secondList.Length; i++)
        {
            int count = 0;
            for (int j = 0; j < word.Length; j++)
            {
                if (word[j] == secondList[i][j])
                {
                    continue;
                }

                count++;
            }

            if (count == 1)
            {
                counter++;
            }
            else if (count == 0)
            {
                counter = 0;
                break;
            }
        }

        return counter;
    }

    public static string[] HasOneWrongLetterFromList(string word, string[] secondList, int number)
    {
        string[] listOfWords = new string[number];
        int counter = 0;
        for (int i = 0; i < secondList.Length; i++)
        {
            int count = 0;
            for (int j = 0; j < word.Length; j++)
            {
                if (word[j] == secondList[i][j])
                {
                    continue;
                }

                count++;
            }

            if (count == 1)
            {
                listOfWords[counter] = secondList[i];
                counter++;
            }
        }

        return listOfWords;
    }

    public static int CountingReverseLetters(string word, string[] secondList)
    {
        int counter = 0;
        for (int i = 0; i < secondList.Length; i++)
        {
            int count = 0;

            for (int j = 1; j < word.Length; j++)
            {
                if (word[j - 1] == secondList[i][j] && word[j] == secondList[i][j - 1])
                {
                    count++;
                }
            }

            if (count == 1)
            {
                counter++;
            }
        }

        return counter;
    }

    public static string[] HasReverseLetters(string word, string[] secondList, int number)
    {
        string[] listOfWords = new string[number];
        int counter = 0;
        for (int i = 0; i < secondList.Length; i++)
        {
            int count = 0;

            for (int j = 1; j < word.Length; j++)
            {
                if (word[j - 1] == secondList[i][j] && word[j] == secondList[i][j - 1])
                {
                    count++;
                }
            }

            if (count == 1)
            {
                listOfWords[counter] = secondList[i];
                counter++;
            }
        }

        return listOfWords;
    }

    public static bool IsTheWord(string word, string[] secondList)
    {
        bool result = false;
        for (int i = 0; i < secondList.Length; i++)
        {
            int count = 0;
            for (int j = 0; j < word.Length; j++)
            {
                if (word[j] == secondList[i][j])
                {
                    continue;
                }

                count++;
            }

            if (count == 0)
            {
                result = true;
            }
        }

        return result;
    }

    public static void CheckAll(string[] secondListOfWords, string[] listOfWords)
    {
        string wordOfThePhrase;
        for (int i = 0; i < secondListOfWords.Length; i++)
        {
            wordOfThePhrase = secondListOfWords[i];
            string[] listOfWordsWithSameNrOfLetters = TheWordsFromTheListHasSameLength(wordOfThePhrase, listOfWords);
            int countingWrong = CountingWrongLetters(wordOfThePhrase, listOfWordsWithSameNrOfLetters);
            string[] wordsWithOneLetterWrong = HasOneWrongLetterFromList(wordOfThePhrase, listOfWordsWithSameNrOfLetters, countingWrong);
            int countingReverse = CountingReverseLetters(wordOfThePhrase, listOfWordsWithSameNrOfLetters);
            string[] wordsWithReverseLetters = HasReverseLetters(wordOfThePhrase, listOfWordsWithSameNrOfLetters, countingReverse);
            string[] oneLessLetter = TheWordsFromTheListHasLessLetters(listOfWords, wordOfThePhrase);
            int countingLess = CountingLessLetterList(oneLessLetter, wordOfThePhrase);
            string[] finalListForOneLetterLess = CheckOneLessLetterList(oneLessLetter, wordOfThePhrase, countingLess);
            string[] oneMoreLetter = TheWordsFromTheListHasMoreLetters(listOfWords, wordOfThePhrase);
            int countingMore = CountingMoreLetterList(oneMoreLetter, wordOfThePhrase);
            string[] finalListForOneLetterMore = CheckOneMoreLetterList(oneMoreLetter, wordOfThePhrase, countingMore);
            bool v = listOfWordsWithSameNrOfLetters.Length > 0;
            bool a = IsTheWord(wordOfThePhrase, listOfWordsWithSameNrOfLetters);
            if (v && a)
            {
                continue;
            }

            Console.Write(wordOfThePhrase + ":");
            SolveTheSameNumberOfLetters(wordOfThePhrase, listOfWords);
            SolveOneLetterLess(wordOfThePhrase, listOfWords);

            SolveOneLetterMore(wordOfThePhrase, listOfWords);

            if (wordsWithOneLetterWrong.Length == 0 && wordsWithReverseLetters.Length == 0 && finalListForOneLetterLess.Length == 0 && finalListForOneLetterMore.Length == 0)
            {
                Console.Write(" (nu sunt sugestii)");
            }

            Console.WriteLine();
        }
    }

    public static void SolveTheSameNumberOfLetters(string wordOfThePhrase, string[] listOfWords)
    {
        string[] listOfWordsWithSameNrOfLetters = TheWordsFromTheListHasSameLength(wordOfThePhrase, listOfWords);
        int countingWrong = CountingWrongLetters(wordOfThePhrase, listOfWordsWithSameNrOfLetters);
        string[] wordsWithOneLetterWrong = HasOneWrongLetterFromList(wordOfThePhrase, listOfWordsWithSameNrOfLetters, countingWrong);
        int countingReverse = CountingReverseLetters(wordOfThePhrase, listOfWordsWithSameNrOfLetters);
        string[] wordsWithReverseLetters = HasReverseLetters(wordOfThePhrase, listOfWordsWithSameNrOfLetters, countingReverse);
        if (wordsWithOneLetterWrong.Length > 0)
        {
            for (int j = 0; j < wordsWithOneLetterWrong.Length; j++)
            {
                Console.Write(" " + wordsWithOneLetterWrong[j]);
            }
        }

        if (wordsWithReverseLetters.Length > 0)
        {
            for (int j = 0; j < wordsWithReverseLetters.Length; j++)
            {
                Console.Write(" " + wordsWithReverseLetters[j]);
            }
        }
    }

    public static void SolveOneLetterLess(string wordOfThePhrase, string[] listOfWords)
    {
        string[] oneLessLetter = TheWordsFromTheListHasLessLetters(listOfWords, wordOfThePhrase);
        int countingLess = CountingLessLetterList(oneLessLetter, wordOfThePhrase);
        string[] finalListForOneLetterLess = CheckOneLessLetterList(oneLessLetter, wordOfThePhrase, countingLess);
        if (finalListForOneLetterLess.Length == 0)
        {
            Console.Write("");
        }
        else
        {
            for (int j = 0; j < finalListForOneLetterLess.Length; j++)
            {
                Console.Write(" " + finalListForOneLetterLess[j]);
            }
        }
    }

    public static void SolveOneLetterMore(string wordOfThePhrase, string[] listOfWords)
    {
        string[] oneMoreLetter = TheWordsFromTheListHasMoreLetters(listOfWords, wordOfThePhrase);
        int countingMore = CountingMoreLetterList(oneMoreLetter, wordOfThePhrase);
        string[] finalListForOneLetterMore = CheckOneMoreLetterList(oneMoreLetter, wordOfThePhrase, countingMore);
        if (finalListForOneLetterMore.Length > 0)
        {
            for (int j = 0; j < finalListForOneLetterMore.Length; j++)
            {
                Console.Write(" " + finalListForOneLetterMore[j]);
            }
        }
        else
        {
            Console.Write("");
        }
    }

    public static bool IsCorrect(string[] secondListOfWords, string[] listOfWords)
    {
        int counter = 0;
        bool result = false;
        string wordOfThePhrase;
        for (int i = 0; i < secondListOfWords.Length; i++)
        {
            wordOfThePhrase = secondListOfWords[i];
            string[] listOfWordsWithSameNrOfLetters = TheWordsFromTheListHasSameLength(wordOfThePhrase, listOfWords);
            int count = CountingLetters(wordOfThePhrase, listOfWordsWithSameNrOfLetters);

            if (listOfWordsWithSameNrOfLetters.Length > 0 && count == 1)
            {
                counter++;
            }
        }

        if (counter == secondListOfWords.Length)
        {
            result = true;
        }

        return result;
    }

    public static int CountingLetters(string word, string[] secondList)
    {
        int counter = 0;
        for (int i = 0; i < secondList.Length; i++)
        {
            int count = 0;
            for (int j = 0; j < word.Length; j++)
            {
                if (word[j] != secondList[i][j])
                {
                    count++;
                }
            }

            if (count == 0)
            {
                counter++;
            }
        }

        return counter;
    }
}