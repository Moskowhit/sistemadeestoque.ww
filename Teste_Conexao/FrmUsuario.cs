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
    public partial class FrmUsuario : Form
    {

        SqlConnection conexao;

        public FrmUsuario()
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
            Funcionario func = new Funcionario();
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
            catch(Exception ex)
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
            int matr = 0;
            try
            {
                //recuperar o id(matricula) do Form(textBox)
                matr = Convert.ToInt32(txtMatricula.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Falha ao converter! "+
                    "Digite somente números" + ex.Message);
            }
            //criar um objeto Funcionario
            Funcionario func = new Funcionario();
            //adicionar o id(matricula) 
        
            func.IdFunc = matr;
            //criar um objeto FuncionarioDAL
            FuncionarioDAL funcDAL = new FuncionarioDAL();
            try
            {   //funcDAL --> abrir a conexao
                funcDAL.abrirConexao(conexao);
                //funcDAL --> realizar a pesquisa
                func = funcDAL.pesquisarFuncId(conexao, func);
                //popular o objeto funcionario e preencher os textbox 
                //correspondentes
                txtNome.Text = func.NomeFunc;
                txtRg.Text = func.RgFunc;
                txtCpf.Text = func.CpfFunc;
                txtUsuario.Text = func.NomeUser;
                txtSenha.Text = func.SenhaUser;
            }
            catch (Exception ex)
            {//mensagem de funcionario nao encontrado
                MessageBox.Show("Funcionario não encontrado! Erro: "
                    + ex.Message);
            }
            finally
            {//funcDAL -->fechar a conexao
                funcDAL.fecharConexao(conexao);
            }


            



        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            FrmProdutos obj01 = new FrmProdutos();
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
            Funcionario func = new Funcionario();
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



            DialogResult resultado = MessageBox.Show("Deseja excluir?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (resultado == DialogResult.OK)
            {
                //String de conexão com o banco de dados
                string strConexao = @"Server=JOREL\SQLEXPRESS;
 Database=BD_Floricultura;Integrated Security = True";
                string cmdDelete =
                 "DELETE funcionarios where id_func =" + txtMatricula.Text;
                SqlConnection con = new SqlConnection(strConexao);
                SqlCommand sqlCommand = new SqlCommand(cmdDelete, con);
                con.Open();
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Dados excluidos com sucesso!");
                btnLimpar.PerformClick();
                con.Close();


                //dialogresult resultado = messagebox.show("deseja excluir?", "atenção", messageboxbuttons.okcancel, messageboxicon.exclamation);

                //if (resultado == dialogresult.ok)
                //{
                //    messagebox.show("excluir...");
                //    recuperar o id do funcionario

                //    criar uma conexao
                //    conexao = clnconexao.getconexao();
                //    int matr = 0;
                //    try
                //    {
                //        recuperar o id(matricula) do form(textbox)
                //        matr = convert.toint32(txtmatricula.text);
                //    }
                //    catch (exception ex)
                //    {
                //        messagebox.show("falha ao converter! " +
                //            "digite somente números" + ex.message);
                //    }
                //    criar a conexao
                //    criar o objeto funcionario e atribuir o id
                //    criar o objeto funcionariodal
                //    com o funcionariodal
                //    abrir conexao
                //    executar a exclusão
                //    enviar msg informando a exclusão
                //    fechar conexao
                //}
                //else
                //{
                //    messagebox.show("cancelar...");

                //}

            }
        }

            private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
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
    }
}

