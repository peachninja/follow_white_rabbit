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



            char[] ch2 = { 'a', 'i', 'n', 'w', 'y', 'p' };
            int count1 = word1.Count(x => x == 'a');
            int count2 = word1.Count(x => x == 'i');
            int count3 = word1.Count(x => x == 'n');
            int count4 = word1.Count(x => x == 'w');
            int count5 = word1.Count(x => x == 'y');
            int count6 = word1.Count(x => x == 'p');

            //charCount[0] += count1;
            //charCount[1] += count2;
            //charCount[2] += count3;
            //charCount[3] += count4;
            //charCount[4] += count5;
            //charCount[5] += count6;



            List<bool> checkAlltrue = new List<bool>();
          


            if ((count1 > 1 || count2 > 1 || count3 > 1 || count4 > 1 || count5 > 1 || count6 > 1))
            {

                return listToAdd;
            }
            //if (charCount[0] > 1|| charCount[1] > 1 || charCount[2] > 1 || charCount[3] > 1 || charCount[4] > 1 || charCount[5] > 1 )
            //{
            //    return listToAdd;
            //}
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
