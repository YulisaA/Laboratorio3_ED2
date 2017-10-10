using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3diffiehellman
{
    class DiffieHellman
    {
        
        public string getKey(string key)
        {
            string result =  Convert.ToString(int.Parse(key), 2);

            if(result.Length > 10)
            {
                 return result.Substring(0, 10);
            }
            while(result.Length < 10)
            {
                result += "0";
            }
            return result;
        }

        //For Alice
        public int AKey(int a, int p, int q)
        {           
            int aKey = 0;
            aKey = (q ^ a) % p;

            return aKey; 
        }
        public int XKey1(int bKey, int a, int p)
        {
            int xKey = 0;

            xKey = (bKey ^ a) % p;

            return xKey;
        }
        //For Bob
        public int BKey(int b, int p, int q)
        {
            int bKey = 0;
            bKey = (q ^ b) % p;

            return bKey;
        }
        public int XKey2(int aKey, int b, int p)
        {
            int xKey = 0;

            xKey = (aKey ^ b) % p;

            return xKey;
        }

        public bool verifyIfPrime(int p)
        {
            int cont = 0;
            for (int i = 1; i <= p; i++)
            {
                if (p % i == 0)
                {
                    cont++;
                }
            }
            if (cont == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Obtain random numbers
        public int[] randomValues()
        {
            int[] numbers = new int[4];
            Random rnd = new Random();
            int a = rnd.Next(0, 999);
            int b = rnd.Next(0, 999);
            int p = rnd.Next(300, 1000);
            int q = rnd.Next(0, 999);
               
            while(!verifyIfPrime(p))
            {
                p = rnd.Next(300, 1000);
            }
            while(!verifyIfPrime(q) || q >= p)
            {
                q = rnd.Next(0, 999);
            }

            while (!(a < p))
            {
                a = rnd.Next(0, 999);
            }           
            while (!(b < p))
            {
                b = rnd.Next(0, 999);
            }

            numbers[0] = a;
            numbers[1] = b;
            numbers[2] = p;
            numbers[3] = q;

            return numbers;
        }
    }
}
