using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3diffiehellman
{
    class Cifrar
    {
        public void CrearCifrado(string Direccion, string nombreOriginal)
        {
            S_DES my_Des = new S_DES();


            string DirecciónArchivoCifrado = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + nombreOriginal + ".cif";
            FileStream Archivo = new FileStream(Direccion, FileMode.Open);
            BinaryReader Lector = new BinaryReader(Archivo);
            FileStream NuevoArchivo = new FileStream(DirecciónArchivoCifrado, FileMode.Create);
            BinaryWriter Escritor = new BinaryWriter(NuevoArchivo);
            //Tamaño Maximo de Bloques
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
                    Salida[i] = my_Des.Cifrado(Entrada[i]);
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

