using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class Conta
    {
        public int numero;
        public string titular;
        public double saldo;
        public Endereco endereco;

        public class Endereco
        {
            public string Logradouro { get; set; }
            public string Cidade { get; set; }
            public string Estado { get; set; }
            public string CEP { get; set; }
        }
    }
}
