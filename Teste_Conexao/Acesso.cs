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
            string connectionString = @"Data Source=WESLEY\SQLEXPRESS;Initial Catalog=BD_DESKTOP;Integrated Security=True;";

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
                            this.Visible = false;
                        }
                        else if (tipoUsuario == "Funcionario")
                        {
                            // Abra o formulário de funcionário
                            Funcionario form = new Funcionario(); // Suponha que você tenha um formulário chamado 'FuncionarioForm'
                            form.Show();
                            this.Visible = false;
                        }
                        

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
            txtUsuario.Text = "Nome:"; // Texto inicial do placeholder
            txtUsuario.ForeColor = Color.Gray; // Cor cinza para o placeholder
            txtSenha.Text = "Senha:"; // Texto inicial do placeholder
            txtSenha.ForeColor = Color.Gray; // Cor cinza
            txtSenha.UseSystemPasswordChar = true; // Certifica-se de que o modo senha está desativado

         


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            System.Drawing.Drawing2D.LinearGradientBrush gradientBrush =
                new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle,
                System.Drawing.Color.FromArgb(34, 139, 34), // Verde mais claro
                System.Drawing.Color.FromArgb(34, 139, 34),  // Verde mais claro
                System.Drawing.Drawing2D.LinearGradientMode.Horizontal);

            e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Cadastro form = new Cadastro();
            form.Show();
            this.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnentra_Click(object sender, EventArgs e)
        {
            // Defina a string de conexão
            string connectionString = @"Data Source=WESLEY\SQLEXPRESS;Initial Catalog=BD_DESKTOP;Integrated Security=True;";

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
                            Administrador adminForm = new Administrador();  // Suponha que você tenha um formulário chamado 'AdminForm'
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

       

        private void txtUsuario_MouseEnter(object sender, EventArgs e)
        {
            // Verifica se o texto atual é o placeholder
            if (txtUsuario.Text == "Nome:")
            {
                txtUsuario.Text = ""; // Limpa o texto
                txtUsuario.ForeColor = Color.Black; // Muda a cor para texto real
            }
        }

        private void txtUsuario_MouseLeave(object sender, EventArgs e)
        {
            // Verifica se o campo ficou vazio
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                txtUsuario.Text = "Nome:"; // Restaura o placeholder
                txtUsuario.ForeColor = Color.Gray; // Muda a cor para cinza
            }
        }

        private void txtSenha_MouseEnter(object sender, EventArgs e)
        {
           
            if (txtSenha.Text == "Senha:")
            {
                txtSenha.Text = ""; // Limpa o texto
                txtSenha.ForeColor = Color.Black; // Muda para a cor padrão do texto
                txtSenha.UseSystemPasswordChar = false; // Ativa o modo senha (*)
            }
        }

        private void txtSenha_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                txtSenha.UseSystemPasswordChar = true; // Desativa o modo senha
                txtSenha.Text = "Senha:"; // Restaura o placeholder
                txtSenha.ForeColor = Color.Gray; // Muda para a cor cinza
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    

   
           
        
    

