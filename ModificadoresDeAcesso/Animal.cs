using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModificadoresDeAcesso
{
    class Animal
    {
        private int idade = 10;
        double peso = 50.4;
        //public double peso = 50.4;

        public int ObterIdade()
        {
            return idade;
        }

        public double ObterPeso
        {
            get { return peso; }
        }

        public static void Mensagem()
        {
            Console.WriteLine("Método estático");
        }
    }
}
