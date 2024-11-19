using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Teste_Conexao
{
    public partial class ProdutosAdm : Form
    {
        public ProdutosAdm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblNome_Click(object sender, EventArgs e)
        {

        }

        private void ProdutosAdm_Load(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSenha_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Administrador form = new Administrador();
            form.Show();
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGravar_Click(object sender, EventArgs e)

        {
            // Captura os valores dos campos de entrada
            string nomeProduto = txtProduto.Text;
            string codigoBarras = txtCodigoBarras.Text;
            int quantidade;
            string fornecedor = txtFornecedor.Text;
            DateTime dataEntrada;
            string Medida = comboBox1.Text;

            // Verifica se a quantidade e a data são válidas
            if (!int.TryParse(txtQuantidade.Text, out quantidade))
            {
                MessageBox.Show("Quantidade inválida.");
                return;
            }

            if (!DateTime.TryParse(txtDatadeentrada.Text, out dataEntrada))
            {
                MessageBox.Show("Data de entrada inválida.");
                return;
            }

            // String de conexão com o banco de dados
            string connectionString = @"Server=wesley\sqlexpress;Database=BD_DESKTOP;Trusted_Connection=True;";

            // Comando SQL para inserir o produto
            string query = "INSERT INTO Produtos (NomeProduto, CodigoBarras, Quantidade, Fornecedor, DataEntrada, Medida) " +
                           "VALUES (@NomeProduto, @CodigoBarras, @Quantidade, @Fornecedor, @DataEntrada, @Medida)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NomeProduto", nomeProduto);
                command.Parameters.AddWithValue("@CodigoBarras", codigoBarras);
                command.Parameters.AddWithValue("@Quantidade", quantidade);
                command.Parameters.AddWithValue("@Fornecedor", fornecedor);
                command.Parameters.AddWithValue("@DataEntrada", dataEntrada);
                command.Parameters.AddWithValue("@Medida", comboBox1.SelectedItem.ToString());
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Produto cadastrado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar o produto.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            // Captura os valores dos campos de entrada
            string nomeProduto = txtProduto.Text;
            string codigoBarras = txtCodigoBarras.Text;
            int quantidade;
            string fornecedor = txtFornecedor.Text;
            DateTime dataEntrada;

            // Validações
            if (!int.TryParse(txtQuantidade.Text, out quantidade))
            {
                MessageBox.Show("Quantidade inválida.");
                return;
            }

            if (!DateTime.TryParse(txtDatadeentrada.Text, out dataEntrada))
            {
                MessageBox.Show("Data de entrada inválida.");
                return;
            }

            // Conexão com o banco de dados
            string connectionString = @"Server=wesley\sqlexpress;Database=BD_floricultura;Trusted_Connection=True;";
            string query = "UPDATE Produtos SET NomeProduto = @NomeProduto, Quantidade = @Quantidade, " +
                           "Fornecedor = @Fornecedor, DataEntrada = @DataEntrada " +
                           "WHERE CodigoBarras = @CodigoBarras";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NomeProduto", nomeProduto);
                command.Parameters.AddWithValue("@CodigoBarras", codigoBarras);
                command.Parameters.AddWithValue("@Quantidade", quantidade);
                command.Parameters.AddWithValue("@Fornecedor", fornecedor);
                command.Parameters.AddWithValue("@DataEntrada", dataEntrada);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Produto alterado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Produto não encontrado ou código de barras incorreto.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // Captura o código de barras do produto a ser excluído
            string codigoBarras = txtCodigoBarras.Text;

            // Verificação básica
            if (string.IsNullOrEmpty(codigoBarras))
            {
                MessageBox.Show("Informe o código de barras do produto a ser excluído.");
                return;
            }

            // String de conexão com o banco
            string connectionString = @"Server=wesley\sqlexpress;Database=BD_floricultura;Trusted_Connection=True;";
            string query = "DELETE FROM Produtos WHERE CodigoBarras = @CodigoBarras";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CodigoBarras", codigoBarras);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Produto excluído com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Produto não encontrado ou código de barras incorreto.");
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
            txtProduto.Text = string.Empty;
            txtCodigoBarras.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
            txtFornecedor.Text = string.Empty;
            txtDatadeentrada.Text = string.Empty;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            MessageBox.Show("Campos limpos com sucesso!");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           


           

        }
        
    }
}
