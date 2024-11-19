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
using System.Windows.Forms.DataVisualization.Charting;

namespace Teste_Conexao
{
    public partial class Relatórioadm : Form
    {
        public Relatórioadm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarDadosPedidos();
            string connectionString = "Data Source=wesley\\sqlexpress;Initial Catalog=BD_DESKTOP;Integrated Security=True";
           
            string query = "SELECT TipoVenda, Quantidade, Faturamento FROM Vendas";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Configurando o gráfico
                chart1.Series.Clear();
                chart1.Titles.Add("Vendas do Dia");

                Series series = chart1.Series.Add("Vendas");
                series.ChartType = SeriesChartType.Pie; // Tipo do gráfico (pizza)

                foreach (DataRow row in dataTable.Rows)
                {
                    string tipoVenda = row["TipoVenda"].ToString();
                    int quantidade = Convert.ToInt32(row["Quantidade"]);
                    series.Points.AddXY(tipoVenda, quantidade);
                }
            }
        }

        private void CarregarDadosPedidos()
        {
            string connectionString = "Data Source=wesley\\sqlexpress;Initial Catalog=BD_DESKTOP;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT PedidoID, Cliente, EnderecoEntrega, Hora, Saida, Situacao FROM Pedidos";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable tabelaPedidos = new DataTable();
                    adapter.Fill(tabelaPedidos);
                    dataGridView1.DataSource = tabelaPedidos; // Exibe os dados no DataGridView
                    dataGridView1.Columns["PedidoID"].Visible = false; // Oculta o PedidoID
                    dataGridView1.Columns["EnderecoEntrega"].Width = 200; // Define largura personalizada

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
            dataGridView1.Columns["PedidoID"].Visible = false; // Oculta o PedidoID
            dataGridView1.Columns["EnderecoEntrega"].Width = 200; // Define largura personalizada

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string connectionString = "WESLEY\\SQLEXPRESS";
            string query = "SELECT TipoVenda, Quantidade, Faturamento FROM Vendas";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Assumindo que seu DataGridView se chama dataGridView1
                dataGridView1.DataSource = dataTable;
            }
        }

        private void btnBuscarPedido_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=WESLEY\SQLEXPRESS;Database=BD_DESKTOP;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir conexão
                    connection.Open();

                    string sqlQuery;

                    // Se o campo de busca estiver vazio, exibe todos os pedidos
                    if (string.IsNullOrEmpty(txtBuscarpedido.Text))
                    {
                        sqlQuery = "SELECT * FROM Pedidos";  // Busca todos os registros
                    }
                    else
                    {
                        sqlQuery = "SELECT * FROM Pedidos WHERE Cliente = @Cliente";  // Busca pelo cliente específico
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(sqlQuery, connection))
                    {
                        // Se houver um valor no campo de busca, adiciona o parâmetro
                        if (!string.IsNullOrEmpty(txtBuscarpedido.Text))
                        {
                            da.SelectCommand.Parameters.AddWithValue("@Cliente", txtBuscarpedido.Text);
                        }

                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);  // Preenche o DataTable com os dados da consulta
                            dataGridView1.DataSource = dt;  // Exibe os resultados no DataGridView
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao buscar Pedido: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string connectionString = "WESLEY\\SQLEXPRESS";
            string query = "SELECT TipoVenda, Quantidade, Faturamento FROM Vendas";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Assumindo que seu DataGridView se chama dataGridView1
                dataGridView1.DataSource = dataTable;
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
