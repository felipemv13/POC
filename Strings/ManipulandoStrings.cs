using System;
using System.Globalization;
using System.Text;

namespace Strings
{
    public class ManipulandoStrings
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
    }
}
