using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MD5_Hash.Controller
{
   public class AppController
    {
        CombinationController combinationController ;
        Md5Controller md5Controller ;
        SortController sortController ;
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
            List<string> wordsList =  sortController.GenerateWordList();

            List<string> anagramWordList = new List<string>();
            List<int> charCount = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                charCount.Add(0);
            }
            Console.WriteLine("Brute Forcing.....");
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            foreach (string word1 in wordsList)
            {

                sortController.SortWords(word1, ConstText, anagramWordList, charCount);
            }
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long count = 0;
            foreach (IEnumerable<string> i in combinationController.Combinations(anagramWordList, Combinations).AsParallel())
            {
                count++;
              
                if (string.Join(" ", i).Length == 20)
                {
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "combinations.txt"), true))
                    {
                    string hashTobeCheck = md5Controller.Md5Hash(string.Join(" ", i));
                    if (hashTobeCheck == HashKey)
                    {
                        outputFile.WriteLine(string.Join(" ", i));
                        Console.WriteLine(string.Join(" ", i));
                        outputFile.WriteLine(count);
                        stopWatch.Stop();


                        TimeSpan ts = stopWatch.Elapsed;

                        // Format and display the TimeSpan value.
                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                            ts.Hours, ts.Minutes, ts.Seconds,
                            ts.Milliseconds / 10);
                        outputFile.WriteLine(elapsedTime);
                            break;
                    }
                    }

                }

            }

         
            Console.ReadKey();

        }
    }
}
