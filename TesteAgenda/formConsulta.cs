using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TesteAgenda
{
    public partial class formConsulta : Form
    {
        public int codigo = 0;        

        public formConsulta()
        {
            InitializeComponent();
        }

        //Ao clicar no botão pesquisar é executado a seguinte linha de comando
        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            //conexão ao servidor
            Conexao conexao = new Conexao();
            GerenciaContato gerenciaContato = new GerenciaContato(conexao);
            //tabela de dados recebe as informações do banco
            dgDados.DataSource = gerenciaContato.Localizar(txtValor.Text);
        }

        //Ao clicar duas vezes em um contato ele é selecionado e a informação do ID de contato selecionado é armazenada e encaminhada para formCadastro.
        private void dgDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                this.codigo = Convert.ToInt32(dgDados.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
        }

        private void formConsulta_Load(object sender, EventArgs e)
        {

        }        
    }
}
