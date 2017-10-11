using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3diffiehellman
{
    class S_DES
    {
        //Declaracion de Variables 
        BitArray[,] S_Box1 = new BitArray[4, 4];
        BitArray[,] S_Box2 = new BitArray[4, 4];
        BitArray LlaveMaestra;

        public S_DES()
        {
            LlaveMaestra = new BitArray(10);
            LlaveMaestra[0] = true;
            LlaveMaestra[1] = true;
            LlaveMaestra[2] = false;
            LlaveMaestra[3] = false;
            LlaveMaestra[4] = false;
            LlaveMaestra[5] = true;
            LlaveMaestra[6] = true;
            LlaveMaestra[7] = true;
            LlaveMaestra[8] = true;
            LlaveMaestra[9] = false;

            BitArray Numero0 = new BitArray(2);
            Numero0[0] = false;
            Numero0[1] = false;

            BitArray Numero1 = new BitArray(2);
            Numero1[0] = false;
            Numero1[1] = true;

            BitArray Numero2 = new BitArray(2);
            Numero2[0] = true;
            Numero2[1] = false;

            BitArray Numero3 = new BitArray(2);
            Numero3[0] = true;
            Numero3[1] = true;


            //--------------------S-Box1
            S_Box1[0, 0] = Numero1;
            S_Box1[0, 1] = Numero0;
            S_Box1[0, 2] = Numero3;
            S_Box1[0, 3] = Numero2;

            S_Box1[1, 0] = Numero3;
            S_Box1[1, 1] = Numero2;
            S_Box1[1, 2] = Numero1;
            S_Box1[1, 3] = Numero0;

            S_Box1[2, 0] = Numero0;
            S_Box1[2, 1] = Numero2;
            S_Box1[2, 2] = Numero1;
            S_Box1[2, 3] = Numero3;

            S_Box1[3, 0] = Numero3;
            S_Box1[3, 1] = Numero1;
            S_Box1[3, 2] = Numero3;
            S_Box1[3, 3] = Numero2;
            //---------------------S-Box 2
            S_Box2[0, 0] = Numero0;
            S_Box2[0, 1] = Numero1;
            S_Box2[0, 2] = Numero2;
            S_Box2[0, 3] = Numero3;

            S_Box2[1, 0] = Numero2;
            S_Box2[1, 1] = Numero0;
            S_Box2[1, 2] = Numero1;
            S_Box2[1, 3] = Numero3;

            S_Box2[2, 0] = Numero3;
            S_Box2[2, 1] = Numero0;
            S_Box2[2, 2] = Numero1;
            S_Box2[2, 3] = Numero0;

            S_Box2[3, 0] = Numero2;
            S_Box2[3, 1] = Numero1;
            S_Box2[3, 2] = Numero0;
            S_Box2[3, 3] = Numero3;
            //---------------------
        }

        //Cifrado por funcion
        public byte Cifrado(byte bloque)
        {
            BitArray bits_bloque = ConvertidorBytesABits(bloque);
            BitArray[] Llaves = GeneradorDeLlaves();
            //Texto Cifrado  = IP-1( fK2 ( SW (fK1 (IP (Texto Plano)))))
            return ConvertidorBitsABytes(ReverseIP(Fk(Switch(Fk(IP(bits_bloque), Llaves[0])), Llaves[1])));

        }

        //Descifrado por Funcion
        public byte Descifrado(byte bloqueDes)
        {
            BitArray bits_bloqueDes = ConvertidorBytesABits(bloqueDes);
            BitArray[] LlavesDes = GeneradorDeLlaves();
            //IP-1 ( fK1( SW( fK2( IP(Texto Cifrado)))))
            return ConvertidorBitsABytes(ReverseIP(Fk(Switch(Fk(IP(bits_bloqueDes), LlavesDes[1])), LlavesDes[0])));

        }

        //Convertidor de Bytes a Bits
        BitArray ConvertidorBytesABits(byte bloqueBB)
        {
            string bits = ConvertidorDecimalABinario(bloqueBB);
            BitArray resultado = new BitArray(8);
            for (int i = 0; i < bits.Length; i++)
            {
                resultado[i] = ConvertidorTextoABinario(bits[i]);
            }
            return resultado;
        }

        //Convertidor de Bits a Bytes
        byte ConvertidorBitsABytes(BitArray bloqueBiBy)
        {
            string resultado = "";
            for (int i = 0; i < bloqueBiBy.Length; i++)
            {
                resultado += ConvertidorBinarioATexto(bloqueBiBy[i]);
            }
            return ConvertidorBinarioADecimal(resultado);
        }

        //Generador de Llaves
        BitArray[] GeneradorDeLlaves()
        {
            BitArray[] LlavesGeneradas = new BitArray[2];
            BitArray[] temporal = SeparadorDeArreglo(P10(LlaveMaestra));
            LlavesGeneradas[0] = P8(LeftShift(temporal[0], 1), LeftShift(temporal[1], 1));
            LlavesGeneradas[1] = P8(LeftShift(temporal[0], 3), LeftShift(temporal[1], 3));
            return LlavesGeneradas;
        }

        // Convertidor de Decimal a Binario
        public string ConvertidorDecimalABinario(byte numero)
        {
            string resultado = "";
            for (int i = 0; i < 8; i++)
            {
                if (numero % 2 == 1)
                    resultado = "1" + resultado;
                else
                    resultado = "0" + resultado;
                numero >>= 1;
            }
            return resultado;
        }

        // Convertidor de Binario a Decimal
        public byte ConvertidorBinarioADecimal(string binario)
        {
            byte resultado = 0;
            for (int i = 0; i < binario.Length; i++)
            {
                resultado <<= 1;
                if (binario[i] == '1')
                    resultado++;
            }
            return resultado;
        }

        // Convertidor de Binario a Texto
        public string ConvertidorBinarioATexto(bool Binario)
        {
            if (Binario)
                return "1";
            else
                return "0";
        }

        //Convertidor de Texto a Binario
        public bool ConvertidorTextoABinario(char bit)
        {
            if (bit == '0')
                return false;
            else if (bit == '1')
                return true;
            else
                return false;
        }

        //Genera Permutacion de 10
        BitArray P10(BitArray ArregloLlave)
        {
            //2 4 1 6 3 9 0 8 7 5
            BitArray ArregloPermutado = new BitArray(10);

            ArregloPermutado[0] = ArregloLlave[2];
            ArregloPermutado[1] = ArregloLlave[4];
            ArregloPermutado[2] = ArregloLlave[1];
            ArregloPermutado[3] = ArregloLlave[6];
            ArregloPermutado[4] = ArregloLlave[3];
            ArregloPermutado[5] = ArregloLlave[9];
            ArregloPermutado[6] = ArregloLlave[0];
            ArregloPermutado[7] = ArregloLlave[8];
            ArregloPermutado[8] = ArregloLlave[7];
            ArregloPermutado[9] = ArregloLlave[5];

            return ArregloPermutado;
        }
        //Genera Permutacion de 8
        BitArray P8(BitArray part1, BitArray part2)
        {

            //5 2 6 3 7 4 9 8

            BitArray ArregloPermutado = new BitArray(8);

            ArregloPermutado[0] = part2[0];//5
            ArregloPermutado[1] = part1[2];//2
            ArregloPermutado[2] = part2[1];//6
            ArregloPermutado[3] = part1[3];//3
            ArregloPermutado[4] = part2[2];//7
            ArregloPermutado[5] = part1[4];//4
            ArregloPermutado[6] = part2[4];//9
            ArregloPermutado[7] = part2[3];//8

            return ArregloPermutado;
        }

        //Genera Permutacion de 4
        BitArray P4(BitArray parte1, BitArray parte2)
        {

            //1 3 2 0
            BitArray ArregloPermutado = new BitArray(4);

            ArregloPermutado[0] = parte1[1];//1
            ArregloPermutado[1] = parte2[1];//3
            ArregloPermutado[2] = parte2[0];//2
            ArregloPermutado[3] = parte1[0];//0

            return ArregloPermutado;
        }

        //Genera Permutacion de Expancion
        BitArray EP(BitArray ArregloDeEntrada)
        {

            //3 0 1 2 1 2 3 0
            BitArray ArregloPermutado = new BitArray(8);

            ArregloPermutado[0] = ArregloDeEntrada[3];//3
            ArregloPermutado[1] = ArregloDeEntrada[0];//0
            ArregloPermutado[2] = ArregloDeEntrada[1];//1
            ArregloPermutado[3] = ArregloDeEntrada[2];//2
            ArregloPermutado[4] = ArregloDeEntrada[1];//1
            ArregloPermutado[5] = ArregloDeEntrada[2];//2
            ArregloPermutado[6] = ArregloDeEntrada[3];//3
            ArregloPermutado[7] = ArregloDeEntrada[0];//0

            return ArregloPermutado;
        }

        //Genera Permutacion Inicial
        BitArray IP(BitArray TextoPlano)
        {

            //1 5 2 0 3 7 4 6
            BitArray ArregloPermutado = new BitArray(8);

            ArregloPermutado[0] = TextoPlano[1];//1
            ArregloPermutado[1] = TextoPlano[5];//5
            ArregloPermutado[2] = TextoPlano[2];//2
            ArregloPermutado[3] = TextoPlano[0];//0
            ArregloPermutado[4] = TextoPlano[3];//3
            ArregloPermutado[5] = TextoPlano[7];//7
            ArregloPermutado[6] = TextoPlano[4];//4
            ArregloPermutado[7] = TextoPlano[6];//6

            return ArregloPermutado;
        }
        //Genera Permutacion Inversa
        BitArray ReverseIP(BitArray TextoPermutado)
        {
            //3 0 2 4 6 1 7 5

            BitArray ArregloPermutado = new BitArray(8);

            ArregloPermutado[0] = TextoPermutado[3];//3
            ArregloPermutado[1] = TextoPermutado[0];//0
            ArregloPermutado[2] = TextoPermutado[2];//2
            ArregloPermutado[3] = TextoPermutado[4];//4
            ArregloPermutado[4] = TextoPermutado[6];//6
            ArregloPermutado[5] = TextoPermutado[1];//1
            ArregloPermutado[6] = TextoPermutado[7];//7
            ArregloPermutado[7] = TextoPermutado[5];//5

            return ArregloPermutado;
        }

        //Funcion Left-Shift
        BitArray LeftShift(BitArray Arreglo, int NumeroDeBit)
        {
            BitArray Cambiado = new BitArray(Arreglo.Length);
            int index = 0;
            for (int i = NumeroDeBit++; index < Arreglo.Length; i++)
            {
                Cambiado[index++] = Arreglo[i % Arreglo.Length];
            }
            return Cambiado;
        }

        //Separador de BLoque
        BitArray[] SeparadorDeArreglo(BitArray block)
        {
            BitArray[] separador = new BitArray[2];
            separador[0] = new BitArray(block.Length / 2);
            separador[1] = new BitArray(block.Length / 2);
            int index = 0;

            for (int i = 0; i < block.Length / 2; i++)
            {
                separador[0][i] = block[i];
            }
            for (int i = block.Length / 2; i < block.Length; i++)
            {
                separador[1][index++] = block[i];
            }
            return separador;
        }

        //Obtiene en que S-Box se va a buscar
        BitArray S_Boxes(BitArray Entrada, int no)
        {
            BitArray[,] S_BoxActual;

            if (no == 1)
                S_BoxActual = S_Box1;
            else
                S_BoxActual = S_Box2;

            return S_BoxActual[ConvertidorBinarioADecimal(ConvertidorBinarioATexto(Entrada[0]) + ConvertidorBinarioATexto(Entrada[3])),
                ConvertidorBinarioADecimal(ConvertidorBinarioATexto(Entrada[1]) + ConvertidorBinarioATexto(Entrada[2]))];
        }

        //Separa y obtiene numeros en las S-Boxes
        BitArray F(BitArray right, BitArray sk)
        {
            BitArray[] temporal = SeparadorDeArreglo(Xor(EP(right), sk));
            return P4(S_Boxes(temporal[0], 1), S_Boxes(temporal[1], 2));
        }

        //Genera Funcion FK
        BitArray Fk(BitArray IP, BitArray Llave)
        {
            BitArray[] temporal = SeparadorDeArreglo(IP);
            BitArray Left = Xor(temporal[0], F(temporal[1], Llave));
            BitArray Union = new BitArray(8);
            int index = 0;
            for (int i = 0; i < 4; i++)
            {
                Union[index++] = Left[i];
            }
            for (int i = 0; i < 4; i++)
            {
                Union[index++] = temporal[1][i];
            }
            return Union;
        }
        //Funcion Switch de lados   
        BitArray Switch(BitArray Entrada)
        {
            BitArray Cambio = new BitArray(8);
            int index = 0;
            for (int i = 4; index < Entrada.Length; i++)
            {
                Cambio[index++] = Entrada[i % Entrada.Length];
            }
            return Cambio;
        }
        //Funcion XOR
        BitArray Xor(BitArray a, BitArray b)
        {
            return b.Xor(a);
        }
    }
}

