using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Strings
{
    public class Program
    {
        private static Stopwatch s0 = new Stopwatch();
        static void Main(string[] args)
        {
            s0.Start();
            var conta1 = new Conta();

            string primeira = "Cidade";
            conta1.numero = 15234;
            conta1.saldo = 0.0;
            conta1.endereco = new Conta.Endereco()
            {
                Cidade = "Sao Paulo"
            };
            conta1.titular = "rua sao paulo 09857-256";

            //ValidaString(conta1.endereco.Estado, conta1);

            //TesteER();

            //Tempos(conta1);

            VerificaIdadeXeY();
        }

        #region Validação de String
        static void ValidaString(string a, Conta conta)
        {
            var valida = !string.IsNullOrWhiteSpace(a) ? Regex.Replace(a, @"[^0-9]", "") : string.Empty;

            var aTrim = conta.endereco.Cidade.Trim();
            var bTrim = conta.endereco.Estado?.Trim();

            bool testeVF;
            var b = a?.ToLower();
            var conta2 = new Conta();
            conta2.endereco = new Conta.Endereco() { };

            var conta3 = new Conta();

            var conta_numero = conta.numero;
            var conta_saldo = conta.saldo;
            var conta_nome = conta.titular?.ToLower();

            if (conta2.endereco.Cidade == conta.endereco.Cidade)
                testeVF = false;

            if (conta_nome == conta.titular)
                Console.WriteLine("Nulos ok");

            List<Conta> contas = new List<Conta>();
            contas.Add(conta2);
            contas.Add(conta);
            testeVF = contas.Any(x => !string.IsNullOrWhiteSpace(x.endereco.Cidade));
            var testeVF_All = contas.All(x => !string.IsNullOrWhiteSpace(x.endereco.Cidade));
            var testeVF_Count = contas.Count(x => !string.IsNullOrWhiteSpace(x.endereco.Cidade));

            //var d = conta.endereco != null ? conta.endereco.CEP ?? "nulo" : string.Empty;
            var d = conta.endereco != null ? conta.endereco.CEP : string.Empty;
            var e = conta3.endereco != null ? conta3.endereco.CEP ?? string.Empty : "obj nulo";
            var f = conta3.endereco?.CEP ?? "obj nulo";
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

        #region Stopwatch
        static void Tempos(Conta c1)
        {
            s0.Stop();
            Console.WriteLine("TEMPO DE COMPILAÇÃO ATÉ INÍCIO DAS DECISÕES - {0}ms", s0.ElapsedMilliseconds);
            Console.WriteLine();

            // TESTE COM 4 CONDIÇÕES EM 1 IF
            var s1 = new Stopwatch();
            s1.Start();
            if (c1 == null || string.IsNullOrWhiteSpace(c1.titular) || c1.endereco == null || string.IsNullOrWhiteSpace(c1.endereco.Cidade))
            { }
            Console.WriteLine("TESTE COM 4 CONDIÇÕES EM 1 IF - {0} tick(s)", s1.ElapsedTicks);

            // TESTE COM 4 IFs E 1 CONDIÇÃO EM CADA
            var s2 = new Stopwatch();
            s2.Start();
            if (c1 == null) { }
            if (string.IsNullOrWhiteSpace(c1.titular)) { }
            if (c1.endereco == null) { }
            if (string.IsNullOrWhiteSpace(c1.endereco.Cidade)) { }
            Console.WriteLine("TESTE COM 4 IFs E 1 CONDIÇÃO EM CADA - {0} tick(s)", s2.ElapsedTicks);

            // TESTE COM 4 CONDIÇÕES EM 1 IF
            var s3 = new Stopwatch();
            s3.Start();
            if (c1 == null || string.IsNullOrWhiteSpace(c1.titular) || c1.endereco == null || string.IsNullOrWhiteSpace(c1.endereco.Cidade))
            { }
            Console.WriteLine("TESTE COM 4 CONDIÇÕES EM 1 IF - {0} tick(s)", s3.ElapsedTicks);

            // TESTE COM IF..ELSE..IF
            var s4 = new Stopwatch();
            s4.Start();
            if (c1 == null) { }
            else if (string.IsNullOrWhiteSpace(c1.titular)) { }
            else if (c1.endereco == null) { }
            else if (string.IsNullOrWhiteSpace(c1.endereco.Cidade)) { }
            Console.WriteLine("TESTE COM IF..ELSE..IF - {0} tick(s)", s4.ElapsedTicks);

            Console.ReadKey();
        }
        #endregion

        #region Datas
        static void VerificaIdadeXeY()
        {
            var IdadeDe = 15;
            var IdadeAte = 65;
            var dataNasc = new DateTime(1979, 07, 22);

            var dataAgora = DateTime.Today;
            var idade = (dataAgora.Year - dataNasc.Year);

            idade = dataAgora.Month < dataNasc.Month || (dataAgora.Month == dataNasc.Month && dataAgora.Day < dataNasc.Day) ? idade - 1 : idade;
            bool a = idade >= IdadeDe && idade < IdadeAte;

            //TimeSpan idade2 = dataAgora - dataNasc;
            //idade22 = idade2.Days;
            //var idade2a = Math.Floor(Convert.ToInt32(idade2) / 365.25);
            //bool b = idade2a >= IdadeDe && idade2a < IdadeAte;
        }
        #endregion
    }
}