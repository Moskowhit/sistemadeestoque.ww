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
using DAL;
using Model;

namespace Teste_Conexao
{
    public partial class Administrador : Form
    {
        SqlConnection conexao;
        public Administrador()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //criar uma conexao
            conexao = clnConexao.getConexao();
            int cod = 0;
            try
            {
                //recuperar o id(matricula) do Form(textBox)
                cod = Convert.ToInt32(button1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao converter! " +
                    "Digite somente números" + ex.Message);
            }
            //criar um objeto Produto
            Produto prod = new Produto();
            //adicionar o id(matricula) recuperado
            prod.Codbar_prod = cod;
            //criar um objeto FuncionarioDAL
            ProdutoDAL prodDAL = new ProdutoDAL();
            try
            {   //funcDAL --> abrir a conexao
                prodDAL.abrirConexao(conexao);
                //funcDAL --> realizar a pesquisa
                prod = prodDAL.pesquisarProd(conexao, prod);
                //popular o objeto funcionario e preencher os textbox 
                //correspondentes
                //        txtNome.Text = prod.NomeProd;
                //        cmbMarca.Text = prod.Categoria;
                //            txtPreco.Text = Convert.ToDouble (prod.Preco).ToString ();
                //        cmbMedida.Text = prod.Medida;
                //        txtQuant.Text = Convert.ToInt32( prod.Quant).ToString ();
            }
            catch (Exception ex)
            {//mensagem de funcionario nao encontrado
                MessageBox.Show("Produto não encontrado! Erro: "
                    + ex.Message);
            }
            finally
            {//funcDAL -->fechar a conexao
                prodDAL.fecharConexao(conexao);
            }

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
          
            //criar uma conexao
            conexao = clnConexao.getConexao();
            //criar um objeto Funcionario 
            Produto prod = new Produto();
            // popular comos dados do  formulário
            //      prod.NomeProd = txtNome.Text;
            //     prod.Categoria = cmbMarca.Text;
            //      prod.Preco = Convert.ToDouble (txtPreco.Text);
            //     prod.Medida = cmbMedida.Text;
            //    prod.Quant = Convert.ToInt32 ((txtQuant.Text).ToString());

            //criar um objeto FuncionarioDAL 
            ProdutoDAL prodDal = new ProdutoDAL();
            //e executar a inserção
            try
            {
                //abrir a conexao
                prodDal.abrirConexao(conexao);
                //executar o insert
                prodDal.adicionar(conexao, prod);

                MessageBox.Show("Dados salvos com sucesso!");
                //       btnLimpar.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha: " + ex.Message);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            //criar uma conexao
            conexao = clnConexao.getConexao();
            int codBarras = 0;
            try
            {
                //recuperar o id(matricula) do Form(textBox)
                //            codBarras = Convert.ToInt32(txtcodBarras.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao converter! " +
                    "Digite somente números" + ex.Message);
            }
            //criar um objeto Produto 
            Produto prod = new Produto();
            prod.Codbar_prod = codBarras;
            // popular comos dados do  formulário
            //          prod.NomeProd = txtNome.Text;
            //          prod.Categoria = cmbMarca.Text;
            //         prod.Preco = Convert.ToDouble (txtPreco.Text );
            //         prod.Medida = cmbMedida.Text;
            //         prod.Quant = Convert.ToInt32 (txtQuant.Text);

            //criar um objeto ProdutoDAL  
            ProdutoDAL ProdDal = new ProdutoDAL();
            //e executar a inserção
            try
            {
                //abrir a conexao
                ProdDal.abrirConexao(conexao);
                //executar o insert
                ProdDal.alterar(conexao, prod);

                MessageBox.Show("Dados salvos com sucesso!");
                //            btnLimpar.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha: " + ex.Message);
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {


            DialogResult resultado = MessageBox.Show("Deseja excluir?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (resultado == DialogResult.OK)
            {
                //String de conexão com o banco de dados
                string strConexao = @"Server=WESLEY\SQLEXPRESS;
 Database=BD_DESKTOP;Integrated Security = True";
                //   string cmdDelete =
                //     "DELETE produto where codbar_prod=" + txtcodBarras.Text;
                //   SqlConnection con = new SqlConnection(strConexao);
                //  SqlCommand sqlCommand = new SqlCommand(cmdDelete, con);
                //  con.Open();
                //   sqlCommand.ExecuteNonQuery();
                //    MessageBox.Show("Dados excluidos com sucesso!");
                //    btnLimpar.PerformClick();
                //    con.Close();
                /*int codProd = 0;
                //recuperar o id(matricula) do Form(textBox)
                codProd = Convert.ToInt32(txtMatricula.Text);
                MessageBox.Show("excluir...");
                //criar uma conexao
                conexao = clnConexao.getConexao();
                Produto prod = new Produto();
         
                //criar um objeto ProdutoDAL 
                ProdutoDAL prodDal = new ProdutoDAL();

                //e executar a inserção
                try
                {
                    //abrir a conexao
                    prodDal.abrirConexao(conexao);
                    //executar o delete
                    prodDal.DelProd(conexao, prod);

                    MessageBox.Show("Dados excluidos com sucesso!");
                    btnLimpar.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha: " + ex.Message);
                }
            }*/
            }
            else
            {
                MessageBox.Show("Cancelar...");

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

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcodBarras_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblBusca_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            estoque form = new estoque();
            form.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }



        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ProdutosAdm form = new ProdutosAdm();
            form.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
           Pedidos form = new Pedidos();
            form.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClientesAdm form = new ClientesAdm();
            form.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FornecedoresAdm form = new FornecedoresAdm();
            form.Show();
            this.Close();
        }

        private void pnlBusca_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
