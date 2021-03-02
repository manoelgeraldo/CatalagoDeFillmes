using System;

namespace CatalagoDeFilmes
{
    class Program
    {
        static FilmeRepositorio repositorio = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoInformada = ObterOpcao();
            while (opcaoInformada.ToUpper() != "7")
            {
                switch (opcaoInformada)
                {
                    case "1":
                        Listar();
                        break;
                    case "2":
                        Inserir();
                        break;
                    case "3":
                        Atualizar();
                        break;
                    case "4":
                        Excluir();
                        break;
                    case "5":
                        Visualizar();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoInformada = ObterOpcao();
            }
            Console.WriteLine("Obrigado por utilizar nosso serviço!");
            Console.ReadLine();
        }

        private static string ObterOpcao()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("---Catálago de Filmes---");
            Console.WriteLine("------------------------");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("[1] - Listar");
            Console.WriteLine("[2] - Inserir");
            Console.WriteLine("[3] - Atualizar");
            Console.WriteLine("[4] - Excluir");
            Console.WriteLine("[5] - Visualizar");
            Console.WriteLine("[6] - Limpar Tela");
            Console.WriteLine("[7] - Sair");
            Console.Write(" Opção: ");

            string opcaoInformada = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoInformada;
        }
        private static void Listar()
        {
            Console.WriteLine();
            Console.WriteLine("---Lista de Filmes---");
            Console.WriteLine();
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine(" Nenhum Filme catalogado!");
                Console.WriteLine();
            }
            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();
                if(!excluido)
                {
                    Console.WriteLine("#Id {0}: - {1}", filme.retornaId(), filme.retornaTitulo());
                }
                if (lista.Count == 0)
                {
                    Console.WriteLine(" Nenhum Filme catalogado!");
                    Console.WriteLine();
                }
            }
        }
        private static void Inserir()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("-----Inserir Filme-----");
            Console.WriteLine("-----------------------");

            Console.Write("Informe o título do Filme: ");
            string tituloInformado = Console.ReadLine();

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Escolha um das opções de gênero acima: ");
            int generoInformado = int.Parse(Console.ReadLine());

            Console.Write("Informe o Ano do filme: ");
            int anoInformado = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe a descrição do filme:");
            Console.Write(">>> ");
            string descricaoInformada = Console.ReadLine();
            Console.WriteLine();

            Filme novoFilme = new Filme(Id: repositorio.ProximoId(), 
                                        titulo: tituloInformado, 
                                        genero: (Genero)generoInformado, 
                                        ano: anoInformado,
                                        descricao: descricaoInformada);
            repositorio.Inserir(novoFilme);
        }
        private static void Atualizar()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("-----Atualizar Filme-----");
            Console.WriteLine("-------------------------");
            Console.Write("Informe o ID do Filme: ");
            
            int idInformado = int.Parse(Console.ReadLine());

            Console.Write("Informe o título do Filme: ");
            string tituloInformado = Console.ReadLine();

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Escolha um das opções de gênero acima: ");
            int generoInformado = int.Parse(Console.ReadLine());

            Console.Write("Informe o Ano do filme: ");
            int anoInformado = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe a descrição do filme:");
            Console.Write(">>> ");
            string descricaoInformada = Console.ReadLine();
            Console.WriteLine();

            Filme atualizarFilme = new Filme(Id: idInformado,
                                        titulo: tituloInformado,
                                        genero: (Genero)generoInformado,
                                        ano: anoInformado,
                                        descricao: descricaoInformada);
            repositorio.Atualizar(idInformado, atualizarFilme);
        }
        protected static void InformacaoTela()
        {
            Console.Write("Informe o título do Filme: ");
            string tituloInformado = Console.ReadLine();

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Escolha um das opções de gênero acima: ");
            int generoInformado = int.Parse(Console.ReadLine());

            Console.Write("Informe o Ano do filme: ");
            int anoInformado = int.Parse(Console.ReadLine());

            Console.Write("Informe a descrição do filme >>>");
            string descricaoInformada = Console.ReadLine();
            Console.WriteLine();
        }
        private static void Excluir()
        {
            Console.Write("Informe o Id do Filme >>> ");
            int idInformado = int.Parse(Console.ReadLine());

            repositorio.Excluir(idInformado);
        }
        private static void Visualizar()
        {
            Console.Write("Informe o id do Filme >>> ");
            int idInformado =  int.Parse(Console.ReadLine());

            var filme = repositorio.RetornaPorId(idInformado);
            Console.WriteLine(filme);
        }

    }
    
}
