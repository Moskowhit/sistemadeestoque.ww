using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teste_Conexao
{
    public partial class PedidoAdm : Form
    {
        public PedidoAdm()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Administrador form = new Administrador();
            form.Show();
            this.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblCpf_Click(object sender, EventArgs e)
        {

        }

        private void PedidosAdm_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            // Captura os valores dos campos
            string codigoBarras = txtNome.Text;
            string descricaoProduto = txtRg.Text;
            int quantidade;
            string setor = comboBox1.Text;
            string numeroPedido = txtSenha.Text;

            // Validações básicas
            if (string.IsNullOrWhiteSpace(codigoBarras) ||
                string.IsNullOrWhiteSpace(descricaoProduto) ||
                string.IsNullOrWhiteSpace(setor) ||
                string.IsNullOrWhiteSpace(numeroPedido))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }

            if (!int.TryParse(txtCpf.Text, out quantidade))
            {
                MessageBox.Show("Quantidade inválida.");
                return;
            }

            // String de conexão com o banco
            string connectionString = @"Server=wesley\sqlexpress;Database=BD_DESKTOP;Trusted_Connection=True;";

            // Comando SQL para inserir os dados
            string query = "INSERT INTO Materia (CodigoBarras, DescricaoProduto, Quantidade, Setor, NumeroPedido) " +
                           "VALUES (@CodigoBarras, @DescricaoProduto, @Quantidade, @Setor, @NumeroPedido)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CodigoBarras", codigoBarras);
                command.Parameters.AddWithValue("@DescricaoProduto", descricaoProduto);
                command.Parameters.AddWithValue("@Quantidade", quantidade);
                command.Parameters.AddWithValue("@Setor", setor);
                command.Parameters.AddWithValue("@NumeroPedido", numeroPedido);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Pedido gravado com sucesso!");
                        LimparCampos(); // Limpa os campos após gravar
                    }
                    else
                    {
                        MessageBox.Show("Erro ao gravar o pedido.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }
        private void LimparCampos()
        {
            txtCpf.Clear();
            txtRg.Clear();
            txtNome.Clear();
            comboBox1.SelectedIndex = -1;
            txtSenha.Clear();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRg_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCpf_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Funcionario form = new Funcionario();
            form.Show();
            this.Visible = false;
        }
    }
}
