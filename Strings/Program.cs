using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Strings
{
    public class Program
    {
        private static Stopwatch s0 = new Stopwatch();
        public static void Main(string[] args)
        {
            VerificaMoedaPais();
            GeradorStringBuilder();
            s0.Start();
            var conta1 = new Conta();

            double a = 150;
            double a1 = 150.00;
            //double a2 = 150,00;

            string primeira = "Cidade";
            conta1.Numero = 15234;
            conta1.Saldo = 0.0;
            conta1.Endereco = new Endereco()
            {
                Cidade = "Sao Paulo"
            };
            conta1.Titular = "rua sao paulo 09857-256";

            //ValidaString(conta1.endereco.Estado, conta1);

            //TesteER();

            //Tempos(conta1);

            Randomico(1);
            var cpfnovo = GerarCpf();
            Gerador endereco = new Gerador();
            endereco.GetEndereco();

        }

        #region Validação de String
        static void ValidaString(string a, Conta conta)
        {
            var valida = !string.IsNullOrWhiteSpace(a) ? Regex.Replace(a, @"[^0-9]", "") : string.Empty;

            var aTrim = conta.Endereco.Cidade.Trim();
            var bTrim = conta.Endereco.Estado?.Trim();

            bool testeVF;
            var b = a?.ToLower();
            var conta2 = new Conta();
            conta2.Endereco = new Endereco() { };

            var conta3 = new Conta();

            var conta_numero = conta.Numero;
            var conta_saldo = conta.Saldo;
            var conta_nome = conta.Titular?.ToLower();

            if (conta2.Endereco.Cidade == conta.Endereco.Cidade)
                testeVF = false;

            if (conta_nome == conta.Titular)
                Console.WriteLine("Nulos ok");

            List<Conta> contas = new List<Conta>();
            contas.Add(conta2);
            contas.Add(conta);
            testeVF = contas.Any(x => !string.IsNullOrWhiteSpace(x.Endereco.Cidade));
            var testeVF_All = contas.All(x => !string.IsNullOrWhiteSpace(x.Endereco.Cidade));
            var testeVF_Count = contas.Count(x => !string.IsNullOrWhiteSpace(x.Endereco.Cidade));

            //var d = conta.endereco != null ? conta.endereco.CEP ?? "nulo" : string.Empty;
            var d = conta.Endereco != null ? conta.Endereco.CEP : string.Empty;
            var e = conta3.Endereco != null ? conta3.Endereco.CEP ?? string.Empty : "obj nulo";
            var f = conta3.Endereco?.CEP ?? "obj nulo";
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
            if (c1 == null || string.IsNullOrWhiteSpace(c1.Titular) || c1.Endereco == null || string.IsNullOrWhiteSpace(c1.Endereco.Cidade))
            { }
            Console.WriteLine("TESTE COM 4 CONDIÇÕES EM 1 IF - {0} tick(s)", s1.ElapsedTicks);

            // TESTE COM 4 IFs E 1 CONDIÇÃO EM CADA
            var s2 = new Stopwatch();
            s2.Start();
            if (c1 == null) { }
            if (string.IsNullOrWhiteSpace(c1.Titular)) { }
            if (c1.Endereco == null) { }
            if (string.IsNullOrWhiteSpace(c1.Endereco.Cidade)) { }
            Console.WriteLine("TESTE COM 4 IFs E 1 CONDIÇÃO EM CADA - {0} tick(s)", s2.ElapsedTicks);

            // TESTE COM 4 CONDIÇÕES EM 1 IF
            var s3 = new Stopwatch();
            s3.Start();
            if (c1 == null || string.IsNullOrWhiteSpace(c1.Titular) || c1.Endereco == null || string.IsNullOrWhiteSpace(c1.Endereco.Cidade))
            { }
            Console.WriteLine("TESTE COM 4 CONDIÇÕES EM 1 IF - {0} tick(s)", s3.ElapsedTicks);

            // TESTE COM IF..ELSE..IF
            var s4 = new Stopwatch();
            s4.Start();
            if (c1 == null) { }
            else if (string.IsNullOrWhiteSpace(c1.Titular)) { }
            else if (c1.Endereco == null) { }
            else if (string.IsNullOrWhiteSpace(c1.Endereco.Cidade)) { }
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

        #region Nomes Randômicas
        static void Randomico(int sexo)
        {
            string[] listaNomeHomem, listaNomeMulher;
            string nome = "";
            Random rnd = new Random();

            if (sexo == 1)
            {
                listaNomeHomem = new string[] { "Antonio", "José", "Claudio", "Mario", "Gustavo",
                                           "Liverton", "Benjamin", "Alex", "Diego", "Raphael",
                                           "Enzo", "Pietro", "Lorenzo", "Tauan", "Joaquim",
                                           "Anthony", "Arthur", "Miguel", "Cristiano", "Magno"};
                nome = $"{listaNomeHomem[rnd.Next(0, 19)].ToString()}";
            }
            else
            {
                listaNomeMulher = new string[] { "Antonia", "Josefa", "Ana Claudia", "Maria", "Guilhermina",
                                            "Livia", "Fabia", "Alexia", "Débora", "Rafaela",
                                            "Inês", "Aurora","Hortênsia","Lilian","Maia",
                                            "Melissa", "Rosa", "Tauane", "Virgínia", "Flora"};
                nome = $"{listaNomeMulher[rnd.Next(0, 19)].ToString()}";
            }

            string[] listaSobreNome = { "Marques", "Almeida", "Moraes", "Duarte", "Vasconcelos",
                                           "Ferraz", "Vargas", "Dolabella", "Fagundes", "Trindade",
                                           "Lins", "Andrade", "Carvalho", "Müller", "Reymond",
                                           "Dantas", "Santana", "Moscovis", "Torres", "Albuquerque" };

            nome = $"{nome} {listaSobreNome[rnd.Next(0, 19)].ToString()} {listaSobreNome[rnd.Next(0, 19)].ToString()}";
            var email = $"{nome.ToLower().Split(' ').FirstOrDefault()}.{nome.ToLower().Split(' ').Last()}@meuemail.com";

            var DataNascimento = new DateTime((2017 - (new Random().Next(1, 8) * 10)), new Random().Next(1, 12), new Random().Next(1, 28)).Date;
        }
        #endregion

        #region GeradorDeCPF
        static String GerarCpf()
        {
            int soma = 0, resto = 0;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Random rnd = new Random();
            string semente = rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            return semente;
        }
        #endregion

        #region Stringbuilder
        static void GeradorStringBuilder()
        {
            var nome1 = "Felipe";
            var nome2 = "Isabela";
            var nome3 = "Daniela";
            StringBuilder sb1 = new StringBuilder();
            sb1.AppendLine(nome1);
            sb1.AppendLine(nome2);
            sb1.AppendLine(nome3);
            Console.WriteLine(sb1);
        }
        #endregion

        #region Moeda
        private static void VerificaMoedaPais()
        {
            var valor1 = 1234;
            var valor2 = -1234.565F;
            Console.WriteLine("Standard Numeric Format Specifiers");
            String s = String.Format("(C) Currency: . . . . . . . . {1:C}\n" +
                                "(D) Decimal:. . . . . . . . . {0:D}\n" +
                                "(E) Scientific: . . . . . . . {1:E}\n" +
                                "(F) Fixed point:. . . . . . . {1:F}\n" +
                                "(G) General:. . . . . . . . . {0:G}\n" +
                                "    (default):. . . . . . . . {0} (default = 'G')\n" +
                                "(N) Number: . . . . . . . . . {0:N}\n" +
                                "(P) Percent:. . . . . . . . . {1:P}\n" +
                                "(R) Round-trip: . . . . . . . {1:R}\n" +
                                "(X) Hexadecimal:. . . . . . . {0:X}\n" +
                                "(MC) Moeda customizada: . . . R$ {0:N}\n" +
                                "(MC) Moeda customizada Neg: . R$ {1:N}\n",
                                valor1, valor2);
            Console.WriteLine(s);

            // obtém a cultura local
            var cultureInfo = System.Globalization.CultureInfo.CurrentCulture;
            var numberFormatInfo = (System.Globalization.NumberFormatInfo)cultureInfo.NumberFormat.Clone();

            var currencySymbol = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
            // fixa o símbolo da moeda estrangeira
            numberFormatInfo.CurrencySymbol = "US$";
            // obtém o valor em moeda estrangeira formatado conforme a cultura local
            var valorFormatado1 = string.Format(numberFormatInfo, "{0:C}", valor1);
            var valorFormatado2 = string.Format(numberFormatInfo, "{0:C}", valor2);
            Console.WriteLine(valorFormatado1);
            Console.WriteLine(valorFormatado2);

            var valorFormatado3 = string.Format("{0} {1:N}", currencySymbol, valor1);
            var valorFormatado4 = string.Format("{0} {1:N}", currencySymbol, valor2);
            Console.WriteLine(valorFormatado3);
            Console.WriteLine(valorFormatado4);

            int num = 98765432;
            Console.WriteLine(string.Format("{0:#,#}", num));
            Console.WriteLine(string.Format("{0:#,##0.##}", 0)); 
            Console.WriteLine(string.Format("{0:#,##0.##}", 0.5));
            Console.WriteLine(string.Format("{0:#,##0.##}", 12314));
            Console.WriteLine(string.Format("{0:#,##0.##}", 12314.23123));
            Console.WriteLine(string.Format("{0:#,##0.##}", 12314.2));
            Console.WriteLine(string.Format("{0:##,##0.00}", 1231412314.2));
            Console.WriteLine(string.Format("{0:##,##0.00}", 1231412314.2));
        }
        #endregion
    }
}