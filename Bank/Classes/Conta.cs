using System;
using System.Threading;

namespace DIO.BanK
{
    public class Conta
    {
        private TipoConta TipoConta {get; set; }
        private double Saldo {get; set; }
        private double Credito {get; set; }
        private string Nome {get; set; }
        private int Senha {get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome, int senha)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
            this.Senha = senha;

        }
        public bool VerificarSenha(int entradaSenha){
            int aux = 2;
            if(this.Senha == entradaSenha)
            return true;
            while(this.Senha != entradaSenha){
                Console.WriteLine("Senha incorreta!\n Você possui mais " + aux + " tentativas");
                aux -= 1;
                int senha = int.Parse(Console.ReadLine());
               
                if (aux == 0){
                Console.WriteLine("Cartão bloqueado!");
                Thread.Sleep(2000);
                Environment.Exit(0);
               
                break;}
            }
                return false;
        }
        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito *-1)){
                Console.Clear();    
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.Clear();
            var data = DateTime.Now.ToString();
            Console.WriteLine("\nAutoatendimento\n\nOperação realizada com sucesso!\nValor do saque: " + valorSaque.ToString("C2") + 
            "\nSaldo atua da conta: " + this.Saldo.ToString("C2") + "\nData e hora da operação: " + data);
            return true;
        }
        public void Depositar(double valorDeposito, Conta contaDestino)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine();
            var data = DateTime.Now.ToString();
            Console.Clear();
            Console.WriteLine("\nAutoatendimento\n\nOperação Realizada com sucesso!\n" + "\nFavorecido: " + contaDestino.Nome + 
            "\nValor: " + valorDeposito.ToString("C2") + "\nData e hora da operação: " + data + "\n");
            
        }
        public void Transferir(double valorTranferencia, Conta contaDestino, Conta contaOrigem)
        {
            if (contaDestino != contaOrigem){
				if(this.Sacar(valorTranferencia)){
                contaDestino.Depositar(valorTranferencia, contaDestino);
                var data = DateTime.Now.ToString();
                Console.Clear();
                Console.WriteLine("\nAutoatendimento\n\nOperação Realizada com sucesso!\nCliente: "+ 
                contaOrigem.Nome + "\nFavorecido: " + contaDestino.Nome + "\nValor: " + valorTranferencia.ToString("C2")
                 + "\nData e hora da operação: " + data + "\n");
                return;
                }
            }
            else
                Console.Clear();
				Console.WriteLine("\nA conta de origem não deve ser a mesma de destino");
        }
         
       
        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo de Conta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo.ToString("C2") + " | ";
            retorno += "Credito: " + this.Credito.ToString("C2");
            return retorno;
        }
    }
}