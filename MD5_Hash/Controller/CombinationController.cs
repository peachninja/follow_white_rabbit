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
                    yield return (int[])result.Clone(); 
               
                    break;
                }
            }
        }

        public  IEnumerable<T[]> CombinationsRosettaWoRecursion<T>(IEnumerable<T> elements, int m)
        {
            var array = elements.ToArray();
            string text = "poultry outwits ants";
          
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

              
                char[] ch1 = text.ToLower().ToCharArray();
                char[] ch2 = string.Join(" ", result).ToCharArray();
                Array.Sort(ch1);
                Array.Sort(ch2);
                string val1 = new string(ch1);
                string val2 = new string(ch2);
                if (val1 == val2)
                {
                    yield return result;
                }

            }
        }
    }
}
