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

            //criar uma conexao
            conexao = clnConexao.getConexao();
            //criar um objeto Funcionario 
            Model.Funcionario func = new Model.Funcionario();
            // popular comos dados do  formulário
            func.NomeFunc = txtNome.Text;
            func.RgFunc = txtRg.Text;
            func.CpfFunc = txtCpf.Text;
            func.NomeUser = txtUsuario.Text;
            func.SenhaUser = txtSenha.Text;

            //criar um objeto FuncionarioDAL 
            FuncionarioDAL funcDal = new FuncionarioDAL();
            //e executar a inserção
            try
            {
                //abrir a conexao
                funcDal.abrirConexao(conexao);
                //executar o insert
                funcDal.adicionar(conexao, func);

                MessageBox.Show("Criado usuario com sucesso!");
                btnLimpar.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha: " + ex.Message);
            }
            Home frm1 = new Home();
            frm1.Show();
            this.Close();

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtCpf.Clear();
            txtRg.Clear();
            txtSenha.Clear();
            txtUsuario.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //criar uma conexao
            conexao = clnConexao.getConexao();
            //criar um objeto Funcionario 
            Model.Funcionario func = new Model.Funcionario();
            // popular comos dados do  formulário
            func.NomeFunc = txtNome.Text;
            func.RgFunc = txtRg.Text;
            func.CpfFunc = txtCpf.Text;
            func.NomeUser = txtUsuario.Text;
            func.SenhaUser = txtSenha.Text;

            //criar um objeto FuncionarioDAL 
            FuncionarioDAL funcDal = new FuncionarioDAL();
            //e executar a inserção
            try
            {
                //abrir a conexao
                funcDal.abrirConexao(conexao);
                //executar o insert
                funcDal.adicionar(conexao, func);

                MessageBox.Show("Criado usuario com sucesso!");
                btnLimpar.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha: " + ex.Message);
            }
            Home frm1 = new Home();
            frm1.Show();
            this.Close();




        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            Administrador obj01 = new Administrador();
            obj01.ShowDialog();

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

             //criar uma conexao
            conexao = clnConexao.getConexao();
            int matr = 0;
            try
            {
                //recuperar o id(matricula) do Form(textBox)
                matr = Convert.ToInt32(txtMatricula.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao converter! " +
                    "Digite somente números" + ex.Message);
            }
            //criar um objeto Funcionario 
            Model.Funcionario func = new Model.Funcionario();
            func.IdFunc = matr;
            // popular comos dados do  formulário
            func.NomeFunc = txtNome.Text;
            func.RgFunc = txtRg.Text;
            func.CpfFunc = txtCpf.Text;
            func.NomeUser = txtUsuario.Text;
            func.SenhaUser = txtSenha.Text;

            //criar um objeto FuncionarioDAL 
            FuncionarioDAL funcDal = new FuncionarioDAL();
            //e executar a inserção
            try
            {
                //abrir a conexao
                funcDal.abrirConexao(conexao);
                //executar o insert
                funcDal.alterar(conexao, func);

                MessageBox.Show("Dados alterados com sucesso!");
                btnLimpar.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha: " + ex.Message);
            }


        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMatricula.Text, out int idFunc))
            {
                MessageBox.Show("Por favor, insira um número válido na matrícula.");
                return;
            }

            try
            {
                string strConexao = @"Server=WESLEY\SQLEXPRESS;Database=BD_DESKTOP;Integrated Security=True";
                string cmdDelete = "DELETE FROM funcionarios WHERE id_func = @idFunc";

                using (SqlConnection con = new SqlConnection(strConexao))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(cmdDelete, con))
                    {
                        sqlCommand.Parameters.AddWithValue("@idFunc", idFunc);
                        con.Open();
                        int rowsAffected = sqlCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Funcionário excluído com sucesso!");
                            btnLimpar.PerformClick(); // Limpar os campos
                        }
                        else
                        {
                            MessageBox.Show("Funcionário não encontrado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir o funcionário: {ex.Message}");
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

