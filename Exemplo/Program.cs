using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Declaração de Variáveis
            int[] codigoAluno = new int[10];
            string[] nomeAluno = new string[10];
            double[] nota1 = new double[10];
            double[] nota2 = new double[10];
            double[] nota3 = new double[10];
            int opcao;
            #endregion

            #region Looping
            do
            {
                Console.WriteLine("[ 1 ] Matricular aluno");
                Console.WriteLine("[ 2 ] Cancelar matrícula de um aluno");
                Console.WriteLine("[ 9 ] Relatório de alunos cadastrados");
                Console.WriteLine("[ 0 ] Sair do Software");
                Console.WriteLine("-------------------------------------");
                Console.Write("Digite uma opção: ");
                opcao = Int32.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        matriculaAluno(ref codigoAluno, ref nomeAluno);
                        break;
                    case 2:
                        cancelarAluno(ref codigoAluno, ref nomeAluno);
                        break;
                    case 9:
                        relatorioAlunos(ref codigoAluno, ref nomeAluno);
                        break;
                    default:
                        saiPrograma();
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
            while (opcao != 0);
            #endregion
        }

        private static void relatorioAlunos(ref int[] codigoAluno, ref string[] nomeAluno)
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("***************| RELATORIO DE ALUNOS |**************************");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("-------Codigo--------Aluno--------------------------------------");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("        {0}           {1}", codigoAluno[i], nomeAluno[i]);
            }
            Console.WriteLine("----------------------------fim relatório----------------------");
        }

        private static void cancelarAluno(ref int[] codigoAluno, ref string[] nomeAluno)
        {
            Console.Clear();
            int i;
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("***************| CANCELAMENTO DE MATRÍCULA |********************");
            Console.WriteLine("----------------------------------------------------------------");
            Console.Write("Digite a posicao/MATRICULA do vetor que deseja CANCELAR: ");
            i = Int32.Parse(Console.ReadLine());
            codigoAluno[i] = 0;
            nomeAluno[i] = "";
            Console.WriteLine("Aluno CANCELADO com Sucesso !");
        }

        private static void saiPrograma()
        {
            Console.WriteLine();
            Console.WriteLine("Bye Bye, vc saiu do Programa. Clique qq tecla para sair...");
        }

        private static void matriculaAluno(ref int[] codigoAluno, ref string[] nomeAluno)
        {
            Console.Clear();
            bool jaExiste = false;
            bool codigoEstaNoIntervalo;
            int i = 0;
            do
            {
                jaExiste = false;
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("******************| MATRÍCULA DE ALUNOS |***********************");
                Console.WriteLine("----------------------------------------------------------------");
                Console.Write("Digite a posicao do vetor que deseja cadastrar: ");
                i = Int32.Parse(Console.ReadLine());
                Console.Write("Código do aluno na Posição {0}: ", i);
                codigoAluno[i] = Int32.Parse(Console.ReadLine());
                codigoEstaNoIntervalo = verificaCodigoIntervalo(codigoAluno[i]);
                jaExiste = verificaCodigoJaExiste(codigoAluno[i], i, codigoAluno);

                if (jaExiste == false)
                {
                    if (codigoEstaNoIntervalo == false)
                    {
                        Console.WriteLine("O Código do aluno deve ser entre 1 e 1000!");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.Write("Nome do aluno na Posição {0}: ", i);
                        nomeAluno[i] = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("O Código do aluno {0} já existe!", codigoAluno[i]);
                    codigoAluno[i] = 50000;
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            while (codigoAluno[i] < 1 || codigoAluno[i] > 1000);
            Console.WriteLine("Aluno cadastrado com Sucesso !");
        }

        private static bool verificaCodigoJaExiste(int codigoDigitado, int posicaoCodigoDigitado, int[] vetor)
        {
            bool jaExiste = false;
            for (int i = 0; i < vetor.Length; i++)
            {
                if (vetor[i] == codigoDigitado && i != posicaoCodigoDigitado)
                {
                    jaExiste = true;
                }
            }
            return jaExiste;
        }

        private static bool verificaCodigoIntervalo(int codigo)
        {
            bool estaNoIntervalo = false;
            if (codigo > 0 && codigo <= 1000)
                estaNoIntervalo = true;
            else
                estaNoIntervalo = false;

            return estaNoIntervalo;
        }
    }
}
