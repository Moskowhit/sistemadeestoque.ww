using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teste_Conexao
{
    public partial class Funcionario : Form
    {
            InitializeComponent();
        public Funcionario()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            estoque form = new estoque();
            form.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Pedidos  form = new Pedidos();
            form.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Relatórioadm form = new Relatórioadm();
            form.Show();
            this.Close();
        }
    }
}
