using System;
using System.Collections.Generic;
using SAFe.Core.Common.Struct;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace Strings
{
    public class Program
    {
        private static Stopwatch s0 = new Stopwatch();

        public static void Main(string[] args)
        {
            ManipulandoStrings.ManipulandoStrings2();
            //TestaLeituraArquivo();
            //TestesRegex.ResolverSexo("feminino","fem");            
            //RemoveSubstringToken("a");
            //TesteStringFormat();
            //CursoMoodleEasy();
            //var nrpedido = GeraNumeroPedido();
            //TesteStruct();
            //TestaTrim();
            //VerificaAny();
            //TestarContagem();
            //TestesComTuplas();
            //VerificaMoedaPais();
            //GeradorStringBuilder();
            //s0.Start();
            //var conta1 = new Conta();

            //var conta3 = new Conta();
            //conta3.Pedidos = new List<Pedido>();
            //var contador3 = 1 + conta3.Pedidos.Count;

            //conta3.Pedidos.Add(
            //    new Pedido
            //    {
            //        Coletor = false,
            //        Dispositivo = "dispositivo fake"
            //    });

            //contador3 = conta3.Pedidos.Count;

            //conta3.Pedidos.Add(
            //    new Pedido
            //    {
            //        Coletor = true,
            //        Dispositivo = "dispositivo real"
            //    });

            //contador3 = conta3.Pedidos.Count;

            //double a = 150;
            //double a1 = 150.00;
            //double a2 = 150,00;

            //string primeira = "Cidade";
            //conta1.Numero = 15234;
            //conta1.Saldo = 0.0;
            //conta1.Endereco = new Endereco()
            //{
            //    Cidade = "Sao Paulo"
            //};
            //conta1.Titular = "rua sao paulo 09857-256";

            //ValidaString(conta1.endereco.Estado, conta1);

            //TesteER();
            //var pedido1 = new Pedido();
            //Tempos(conta1, pedido1);

            //Randomico(1);
            //var cpfnovo = GerarCpf();
            //Gerador endereco = new Gerador();
            //endereco.GetEndereco();

        }

        private static void TestaLeituraArquivo()
        {
            var path = @"C:\SAFe\RoboDecisaoExterna\Log\";
            var filename = "dataHistory.txt";
            var fileContent = new List<string>();

            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }

            if (!File.Exists($@"{path}{filename}"))
            {
                using (StreamWriter file =
                    new StreamWriter($@"{path}{filename}"))
                {
                }
            }

            Stream entrada = File.Open($@"{path}{filename}", FileMode.Open);
            StreamReader leitor = new StreamReader(entrada);
            //string linha = leitor.ReadLine();
            for (int i = 0; !leitor.EndOfStream; i++)
            {
                fileContent.Add(leitor.ReadLine());
            }
            leitor.Close();
            entrada.Close();

            fileContent.Remove("");
            fileContent.Sort(); // ASC
            var a = fileContent.FirstOrDefault();            
        }

        private static void TesteStringFormat()
        {
            int a1 = 11;
            int b1 = 22116664;
            var c1 = string.Format("{0}{1}", a1.ToString(), b1);
            var listaTelefones = new List<string>();
            listaTelefones.Add(c1);

            int a2 = 11;
            int b2 = 948702549;
            var c2 = string.Format("{0}{1}", a2.ToString(), b2);
            listaTelefones.Add(c2);
        }

        private static void CursoMoodleEasy()
        {
            string[] nomes = new string[4];
            nomes[0] = "Felipe";

            List<string> nomes2 = new List<string>();
            nomes2.Add("Felipe");

            foreach (var item in nomes)
            {
                Console.WriteLine(item);
            }

            foreach (var item in nomes2)
            {
                Console.WriteLine(item);
            }

            //int z = 10;

            //for (int x = 0; x < 3; x++)
            //{
            //    int z = 0;
            //    z = z + x;
            //}

            //Console.WriteLine(z);


            //for (int x = 0; x <= 12;)
            //{
            //    Console.WriteLine("C#");
            //}
        }

        private static object GeraNumeroPedido()
        {
            var a = new Gerador();
            return a.GeraNumeroPedido();
        }

        private static void TesteStruct()
        {
            var estrutura = new StructExemplo();

            Pedido pedido1 = new Pedido
            {
                DataDaCompra = new DateTime(2017, 1, 1, 1, 1, 1),
                NumeroIp = "127.0.0.1"
            };
            Pedido pedido2 = new Pedido
            {
                DataDaCompra = new DateTime(2018, 1, 1, 1, 1, 1),
                NumeroIp = "128.0.0.1"
            };

            estrutura.ListaAprovados = new List<string>(); // necessário inicializar a lista.

            estrutura.ListaAprovados.Add(pedido1.NumeroIp);
            estrutura.ListaAprovados.Add(pedido2.NumeroIp);
        }

        #region Verificar Replace e Regex
        private static void TestaTrim()
        {
            string a1 = "alfabeto@abecedario.com.br";
            string a2 = " fel ipe.carval ho@ meua be ce dario. co m. br";
            string aa2 = " fel ipe.carval ho@ meua be ce dario. co m. br";
            string a3 = string.Empty;
            string a4 = null;
            string a5 = "teste";
            string a6 = "Mário Gonçãlvês João de Guérra";
            var stringBuild = new StringBuilder();

            var a1a = a1.Trim();

            Stopwatch s0 = new Stopwatch();
            s0.Start();
            var a2a = a2.Replace(" ", "");
            s0.Stop();
            Console.WriteLine(s0.Elapsed);
            Console.WriteLine(s0.ElapsedTicks);
            var a3a = a3.Trim();
            var a4a = a4?.Trim();

            Stopwatch s6 = new Stopwatch();
            s6.Start();
            var a6a = Regex.Replace(a6, "[^0-9a-zA-Z]+", ""); // retiro caracteres especiais
            s6.Stop();
            Console.WriteLine(s6.Elapsed);

            Stopwatch s2a = new Stopwatch();
            s2a.Start();
            var aa2a = aa2.Replace(" ", "");
            s2a.Stop();
            Console.WriteLine(s2a.Elapsed);

            Stopwatch s7 = new Stopwatch();
            s7.Start();
            a6a = Regex.Replace(a6, "[^0-9a-zA-Z]+", ""); // retiro caracteres especiais
            s7.Stop();
            Console.WriteLine(s7.Elapsed);

            if (a1?.Trim() == a2?.Trim())
                Console.WriteLine("Emails iguais.");
            else
                Console.WriteLine("Emails diferentes.");

            if (a1?.Trim() == a4?.Trim())
                Console.WriteLine("Emails vazios.");

            // Testar TRIM na StringBuilder
            stringBuild.Append("[");
            stringBuild.Append(a1);
            stringBuild.Append(a2);
            stringBuild.Append(a3);
            stringBuild.Append(a4);
            stringBuild.Append(a5);
            stringBuild.Append(a6);
            stringBuild.Append("]");
            var file = stringBuild.Replace(" ", string.Empty);
        }
        #endregion

        #region Verificar Any , All
        private static void VerificaAny()
        {
            var lista = new List<Pedido>();// as IEnumerable<Pedido>;
            Pedido pedido1 = new Pedido
            {
                DataDaCompra = new DateTime(2017, 1, 1, 1, 1, 1)
            };
            Pedido pedido2 = new Pedido();
            Pedido pedido3 = new Pedido();
            Pedido pedido4 = new Pedido();
            Pedido pedido5 = new Pedido();


            //lista.Add(pedido1);
            //lista.Add(pedido2);
            //lista.Add(pedido3);
            //lista.Add(pedido4);
            //lista.Add(pedido5);
            if (lista.All(x => x.DataDaCompra == default(DateTime)))
            {
                Console.WriteLine($"Só existem datas nulas.");
                var beta = lista.OrderByDescending(x => x.DataDaCompra).FirstOrDefault();
                if (beta == null)
                    Console.WriteLine($"Não temos pedidos.");
            }
            if (lista.Any(x => x.DataDaCompra != default(DateTime)))
                Console.WriteLine($"Existem datas não nulas.");

            if (!lista.Any(x => x.DataDaCompra != default(DateTime)))
                Console.WriteLine($"Só existem datas nulas.");
        }
        #endregion

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
        static void Tempos(Conta c1 = null, Pedido pedido = null)
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


            // TESTE COM CONCATENAÇÃO
            var idEnderecoPedido = 1;
            var s5 = new Stopwatch();
            s5.Start();
            string _insert = "INSERT INTO Pedido (id, numerodopedido, datadacompra, datacriacao, dataalteracao, idempresa " +
            (pedido.NumeroIp == null ? "" : ", numeroip") +
            ", idconsumidor, idstatus, " +
            "idenderecoentrega, lote " +
            (pedido.IdMotivoChargeback == null ? "" : ", IdMotivoChargeback") +
            (pedido.Operador == null ? "" : ",  Operador") +
            (pedido.Token == null ? "" : ", Token") +
            ", valortotal, valorjuros, valordesconto, valoracrescimo, valorparcela, frete, emailentrega, canalnome, idcanal, iddevice, statustransacao, " +
            "descricaostatustransacao, vendedor" +
            (pedido.IdMotivo == null ? "" : ", IdMotivo") +
            (pedido.Coletor == null ? "" : ", Coletor ") +
            (pedido.IdStatusFinal == null ? "" : ", IdStatusFinal ") +
            (pedido.IdMotivoFinal == null ? "" : ", IdMotivoFinal ") +
            (pedido.Dispositivo == null ? "" : ", Dispositivo ") +
            (pedido.TipoDeEntrega == null ? "" : ", TipoDeEntrega ") +
            (pedido.DecisaoExterna == null ? "" : ", DecisaoExterna ") +
            ", reanalise) " +
            " VALUES " +
            "(@Id " +
            ", @NumeroDoPedido" +
            ", @DataDaCompra" +
            ", getdate()" +
            ", getdate()" +
            ", @IdEmpresa " +
            (pedido.NumeroIp == null ? "" : ", @NumeroIp") +
            ", @IdConsumidor" +
            ", @IdStatus " +
            ", " + (idEnderecoPedido == 0 ? "null" : "@IdEnderecoEntrega") +
            ", @Lote" +
            (pedido.IdMotivoChargeback == null ? "" : ", @IdMotivoChargeback") +
            (pedido.Operador == null ? "" : ",  @Operador") +
            (pedido.Token == null ? "" : ", @Token") +
            ", @ValorTotal" +
            ", @ValorJuros" +
            ", @ValorDesconto " +
            ", @ValorAcrescimo " +
            ", @ValorParcela" +
            ", @Frete" +
            ", @EmailEntrega" +
            ", @CanalNome" +
            ", @IdCanal" +
            ", @IdDevice" +
            ", @StatusTransacao" +
            ", @DescricaoStatusTransacao" +
            ", @Vendedor " +
            (pedido.IdMotivo == null ? "" : ", @IdMotivo") +
            (pedido.Coletor == null ? "" : ", @Coletor ") +
            (pedido.IdStatusFinal == null ? "" : ", @IdStatusFinal ") +
            (pedido.IdMotivoFinal == null ? "" : ", @IdMotivoFinal ") +
            (pedido.Dispositivo == null ? "" : ", @Dispositivo ") +
            (pedido.TipoDeEntrega == null ? "" : ", @TipoDeEntrega ") +
            (pedido.DecisaoExterna == null ? "" : ", @DecisaoExterna ") +
            ", @Reanalise" +
            ") ";
            s5.Stop();
            Console.WriteLine("TESTE COM CONCATENAÇÃO v1 - {0} tick(s)", s5.ElapsedTicks);



            // TESTE COM STRINGBUILDER com 75
            var s6 = new Stopwatch();
            s6.Start();
            var queryTemp = new StringBuilder(75);
            queryTemp.AppendLine("INSERT INTO [dbo].[Pedido]");
            queryTemp.AppendLine(" ([id]");
            queryTemp.AppendLine(", [numerodopedido]");
            queryTemp.AppendLine(", [datadacompra]");
            queryTemp.AppendLine(", [datacriacao]");
            queryTemp.AppendLine(", [dataalteracao]");
            queryTemp.AppendLine(", [idempresa]");
            queryTemp.AppendLine(pedido.NumeroIp == null ? "" : ", [numeroip]");
            queryTemp.AppendLine(", [idconsumidor]");
            queryTemp.AppendLine(", [idstatus]");
            queryTemp.AppendLine(", [idenderecoentrega]");
            queryTemp.AppendLine(", [lote]");
            queryTemp.AppendLine(pedido.IdMotivoChargeback == null ? "" : ", [IdMotivoChargeback]");
            queryTemp.AppendLine(pedido.Operador == null ? "" : ",  [Operador]");
            queryTemp.AppendLine(pedido.Token == null ? "" : ", [Token]");
            queryTemp.AppendLine(", [valortotal]");
            queryTemp.AppendLine(", [valorjuros]");
            queryTemp.AppendLine(", [valordesconto]");
            queryTemp.AppendLine(", [valoracrescimo]");
            queryTemp.AppendLine(", [valorparcela]");
            queryTemp.AppendLine(", [frete]");
            queryTemp.AppendLine(", [emailentrega]");
            queryTemp.AppendLine(", [canalnome]");
            queryTemp.AppendLine(", [idcanal]");
            queryTemp.AppendLine(", [iddevice]");
            queryTemp.AppendLine(", [statustransacao]");
            queryTemp.AppendLine(", [descricaostatustransacao]");
            queryTemp.AppendLine(", [vendedor]");
            queryTemp.AppendLine(pedido.IdMotivo == null ? "" : ", [IdMotivo]");
            queryTemp.AppendLine(pedido.Coletor == null ? "" : ", [Coletor]");
            queryTemp.AppendLine(pedido.IdStatusFinal == null ? "" : ", [IdStatusFinal]");
            queryTemp.AppendLine(pedido.IdMotivoFinal == null ? "" : ", [IdMotivoFinal]");
            queryTemp.AppendLine(pedido.Dispositivo == null ? "" : ", [Dispositivo]");
            queryTemp.AppendLine(pedido.TipoDeEntrega == null ? "" : ", [TipoDeEntrega]");
            queryTemp.AppendLine(pedido.DecisaoExterna == null ? "" : ", [DecisaoExterna]");
            queryTemp.AppendLine(", [reanalise]");
            queryTemp.AppendLine(" VALUES ");
            queryTemp.AppendLine(", @Id");
            queryTemp.AppendLine(", @NumeroDoPedido");
            queryTemp.AppendLine(", @DataDaCompra");
            queryTemp.AppendLine(", GETDATE()");
            queryTemp.AppendLine(", GETDATE()");
            queryTemp.AppendLine(", @IdEmpresa");
            queryTemp.AppendLine(pedido.NumeroIp == null ? "" : ", @NumeroIp");
            queryTemp.AppendLine(", @IdConsumidor");
            queryTemp.AppendLine(", @IdStatus");
            queryTemp.AppendLine(idEnderecoPedido == 0 ? ", NULL" : ", @IdEnderecoEntrega");
            queryTemp.AppendLine(", @Lote");
            queryTemp.AppendLine(pedido.IdMotivoChargeback == null ? "" : ", @IdMotivoChargeback");
            queryTemp.AppendLine(pedido.Operador == null ? "" : ",  @Operador");
            queryTemp.AppendLine(pedido.Token == null ? "" : ", @Token");
            queryTemp.AppendLine(", @ValorTotal");
            queryTemp.AppendLine(", @ValorJuros");
            queryTemp.AppendLine(", @ValorDesconto");
            queryTemp.AppendLine(", @ValorAcrescimo");
            queryTemp.AppendLine(", @ValorParcela");
            queryTemp.AppendLine(", @Frete");
            queryTemp.AppendLine(", @EmailEntrega");
            queryTemp.AppendLine(", @CanalNome");
            queryTemp.AppendLine(", @IdCanal");
            queryTemp.AppendLine(", @IdDevice");
            queryTemp.AppendLine(", @StatusTransacao");
            queryTemp.AppendLine(", @DescricaoStatusTransacao");
            queryTemp.AppendLine(", @Vendedor");
            queryTemp.AppendLine(pedido.IdMotivo == null ? "" : ", @IdMotivo");
            queryTemp.AppendLine(pedido.Coletor == null ? "" : ", @Coletor");
            queryTemp.AppendLine(pedido.IdStatusFinal == null ? "" : ", @IdStatusFinal");
            queryTemp.AppendLine(pedido.IdMotivoFinal == null ? "" : ", @IdMotivoFinal");
            queryTemp.AppendLine(pedido.Dispositivo == null ? "" : ", @Dispositivo");
            queryTemp.AppendLine(pedido.TipoDeEntrega == null ? "" : ", @TipoDeEntrega");
            queryTemp.AppendLine(pedido.DecisaoExterna == null ? "" : ", @DecisaoExterna");
            queryTemp.AppendLine(", @Reanalise); ");
            var queryString = queryTemp.ToString();

            s6.Stop();
            Console.WriteLine("TESTE COM STRINGBUILDER com 75- {0} tick(s)", s6.ElapsedTicks);


            // TESTE COM CONCATENAÇÃO
            var s51 = new Stopwatch();
            s51.Start();
            string _insert51 = "INSERT INTO Pedido (id, numerodopedido, datadacompra, datacriacao, dataalteracao, idempresa " +
            (pedido.NumeroIp == null ? "" : ", numeroip") +
            ", idconsumidor, idstatus, " +
            "idenderecoentrega, lote " +
            (pedido.IdMotivoChargeback == null ? "" : ", IdMotivoChargeback") +
            (pedido.Operador == null ? "" : ",  Operador") +
            (pedido.Token == null ? "" : ", Token") +
            ", valortotal, valorjuros, valordesconto, valoracrescimo, valorparcela, frete, emailentrega, canalnome, idcanal, iddevice, statustransacao, " +
            "descricaostatustransacao, vendedor" +
            (pedido.IdMotivo == null ? "" : ", IdMotivo") +
            (pedido.Coletor == null ? "" : ", Coletor ") +
            (pedido.IdStatusFinal == null ? "" : ", IdStatusFinal ") +
            (pedido.IdMotivoFinal == null ? "" : ", IdMotivoFinal ") +
            (pedido.Dispositivo == null ? "" : ", Dispositivo ") +
            (pedido.TipoDeEntrega == null ? "" : ", TipoDeEntrega ") +
            (pedido.DecisaoExterna == null ? "" : ", DecisaoExterna ") +
            ", reanalise) " +
            " VALUES " +
            "(@Id " +
            ", @NumeroDoPedido" +
            ", @DataDaCompra" +
            ", getdate()" +
            ", getdate()" +
            ", @IdEmpresa " +
            (pedido.NumeroIp == null ? "" : ", @NumeroIp") +
            ", @IdConsumidor" +
            ", @IdStatus " +
            ", " + (idEnderecoPedido == 0 ? "null" : "@IdEnderecoEntrega") +
            ", @Lote" +
            (pedido.IdMotivoChargeback == null ? "" : ", @IdMotivoChargeback") +
            (pedido.Operador == null ? "" : ",  @Operador") +
            (pedido.Token == null ? "" : ", @Token") +
            ", @ValorTotal" +
            ", @ValorJuros" +
            ", @ValorDesconto " +
            ", @ValorAcrescimo " +
            ", @ValorParcela" +
            ", @Frete" +
            ", @EmailEntrega" +
            ", @CanalNome" +
            ", @IdCanal" +
            ", @IdDevice" +
            ", @StatusTransacao" +
            ", @DescricaoStatusTransacao" +
            ", @Vendedor " +
            (pedido.IdMotivo == null ? "" : ", @IdMotivo") +
            (pedido.Coletor == null ? "" : ", @Coletor ") +
            (pedido.IdStatusFinal == null ? "" : ", @IdStatusFinal ") +
            (pedido.IdMotivoFinal == null ? "" : ", @IdMotivoFinal ") +
            (pedido.Dispositivo == null ? "" : ", @Dispositivo ") +
            (pedido.TipoDeEntrega == null ? "" : ", @TipoDeEntrega ") +
            (pedido.DecisaoExterna == null ? "" : ", @DecisaoExterna ") +
            ", @Reanalise" +
            ") ";
            s51.Stop();
            Console.WriteLine("TESTE COM CONCATENAÇÃO - {0} tick(s)", s51.ElapsedTicks);


            // TESTE COM FORMATAÇÃO
            var s7 = new Stopwatch();
            s7.Start();
            string testeFormat = @"INSERT INTO Pedido (id, numerodopedido, datadacompra, datacriacao, dataalteracao, idempresa
            (pedido.NumeroIp == null ? \ \  \, numeroip\
            , idconsumidor, idstatus,
            idenderecoentrega, lote
            (pedido.IdMotivoChargeback == null ?  : , IdMotivoChargeback
            (pedido.Operador == null ?  : ,  Operador
            (pedido.Token == null ?  : , Token
             valortotal, valorjuros, valordesconto, valoracrescimo, valorparcela, frete, emailentrega, canalnome, idcanal, iddevice, statustransacao, 
            descricaostatustransacao, vendedor
            (pedido.IdMotivo == null ?  : , IdMotivo
            (pedido.Coletor == null ?  : , Coletor  +
            (pedido.IdStatusFinal == null ?  : , IdStatusFinal  +
            (pedido.IdMotivoFinal == null ?  : , IdMotivoFinal ) +
            (pedido.Dispositivo == null ?  : , Dispositivo ) +
            (pedido.TipoDeEntrega == null ?  :  TipoDeEntrega) +
            (pedido.DecisaoExterna == null ?  :  DecisaoExterna ) +
            , reanalise)  +
             VALUES  +
            (@Id  +
            , @NumeroDoPedido +
            , @DataDaCompra +
            , getdate() +
            , getdate() +
            , @IdEmpresa  +
            (pedido.NumeroIp == null ?  : , @NumeroIp) +
            , @IdConsumidor +
            , @IdStatus  +
            ,  + (idEnderecoPedido1 == 0 ? null : @IdEnderecoEntrega) +
            , @Lote +
            (pedido.IdMotivoChargeback == null ?  : , @IdMotivoChargeback) +
            (pedido.Operador == null ?  : ,  @Operador) +
            (pedido.Token == null ?  : , @Token) +
            , @ValorTotal +
            , @ValorJuros +
            , @ValorDesconto  +
            , @ValorAcrescimo  +
            , @ValorParcela +
            , @Frete +
            , @EmailEntrega +
            , @CanalNome +
            , @IdCanal +
            , @IdDevice +
            , @StatusTransacao +
            , @DescricaoStatusTransacao +
            , @Vendedor  +
            (pedido.IdMotivo == null ?  : , @IdMotivo) +
            (pedido.Coletor == null ?  :  @Coletor ) +
            (pedido.IdStatusFinal == null ?  : , @IdStatusFinal ) +
            (pedido.IdMotivoFinal == null ?  : , @IdMotivoFinal ) +
            (pedido.Dispositivo == null ?  : , @Dispositivo ) +
            (pedido.TipoDeEntrega == null ?  :, @TipoDeEntrega ) +
            (pedido.DecisaoExterna == null ?  : , @DecisaoExterna ) +
            , @Reanalise +
            ) ";
            s7.Stop();
            Console.WriteLine("TESTE COM FORMATAÇÃO - {0} tick(s)", s7.ElapsedTicks);

            // TESTE COM STRINGBUILDER SEM IF
            var s8 = new Stopwatch();
            s8.Start();
            var testesbs = new StringBuilder(100);
            testesbs.AppendLine("INSERT INTO Pedido (id, numerodopedido, datadacompra, datacriacao, dataalteracao, idempresa");
            testesbs.AppendLine("(pedido.NumeroIp == null ? , numeroip");
            testesbs.AppendLine(", idconsumidor, idstatus,");
            testesbs.AppendLine("idenderecoentrega, lote");
            testesbs.AppendLine("(pedido.IdMotivoChargeback == null ?  : , IdMotivoChargeback");
            testesbs.AppendLine("(pedido.Operador == null ?  : ,  Operador");
            testesbs.AppendLine("(pedido.Token == null ?  : , Token");
            testesbs.AppendLine(" valortotal, valorjuros, valordesconto, valoracrescimo, valorparcela, frete, emailentrega, canalnome, idcanal, iddevice, statustransacao, ");
            testesbs.AppendLine("descricaostatustransacao, vendedor");
            testesbs.AppendLine("(pedido.IdMotivo == null ?  : , IdMotivo");
            testesbs.AppendLine("(pedido.Coletor == null ?  : , Coletor  +");
            testesbs.AppendLine("(pedido.IdStatusFinal == null ?  : , IdStatusFinal  +");
            testesbs.AppendLine("(pedido.IdMotivoFinal == null ?  : , IdMotivoFinal ) +");
            testesbs.AppendLine("(pedido.Dispositivo == null ?  : , Dispositivo ) +");
            testesbs.AppendLine("(pedido.TipoDeEntrega == null ?  :  TipoDeEntrega) +");
            testesbs.AppendLine("(pedido.DecisaoExterna == null ?  :  DecisaoExterna ) +");
            testesbs.AppendLine(", reanalise)  +");
            testesbs.AppendLine(" VALUES  +");
            testesbs.AppendLine("(@Id  +");
            testesbs.AppendLine(", @NumeroDoPedido +");
            testesbs.AppendLine(", @DataDaCompra +");
            testesbs.AppendLine(", getdate() +");
            testesbs.AppendLine(", getdate() +");
            testesbs.AppendLine(", @IdEmpresa  +");
            testesbs.AppendLine("(pedido.NumeroIp == null ?  : , @NumeroIp) +");
            testesbs.AppendLine(", @IdConsumidor +");
            testesbs.AppendLine(", @IdStatus  +");
            testesbs.AppendLine(",  + (idEnderecoPedido1 == 0 ? null : @IdEnderecoEntrega) +");
            testesbs.AppendLine(", @Lote +");
            testesbs.AppendLine("(pedido.IdMotivoChargeback == null ?  : , @IdMotivoChargeback) +");
            testesbs.AppendLine("(pedido.Operador == null ?  : ,  @Operador) +");
            testesbs.AppendLine("(pedido.Token == null ?  : , @Token) +");
            testesbs.AppendLine(", @ValorTotal +");
            testesbs.AppendLine(", @ValorJuros +");
            testesbs.AppendLine(", @ValorDesconto  +");
            testesbs.AppendLine(", @ValorAcrescimo  +");
            testesbs.AppendLine(", @ValorParcela +");
            testesbs.AppendLine(", @Frete +");
            testesbs.AppendLine(", @EmailEntrega +");
            testesbs.AppendLine(", @CanalNome +");
            testesbs.AppendLine(", @IdCanal +");
            testesbs.AppendLine(", @IdDevice +");
            testesbs.AppendLine(", @StatusTransacao +");
            testesbs.AppendLine(", @DescricaoStatusTransacao +");
            testesbs.AppendLine(", @Vendedor  +");
            testesbs.AppendLine("(pedido.IdMotivo == null ?  : , @IdMotivo) +");
            testesbs.AppendLine("(pedido.Coletor == null ?  :  @Coletor ) +");
            testesbs.AppendLine("(pedido.IdStatusFinal == null ?  : , @IdStatusFinal ) +");
            testesbs.AppendLine("(pedido.IdMotivoFinal == null ?  : , @IdMotivoFinal ) +");
            testesbs.AppendLine("(pedido.Dispositivo == null ?  : , @Dispositivo ) +");
            testesbs.AppendLine("(pedido.TipoDeEntrega == null ?  :, @TipoDeEntrega ) +");
            testesbs.AppendLine("(pedido.DecisaoExterna == null ?  : , @DecisaoExterna ) +");
            testesbs.AppendLine(", @Reanalise +");
            testesbs.AppendLine(") ; ");
            s8.Stop();
            Console.WriteLine("TESTE COM STRINGBUILDER SEM IF - {0} tick(s)", s8.ElapsedTicks);

            var queryString1 =
                @"INSERT INTO [dbo].[InformacaoAdicional] ([DataCadastroConsumidor], [IdPedido])
                VALUES (@DataCadastroConsumidor, @IdPedido)";

            Console.WriteLine(queryString1);

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
            StringBuilder sb1 = new StringBuilder();
            var nome1 = "Felipe";
            var nome2 = "Isabela";
            var nome3 = "Daniela";
            sb1.AppendLine(nome1);
            sb1.AppendLine(nome2);
            sb1.AppendLine(nome3);
            string texto1 = sb1.ToString();

            Console.WriteLine(sb1);
            Console.WriteLine(texto1);

            sb1.Clear();
            Console.WriteLine(sb1);
            var teste = string.Empty;
            if (teste == sb1.ToString())
                Console.WriteLine("sb1.clear() é igual a teste");

            if (teste == "")
                Console.WriteLine("teste é igual a string.empty");

            if ("" == string.Empty)
                Console.WriteLine("\"\" é igual a string.empty");

            if (string.Empty == sb1.ToString())
                Console.WriteLine("sb1.clear() é igual a string.empty");

            var sbQuery = new StringBuilder();
            sbQuery.AppendLine("INSERT INTO [dbo].[Ingresso]");
            sbQuery.Append("([Data]");
            sbQuery.Append(", [IdSetor]");
            sbQuery.Append(false == null ? "" : ", [TaxaServico]");
            sbQuery.Append(true == null ? "" : ", [GrupoDeVendas]");
            sbQuery.Append(", [IdTipoDeDesconto]");
            sbQuery.Append(", [IdMeioDeEntrega]");
            sbQuery.AppendLine(true == null ? ")" : ", [ProdutoId])");
            sbQuery.AppendLine("VALUES");
            sbQuery.Append("(@Data");
            sbQuery.Append(", @IdSetor");
            sbQuery.Append(false == null ? "" : ", @TaxaServico");
            sbQuery.Append(true == null ? "" : ", @GrupoDeVendas");
            sbQuery.Append(", @IdTipoDeDesconto");
            sbQuery.Append(", @IdMeioDeEntrega");
            sbQuery.AppendLine(true == null ? ");" : ", @ProdutoId);");
            sbQuery.Append("SELECT CAST(scope_identity() AS int) ");
            var queryInsert = sbQuery.ToString();
            Console.WriteLine(queryInsert);

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

        #region Tupla
        static void TestesComTuplas()
        {
            var novaTupla = new List<Tuple<string, int, object>>();

            var ps = new List<Tuple<string, object>>();
            var ps2 = new List<Tuple<string, object>>();
            ps2.Clear();

            if (ps.Count == ps2.Count) Console.WriteLine("Tuplas tem o mesmo tamanho.");

            Console.ReadKey();
        }
        #endregion

        #region Pedido
        static void TestarContagem()
        {
            var pedido1 = new Pedido()
            {
                IdPedido = 1,
                DataDaCompra = new DateTime(2017, 01, 01, 10, 00, 00),
                Consumidor = new Consumidor
                {
                    Cpf = "12345678900",
                    Email = "felipe@felipe.com"
                }
            };
            var pedido2 = new Pedido()
            {
                IdPedido = 2,
                DataDaCompra = new DateTime(2017, 01, 01, 10, 00, 00),
                Consumidor = new Consumidor
                {
                    Cpf = "12345678900",
                    Email = "felipe@felipe.com"
                }
            };
            var pedido3 = new Pedido()
            {
                IdPedido = 3,
                DataDaCompra = new DateTime(2017, 01, 02, 10, 00, 00),
                Consumidor = new Consumidor
                {
                    Cpf = "12345678900",
                    Email = "felipe@felipe.com"
                }
            };

            // Teste Pedido 0
            List<Pedido> testePedidos0 = null;
            bool teste0 = testePedidos0?.Count(x => x.IdPedido != pedido3.IdPedido
                                            && x.DataDaCompra <= pedido3.DataDaCompra
                                            && x.Consumidor.Cpf == pedido3.Consumidor.Cpf
                                            && x.Consumidor?.Email?.ToLower() == pedido3.Consumidor?.Email?.ToLower()) == 0;

            // Teste Pedido 1
            List<Pedido> testePedidos1 = new List<Pedido>();
            testePedidos1.Add(pedido1);
            bool teste1 = false;
            if (testePedidos1 != null)
            {
                teste1 = testePedidos1?.Count(x => x.IdPedido != pedido3.IdPedido
                                            && x.DataDaCompra <= pedido3.DataDaCompra
                                            && x.Consumidor.Cpf == pedido3.Consumidor.Cpf
                                            && x.Consumidor?.Email?.ToLower() == pedido3.Consumidor?.Email?.ToLower()) == 0;
            }

            // Teste Pedido 2
            List<Pedido> testePedidos2 = new List<Pedido>();
            testePedidos2.Add(pedido2);
            bool teste2 = false;
            if (testePedidos2 != null)
            {
                teste2 = testePedidos2?.Count(x => x.IdPedido != pedido3.IdPedido
                                            && x.DataDaCompra <= pedido3.DataDaCompra
                                            && x.Consumidor.Cpf == pedido3.Consumidor.Cpf
                                            && x.Consumidor?.Email?.ToLower() == pedido3.Consumidor?.Email?.ToLower()) > 0;
            }
            Console.WriteLine(teste0);
            Console.WriteLine(teste1);
            Console.WriteLine(teste2);
        }
        #endregion

        #region Remover Substring
        static void RemoveSubstringToken(string pedido)
        {
            string inteira = @"""CodigoBVS"": ""JCN"",    ""Token"": ""TID26acfe000e04e"",    ""Consumidor"": {        ""CpfCnpj"": ""41310678898"", """;
            Console.WriteLine(inteira);
            int indiceInicioSubstring = inteira.IndexOf(@"""Token", 0);
            Console.WriteLine(indiceInicioSubstring);
            int indiceFimSubstring = inteira.IndexOf(@""", ", indiceInicioSubstring);
            Console.WriteLine(indiceFimSubstring);
            var substringToken = inteira.Substring(indiceInicioSubstring, indiceFimSubstring - indiceInicioSubstring + 2);
            Console.WriteLine(substringToken);
            Console.WriteLine(inteira.Replace(substringToken, string.Empty));

            Console.Read();
        }
        #endregion

    }
}