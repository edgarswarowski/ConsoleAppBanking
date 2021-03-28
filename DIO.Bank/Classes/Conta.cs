using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Bank
{
    class Conta
    {
        private TipoConta TipoConta { get; set; }
        
        private double Saldo { get; set; }

        private double Credito { get; set; }
        private string Name { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string name)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Name = name;
        }

        public bool Sacar(double valorSaque)
        {
            //validacao saldo suficiente
            if(this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine("O saldo atual da conta de {0} é {1}", this.Name, this.Saldo);

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("O saldo atual da conta de {0} é {1}", this.Name, this.Saldo);
        }

        public void Transfeir(double valorTransferencia, Conta contaDestino)
        {
         
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo de Conta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Name + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Credito: " + this.Credito;

            return retorno;
        }

    }
}
