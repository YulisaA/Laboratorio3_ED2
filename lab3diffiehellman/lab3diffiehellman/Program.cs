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
            Parametros parametros = new Parametros();            


            S_DES my_Des = new S_DES();
            Cifrar Cifrado = new Cifrar();
            Descifrar Descifrado = new Descifrar();
            Console.WriteLine("Ingrese el comando y la dirección del archivo a cifrar:");
            string textoIngresado = Console.ReadLine();

            string Direccion = parametros.ObtenerDirección(textoIngresado);
            string nombreArchivo = Path.GetFileNameWithoutExtension(Direccion);

            if (parametros.validarComprimir(textoIngresado) == true)
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

            if (parametros.validarDescomprimir(textoIngresado2) == true)
            {            
                Descifrado.CrearDescifrado(Direccion2);
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
