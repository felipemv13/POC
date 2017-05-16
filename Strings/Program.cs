using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class Program
    {
        private string b;

        static void Main(string[] args)
        {
            var conta = new Conta();


            string primeira = "Cidade";
            conta.numero = 15234;
            conta.saldo = 0.0;
            conta.endereco = new Conta.Endereco()
            {
                Cidade = "Sao Paulo"
            };
            //conta.titular = "rua sao paulo 09857-256";

            ValidaToLower(primeira, conta);
        }

        static void ValidaToLower(string a, Conta conta)
        {
            bool teste;
            var b = a.ToLower();
            var c = new Conta();
            c.endereco = new Conta.Endereco() { };

            var conta_numero = conta.numero;
            var conta_saldo = conta.saldo;
            var conta_nome = conta.titular?.ToLower();

            if (c.endereco.Cidade == conta.endereco.Cidade)
                teste = false;

            if (conta_nome == conta.titular)
                Console.WriteLine("Nulos ok");

        }
    }
}
