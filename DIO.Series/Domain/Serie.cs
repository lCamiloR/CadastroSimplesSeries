using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series.Domain
{
    public class Serie : BaseEntity
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Ativo { get; set; }

        public Serie(int id, Genero genero, string titulo, int ano, string descricao = "")
        {
            if (string.IsNullOrEmpty(titulo))
            {
                throw new ArgumentException($"'{nameof(titulo)}' cannot be null or empty.", nameof(titulo));
            }

            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Ano = ano;
            this.Descricao = descricao;
            this.Ativo = true;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"Gênero: {this.Genero}{Environment.NewLine}");
            builder.Append($"Titulo: {this.Titulo}{Environment.NewLine}");
            builder.Append($"Descrição: {this.Descricao}{Environment.NewLine}");
            builder.Append($"Ano de Inicio: {this.Ano}{Environment.NewLine}");
            builder.Append($"Ativo: {this.Ativo}{Environment.NewLine}");

            return builder.ToString();
        }

        public string getTitulo()
        {
            return this.Titulo;
        }
        public int getId()
        {
            return this.Id;
        }

        public bool isAtivo()
        {
            return this.Ativo;
        }

        public void Desativar()
        {
            this.Ativo = false;
        }

    }
}
