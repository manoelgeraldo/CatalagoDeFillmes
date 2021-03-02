using System;

namespace CatalagoDeFilmes
{
    public class Filme : EntidadeBase
    {
        ///-------ATRIBUTOS-------///
        private string Titulo { get; set; }
        private Genero Genero { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        //-------MÉTODOS--------///
        public Filme(int Id, string titulo, Genero genero, string descricao, int ano)
        {
            this.Id = Id;
            this.Titulo = titulo;
            this.Genero = genero;
            this.Ano = ano;
            this.Descricao = descricao;
            this.Excluido = false;

        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            return retorno;

        }
        public int retornaId()
        {
            return this.Id;
        }
        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public void excluir()
        {
            this.Excluido = true;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
    }
}