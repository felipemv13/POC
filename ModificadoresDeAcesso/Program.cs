using System;

namespace ModificadoresDeAcesso
{
    class Program
    {
        static void Main(string[] args)
        {
            int idade;
            double peso;

            Animal bicho = new Animal();

            idade = bicho.ObterIdade();
            peso = bicho.ObterPeso;
            //bicho.peso = 50;

            Console.WriteLine("A idade é {0} e o peso é {1:F}.", idade, peso);
            
            Animal.Mensagem();

            double pi;
            pi = Math.PI;

            Console.WriteLine("O valor de PI é {0}.", pi);

            Console.Read();
        }
    }
}
