using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
namespace MD5_Hash
{
    class Program
    {
       
        static void Main(string[] args)
        {
            string text = "poultry outwits ants";
          
            List<string> anagramWordList = new List<string>();
           

            string hashToCheck = "e4820b45d2277f3844eac66c903e84be";
          
            List<string> wordList =  GenerateWordList();

            foreach (string word1 in wordList)
            {
               
                    SortWords(word1, text, anagramWordList);
            
               
             
            }
            const int k = 3;
            long countCombinations = 0;
                 //string hashTobeCheck1 = MD5Hash("ty outlaws printouts");
            foreach (IEnumerable<string> i in Combinations(anagramWordList, k))
            {
                countCombinations++;
                if (string.Join(" ", i).Length == 20)
                { 
                    string hashTobeCheck = MD5Hash(string.Join(" ", i));
                    if (hashTobeCheck == hashToCheck)
                    {
                        Console.WriteLine(string.Join(" ", i));
                    }


                }

            }
            Console.WriteLine(countCombinations);
            int debug = 5;
            Console.ReadKey();
        }

        public static List<string> SortWords(string word1, string word2, List<string> listToAdd)
        {
           
            char[] ch1 = word1.ToLower().ToCharArray();

            List<bool> checkAlltrue = new List<bool>();
          
            foreach (var item in ch1)
            {

                bool booleaner = word2.Contains(item);
                checkAlltrue.Add(booleaner);
                if (booleaner == false)
                {
                    break;
                }
           

            }
            if (checkAlltrue.All(x => x))
            {
                listToAdd.Add(word1);
            }
          
            return listToAdd;
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
        public static List<string> GenerateWordList()
        {
            string line;
            List<string> allWords = new List<string>();
            System.IO.StreamReader file =
              new System.IO.StreamReader(@"c:\Users\wmh\Downloads\wordlist.txt");

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
