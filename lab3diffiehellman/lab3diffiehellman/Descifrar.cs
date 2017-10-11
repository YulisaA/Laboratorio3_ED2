using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3diffiehellman
{
    class Descifrar
    {
        public void CrearDescifrado(string Direccion)
        {
            S_DES my_Des = new S_DES();
            string DirecciónArchivoDescifrado = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Descifrado.txt";
            FileStream Archivo = new FileStream(Direccion, FileMode.Open);
            BinaryReader Lector = new BinaryReader(Archivo);
            FileStream NuevoArchivo = new FileStream(DirecciónArchivoDescifrado, FileMode.Create);
            BinaryWriter Escritor = new BinaryWriter(NuevoArchivo);
            //Tamaño maximo de bloques 
            int TamañoDelBloque = 4 * 1024;
            int NumeroDeIteracion;
            if (Archivo.Length < TamañoDelBloque)
                NumeroDeIteracion = 1;
            else if (Archivo.Length % TamañoDelBloque == 0)
                NumeroDeIteracion = (int)Archivo.Length / TamañoDelBloque;
            else
                NumeroDeIteracion = ((int)Archivo.Length / TamañoDelBloque) + 1;
            while (NumeroDeIteracion-- > 0)
            {
                if (NumeroDeIteracion == 0)
                    TamañoDelBloque = (int)Archivo.Length % TamañoDelBloque;
                byte[] Entrada = Lector.ReadBytes(TamañoDelBloque);
                byte[] Salida = new byte[Entrada.Length];
                for (int i = 0; i < Salida.Length; i++)
                {
                    Salida[i] = my_Des.Descifrado(Entrada[i]);
                }
                Escritor.Write(Salida);
                Escritor.Flush();
            }
            Escritor.Close();
            NuevoArchivo.Close();
            Lector.Close();
            Archivo.Close();
        }
    }
}
