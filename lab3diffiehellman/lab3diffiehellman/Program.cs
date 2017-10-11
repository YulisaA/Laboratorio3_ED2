using System;
using System.Collections;
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
            int publicKeyA = diffieMethods.AKey(6, 23, 11);
            int publicKeyB = diffieMethods.BKey(5, 23, 11);

            int a = diffieMethods.XKey1(publicKeyB, 251, 739);

            int b = diffieMethods.XKey2(publicKeyA, 87, 223);
            Console.WriteLine("Clave pública A: " + diffieMethods.getKey(publicKeyA.ToString()));
            Console.WriteLine("Clave pública B: " + diffieMethods.getKey(publicKeyB.ToString()));

            Console.WriteLine("Clave privada: " + diffieMethods.getKey(a.ToString()));
            Console.WriteLine("Clave privada (comprobación): " + diffieMethods.getKey(b.ToString()));
            Console.WriteLine("");
            Console.WriteLine("Ingrese su direccion");
            string Direccion = Console.ReadLine();
            S_DES my_Des = new S_DES();
            Cifrar Cifrado = new Cifrar();
            Cifrado.CrearCifrado(Direccion);

            Console.WriteLine("Cifrado completo");

            Console.WriteLine("Ingrese su direccion2");
            string Direccion2 = Console.ReadLine();
            Descifrar Descifrado = new Descifrar();
            Descifrado.CrearDescifrado(Direccion2);
            Console.WriteLine("Descifrado completo");
            Console.ReadKey();

            Console.ReadLine();
        }

    }
}
