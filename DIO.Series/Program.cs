using DIO.Series.Domain;
using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ExtrairOpcaoUsuario();

            while (opcaoUsuario != "X")
            {

                switch (opcaoUsuario)
                {
                    case "1":
                        InserirSerie();
                        break;
                    case "2":
                        ListarSeries();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSeries();
                        break;
                    case "5":
                        VisualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ExtrairOpcaoUsuario();

            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserindo nova serie.");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"ID {i}: {Enum.GetName(typeof(Genero), i)}");
            }
            Console.WriteLine("Digite o numero do genero: ");
            int numGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo: ");
            string titulo = Console.ReadLine();
            
            Console.WriteLine("Digite o ano de inicio: ");
            int anoInicio = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite uma descrição: ");
            string descricao = Console.ReadLine();
            Serie s = new Serie
            (
                id: repositorio.ProximoId(),
                genero: (Genero)numGenero,
                titulo: titulo,
                ano: anoInicio,
                descricao: descricao
            );

            repositorio.Insert(s);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Atualizando serie.");

            Console.WriteLine("Digite o ID da série a atualizar: ");
            int idAtt = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"ID {i}: {Enum.GetName(typeof(Genero), i)}");
            }
            Console.WriteLine("Digite o numero do genero: ");
            int numGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo: ");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio: ");
            int anoInicio = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite uma descrição: ");
            string descricao = Console.ReadLine();
            Serie s = new Serie
            (
                id: idAtt,
                genero: (Genero)numGenero,
                titulo: titulo,
                ano: anoInicio,
                descricao: descricao
            );

            repositorio.Atualiza(idAtt, s);
        }

        private static void ExcluirSeries()
        {
            Console.WriteLine("Excluindo serie.");

            Console.WriteLine("Digite o ID da série a ser excluida: ");
            int idEx = int.Parse(Console.ReadLine());

            repositorio.Exclui(idEx);
        }

        private static void VisualizarSeries()
        {
            Console.WriteLine("Visualizando serie.");

            Console.WriteLine("Digite o ID da série a ser visualizada: ");
            int idList = int.Parse(Console.ReadLine());

            Serie s = repositorio.RetornaPorId(idList);

            if (s == null)
            {
                Console.WriteLine("Nenhum registro com esse ID.");
                return;
            }

            Console.WriteLine(s.ToString());
        }

        private static void ListarSeries()
        {
            Console.WriteLine("IListando series cadastradas.");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Sem séries cadastradas.");
                return;
            }

            foreach(Serie serie in lista)
            {
                Console.WriteLine($"ID {serie.getId()}: {serie.getTitulo()} - {(serie.isAtivo() ? "Ativo" : "Inativo")}");
            }
        }

        private static string ExtrairOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir nova série");
            Console.WriteLine("2 - Listar séries");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair do sistema");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
