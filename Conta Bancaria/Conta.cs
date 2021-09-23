using System;
using Transferencias_Bancarias.Conta_Bancaria.Tipo_da_Conta;

namespace Transferencias_Bancarias.Conta_Bancaria
{
    class Conta
    {

        private string nomeDoUsuario;
        private Banco banco;
        private int numeroDaConta;
        private TipoDaConta tipoDaConta;
        private double saldo;
        

        public Conta(string nomeDoUsuario, Banco banco, int numeroDaConta, TipoDaConta tipoDaConta)
        {
            this.nomeDoUsuario = nomeDoUsuario;
            this.banco = banco;
            this.numeroDaConta = numeroDaConta;
            this.tipoDaConta = tipoDaConta;
        }

        public string getNomeDoUsuario()
        {
            return this.nomeDoUsuario;
        }

        public void setNomeDoUsuario(string nomeDoUsuario)
        {
            this.nomeDoUsuario = nomeDoUsuario;
        }

        public Banco getBanco()
        {
            return banco;
        }

        public void setBanco(Banco banco)
        {
            this.banco = banco;
        }

        public int getNumeroDaConta()
        {
            return numeroDaConta;
        }

        public void setNumeroDaConta(int numeroDaConta)
        {
            this.numeroDaConta = numeroDaConta;
        }

        public TipoDaConta getTipoDaConta()
        {
            return this.tipoDaConta;
        }

        public double getSaldo()
        {
            return this.saldo;
        }

        public void depositar(double valor)
        {
            this.saldo += valor;
        }

        public void sacar(double valor)
        {
            this.saldo -= valor;
        }

        public bool transferir(Conta Conta_a_Transferir, Conta Conta_a_Ser_Transferida, double valor)
        {
            if (Conta_a_Transferir.getSaldo() >= valor)
            {
                Conta_a_Transferir.sacar(valor);
                Conta_a_Ser_Transferida.depositar(valor);
                Console.WriteLine("Transferência realizada com sucesso");
                return true;
            }
            Console.WriteLine("Não pôde ser realizada a transferência. Valor do saldo inferior ao informado");
            return false;
        }

        public string toString()
        {
            return string.Format("Nome do Usuário {0} \nBanco: {1} \nNúmero da Conta: {2} \nTipo da Conta: {3} \nSaldo: R${4}\n", this.nomeDoUsuario, 
                this.banco, this.numeroDaConta, this.tipoDaConta, this.saldo.ToString("F"));
        }
    }
}
