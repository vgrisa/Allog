using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente
{
    class Program
    {
        public static string caminhoArquivo = "C:\\Users\\7971524\\Desktop\\CadastroCliente\\clientes.txt";

        public static int BuscaIncrementoId(List<Cliente> clientes)
        {
            int id = 0;
            if (clientes.Count() == 0)
            {
                id = 0;
            }
            else
            {
                id = clientes[clientes.Count() - 1].Id;
            }

            return id + 1;
        }
        public static void CadastroClientes(List<Cliente> clientes)
        {
            Cliente cliente = new Cliente();
            bool continua = true;

            try
            {
                while (continua)
                {
                    Console.Clear();
                    Console.Write("Escreva o NOME: ");
                    cliente.Nome = Console.ReadLine();
                    Console.Write("\nEscreva o ENDERECO: ");
                    cliente.Endereco = Console.ReadLine();
                    Console.Write("\nEscreva o EMAIL: ");
                    cliente.Email = Console.ReadLine();
                    Console.Write("\nEscreva o TELFONE: ");
                    cliente.Telefone = Console.ReadLine();

                    int id = BuscaIncrementoId(clientes);
                    StreamWriter arquivo = File.AppendText(caminhoArquivo);
                    arquivo.WriteLine($"{id};{cliente.Nome.ToUpper()};{cliente.Endereco.ToUpper()};{cliente.Email.ToUpper()};{cliente.Telefone.ToUpper()};");
                    arquivo.Close();
                    Console.WriteLine("\nCADASTRO CONCLUIDO COM SUCESSO!");

                    Console.WriteLine("\n\nContinuar Cadastrando?");
                    Console.WriteLine("[1] - SIM");
                    Console.WriteLine("[2] - NAO");
                    int escolha = Convert.ToInt32(Console.ReadLine());
                    if (escolha != 1) continua = false;
                }
            }
            catch (Exception e)
            {
                
            }

        }
        public static List<Cliente> RetornaClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            string linha;
            string[] separadas;
            int contador = 0;
            try
            {
                if (File.Exists(caminhoArquivo))
                {
                    StreamReader sr = new StreamReader(caminhoArquivo);
                    linha = sr.ReadLine();
                    while (linha != null)
                    {
                        Cliente clienteAux = new Cliente();
                        separadas = linha.Split(';');

                        clienteAux.Id = Convert.ToInt32(separadas[0]);
                        clienteAux.Nome = separadas[1];
                        clienteAux.Endereco = separadas[2];
                        clienteAux.Email = separadas[3];
                        clienteAux.Telefone = separadas[4];

                        clientes.Add(clienteAux);
                        linha = sr.ReadLine();
                        contador++;
                    }
                    sr.Close();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Algo deu errado, tente novamente");
            }
            return clientes;
        }
        public static void ListaClientes(List<Cliente> clientes)
        {
            Console.Clear();
            if (clientes.Count() == 0)
            {
                Console.WriteLine("Nao existem cadastros ;-;");
            }
            else
            {
                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"ID: {cliente.Id}\nNOME: {cliente.Nome}\nENDERECO: {cliente.Endereco}\nEMAIL: {cliente.Email}\nTELEFONE: {cliente.Telefone}\n\n");
                }
            }
            Console.ReadLine();
        }
        public static void Excluir(List<Cliente> clientes)
        {
            int id;
            bool existe = false;
            Console.Clear();
            if (clientes.Count() == 0)
            {
                Console.WriteLine("Nao existem cadastros ;-;");
            }
            else
            {
                Console.Write("Digite o ID de quem deseja EXCLUIR: ");
                id = Convert.ToInt32(Console.ReadLine());

                List<string> linhas = new List<string>();

                foreach (var cliente in clientes)
                {
                    if (cliente.Id == id) existe = true;
                }

                if (existe)
                {
                    clientes.RemoveAll(x => x.Id == id);
                    try
                    {
                        File.WriteAllText(caminhoArquivo, "");
                        foreach (var cliente in clientes)
                        {
                            linhas.Add($"{cliente.Id};{cliente.Nome.ToUpper()};{cliente.Endereco.ToUpper()};{cliente.Email.ToUpper()};{cliente.Telefone.ToUpper()};");
                        }
                        File.AppendAllLines(caminhoArquivo, linhas);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Algo deu errado");
                    }
                    Console.WriteLine("\n\nCLIENTE exlcuido com Sucesso!");
                }
                else
                {
                    Console.WriteLine("\n\nID nao existe.");
                }
            }
            Console.ReadLine();
        }
        public static void Editar(List<Cliente> clientes)
        {
            int id, escolha;
            string novo;
            bool existe = false;
            List<string> linhas = new List<string>();
            Console.Clear();
            if (clientes.Count() == 0)
            {
                Console.WriteLine("Nao existem cadastros ;-;");
            }
            else
            {
                Console.Write("Digite o ID de quem deseja EXCLUIR: ");
                id = Convert.ToInt32(Console.ReadLine());

                foreach (var cliente in clientes)
                {
                    if (cliente.Id == id) existe = true;
                }
                Console.Clear();
                if (existe)
                {
                    Console.WriteLine("Oque voce deseja editar?");
                    Console.WriteLine("[1] - Nome");
                    Console.WriteLine("[2] - Endereco");
                    Console.WriteLine("[3] - Email");
                    Console.WriteLine("[4] - Telefone");
                    escolha = Convert.ToInt32(Console.ReadLine());
                    while (escolha > 4 || escolha < 1)
                    {
                        Console.WriteLine("Digite uma opcao valida: ");
                        escolha = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.Write("\nDigite o novo ");

                    switch (escolha)
                    {
                        case 1:
                            Console.Write("Nome: ");
                            novo = Console.ReadLine();
                            clientes.Where(x => x.Id == id).FirstOrDefault().Nome = novo;
                            break;
                        case 2:
                            Console.Write("Endereco: ");
                            novo = Console.ReadLine();
                            clientes.Where(x => x.Id == id).FirstOrDefault().Endereco = novo;
                            break;
                        case 3:
                            Console.Write("Email: ");
                            novo = Console.ReadLine();
                            clientes.Where(x => x.Id == id).FirstOrDefault().Email = novo;
                            break;
                        case 4:
                            Console.Write("Telefone: ");
                            novo = Console.ReadLine();
                            clientes.Where(x => x.Id == id).FirstOrDefault().Telefone = novo;
                            break;
                        default:
                            Console.Clear();
                            break;
                    }
                    try
                    {
                        File.WriteAllText(caminhoArquivo, "");
                        foreach (var cliente in clientes)
                        {
                            linhas.Add($"{cliente.Id};{cliente.Nome.ToUpper()};{cliente.Endereco.ToUpper()};{cliente.Email.ToUpper()};{cliente.Telefone.ToUpper()};");
                        }
                        File.AppendAllLines(caminhoArquivo, linhas);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Algo deu errado");
                    }
                }
                else
                {
                    Console.WriteLine("\n\nID nao existe.");
                }
            }
            Console.ReadLine();
        }


        static void Main(string[] args)
        {
            int escolha;
            bool sair = false;
            List<Cliente> clientes = new List<Cliente>();

            while (!sair)
            {
                clientes = RetornaClientes();
                Console.Clear();
                Console.WriteLine("Bem Vindo ao Cadastro de Clientes Super Ultra Mega Blaster 3000");
                Console.WriteLine("Oque voce deseja fazer?\n");
                Console.WriteLine("[1] - Cadastrar");
                Console.WriteLine("[2] - Editar");
                Console.WriteLine("[3] - Excluir");
                Console.WriteLine("[4] - Listar");
                Console.WriteLine("[5] - Sair");
                escolha = Convert.ToInt32(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        CadastroClientes(clientes);
                        break;
                    case 2:
                        Editar(clientes);
                        break;
                    case 3:
                        Excluir(clientes);
                        break;
                    case 4:
                        ListaClientes(clientes);
                        break;
                    case 5:
                        sair = true;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
