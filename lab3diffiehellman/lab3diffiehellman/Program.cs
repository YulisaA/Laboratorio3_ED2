using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
          
            Parametros parametros = new Parametros();            



            S_DES my_Des = new S_DES();
            Cifrar Cifrado = new Cifrar();
            Descifrar Descifrado = new Descifrar();

                Console.WriteLine("Ingrese el comando y la dirección del archivo a cifrar:");
                string textoIngresado = Console.ReadLine();

                string Direccion = parametros.ObtenerDirección(textoIngresado);
                string nombreArchivo = Path.GetFileNameWithoutExtension(Direccion);

                if (parametros.validarComprimir(textoIngresado))
                {
                    Cifrado.CrearCifrado(Direccion, nombreArchivo);
                    Console.WriteLine("Cifrado completo.");
                }
                else
                {
                    Console.WriteLine("Asegúrese de ingresar el parámetro -c para cifrar y -f antes de la ruta.");
                    Console.WriteLine("Ejemplo: -c -f\"DirecciónDelArchivo\"");
                }           

                Console.WriteLine("");
                Console.WriteLine("Ingrese el comando y la dirección del archivo a descifrar:");
                string textoIngresado2 = Console.ReadLine();
                string Direccion2 = parametros.ObtenerDirección(textoIngresado2);
                string extension = Path.GetExtension(Direccion);

                if (parametros.validarDescomprimir(textoIngresado2))
                {
                    Descifrado.CrearDescifrado(Direccion2, extension);
                    Console.WriteLine("Descifrado completo.");
                }
                else
                {
                    Console.WriteLine("Asegúrese de ingresar el parámetro -d para descifrar y -f antes de la ruta.");
                    Console.WriteLine("Ejemplo: -d -f\"DirecciónDelArchivo\"");
                }


            Console.ReadLine();
        }

    }
}
