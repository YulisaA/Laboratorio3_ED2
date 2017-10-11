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
