using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MD5_Hash.Controller
{
    public class SortController
    {


        public  List<string> SortWords(string word1, string word2, List<string> listToAdd, List<int> charCount)
        {

            char[] ch1 = word1.ToLower().ToCharArray();
          
            int count1 = word1.Count(x => x == 'a');
            int count2 = word1.Count(x => x == 'i');
            int count3 = word1.Count(x => x == 'n');
            int count4 = word1.Count(x => x == 'w');
            int count5 = word1.Count(x => x == 'y');
            int count6 = word1.Count(x => x == 'p');
            int count7 = word1.Count(x => x == 'l');
            int count8 = word1.Count(x => x == 'r');
            int count9 = word1.Count(x => x == 'o');
            int count10 = word1.Count(x => x == 's');
            int count11 = word1.Count(x => x == 'u');

          

            List<bool> checkAlltrue = new List<bool>();
          


            if ((count1 > 1 || count2 > 1 || count3 > 1 || count4 > 1 || count5 > 1 || count6 > 1 || count7 > 1 || count8 > 1 || count9 > 2 || count10 > 2 || count11 > 2))
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

        public List<string> GenerateWordList()
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
    }
}
