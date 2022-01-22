using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            string isResume = "y";
            while (isResume == "y")
            {
                Console.Clear();
                Console.Title = "Algorithms - Word(s) graphs";
                string word = "";
                char[] alphabets =
                {
                'a','b','c','d','e',
                'f','g','h','i','j',
                'k','l','m','n','o',
                'p','q','r','s','t',
                'u','v','w','x','y','z'
                };

                char[] wordBreak = { };
                int[] yCoordinates;

                void PrintHeader()
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Algorithms - Creating line graph from words/sentence");
                    Console.WriteLine("====================================================");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("INSTRUCTIONS");
                    Console.WriteLine("=============================================================================");
                    Console.WriteLine("1. Enter any words or sentence and let the magic begin");
                    Console.WriteLine("2. No numbers or characters are accepted - will be taken out from the word(s)");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                PrintHeader();
                try
                {
                    string getWord()
                    {
                        Console.Write("Enter any word or sentence: ");
                        word = Console.ReadLine();
                        word = word.ToLower();
                        return word;
                    }
                    word = getWord();


                    bool CheckWordIsNull(string inWord)
                    {
                        if (inWord.Length < 1)
                            return true;
                        else if (inWord.Length >= 1)
                            return false;
                        else
                            return false;
                    }

                    bool checkForNull = CheckWordIsNull(word);

                    void Calculate(string inWord)
                    {
                        wordBreak = word.ToCharArray();

                        if (wordBreak.Any())
                        {
                            yCoordinates = new int[wordBreak.Length];
                            for (int i = 0; i < wordBreak.Length; i++)
                            {
                                if (alphabets.Contains(wordBreak[i]))
                                {
                                    int indexOfAlpha = Array.IndexOf(alphabets, wordBreak[i]);
                                    yCoordinates[i] = indexOfAlpha;
                                }
                            }
                            Console.WriteLine("Don't close app.");
                            Console.WriteLine("Please wait your chart is generating.....");
                            Application.EnableVisualStyles();
                            Application.Run(new GraphUI(yCoordinates));
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong...");
                            Environment.Exit(0);
                        }
                    }

                    void RunTest()
                    {
                        if (checkForNull)
                        {
                            Console.WriteLine("Restart again.... Word cannot be empty.");
                            while (checkForNull == true)
                            {
                                word = getWord();
                                checkForNull = CheckWordIsNull(word);
                                if (checkForNull)
                                    Console.WriteLine("Restart again.... Word cannot be empty.");
                            }
                            if (!checkForNull)
                                Calculate(word);
                        }
                        else
                        {
                            Calculate(word);
                        }
                    }
                    RunTest();
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine("Error is:");
                    Console.WriteLine(ex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error is:");
                    Console.WriteLine(ex.Message);
                }
                Console.Write("Do you wish to continue [y or n]: ");
                isResume = Console.ReadLine();
                isResume = isResume.ToLower();
            }
            Environment.Exit(0);
            Console.ReadKey();
        }
    }
}
