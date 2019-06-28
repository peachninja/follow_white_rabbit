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
           // const string hashToCheck = "23170acc097c24edb98fc5488ab033fe";
            const int k = 3;
          
            AppController appController = new AppController(text, hashToCheck, k);
            appController.Run();
        
            Console.ReadKey();

        }

    }
}
