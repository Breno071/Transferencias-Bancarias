
using Transferencias_Bancarias.Conta_Bancaria;
using Transferencias_Bancarias.Conta_Bancaria.Tipo_da_Conta;
using Transferencias_Bancarias.Repositorio;

namespace Transferencias_Bancarias.Service
{
    class Service
    {
        public static void adicionarConta(string nomeDoUsuario, Banco banco, int numeroDaConta,
                                       TipoDaConta tipoDaConta)
        {
            Repository.addConta(nomeDoUsuario, banco, numeroDaConta, tipoDaConta);
        }

        public static void getAllContas()
        {
            Repository.getAllContas();
        }

        internal static void depositar(string nomeDoUsuario, int numeroDaConta,int valor)
        {
            Repository.depositar(nomeDoUsuario, numeroDaConta ,valor);
        }

        internal static bool exists(string nomeDoUsuario, int numeroDaConta)
        {
            return Repository.getConta(nomeDoUsuario, numeroDaConta);
        }

        internal static void sacar(string nome, int numeroConta, int valor)
        {
            Repository.sacar(nome, numeroConta, valor);
        }

        internal static void transferir(string nome, int numeroConta, string nome2, int numeroConta2, int valor)
        {
            Repository.transferir(nome, numeroConta, nome2, numeroConta2, valor);
        }
    }
}
