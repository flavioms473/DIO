using System;
using System.Collections.Generic;
using App_series.Interfaces;

namespace App_series
{
    class Program 
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();

           while (opcaoUsuario.ToUpper() != "X")
           {
               switch(opcaoUsuario)
               {
                   case "1":
                     ListarSeries();
                     break;

                     case "2":
                       InserirSerie();
                       break;

                       case "3":
                        AtualizarSerie();
                        break;

                        case "4":
                         ExcluirSerie();
                         break;

                         case "5":
                         VisualizarSerie();
                          break;

                          case "C":
                          Console.Clear();
                          break;

                          default:
                          break;

                          throw new ArgumentOutOfRangeException();
                   
               }

               opcaoUsuario = ObterOpcaoUsuario();
                
           }

           Console.WriteLine("Obrigado por utilizar nossos serviços");
           Console.ReadLine();
                   
        }

        
        private static void  ExcluirSerie()
		{
			Console.WriteLine("Digite o id da série: " );
			 int indiceSerie  = int.Parse(Console. ReadLine());

			repositorio. Exclui(indiceSerie);
		}

      private  static void  VisualizarSerie()
		{
			Console.WriteLine("Digite o id da série: " );
			int indiceSerie  = int. Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console. WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console. WriteLine("Digite o id da série: " );
			 int indiceSerie  = int.Parse(Console. ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console. WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.WriteLine( "Digite o gênero entre as opções acima: " );
			int entradaGenero = int.Parse(Console. ReadLine());

			Console. Write("Digite o Título da Série: " );
			string entradaTitulo = Console. ReadLine();

			Console. Write("Digite o Ano de Início da Série: " );
			int entradaAno = int.Parse(Console. ReadLine());

			Console.WriteLine("Digite a Descrição da Série: " );
			string entradaDescricao = Console. ReadLine();

			Series atualizaSerie = new Series(id: indiceSerie,
										genero:(Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualizada(indiceSerie, atualizaSerie);
		}
       private static void ListarSeries()
		{
			Console. WriteLine("Listar séries" );

			var lista = repositorio.lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie. retornaId(), serie. retornaTitulo(),(excluido ?  "*Excluído*"  : ""));
			}
		}

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}" , i, Enum.GetName(typeof(Genero),  i));
            }
                Console.WriteLine("Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                 Console.WriteLine("Digite o Titulo da série: ");
                 string entradaTitulo = Console.ReadLine();

                  Console.WriteLine("Digite o Ano de inicio da série: ");
                 int entradaAno = int.Parse(Console.ReadLine());

                 Console.WriteLine("Digite a descrição da série: ");
                 string entradaDescricao = Console.ReadLine();

                 Series novaSerie = new Series(id: repositorio.ProximoId(),
                                             genero: (Genero)entradaGenero,
                                             titulo: entradaTitulo,
                                             ano: entradaAno,
                                             descricao: entradaDescricao);
                                             
                repositorio.Insere(novaSerie);
            
        }

        private static string ObterOpcaoUsuario()
        
                   
        {
            Console.WriteLine();
             Console.WriteLine("Séries a seu dispor");
              Console.WriteLine("Informe a opção desejada:");
               Console.WriteLine();
                Console.WriteLine("1- Listar séries");
                 Console.WriteLine("2- Inserir nova série");
                  Console.WriteLine("3- Atualizar série");
                   Console.WriteLine("4- Excluir série");
                    Console.WriteLine("5- Visualisar série");
                     Console.WriteLine("c- Limpar tela");
                      Console.WriteLine("x- Sair");
                       Console.WriteLine();

                string ObterOpcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return ObterOpcaoUsuario;
        }
    }
}
