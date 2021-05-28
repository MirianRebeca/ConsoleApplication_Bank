using System;
using System.Collections.Generic;
using System.Threading;

namespace DIO.BanK
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
					default:
						Console.WriteLine("Opção inválida!");
						break;

						
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}
			
			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Thread.Sleep(2000);
       	}
		private static void Depositar()
		{
			if (VerificaConta()){
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito, listContas[indiceConta]);
		}}
		private static void Sacar()
		{
			if (VerificaConta()){
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser sacado: ");
			double valorSaque = double.Parse(Console.ReadLine());

			Console.Write("Digite sua senha: ");
			int entradaSenha = int.Parse(Console.ReadLine());
			if(listContas[indiceConta].VerificarSenha(entradaSenha)){
            listContas[indiceConta].Sacar(valorSaque);}
			
		}}
			
		private static void Transferir()
		{
			if (VerificaConta()){
			Console.Write("Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());

			Console.Write("Digite sua senha: ");
			int entradaSenha = int.Parse(Console.ReadLine());
			if(listContas[indiceContaOrigem].VerificarSenha(entradaSenha)){
            listContas[indiceContaOrigem].Transferir(valorTransferencia, 
			listContas[indiceContaDestino], listContas[indiceContaOrigem]);
		}}
		}
		private static void InserirConta()
		{
			Console.Clear();
			Console.WriteLine("Inserir nova conta\n");

			Console.Write("Escolha o tipo de conta:\n1- Conta Pessoa Física - Poupança\n"
			+"2- Pessoa Física - Conta Corrente\n3- Pessoa Juridica");
			int entradaTipoConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Cliente: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite uma senha de 6 digitos númericos: ");
			int entradaSenha =  int.Parse(Console.ReadLine());	

			Console.Write("Digite o saldo inicial: ");
			double entradaSaldo = double.Parse(Console.ReadLine());
			double entradaCredito = entradaSaldo*0.1;
			if(entradaTipoConta == 1){
           		entradaCredito += 250;
            }if(entradaTipoConta == 2){
                entradaCredito +=  500;
            }else{
                entradaCredito +=  850;
            }

			Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
										saldo: entradaSaldo,
										credito: entradaCredito,
										nome: entradaNome, senha: entradaSenha);

			listContas.Add(novaConta);

			Console.Clear();
			Console.WriteLine("Operação realizada com sucesso!");

		}
		

		private static void ListarContas()
		{
			if (VerificaConta()){
			Console.Clear();
			for (int i = 0; i < listContas.Count; i++)
			{
				Conta conta = listContas[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(conta);
			}
		}}
		private static bool VerificaConta()
		{
		if (listContas.Count == 0)
			{
				Console.Clear();
				Console.WriteLine("Nenhuma conta cadastrada.");
				return false;
			}return true;
		}

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}
