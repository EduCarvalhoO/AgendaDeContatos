using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TesteAgenda
{
    class Conexao
    {
        //Alterar caminho de conexão para o banco de dados de acordo com sua máquina.
        private String _stringConexao = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\ProjetosC#\\TesteAgenda\\BancoAgenda.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection _conexao;

        public Conexao()
        {
            this._conexao = new SqlConnection();            
            this._conexao.ConnectionString = _stringConexao;
        }

        public String StringConexao
        {
            get { return this._stringConexao; }
            set { this._stringConexao = value; }
        }

        public SqlConnection ObjetoConexao
        {
            get { return this._conexao; }
            set { this._conexao = value; }
        }

        public void Conectar()
        {
            this._conexao.Open();
        }

        public void Desconectar()
        {
            this._conexao.Close();
        }

    }
}
