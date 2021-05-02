using System;
using System.Collections.Generic;
using System.Text;

namespace TesteAgenda
{
    class Contato
    {
        public Contato()
        {
            this.Id = 0;
            this.Nome = "";
            this.Telefone = "";
            this.Rua = "";            
        }

        public Contato(int id, string nome, string telefone, string rua, string bairro, string cidade, string estado)
        {
            this.Id = id;
            this.Nome = nome;
            this.Telefone = telefone;
            this.Rua = rua;            
        }

        private int id;
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        private string nome;

        public string Nome
        {
            get
            {
                return this.nome;
            }
            set
            {
                this.nome = value;
            }
        }

        private string telefone;

        public string Telefone
        {
            get
            {
                return this.telefone;
            }
            set
            {
                this.telefone = value;
            }
        }

        private string rua;

        public string Rua
        {
            get
            {
                return this.rua;
            }
            set
            {
                this.rua = value;
            }
        }


    }
}
