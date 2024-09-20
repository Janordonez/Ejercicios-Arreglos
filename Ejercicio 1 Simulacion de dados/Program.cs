using System;

namespace Simulacion_Dados
{
    class Dados
    {

        int Dado1;
        int Dado2;

        int Suma;
        

        double Porcentaje;
        static void Main(string[] args)
        {
            Dados dados = new Dados();
            Random rnd = new Random(); //Algoritmo que genera numeros de manera pseudoaleatoria 

            int[] Resultados = new int[13];// Arreglo unidimensional para almacenar todos los resultados

            for (int i = 0; i < 36000; i++)
            {
                dados.Dado1 = rnd.Next(1, 7);//Genera un numero aleatoria entre 1 y 6 
                dados.Dado2 = rnd.Next(1, 7);

                dados.Suma = dados.Dado1 + dados.Dado2; //Suma el resultados de los dos dados

                Resultados[dados.Suma]++; //Incrementa dependiendo del indice en el cual se encuentra
            }

            for (int i = 2; i < 13; i++) //Mostrar los resultados
            {
                Console.WriteLine($"{i}\t{Resultados[i]}");
            }

            dados.Porcentaje = ((double)Resultados[7] / 36000) * 100; //Mostramos los dados mediante un double 
            Console.WriteLine("El porcentaje de la suma de 7 es:" + "%"+dados.Porcentaje);
        }
    }
}