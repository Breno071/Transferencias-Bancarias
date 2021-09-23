using System;
using System.Collections.Generic;
using System.Threading;
using Transferencias_Bancarias.Conta_Bancaria;
using Transferencias_Bancarias.Conta_Bancaria.Tipo_da_Conta;

namespace Transferencias_Bancarias.Repositorio
{
    class Repository
    {
        private static List<Conta> contas = new List<Conta>();

        public static void addConta(string nomeDoUsuario, Banco banco, int numeroDaConta,
                                       TipoDaConta tipoDaConta)
        {
            foreach (Conta conta in contas)
            {
                if (conta.getNomeDoUsuario().Equals(nomeDoUsuario) && conta.getNumeroDaConta() == numeroDaConta)
                {
                    Console.WriteLine("Essa Conta já está cadastrada!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    Program.assistenteDeTransacoes();
                }
            }
            contas.Add(new Conta(nomeDoUsuario, banco, numeroDaConta, tipoDaConta));
            Console.WriteLine("Conta cadastrada com sucesso!");
            Thread.Sleep(2000);
            Console.Clear();
            Program.assistenteDeTransacoes();
        }

        internal static void sacar(string nome, int numeroConta, int valor)
        {
            if (getConta(nome, numeroConta))
            {
                foreach (Conta conta in contas)
                {
                    if (conta.getSaldo() >= valor)
                    {
                        conta.sacar(valor);
                        Console.WriteLine("Valor sacado com sucesso");
                        Console.WriteLine("------------------------\n");
                        Console.WriteLine(conta.toString());
                        Thread.Sleep(1500);
                        Program.assistenteDeTransacoes();
                    }
                    else
                    {
                        Console.WriteLine("Saldo insuficiente");
                        Thread.Sleep(1500);
                        Program.assistenteDeTransacoes();
                    }
                    
                }
            }
            else
            {
                Console.WriteLine("Conta não cadastrada no sistema");
                Thread.Sleep(1500);
                Program.assistenteDeTransacoes();
            }
        }

        internal static void transferir(string nome, int numeroConta, string nome2, int numeroConta2, int valor)
        {
            foreach (Conta conta in contas)
            {
                if (conta.getNomeDoUsuario().Equals(nome) && conta.getNumeroDaConta() == numeroConta)
                {
                    if (conta.getSaldo() >= valor)
                    {
                        conta.sacar(valor);
                        foreach (Conta c in contas)
                        {
                            if (c.getNomeDoUsuario().Equals(nome2) && conta.getNumeroDaConta() == numeroConta2)
                            {
                                c.depositar(valor);
                                Console.WriteLine("Transferência realizada com sucesso!");
                                Thread.Sleep(1500);
                                Console.WriteLine(conta.toString());
                                Console.WriteLine("---------------------");
                                Console.WriteLine(c.toString());
                                Thread.Sleep(1500);
                                Program.assistenteDeTransacoes();
                            }
                                
                        }

                    }
                    else
                    {
                        Console.WriteLine("Saldo insuficiente para transferência");
                        Thread.Sleep(1500);
                        Program.assistenteDeTransacoes();
                    }
                }
            }
        }

        internal static void depositar(string nomeDoUsuario, int numeroDaConta, int valor)
        {
            if (getConta(nomeDoUsuario, numeroDaConta))
            {
                foreach (Conta conta in contas)
                {
                    if (conta.getNomeDoUsuario().Equals(nomeDoUsuario))
                    {
                        conta.depositar(valor);
                        Console.WriteLine("\nValor depositado com sucesso\n");
                        Thread.Sleep(1500);
                        Console.WriteLine(conta.toString());
                        Program.assistenteDeTransacoes();
                    }
                }
            }
            else
            {
                Console.WriteLine("Conta não cadastrada no sistema\n");
                Thread.Sleep(1500);
                Program.assistenteDeTransacoes();
            }
        }

        public static void getAllContas()
        {
            if (contas.Count > 0)
            {
                Console.WriteLine("---------------------------");  
                foreach (Conta conta in contas) Console.WriteLine(conta.toString());
                Console.WriteLine("---------------------------");

                Thread.Sleep(1500);
                Console.WriteLine("1- Voltar para o Assitente de Transações");
                Console.WriteLine("2- Encerrar o programa\n");
                int user = int.Parse(Console.ReadLine());
                while (user < 1 || user > 2)
                {
                    Console.WriteLine("Opção inválida. Digite apenas 1 ou 2");
                    Thread.Sleep(1500);
                    Console.WriteLine("1- Voltar para o Assitente de Transações");
                    Console.WriteLine("2- Encerrar o programa\n");
                    user = int.Parse(Console.ReadLine());
                }
                if (user == 1)
                {
                    Program.assistenteDeTransacoes();
                }
                else Environment.Exit(0);

                
            }
            else
            {
                Console.WriteLine("Nenhuma conta encontrada");
                Thread.Sleep(1500);
                Console.Clear();
                Program.assistenteDeTransacoes();
            }
            
        }

        public static bool getConta(string nomeDoUsuario, int numeroDaConta)
        {
            foreach (Conta c in contas)
            {
                if (c.getNomeDoUsuario().Equals(nomeDoUsuario) && c.getNumeroDaConta() == numeroDaConta)
                {
                    return true; 
                }
            }
            return false;   
        }
    }
}
