using System;
namespace Dio.Bank
{
    public class Conta
    {
        private TipoConta TipoConta {get;set;}
        private string Nome {get;set;}
        private double Saldo {get;set;}
        private double Limite {get;set;}

        public Conta(TipoConta TipoConta,string Nome,double Saldo,double Limite){
            this.Nome=Nome;
            this.TipoConta=TipoConta;
            this.Saldo=Saldo;
            this.Limite=Limite;
        }
        public bool Sacar(double ValorSaque){
            if ((this.Saldo-ValorSaque)<=(-this.Limite)){
                Console.WriteLine("Sem saldo disponível para esta operação!");
                return false;
            } else {
                this.Saldo-=ValorSaque;
                Console.WriteLine("Saldo atual da conta de {0} é {1}",this.Nome,this.Saldo);
                return true;
            }
        }
         public void Depositar(double ValorDeposito){
            this.Saldo+=ValorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1}",this.Nome,this.Saldo);
         }

         
         public void Transferir(double ValorTransferir,Conta Conta){
            if (this.Sacar(ValorTransferir)){
                Conta.Depositar(ValorTransferir);
            }
         }

        public override string ToString()
        {
            String Retorno="";
            Retorno+="Tipo Conta: "+this.TipoConta+" | ";
            Retorno+="Nome: "+this.Nome+" | ";
            Retorno+="Limite: "+this.Limite+" | ";
            Retorno+="Saldo: "+this.Saldo+" | ";
            return Retorno;
        }
    }
}

