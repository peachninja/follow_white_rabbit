using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MD5_Hash.Controller
{
   public class CombinationController
    {

       


        private  IEnumerable<int[]> CombinationsRosettaWoRecursion(int m, int n)
        {
            int[] result = new int[m];
            Stack<int> stack = new Stack<int>(m);
            stack.Push(0);
            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();
                while (value < n)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index != m) continue;
                    yield return (int[])result.Clone(); // thanks to @xanatos
                    //yield return result;
                    break;
                }
            }
        }

        public  IEnumerable<T[]> CombinationsRosettaWoRecursion<T>(IEnumerable<T> elements, int m)
        {
            var array = elements.ToArray();
            string text = "poultry outwits ants";
            char[] ch1 = text.ToLower().ToCharArray();
            Array.Sort(ch1);
            string val1 = new string(ch1);
            string val2 = "";
            char[] ch2 = val2.ToCharArray();
            //var size = elem.Length;
            if (array.Length < m)
                throw new ArgumentException("Array length can't be less than number of selected elements");
            if (m < 1)
                throw new ArgumentException("Number of selected elements can't be less than 1");
            T[] result = new T[m];
            foreach (int[] j in CombinationsRosettaWoRecursion(m, array.Length))
            {
                for (int i = 0; i < m; i++)
                {
                    result[i] = array[j[i]];
                }

                ch2 = string.Join(" ", result).ToLower().ToCharArray();
                Array.Sort(ch2);
                val2 = new string(ch2);
                //int count1 = string.Join(" ", result).Count(x => x == 'a');
                //int count2 = string.Join(" ", result).Count(x => x == 'i');
                //int count3 = string.Join(" ", result).Count(x => x == 'n');
                //int count4 = string.Join(" ", result).Count(x => x == 'w');
                //int count5 = string.Join(" ", result).Count(x => x == 'y');
                //int count6 = string.Join(" ", result).Count(x => x == 'p');
                //int count9 = string.Join(" ", result).Count(x => x == 'o');
                //int count10 = string.Join(" ", result).Count(x => x == 's');


                //if (string.Join(" ", result).Length == 20 && !(count1 > 1 || count2 > 1 || count3 > 1 || count4 > 1 || count5 > 1 || count6 > 1 || count9 > 2 || count10 > 2))
                //{
                //    yield return result;
                //}
                if (val1 == val2)
                {
                    yield return result;
                }




            }
        }
    }
}
