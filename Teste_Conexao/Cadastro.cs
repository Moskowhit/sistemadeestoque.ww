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
using DAL;
using Model;

namespace Teste_Conexao
{
    public partial class Cadastro : Form
    {

        SqlConnection conexao;

        public Cadastro()
        {
            InitializeComponent();
        }

        private void btnTestar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = clnConexao.getConexao();
                MessageBox.Show("Conexão estabelecida!");
                conexao.Open();
                MessageBox.Show("Conexão aberta...\nAguardando SQL...");
                //habilitar via código o botão fechar

            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha: " + ex.Message);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {

            if(conexao.State == ConnectionState.Open)
            {
                try
                {
                    conexao.Close();
                    //desabilitar o botão  fechar via código
                     
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Falha ao fechar: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Conexão já se encontra fechada!");
            }

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

            // Captura os valores dos campos de entrada
            string nomeFunc = txtNome.Text;
            string matricula = txtMatricula.Text;
            string setor = txtSetor.Text;
            string nomeUser = txtUsuario.Text;
            string senhaUser = txtSenha.Text;
            string tipoUsuario = "Funcionario"; // Definido como "Funcionario" por padrão, você pode ajustar conforme a lógica do sistema

            // String de conexão
            string connectionString = @"Server=wesley\sqlexpress;Database=BD_DESKTOP;Trusted_Connection=True;";
            string query = "INSERT INTO Funcionarios (nome_func, matricula, setor, nome_user, senha_user, tipo_usuario) " +
                           "VALUES (@NomeFunc, @Matricula, @Setor, @NomeUser, @SenhaUser, @TipoUsuario)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NomeFunc", nomeFunc);
                command.Parameters.AddWithValue("@Matricula", matricula);
                command.Parameters.AddWithValue("@Setor", setor);
                command.Parameters.AddWithValue("@NomeUser", nomeUser);
                command.Parameters.AddWithValue("@SenhaUser", senhaUser);
                command.Parameters.AddWithValue("@TipoUsuario", tipoUsuario);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Funcionário gravado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao gravar funcionário: " + ex.Message);
                }
            }

            Acesso frm1 = new Acesso();
            frm1.Show();
            this.Close();

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtMatricula.Clear();
            txtSetor.Clear();
            txtUsuario.Clear();
            txtSenha.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            



        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtMatricula.Clear();
            txtSetor.Clear();
            txtUsuario.Clear();
            txtSenha.Clear();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            // Captura os valores dos campos de entrada
            string nomeFunc = txtNome.Text;
            string matricula = txtMatricula.Text; // Usada como chave para identificar o registro
            string setor = txtSetor.Text;
            string nomeUser = txtUsuario.Text;
            string senhaUser = txtSenha.Text;
            string tipoUsuario = "Funcionario"; // Definido como "Funcionario" por padrão, pode ser ajustado conforme necessário

            // String de conexão
            string connectionString = @"Server=wesley\sqlexpress;Database=BD_DESKTOP;Trusted_Connection=True;";
            string query = "UPDATE Funcionarios SET nome_func = @NomeFunc, setor = @Setor, nome_user = @NomeUser, senha_user = @SenhaUser, tipo_usuario = @TipoUsuario " +
                           "WHERE matricula = @Matricula";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NomeFunc", nomeFunc);
                command.Parameters.AddWithValue("@Setor", setor);
                command.Parameters.AddWithValue("@NomeUser", nomeUser);
                command.Parameters.AddWithValue("@SenhaUser", senhaUser);
                command.Parameters.AddWithValue("@TipoUsuario", tipoUsuario);
                command.Parameters.AddWithValue("@Matricula", matricula);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Funcionário alterado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Funcionário não encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao alterar funcionário: " + ex.Message);
                }
            }



        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string matricula = txtMatricula.Text;

            string connectionString = @"Server=wesley\sqlexpress;Database=BD_DESKTOP;Trusted_Connection=True;";
            string query = "DELETE FROM Funcionarios WHERE Matricula = @Matricula";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Matricula", matricula);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Usuário excluído com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Usuário não encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir usuário: " + ex.Message);
                }
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Acesso obj = new Acesso();
            this.Hide();
            obj.ShowDialog();
        }

        private void FrmFunc_Load(object sender, EventArgs e)
        {

        }

        private void txtMatricula_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblCpf_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtRg_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCpf_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

