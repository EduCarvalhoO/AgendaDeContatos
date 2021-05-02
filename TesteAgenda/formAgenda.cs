using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TesteAgenda
{
    public partial class formAgenda : Form
    {
        public formAgenda()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Contatos_Click(object sender, EventArgs e)
        {
            formCadastro f = new formCadastro();
            f.ShowDialog();
            f.Dispose();
        }
    }
}
