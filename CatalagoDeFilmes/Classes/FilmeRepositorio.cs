using System.Collections.Generic;
using CatalagoDeFilmes.Interfaces;

namespace CatalagoDeFilmes
{
    public class FilmeRepositorio : IRepositorio<Filme>
    {
        private List<Filme> ListaDeFilmes = new List<Filme>();
        public void Atualizar(int id, Filme entidade)
        {
            ListaDeFilmes[id] = entidade;
        }

        public void Excluir(int id)
        {
            ListaDeFilmes[id].excluir();
        }

        public void Inserir(Filme entidade)
        {
            ListaDeFilmes.Add(entidade);
        }

        public List<Filme> Lista()
        {
            return ListaDeFilmes;
        }

        public int ProximoId()
        {
            return ListaDeFilmes.Count;
        }

        public Filme RetornaPorId(int id)
        {
            return ListaDeFilmes[id];
        }
    }
}