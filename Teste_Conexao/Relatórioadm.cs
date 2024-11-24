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
using System.Drawing.Printing;

namespace Teste_Conexao
{
    public partial class Relatórioadm : Form
    {

        private string connectionString = @"Server=wesley\sqlexpress;Database=BD_DESKTOP;Trusted_Connection=True;";
        private PrintDocument printDocument2 = new PrintDocument();
        private string documentTitle = "Relatório de Dados"; // Título do relatório
        private DataGridView dataGridViewToPrint;
        public Relatórioadm()
        {
            InitializeComponent();
            printDocument2.PrintPage += new PrintPageEventHandler(PrintDocument2_PrintPage);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarDados();
            CarregarDadosPedidos();
            CarregarDadoos();


        }
        private void CarregarDados()
        {
            try
            {
                // Conexão com o banco de dados
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Pedido, Quantidade, Faturamento FROM Vendas";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    // Preenche o DataTable com os dados
                    da.Fill(dt);

                    // Adiciona uma nova coluna ao DataTable para o Total
                    dt.Columns.Add("Faturamento Total", typeof(decimal));

                    // Calcula os valores e preenche a nova coluna
                    foreach (DataRow row in dt.Rows)
                    {
                        int quantidade = Convert.ToInt32(row["Quantidade"]);
                        decimal faturamento = Convert.ToDecimal(row["Faturamento"]);

                        // Calcula o faturamento total para a linha atual
                        row["Faturamento Total"] = quantidade * faturamento;
                    }

                    // Exibe os dados no DataGridView
                    dataGridView2.DataSource = dt;

                    // Calcula os totais gerais
                    int totalQtd = 0;
                    decimal totalFat = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        totalQtd += Convert.ToInt32(row["Quantidade"]);
                        totalFat += Convert.ToDecimal(row["Faturamento Total"]);
                    }

                   // Exibe os totais nas labels
                    lblTotalQtd.Text = $"Total: {totalQtd}";
                    lblTotalFat.Text = $"R$ {totalFat:N2}";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
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
                    dataGridView1.Columns["EnderecoEntrega"].Width = 100; // Define largura personalizada

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
            

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
                dataGridView2.DataSource = dataTable;
            }
        }
       
        private void chart1_Click(object sender, EventArgs e)
        {

        }
        private void CarregarDadoos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Pedido, SUM(Quantidade) AS Quantidade FROM Vendas GROUP BY Pedido";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    // Preencher o DataGridView (se necessário)
                    dataGridView2.DataSource = dt;

                    // Preencher o gráfico de pizza
                    chart1.Series.Clear();
                    Series series = new Series
                    {
                        Name = "Vendas",
                        IsValueShownAsLabel = true,
                        ChartType = SeriesChartType.Pie
                    };

                    chart1.Series.Add(series);

                    foreach (DataRow row in dt.Rows)
                    {
                        string pedido = row["Pedido"].ToString();
                        int quantidade = Convert.ToInt32(row["Quantidade"]);
                        series.Points.AddXY(pedido, quantidade);
                    }
                    chart1.Series["Vendas"].LegendText = "#VALX"; // Exibe o nome do pedido
                    chart1.Series["Vendas"].Label = "#PERCENT";  // Exibe o percentual no gráfico
                    chart1.ChartAreas[0].Area3DStyle.Enable3D = true; // Ativa efeito 3D

                    // Estilizando o DataGridView
                    dataGridView2.BackgroundColor = System.Drawing.Color.White; // Fundo do DataGrid
                    dataGridView2.GridColor = System.Drawing.Color.LightGray; // Cor das linhas de grade
                    dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(60, 120, 180); // Cor do cabeçalho
                    dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White; // Texto do cabeçalho
                    dataGridView2.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold); // Fonte do cabeçalho

                    dataGridView2.DefaultCellStyle.BackColor = System.Drawing.Color.White; // Fundo das células
                    dataGridView2.DefaultCellStyle.ForeColor = System.Drawing.Color.Black; // Cor do texto das células
                    dataGridView2.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10); // Fonte das células
                    dataGridView2.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(230, 240, 250); // Fundo da célula selecionada
                    dataGridView2.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black; // Texto da célula selecionada

                    dataGridView2.EnableHeadersVisualStyles = false; // Desativa o estilo padrão do cabeçalho
                    dataGridView2.BorderStyle = BorderStyle.None; // Remove a borda do DataGridView
                    

                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // Define o DataGridView que será impresso
            dataGridViewToPrint = dataGridView2; // Altere para o nome correto do seu DataGridView

            // Configura a visualização antes da impressão
            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Document = printDocument2;

            // Mostra a janela de visualização
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument2.Print();
            }
        }
        private void PrintDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Configurações iniciais
            int marginLeft = 40; // Margem esquerda
            int marginTop = 60;  // Margem superior
            int cellHeight = 30; // Altura de cada célula
            int currentY = marginTop; // Posição Y atual
            int currentX = marginLeft; // Posição X inicial
            int headerHeight = 40; // Altura do cabeçalho
            Font fontHeader = new Font("Arial", 12, FontStyle.Bold);
            Font fontCell = new Font("Arial", 10, FontStyle.Regular);
            Pen pen = new Pen(Color.Black, 1);

            // Título do relatório
            e.Graphics.DrawString(documentTitle, new Font("Arial", 16, FontStyle.Bold),
                Brushes.Black, marginLeft, currentY);
            currentY += 50; // Move para baixo após o título

            // Desenho do cabeçalho
            foreach (DataGridViewColumn column in dataGridViewToPrint.Columns)
            {
                e.Graphics.FillRectangle(Brushes.LightGray,
                    new Rectangle(currentX, currentY, column.Width, headerHeight));
                e.Graphics.DrawRectangle(pen,
                    new Rectangle(currentX, currentY, column.Width, headerHeight));
                e.Graphics.DrawString(column.HeaderText, fontHeader, Brushes.Black,
                    new RectangleF(currentX, currentY, column.Width, headerHeight));
                currentX += column.Width;
            }

            currentY += headerHeight; // Move para baixo após o cabeçalho

            // Desenho das linhas de dados
            foreach (DataGridViewRow row in dataGridViewToPrint.Rows)
            {
                if (row.IsNewRow) continue; // Ignora a linha vazia no final do DataGridView

                currentX = marginLeft; // Reseta a posição X para a margem esquerda
                foreach (DataGridViewCell cell in row.Cells)
                {
                    string cellValue = cell.Value?.ToString() ?? string.Empty;
                    e.Graphics.DrawRectangle(pen,
                        new Rectangle(currentX, currentY, cell.Size.Width, cellHeight));
                    e.Graphics.DrawString(cellValue, fontCell, Brushes.Black,
                        new RectangleF(currentX, currentY, cell.Size.Width, cellHeight));
                    currentX += cell.Size.Width;
                }

                currentY += cellHeight; // Move para a próxima linha
            }
        }
    }
}
