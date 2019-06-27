using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MD5_Hash.Controller;

namespace MD5_Hash
{
    class Program
    {

        static void Main(string[] args)
        {
            const string text = "poultry outwits ants";
            const string hashToCheck = "e4820b45d2277f3844eac66c903e84be";
            //Console.WriteLine("Brute Forcing.....");
            const int k = 3;
            AppController appController = new AppController(text, hashToCheck, k);
            appController.Run();
            //List<string> anagramWordList = new List<string>();
            //List<string> wordList = GenerateWordList();
            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();
            //foreach (string word1 in wordList)
            //{

            //    SortWords(word1, text, anagramWordList);



            //}
            //long countCombinations = 0;
            //string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


            //Parallel.ForEach<Enumerable<T>(Combinations(anagramWordList, k), i =>
            //{
            //    //countCombinations++;
            //    //if (string.Join(" ", i).Length == 20)
            //    //{
            //    //    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "combinations.txt"), true))
            //    //    {
            //    //        outputFile.WriteLine(string.Join(" ", i));
            //    //        string hashTobeCheck = Md5Hash(string.Join(" ", i));
            //    //        if (hashTobeCheck == hashToCheck)
            //    //        {

            //    //            Console.WriteLine(string.Join(" ", i));
            //    //            outputFile.WriteLine(countCombinations);
            //    //            stopWatch.Stop();

            //    //        }
            //    //    }
            //    //}
            //});

            //foreach (IEnumerable<string> i in Combinations(anagramWordList, k).AsParallel())
            //{
            //    countCombinations++;
            //    if (string.Join(" ", i).Length == 20)
            //    {
            //        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "combinations.txt"), true))
            //        {
                        
            //            string hashTobeCheck = Md5Hash(string.Join(" ", i));
            //            if (hashTobeCheck == hashToCheck)
            //            {
            //                outputFile.WriteLine(string.Join(" ", i));
            //                Console.WriteLine(string.Join(" ", i));
            //                outputFile.WriteLine(countCombinations);
            //                stopWatch.Stop();
            //                break;
            //            }
            //        }

            //    }
            //}
            //foreach (IEnumerable<string> i in Combinations(anagramWordList, k))
            //{
            //    countCombinations++;
            //    if (string.Join(" ", i).Length == 20)
            //    {
            //        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "combinations.txt"), true))
            //        {
            //            outputFile.WriteLine(string.Join(" ", i));
            //            string hashTobeCheck = Md5Hash(string.Join(" ", i));
            //            if (hashTobeCheck == hashToCheck)
            //            {
                           
            //                Console.WriteLine(string.Join(" ", i));
            //                outputFile.WriteLine(countCombinations);
            //                stopWatch.Stop();
            //                break;
            //            }
            //        }

            //    }

            ////}
            //TimeSpan ts = stopWatch.Elapsed;

            //// Format and display the TimeSpan value.
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //    ts.Hours, ts.Minutes, ts.Seconds,
            //    ts.Milliseconds / 10);
            //Console.WriteLine("RunTime " + elapsedTime);
            //Console.WriteLine(countCombinations);
            //int debug = 5;
            Console.ReadKey();

        }


        public static List<string> SortWords(string word1, string word2, List<string> listToAdd)
        {

            char[] ch1 = word1.ToLower().ToCharArray();

          
           
            char[] ch2 = {'a','i','n','w', 'y', 'p'};
            int count1 = word1.Where(x => x == 'a').Count();
            int count2 = word1.Where(x => x == 'i').Count();
            int count3 = word1.Where(x => x == 'n').Count();
            int count4 = word1.Where(x => x == 'w').Count();
            int count5 = word1.Where(x => x == 'y').Count();
            int count6 = word1.Where(x => x == 'p').Count();
          


            List<int> countCh2 = new List<int>();
          
            List<bool> checkAlltrue = new List<bool>();
            foreach (var i in ch2)
            {
                int count = word1.Where(x => x == i).Count();
                countCh2.Add(count);
            }
         

            if(count1 > 1 || count2 > 1 || count3 > 1|| count4 > 1 ||count5 > 1 || count6 > 1 )
            {
               
                return listToAdd;
            }
            else
            {
                foreach (var item in ch1)
                {

                    bool checkContains = word2.Contains(item);
                    checkAlltrue.Add(checkContains);
                    if (checkContains == false)
                    {
                        break;
                    }


                }
                if (checkAlltrue.All(x => x))
                {
                    listToAdd.Add(word1);
                }
            }
         
            

          

            return listToAdd;
        }

        public static string Md5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5Provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            foreach (var t in bytes)
            {
                hash.Append(t.ToString("x2"));
            }
            return hash.ToString();
        }
        public static List<string> GenerateWordList()
        {
            string line;
            string path = "../../../resource/wordlist.txt";
            List<string> allWords = new List<string>();
            System.IO.StreamReader file =
              new System.IO.StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                allWords.Add(line);
            }
            file.Close();
            return allWords;
        }




        private static bool NextCombination(IList<int> num, int n, int k)
        {
            bool finished;

            var changed = finished = false;

            if (k <= 0) return false;

            for (var i = k - 1; !finished && !changed; i--)
            {
                if (num[i] < n - 1 - (k - 1) + i)
                {
                    num[i]++;

                    if (i < k - 1)
                        for (var j = i + 1; j < k; j++)
                            num[j] = num[j - 1] + 1;
                    changed = true;
                }
                finished = i == 0;
            }

            return changed;
        }

        private static IEnumerable Combinations<T>(IEnumerable<T> elements, int k)
        {
            var elem = elements.ToArray();
            var size = elem.Length;

            if (k > size) yield break;

            var numbers = new int[k];

            for (var i = 0; i < k; i++)
                numbers[i] = i;

            do
            {
                yield return numbers.Select(n => elem[n]);
            } while (NextCombination(numbers, size, k));
        }

    }
}
