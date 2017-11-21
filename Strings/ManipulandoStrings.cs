using System;

namespace Strings
{
    public class ManipulandoStrings
    {

        public static void ManipulandoStrings2()
        {
            string rua = null;
            string bairro = "Vila Sésamo";
            DateTime dt = new DateTime(2017,10,13);

            if (dt == default(DateTime))
                return;

            var queryEndereco = $@"INSERT INTO [dbo].[TESTE] ([Rua], [Bairro], [DataCriacao])
                        VALUES ('{rua ?? ""}', '{bairro ?? null}', '{dt == ? "" : {dt}');
                        SELECT CAST(scope_identity() AS int)";

            string x = null;
            string y = null;
            string z = "olá";

            var w = x ?? y ?? z;

            var novoEnd = $"{queryEndereco}";
        }
    }
}
