using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3diffiehellman
{
    class Program
    {
        static void Main(string[] args)
        {
            DiffieHellman diffieMethods = new DiffieHellman();
            /*numbers[0] = a;
            numbers[1] = b;
            numbers[2] = p;
            numbers[3] = q;*/

            int [] values = diffieMethods.randomValues();
            int publicKeyA = diffieMethods.AKey(values[0], values[2], values[3]);
            int publicKeyB = diffieMethods.BKey(values[1], values[2], values[3]);
            

            int a = diffieMethods.XKey1(publicKeyB, values[0], values[2]);

            int b = diffieMethods.XKey2(publicKeyA, values[1], values[2]);

            Console.WriteLine("Clave pública A: " + diffieMethods.getKey(publicKeyA.ToString()));
            Console.WriteLine("Clave pública B: " + diffieMethods.getKey(publicKeyB.ToString()));

            Console.WriteLine("");

            Console.WriteLine("Clave privada: " + diffieMethods.getKey(a.ToString()));
            Console.WriteLine("Clave privada (comprobación): " + diffieMethods.getKey(b.ToString()));

            Console.ReadLine();
        }

    }
}
