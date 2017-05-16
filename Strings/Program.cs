using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Strings
{
    public class Program
    {
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

            ValidaString(primeira, conta);

            TesteER();
        }

        #region Validação de String
        static void ValidaString(string a, Conta conta)
        {
            bool testeVF;
            var b = a.ToLower();
            var c = new Conta();
            c.endereco = new Conta.Endereco() { };

            var conta_numero = conta.numero;
            var conta_saldo = conta.saldo;
            var conta_nome = conta.titular?.ToLower();

            if (c.endereco.Cidade == conta.endereco.Cidade)
                testeVF = false;

            if (conta_nome == conta.titular)
                Console.WriteLine("Nulos ok");

            List<Conta> contas = new List<Conta>();
            contas.Add(c);
            contas.Add(conta);
            testeVF = contas.Any(x => !string.IsNullOrWhiteSpace(x.endereco.Cidade));
            var testeVF_All = contas.All(x => !string.IsNullOrWhiteSpace(x.endereco.Cidade));
            var testeVF_Count = contas.Count(x => !string.IsNullOrWhiteSpace(x.endereco.Cidade));
        }
        #endregion

        #region Regular Expression
        static void TesteER()
        {
            Regex ER = new Regex("n[ãa]o", RegexOptions.None);
            String[] texto = new String[10];
            texto[0] = "Eu não quero";
            texto[1] = "nao quero mais";
            texto[2] = "Quero sim";
            texto[3] = "O anao está lá";
            texto[4] = "No ano de 1987";
            texto[5] = "minimercado";
            texto[6] = "mini-mercado";
            texto[7] = "super-mercado";
            texto[8] = "hiper-mercado";
            texto[9] = "hiper mercado";
            for (int i = 0; i < texto.Length; i++)
            {
                string Casou = "casou";
                if (!ER.IsMatch(texto[i]))
                    Casou = "não casou";

                Console.WriteLine(string.Format("O texto \"{0,-30}\" [{1}]", texto[i], Casou));
            }
        }
        #endregion
    }
}