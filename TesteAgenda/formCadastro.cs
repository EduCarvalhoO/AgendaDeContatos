using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TesteAgenda
{
    public partial class formCadastro : Form
    {
        //Variavel que irá armazenar o tipo de operação que está sendo executada. Estados: Inserir dados ou alterar
        public string operacao = "";

        
        public formCadastro()
        {
            InitializeComponent();
        }

        //Método criado para gerenciar os botões que ficarão disponíveis para interação do usuario
        public void ControleBotoes(int op)
        {
            painelDados.Enabled = false;
            btnInserir.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = false;
            btnLocalizar.Enabled = false;
            btnSalvar.Enabled = false;

            //Modo de operação = 1 será possível inserir um novo cadastro ou localizar um cadastro existente
            if (op == 1)
            {
                btnInserir.Enabled = true;
                btnLocalizar.Enabled = true;
            }

            //Modo de operação = 2 será possível salvar uma alteração ou um novo contato baseado no conteudo armazenado na variavel String operação citada no início do código
            if (op == 2)
            {
                painelDados.Enabled = true;
                btnCancelar.Enabled = true;
                btnSalvar.Enabled = true;
            }

            //Modo de operação = 3 será possível excluir um contato ou alterar após o mesmo ser localizado e selecionado
            if (op == 3)
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }

        //Método utilizado para limpar os campos de dados após uma alteração
        public void LimparCampos()
        {            
            txtEndereco.Clear();
            txtID.Clear();
            txtTelefone.Clear();
            txtNome.Clear();
        }

        //Função que será executada assim que o objeto formCadastro for aberto. 
        private void formCadastro_Load(object sender, EventArgs e)
        {
            this.ControleBotoes(1);
        }

        //Função que será ativa ao clicar no botão Inserir
        private void btnInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "Inserir dados"; //Alteração no modo de operação
            this.ControleBotoes(2); //Parametro 2 para alternar os botões disponíveis para interação
        }

        //Função que será ativa ao clicar no botão Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.ControleBotoes(1);
            this.LimparCampos();
        }

        //Função que será ativa ao clicar no botão Salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //Verificação para que não seja enviado conteúdo vazio para o banco de dados
                if(txtNome.Text.Length <= 3)
                {
                    MessageBox.Show("Insira um nome válido");
                    return;                }

                if (txtTelefone.Text.Length <= 10)
                {
                    MessageBox.Show("Insira um Telefone válido");
                    return;
                }

                if (txtEndereco.Text.Length <= 3)
                {
                    MessageBox.Show("Insira um Endereço válido");
                    return;
                }

                //instanciado um novo contato e atribuido a ele os dados inseridos pelo usuario
                Contato contato = new Contato();
                contato.Nome = txtNome.Text;
                contato.Rua = txtEndereco.Text;
                contato.Telefone = txtTelefone.Text;

                //Acesso ao banco de dados
                Conexao conexao = new Conexao();
                GerenciaContato gerenciaContato = new GerenciaContato(conexao);

                if (this.operacao == "Inserir dados")
                {
                    //Registro no banco de dados
                    gerenciaContato.Incluir(contato);
                    MessageBox.Show("Registro Inserido com ID: " + contato.Id.ToString());
                }

                else
                {
                    //Registro alterado no banco de dados
                    contato.Id = Convert.ToInt32(txtID.Text);
                    gerenciaContato.Alterar(contato);
                    MessageBox.Show("Registro alterado para o contato:" + contato.Nome.ToString());                   
                }

                this.ControleBotoes(1);
                this.LimparCampos();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        //Função que será executada ao clicar no botão Localizar contatos
        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            //Instanciado formConsulta
            formConsulta consulta = new formConsulta();
            consulta.ShowDialog();
            //Checagem se o código fornecido é valido.
            if (consulta.codigo != 0)
            {   
                //Realizado conexão ao banco de dados
                Conexao conexao = new Conexao();
                GerenciaContato gerenciaContato = new GerenciaContato(conexao);

                //Instancia de contato para receber as informações do contato selecionado
                Contato contato = gerenciaContato.carregaContato(consulta.codigo);
                txtID.Text = contato.Id.ToString();
                txtNome.Text = contato.Nome.ToString();
                txtEndereco.Text = contato.Rua.ToString();
                txtTelefone.Text = contato.Telefone.ToString();
                this.ControleBotoes(3);
            }
            consulta.Dispose();
        }

        //Função executada ao clicar em alterar
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            //alterado modo de operação e alterado o cadastro do contato
            this.operacao = "alterar";
            this.ControleBotoes(2);
        }

        //Função executada ao clicar no botão Excluir
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //Checagem se o usuario realmente deseja excluir o contato selecionado
            DialogResult dialog = MessageBox.Show("Deseja excluir o Registro?", "Aviso", MessageBoxButtons.YesNo);
            //Caso opte por sim é feito a exclusão do banco de dados
            if (dialog.ToString() == "Yes")
            {
                Conexao conexao = new Conexao();
                GerenciaContato gerenciaContato = new GerenciaContato(conexao);
                gerenciaContato.Excluir(Convert.ToInt32(txtID.Text));
                this.ControleBotoes(1);
                this.LimparCampos();
            }
        }
    }
}
