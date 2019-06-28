using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace MD5_Hash.Controller
{
    internal class ConsoleSpinner
    {
        private int _currentAnimationFrame;

        public ConsoleSpinner()
        {
            SpinnerAnimationFrames = new[]
                                     {
                                         '|',
                                         '/',
                                         '-',
                                         '\\'
                                     };
        }

        public char[] SpinnerAnimationFrames { get; set; }

        public void UpdateProgress()
        {
            // Store the current position of the cursor
         
            Console.CursorVisible = false;

            // Store the current position of the cursor
            var originalX = Console.CursorLeft;
            var originalY = Console.CursorTop;
            // Write the next frame (character) in the spinner animation
            Console.Write(SpinnerAnimationFrames[_currentAnimationFrame]);

            // Keep looping around all the animation frames
            _currentAnimationFrame++;
            if (_currentAnimationFrame == SpinnerAnimationFrames.Length)
            {
                _currentAnimationFrame = 0;
            }

            // Restore cursor to original position
            Console.SetCursorPosition(originalX, originalY);
        }
    }
    public class AppController
    {
        CombinationController combinationController;
        Md5Controller md5Controller;
        SortController sortController;
        public string ConstText { get; set; }
        public string HashKey { get; set; }
        public int Combinations { get; set; }
        public AppController(string text, string hashKey, int combinations)
        {
            combinationController = new CombinationController();
            md5Controller = new Md5Controller();
            sortController = new SortController();
            ConstText = text;
            HashKey = hashKey;
            Combinations = combinations;
        }


        public void Run()
        {
            List<string> wordsList = sortController.GenerateWordList();

            List<string> anagramWordList = new List<string>();
            List<int> charCount = new List<int>();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long count = 0;
           
            for (int i = 0; i < 6; i++)
            {
                charCount.Add(0);
            }

            var s = new ConsoleSpinner();


            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Console.WriteLine("Finding the secret phase.....");
            foreach (string word1 in wordsList)
            {

                sortController.SortWords(word1, ConstText, anagramWordList, charCount);
            }
            bool spinning = true;


            //using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "combinations2134.txt"), true))
            //{
            //    foreach (var i in anagramWordList)
            //    {
            //        outputFile.WriteLine(i);
            //    }
            //}



            foreach (string[] i in combinationController.CombinationsRosettaWoRecursion(anagramWordList, 3).AsParallel())
            {



                s.UpdateProgress();

                count++;
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "combinations.txt"), true))
                {


                    outputFile.WriteLine(string.Join(" ", i));
                    string hashTobeCheck = md5Controller.Md5Hash(string.Join(" ", i));
                    if (hashTobeCheck == HashKey)
                    {

                        Console.WriteLine(string.Join(" ", i));
                        outputFile.WriteLine(count);
                        stopWatch.Stop();


                        TimeSpan ts = stopWatch.Elapsed;


                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                            ts.Hours, ts.Minutes, ts.Seconds,
                            ts.Milliseconds / 10);
                        outputFile.WriteLine(elapsedTime);

                        break;
                    }


                }
            }




            Console.ReadKey();

        }
    }
}
