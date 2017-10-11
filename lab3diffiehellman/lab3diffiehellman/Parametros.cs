using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3diffiehellman
{
    class Parametros
    {
        //Validar -c
        public bool validarComprimir(string TextoIngresado)
        {
            TextoIngresado.TrimStart();
            TextoIngresado.Replace(" ", "");

            if (TextoIngresado.Contains("-c") == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Validar -d
        public bool validarDescomprimir(string TextoIngresado)
        {
            TextoIngresado.TrimStart();
            TextoIngresado.Replace(" ", "");

            if (TextoIngresado.Contains("-d") == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ObtenerDirección(string TextoIngresado)
        {
            string[] direccion = new string[2];
            string ruta = "";
            char delimitador = '"';
            TextoIngresado.TrimStart();
            TextoIngresado.Replace(" ", "");

            if (TextoIngresado.Contains("-f") == true)
            {
                direccion = TextoIngresado.Split(delimitador);
                ruta = direccion[1];
            }
            else
            {
                Console.WriteLine("Ingrese el comando -f antes de la dirección del archivo.");
            }

            return ruta;
        }
    }
}
