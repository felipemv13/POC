using System;

namespace Strings
{
    public class Gerador
    {
        public void GetConsumidor(int sexo)
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
                nome = String.Format("{listaNomeHomem[rnd.Next(0, 19)].ToString()}");
            }
            else
            {
                listaNomeMulher = new string[] { "Antonia", "Josefa", "Ana Claudia", "Maria", "Guilhermina",
                                            "Livia", "Fabia", "Alexia", "Débora", "Rafaela",
                                            "Inês", "Aurora","Hortênsia","Lilian","Maia",
                                            "Melissa", "Rosa", "Tauane", "Virgínia", "Flora"};
                nome = String.Format("{listaNomeMulher[rnd.Next(0, 19)].ToString()}");
            }

            string[] listaSobreNome = { "Marques", "Almeida", "Moraes", "Duarte", "Vasconcelos",
                                           "Ferraz", "Vargas", "Dolabella", "Fagundes", "Trindade",
                                           "Lins", "Andrade", "Carvalho", "Müller", "Reymond",
                                           "Dantas", "Santana", "Moscovis", "Torres", "Albuquerque" };

            nome = String.Format("{nome} {listaSobrenome[rnd.Next(0, 19)].ToString()}");

        }

        public Endereco GetEndereco()
        {
            string[] listaRua = {"Rua Alfredo Batista", "Rua Cassio Magalhães", "Rua Conselheiro Neves", "Avenida Paulista", "Rua Antonio Bento",
                                 "Rua Chico Bento", "Rua Ana Maria","Rua Brig Bartolomeu", "Rua Eugenio de Lima", "Rua Joaquim Floriano","Rua Estela",
                                 "Rua Consolação", "Rua Matias Aires", "Rua Epitácio Pessoa", "Rua Bartolomeuy de Gusmão", "Rua Osvaldo Cruz", "Rua São Paulo",
                                 "Rua São José", "Travessa da Maioba", "Rua Santos", "Alameda Santos", "Rua Higienópolis", "Rua Macaperibe"};

            string[] listaComplemento = { "Casa 01", "apt 22", null, "Bl b Ap 109", "s/n" };
            string[] listaBairro = { "Planalto Paulista", "Centro", "Maingá", "Ingá", "Galício",
                                     "Ponta da Praia", "Embaré", "Santa Paula", "Jd Aparecida", "Bonfiglioli"};
            string[] listaCidade = { "Santos", "São Paulo", "São Caetano do Sul", "São Bernardo do Campo", "Santo André", "Mauá",
                                     "Suzano", "São José dos Campos", "São Bento do Araçuaí", "São Bento do Sapucaí", "Osasco",
                                     "Barueri", "Vinhedo", "Campinas", "Jundiaí", "Mogi das Cruzes", "Itatiba"};
            string[] listaUF = { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB",
                                 "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };
            string[] listaCep = { "72859-613", "69089-073", "27963-610", "78025-101", "77820-336", "07084-170", "58401-213", "31650-475", "88517-150", "64011-665",
                                  "72312-201", "58401-279", "41205-085", "58066-134", "59073-150", "89812-663", "03460-130", "85601-867", "69309-408", "79034-009",
                                  "58037-665", "59129-589", "76829-496", "64039-705", "87014-110", "64090-610", "54230-300", "38183-318", "59075-710", "89232-415",
                                  "68627-540", "24875-145", "69901-806", "29210-303", "49043-787", "68744-322", "70640-710", "68903-778", "27350-360", "41940-105"};
            var rua = listaRua[new Random().Next(0, 22)];
            var complemento = listaComplemento[new Random().Next(0, 4)];
            var numero = new Random().Next(1, 1000).ToString();
            Endereco end = new Endereco
            {
                Rua = rua,
                Numero = numero,
                Complemento = complemento,
                Logradouro = $"{rua}, {numero} - {complemento}",
                Bairro = listaBairro[new Random().Next(0, 9)],
                Cidade = listaCidade[new Random().Next(0, 16)],
                Estado = listaUF[new Random().Next(0, 26)],
                CEP = listaCep[new Random().Next(0, 39)],
                Pais = "Brasil"
            };
            return end;
        }
    }
}
