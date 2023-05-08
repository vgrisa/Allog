using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        public static void Dolar()
        {
            double cotacao = 0, valor = 0;
            bool certo = false;
            while (!certo)
            {
                certo = true;
                try
                {
                    Console.WriteLine("\nInsira a cotacao:");
                    cotacao = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("\nInsira o valor:");
                    valor = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("\nAlgo deu errado\n");
                    certo = true;
                }
            }
            double valorConvertido = valor * cotacao;
            Console.WriteLine("\nO valor convertido é: " + valorConvertido.ToString("F2") + " reais");
        }
        public static void Temperatura()
        {
            bool entradaValida = false;
            double celcius, fhr = 0;

            while (!entradaValida)
            {
                try
                {
                    Console.WriteLine("Insira a temperatura em Celsius:");
                    celcius = Convert.ToDouble(Console.ReadLine());
                    fhr = (celcius * 9 + 160) / 5;
                    entradaValida = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("\n Algo deu errado, tente dnovo!\n");
                }
            }
            Console.WriteLine("A temperatura em F é: " + fhr);
        }
        public static void SubstituiCaractere()
        {
            string frase;
            Console.WriteLine("Escreva uma frase:");
            frase = Console.ReadLine();
            char[] caracteres = frase.ToCharArray();
            for (int i = 0; i < caracteres.Length; i++)
            {
                if (caracteres[i] == 'a')
                {
                    caracteres[i] = '&';
                }
            }
            string substituido = new string(caracteres);
            Console.WriteLine(substituido);
        }
        public static void Cadastro()
        {
            string nome, email, telefone, rg;
            string caminhoArquivo = "C:\\Users\\7971524\\Desktop\\Allog\\C#\\1 - Inicio\\ConsoleApp1\\cadastro.txt";
            try
            {
                Console.WriteLine("Escreva seu Nome:");
                nome = Console.ReadLine();
                Console.WriteLine("Escreva seu Email:");
                email = Console.ReadLine();
                Console.WriteLine("Escreva seu Telefone:");
                telefone = Console.ReadLine();
                Console.WriteLine("Escreva seu Rg:");
                rg = Console.ReadLine();


                StreamWriter arquivo = File.AppendText(caminhoArquivo);
                arquivo.WriteLine($"{nome}-{email}-{telefone}-{rg}");
                arquivo.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado, tente novamente");
            }
            Console.WriteLine();
            try
            {
                string linha, nomeN, emailN, telefoneN, rgN;
                string[] separadas;
                StreamReader sr = new StreamReader(caminhoArquivo);
                linha = sr.ReadLine();
                while (linha != null)
                {
                    separadas = linha.Split('-');
                    nomeN = separadas[0];
                    emailN = separadas[1];
                    telefoneN = separadas[2];
                    rgN = separadas[3];
                    Console.WriteLine($"Nome: {nomeN} - Email: {emailN} - Telefone: {telefoneN} - RG: {rgN}");
                    linha = sr.ReadLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Algo deu errado, tente novamente");
            }
        }


        static void Main(string[] args)
        {
            //exercicio 1
            //Dolar();

            //exercicio 2
            //Temperatura();

            //exercicio 6
            //SubstituiCaractere();

            //exercicio 9
            Cadastro();




            Console.Read();
        }
    }
}
