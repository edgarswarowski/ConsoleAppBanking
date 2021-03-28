using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar os nossos serviços!");
            Console.ReadLine();
            Console.WriteLine();
        }

        private static void Depositar()
        {
            Console.WriteLine("Depositar:");
            Console.WriteLine("Selecione a conta a ser depositada:");
            int contaDeposito = int.Parse(Console.ReadLine());

            //validar pra ver se a conta existe
            int contaValidada = validaContas(contaDeposito);
            if (contaValidada == 1)
                return;

            Console.WriteLine("Digite o valor do depósito:");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[contaDeposito].Depositar(valorDeposito);

            Console.WriteLine("Deposito realizado com sucesso");
        }

        private static void Transferir()
        {
            Console.WriteLine("Transferir:");
            Console.WriteLine("Selecione a conta de origem:");
            int contaOrigem = int.Parse(Console.ReadLine());

            //validar pra ver se a conta existe
            int contaValidada = validaContas(contaOrigem);
            if (contaValidada == 1)
                return;

            Console.WriteLine("Selecione a conta de destino:");
            int contaDestino = int.Parse(Console.ReadLine());

            //validar pra ver se a conta existe
            contaValidada = validaContas(contaDestino);
            if (contaValidada == 1)
                return;

            Console.WriteLine("Digite o valor a ser transferido:");
            double valorTransf = double.Parse(Console.ReadLine());

            listContas[contaOrigem].Transfeir(valorTransf, listContas[contaDestino]);

            Console.WriteLine("Transferencia realizada com sucesso!!!");
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            int contaValidada = validaContas(indiceConta);
            if (contaValidada == 1)
                return;

            Console.WriteLine("Digite o valor do saque: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas:");

            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada!!!");

                return;
            }

            for(int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");
            
            Console.WriteLine("Digite 1 para Pessoa Fisica | Digite 2 para Pessoa Juridica");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente:");
            string nomeCliente = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial:");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o credito:");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(
                tipoConta: (TipoConta)entradaTipoConta,
                saldo: entradaSaldo,
                credito: entradaCredito,
                name: nomeCliente);

            listContas.Add(novaConta);

            Console.WriteLine("Conta adicionada com sucesso!!!");
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!");
            Console.WriteLine("Informe a opcao desejada:");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair!");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static int validaContas(int indiceEntrada)
        {
            //se for conta invalida, retorna 1
            //validacao para quando nao tiver contas cadastradas
            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada!!!");
                return 1;
            }

            //validacao para nao selecionar contas inexistentes na lista
            if (indiceEntrada > listContas.Count - 1 || indiceEntrada < 0)
            {
                Console.WriteLine("Conta inexistente!!!");
                return 1;
            }

            //se for conta valida, retorna 2
            return 2;
        }
    }
}
