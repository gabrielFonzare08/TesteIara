using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestesUnitários
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Testes Unitários em C#\r");
            Console.WriteLine("------------------------\n");
            Console.WriteLine("Selecione uma opção para iniciar:");
            Console.WriteLine("\t1 - Retornar Impares");
            Console.WriteLine("\t2 - Retirar Letras duplicadas");

            Console.Write("Sua escolha? ");

            switch (Console.ReadLine())
            {
                case "1":
                    var resultado = retornaSeHaApenasImpares();

                    if (resultado != null)
                    {
                        Console.WriteLine("O Array não possui apenas números impares!");
                    }
                    else
                    {
                        Console.Write("O Array possui apenas números impares!");
                    }

                    break;
                case "2":
                    Console.Write("Quantas palavras o array tera?");

                    int npalavras = int.Parse(Console.ReadLine());
                    string[] palavras = new string[npalavras];

                    for (int i = 0; i < npalavras; i++)
                    {
                        Console.Write("Digite a palavra:");
                        palavras[i] = Console.ReadLine();

                    }

                   

                        break;
            }


        }

        public static IEnumerable<int> retornaSeHaApenasImpares(){

            int[] numeros = { 1, 2, 3, 5, 8, 13, 21, 32, 55, 89, 144 };

            var resultado = from n in numeros where (n % 2) == 0 select n;

            return resultado;
        }
    }
}
