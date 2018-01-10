using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Strings
{
    public static class ManipulandoStrings
    {

        public static void ManipulandoStrings2()
        {
            string rua = null;
            string bairro = "Vila Sésamo";
            DateTime dt = new DateTime(2017, 10, 13);

            if (dt == default(DateTime))
                dt = DateTime.Now;

            var queryEndereco = $@"INSERT INTO [dbo].[TESTE] ([Rua], [Bairro], [DataCriacao])
                        VALUES ('{rua ?? ""}', '{bairro ?? null}', '{dt}';
                        SELECT CAST(scope_identity() AS int)";

            string x = null;
            string y = null;
            string z = "olá";

            var w = x ?? y ?? z;

            double? valortotal = 10.90;

            var novoEnd = $"{queryEndereco}";

            var queryString = "";
            var queryField = new StringBuilder();
            var queryInsertValue = new StringBuilder();
            var id = new Guid();

            Console.WriteLine($"Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

            var formatDecimal = new CultureInfo("en-US");

            queryField.Append("INSERT INTO [dbo].[Consumidor] ");
            queryInsertValue.Append(" VALUES ");
            queryField.Append("([id]");
            queryInsertValue.Append($"('{Guid.NewGuid()}'");
            queryField.Append(", [CpfCnpj] ");
            queryInsertValue.Append(", '15232515880'");
            queryField.Append(", [valortotalUs] ");
            queryInsertValue.Append($", {valortotal?.ToString(formatDecimal)}");
            valortotal = null;
            queryField.Append(", [valortotalBr1] ");
            queryInsertValue.Append($", {(valortotal != null ? valortotal?.ToString(formatDecimal) : 0.ToString())}");
            queryField.Append(", [valortotalBr2] ");
            queryInsertValue.Append($", {(valortotal != null ? valortotal?.ToString(formatDecimal) : Convert.ToString("0"))}");
            queryField.Append(", [valortotalBr2] ");
            queryInsertValue.Append($", {(valortotal != null ? valortotal?.ToString(formatDecimal) : "0")}");
            queryField.AppendLine(")");
            queryInsertValue.AppendLine(");");

            queryInsertValue.AppendLine(" SELECT (scope_identity())");

            queryString = queryField.ToString() + queryInsertValue.ToString();
            queryField.Clear();
            queryInsertValue.Clear();

        }

        public static bool IsValidCEP(this string input)
        {
            return Regex.IsMatch(input, @"^[0-9]{4,5}-?[0-9]{3}$");
        }

        public static bool IsValidCpf(this string input)
        {
            if ((input == "00000000000") || (input == "11111111111") || (input == "22222222222") ||
                (input == "33333333333") || (input == "44444444444") || (input == "55555555555") ||
                (input == "66666666666") || (input == "77777777777") || (input == "88888888888") ||
                (input == "99999999999"))
            {
                return false;
            }

            if (!Regex.IsMatch(input, @"^\d{1,3}\.?\d{3}\.?\d{3}\-?\d{2}$"))
                return false;
            string cpf = Regex.Replace(input, @"[^0-9]", "").PadLeft(11, '0');
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto;
            return cpf.EndsWith(digito);
        }
    }
}
