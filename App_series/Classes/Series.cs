using System;

namespace App_series
{
    public class Series : EntidadeBase
    {
        private Genero Genero{get; set;}
        private string Titulo {get; set;}
        private string Descricao{get; set;}
        private int Ano {get; set;}

        private bool Excluido{get; set;}

        // metodos


        public Series(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }


        public override string ToString()
        {
            string retorno = "";
             retorno += "Gênero: " + this.Genero + Environment.NewLine;
             retorno += "Titulo: " + this.Genero + Environment.NewLine;
             retorno += "Descrição: " + this.Genero + Environment.NewLine;
             retorno += "Excluido: " + this.Excluido;
            
             return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.id;
        }

          public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Exclui()
        {
            this.Excluido = true;
        }

      
    }
}