using System;
using System.Collections.Generic;

namespace Dio.Bank
{
    class Program
    {

        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
                while (true){
                    
                    String opcao = ObterOpcaoMenu();
                    switch (opcao){
                        case "1":
                            ListarConta();
                            break;
                        case "2": 
                            InserirConta();
                            break;
                        case "3":
                            TransferirValor();
                            break;
                        case "4":
                            SacarDeConta();
                            break;
                        case "5":
                           DepositarEmConta();
                            break;
                        case "6":
                            Console.Clear();
                            break;
                        case "7":
                            break;
                    }
                }
        }
        static private void ListarConta(){
            if (listaContas.Count>0){
                for (int count=0;count<listaContas.Count;count++){
                    Conta conta = listaContas[count];
                    Console.Write("#{0}:",count);
                    Console.WriteLine(conta.ToString());
                }
            } else {
                Console.WriteLine("Não existe conta cadastradas até o momento!");
            }
        }
        static private void InserirConta(){
            Console.Write("Tipo de conta: 1-Pessoa Jurídica 2-Pessoa Física: ");
            int tipoConta = int.Parse(Console.ReadLine());  

            Console.Write("Nome do cliente: ");
            String nome = Console.ReadLine();

            Console.Write("Informe valor inicial: ");            
            double valorInicial = double.Parse(Console.ReadLine());

            Console.Write("Informe limite da conta: ");
            double valorLimite = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta((TipoConta)tipoConta,nome,valorInicial,valorLimite);

            listaContas.Add(novaConta);
        }
        private static void SacarDeConta(){
            Console.Write("Informe o número da conta: ");
            int posicaoConta = int.Parse(Console.ReadLine());  

            Console.Write("Informe valor de saque: ");            
            double valorSaque = double.Parse(Console.ReadLine());

            if (posicaoConta>=listaContas.Count){
                Console.WriteLine("O número da conta é inválido!");
            } else {
                listaContas[posicaoConta].Sacar(valorSaque);
            }
            
        }
          private static void TransferirValor(){
            Console.Write("Informe o número da conta de origem: ");
            int posicaoContaOrigem = int.Parse(Console.ReadLine());  

            Console.Write("Informe o número da conta de destino: ");
            int posicaoContaDestino = int.Parse(Console.ReadLine()); 

            Console.Write("Informe valor de transferência: ");            
            double ValorTransferir = double.Parse(Console.ReadLine());

            if (posicaoContaOrigem>=listaContas.Count){
                Console.WriteLine("O número da conta de origem é inválido!");
            }else  if (posicaoContaDestino>=listaContas.Count){
                Console.WriteLine("O número da conta de destino é inválido!");
            }
             else {
                listaContas[posicaoContaOrigem].Transferir(ValorTransferir,listaContas[posicaoContaDestino]);
            }

        }
        private static void DepositarEmConta(){
            Console.Write("Informe o número da conta: ");
            int posicaoConta = int.Parse(Console.ReadLine());  

            Console.Write("Informe valor de depósito: ");            
            double valorDeposito = double.Parse(Console.ReadLine());

            if (posicaoConta>=listaContas.Count){
                Console.WriteLine("O número da conta é inválido!");
            } else {
                listaContas[posicaoConta].Depositar(valorDeposito);
            }
            
        }
        private static string ObterOpcaoMenu(){
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1. Listar contas");
            Console.WriteLine("2. Inserir nova conta");
            Console.WriteLine("3. Transferir");
            Console.WriteLine("4. Sacar");
            Console.WriteLine("5. Depositar");
            Console.WriteLine("6. Limpar tela");
            Console.WriteLine("7. Sair");

            String OpcaoUsuario = Console.ReadLine();
            Console.WriteLine("Opção escolhida: "+OpcaoUsuario);
            return  OpcaoUsuario;
        }
    }
}
