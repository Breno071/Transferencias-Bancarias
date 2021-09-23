using System;
using System.Threading;
using Transferencias_Bancarias.Conta_Bancaria.Tipo_da_Conta;
using Transferencias_Bancarias.Conta_Bancaria;


namespace Transferencias_Bancarias
{
    class Program
    {
        static void Main(string[] args)
        {
            assistenteDeTransacoes();
        }

        public static void assistenteDeTransacoes()
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Bem vindo ao assistente de transações bancárias");
            Console.WriteLine("-----------------------------------------------");
            Thread.Sleep(1000);
            Console.WriteLine("Digite o número de uma das opções abaixo ou digite 0 para fechar o assistente:\n");
            Console.WriteLine("1- Criar conta bancária");
            Console.WriteLine("2- Listar todas as contas");
            Console.WriteLine("3- Depositar");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Realizar transferência");
            Console.WriteLine("6- Limpar tela");
            Console.WriteLine("0- Sair do assistente\n");

            int user = int.Parse(Console.ReadLine());

            while (user != 0)
            {

                while (user < 0 || user > 10)
                {
                    Console.WriteLine("Opção Inválida! Digite uma opção válida ou digite 0 para fechar o assistente");
                    Thread.Sleep(1500);
                    Console.WriteLine("1- Criar conta bancária");
                    Console.WriteLine("2- Listar todas as contas");
                    Console.WriteLine("3- Depositar");
                    Console.WriteLine("4- Sacar");
                    Console.WriteLine("5- Realizar transferência");
                    Console.WriteLine("6- Limpar tela");
                    Console.WriteLine("0- Sair do assistente\n");
                    user = int.Parse(Console.ReadLine());
                }
                switch (user)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Digite o nome do usuário");
                        string nomeDoUsuario = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("Informe o número do Banco da Conta a ser criada");
                        Banco banco = escolherBanco();

                        Console.Clear();
                        Console.WriteLine("Digite o número da conta");
                        int numeroDaConta = int.Parse(Console.ReadLine());

                        Console.Clear();
                        Console.WriteLine("Informe o tipo da conta a ser criada");
                        TipoDaConta tipoDaConta = escolherTipoDaConta();
                        /*Console.WriteLine("Confirmar?");
                        Console.WriteLine("1- SIM");
                        Console.WriteLine("2- CANCELAR");*/
                        criarConta(nomeDoUsuario, banco, numeroDaConta, tipoDaConta);
                        break;

                    case 2:
                        listarContas();
                        break;

                    case 3:
                        Console.WriteLine("Informe o nome do usuário:\n");
                        string nome = Console.ReadLine();
                        Console.WriteLine("Informe o número da conta\n");
                        int numeroConta = int.Parse(Console.ReadLine());
                        Console.WriteLine("informe o valor a ser depositado\n");
                        int valor = int.Parse(Console.ReadLine());
                        depositar( nome, numeroConta, valor);
                        break;

                    case 4:
                        Console.WriteLine("Informe o nome do usuário:\n");
                        nome = Console.ReadLine();
                        Console.WriteLine("Informe o número da conta\n");
                        numeroConta = int.Parse(Console.ReadLine());
                        Console.WriteLine("informe o valor a ser sacado\n");
                        valor = int.Parse(Console.ReadLine());
                        sacar(nome, numeroConta, valor);
                        break;

                    case 5:
                        Console.WriteLine("Informe o nome do usuário da primeira conta:\n");
                        nome = Console.ReadLine();
                        Console.WriteLine("Informe o número da primeira conta\n");
                        numeroConta = int.Parse(Console.ReadLine());

                        Console.WriteLine("Informe o nome do usuário da segunda conta:\n");
                        string nome2 = Console.ReadLine();
                        Console.WriteLine("Informe o número da segunda conta\n");

                        int numeroConta2 = int.Parse(Console.ReadLine());
                        Console.WriteLine("informe o valor a ser transferido\n");
                        valor = int.Parse(Console.ReadLine());
                        transferir(nome, numeroConta, nome2, numeroConta2, valor);
                        break;
                    case 6:
                        Console.Clear();
                        assistenteDeTransacoes();
                        break;
                }
                break;

            }
        }  

        private static Banco escolherBanco()
        {
            
            Console.WriteLine("1- Banco do Brasil");
            Console.WriteLine("2- Itaú");
            Console.WriteLine("3- Santander");
            Console.WriteLine("4- Caixa");
            Console.WriteLine("5- BNDES");
            Console.WriteLine("6- HSBC");
            Console.WriteLine("7- SAFRA");
            int numeroDoBanco = int.Parse(Console.ReadLine());
            while (numeroDoBanco < 0 || numeroDoBanco > 7)
            {
                Console.WriteLine("Opção inválida!");
                Thread.Sleep(1500);
                Console.WriteLine("Informe o número do Banco da Conta a ser criada");
                Console.WriteLine("1- Banco do Brasil");
                Console.WriteLine("2- Itaú");
                Console.WriteLine("3- Santander");
                Console.WriteLine("4- Caixa");
                Console.WriteLine("5- BNDES");
                Console.WriteLine("6- HSBC");
                Console.WriteLine("7- SAFRA");
                
                numeroDoBanco = int.Parse(Console.ReadLine());
            }

            switch (numeroDoBanco)
            {
                case 1:
                    return Banco.BANCO_DO_BRASIL;
                case 2:
                    return Banco.ITAÚ;
                case 3:
                    return Banco.SANTANDER;
                case 4:
                    return Banco.CAIXA;
                case 5:
                    return Banco.BNDES;
                case 6:
                    return Banco.HSBC;
                case 7:
                    return Banco.SAFRA;
                default:
                    return Banco.BANCO_DO_BRASIL;
                    
            }
        }

        private static TipoDaConta escolherTipoDaConta()
        {
            
            Console.WriteLine("1- CONTA CORRENTE");
            Console.WriteLine("2- CONTA POUPANÇA");
            Console.WriteLine("3- CONTA SALÁRIO\n");
            Console.WriteLine("Será selecionado a conta corrente caso digite outro valor");
            int user = int.Parse(Console.ReadLine());
            switch (user)
            {
                case 1:
                    return TipoDaConta.CORRENTE;
                case 2:
                    return TipoDaConta.POUPANÇA;
                case 3:
                    return TipoDaConta.SALÁRIO;
                default:
                    Console.WriteLine("Conta Corrente selecionada");
                    return TipoDaConta.CORRENTE;
            }
            
        }

        private static void criarConta(string nomeDoUsuario, Banco banco, int numeroDaConta, 
                                       TipoDaConta tipoDaConta)
        {
            Service.Service.adicionarConta(nomeDoUsuario, banco, numeroDaConta, tipoDaConta);

        }

        private static void listarContas()
        {
            Service.Service.getAllContas();
        }

        private static void sacar(string nome, int numeroConta, int valor)
        {
            Service.Service.sacar(nome, numeroConta, valor);
        }

        private static void depositar(string nomeDoUsario, int numeroDaConta, int valor)
        {
            Service.Service.depositar(nomeDoUsario, numeroDaConta, valor);
        }

        private static void transferir(string nome, int numeroConta, string nome2, int numeroConta2, int valor)
        {
            bool conta1 = Service.Service.exists(nome, numeroConta);
            bool conta2 = Service.Service.exists(nome2, numeroConta2);
            if (conta1 && conta2) { Service.Service.transferir(nome, numeroConta, nome2, numeroConta2, valor); }
            else 
            { 
                Console.WriteLine("Você só pode realizar a transferência entre duas contas previamente cadastradas");
                Thread.Sleep(1500);
                assistenteDeTransacoes();
            }
        }

    }
}
