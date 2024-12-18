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
    public partial class estoqueFuncionario : Form
    {
        public estoqueFuncionario()
        {
            InitializeComponent();
        }

        private void btnbuscarproduto_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=WESLEY\SQLEXPRESS;Database=BD_DESKTOP;Integrated Security=True;";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir conexão
                    connection.Open();

                    var sqlQuery = "SELECT *FROM Produtos where CodigoBarras = '" + txtBuscarProduto.Text + "'";
                    using (SqlDataAdapter da = new SqlDataAdapter(sqlQuery, connection))
                    {

                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao buscar produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Funcionario form = new  Funcionario();
            form.Show();
            this.Visible = false;
        }

        private void estoqueFuncionario_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Funcionario form = new Funcionario();
            form.Show();
            this.Visible = false;
        }
    }
}
