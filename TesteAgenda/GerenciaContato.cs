using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TesteAgenda
{
    class GerenciaContato
    {
        private Conexao objConexao;


        public GerenciaContato (Conexao conexao)
        {
            objConexao = conexao;
        }

        //Método que irá incluir o contato no banco de dados
        public void Incluir(Contato contato)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = objConexao.ObjetoConexao;
            comando.CommandText = "insert into TesteAgenda ( nome, telefone, endereco ) values (@nome, @telefone, @endereco); select @@IDENTITY;"; //Comando SQL
            comando.Parameters.AddWithValue("@nome", contato.Nome);
            comando.Parameters.AddWithValue("@telefone", contato.Telefone);
            comando.Parameters.AddWithValue("@endereco", contato.Rua);
            objConexao.Conectar();
            contato.Id = Convert.ToInt32(comando.ExecuteScalar());
            objConexao.Desconectar();
        }


        //Método que irá alterar o contato no banco de dados
        public void Alterar(Contato contato)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = objConexao.ObjetoConexao;
            comando.CommandText = "update TesteAgenda set nome=@nome, telefone=@telefone, endereco = @endereco where id = @id"; //Comando SQL
            comando.Parameters.AddWithValue("@nome", contato.Nome);
            comando.Parameters.AddWithValue("@telefone", contato.Telefone);
            comando.Parameters.AddWithValue("@endereco", contato.Rua);
            comando.Parameters.AddWithValue("@id", contato.Id);
            objConexao.Conectar();
            comando.ExecuteNonQuery();
            objConexao.Desconectar();
        }

        //Método que irá Excluir o contato no banco de dados
        public void Excluir(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = objConexao.ObjetoConexao;
            comando.CommandText = "delete from TesteAgenda where id = @id";      //Comando SQL     
            comando.Parameters.AddWithValue("@id", id);
            objConexao.Conectar();
            comando.ExecuteNonQuery();
            objConexao.Desconectar();
        }

        //Método que irá Localizar os contatos no banco de dados
        public DataTable Localizar(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TesteAgenda where nome like '%" + valor + "%'", objConexao.StringConexao); //Comando SQL
            da.Fill(tabela);
            return tabela;
        }

        //Método responsável por armazenar os dados de contato de acordo com o código ID.
        public Contato carregaContato(int codigo)
        {
            Contato contato = new Contato();
            SqlCommand comando = new SqlCommand();
            comando.Connection = objConexao.ObjetoConexao;
            comando.CommandText = "select * from TesteAgenda where id =" + codigo.ToString(); //Comando SQL
            objConexao.Conectar();
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                contato.Id = Convert.ToInt32(registro[ "id" ]);
                contato.Nome = Convert.ToString(registro["nome"]);
                contato.Rua = Convert.ToString(registro["endereco"]);
                contato.Telefone = Convert.ToString(registro["telefone"]);
            }
            return contato;
        }
    }
}
