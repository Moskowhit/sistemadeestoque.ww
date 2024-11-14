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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Teste_Conexao
{
    public partial class Acesso : Form
    {
        public Acesso()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Home form = new Home();
            form.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            // Defina a string de conexão
            string connectionString = @"Data Source=WESLEY\SQLEXPRESS;Initial Catalog=BD_Floricultura;Integrated Security=True;";

            // Defina a consulta SQL para buscar 'nome_user', 'senha_user' e 'tipo_usuario' com base na entrada
            string query = "SELECT nome_user, senha_user, tipo_usuario FROM funcionarios WHERE nome_user = @nomeUser AND senha_user = @senhaUser";

            // Abrindo a conexão e executando a consulta
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nomeUser", txtUsuario.Text); // Usuário inserido
                command.Parameters.AddWithValue("@senhaUser", txtSenha.Text); // Senha inserida

                try
                {
                    // Abrindo a conexão
                    connection.Open();

                    // Executando o comando e verificando se há resultados
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Usuário e senha encontrados
                        string tipoUsuario = reader["tipo_usuario"].ToString();

                        MessageBox.Show("Login realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Verificar o tipo de usuário e abrir o formulário correspondente
                        if (tipoUsuario == "Administrador")
                        {
                            // Abra o formulário de administrador
                            Administrador adminForm = new Administrador(); // Suponha que você tenha um formulário chamado 'AdminForm'
                            adminForm.Show();
                        }
                        else if (tipoUsuario == "Funcionario")
                        {
                            // Abra o formulário de funcionário
                             Funcionario form = new Funcionario(); // Suponha que você tenha um formulário chamado 'FuncionarioForm'
                                form.Show();
                        }

                        this.Close();
                    }
                    else
                    {
                        // Nenhum registro encontrado com as credenciais fornecidas
                        MessageBox.Show("Usuário ou senha incorretos.", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao buscar dados: " + ex.Message);
                }
            }




        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            // Obtenha os valores de login e senha dos campos de texto
            string login = txtUsuario.Text;
            string senha = txtSenha.Text;

            // Conexão com o banco de dados
            string connectionString = @"Data Source=DESKTOP-9D5DMOS\SQLEXPRESS;Initial Catalog=BD_Floricultura;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Comando para chamar a função de verificação do administrador
                    using (SqlCommand command = new SqlCommand("SELECT dbo.VerificarAdministrador(@login, @senha)", connection))
                    {
                        command.Parameters.AddWithValue("@login", login);
                        command.Parameters.AddWithValue("@senha", senha);

                        // Executar a função e obter o resultado
                        int result = (int)command.ExecuteScalar();

                        if (result == 1)
                        {
                            MessageBox.Show("Login de administrador bem-sucedido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Credenciais inválidas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Acesso_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
    

   
           
        
    

