using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teste_Conexao
{
    public partial class Funcionario : Form
    {
        private string versaoAtual = "1.0.0"; // Versão atual do sistema.
        private string novaVersaoDisponivel = "1.1.0"; // Versão nova simulada.

        public Funcionario()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            estoque form = new estoque();
            form.Show();
            this.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Pedidos  form = new Pedidos();
            form.Show();
            this.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Relatórioadm form = new Relatórioadm();
            form.Show();
            this.Visible = false;

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void VerificarNovaAtualizacao()
        {
            if (novaVersaoDisponivel != versaoAtual) // Simula a checagem da nova versão.
            {
                // Exibe uma mensagem para o usuário.
                var resultado = MessageBox.Show(
                    $"Nova atualização disponível! Versão: {novaVersaoDisponivel}\n" +
                    "Deseja atualizar agora?",
                    "Atualização Disponível",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Simula o processo de atualização.
                    IniciarAtualizacao();
                }
                else
                {
                    MessageBox.Show("A atualização foi adiada. Você pode atualizá-la mais tarde.",
                                    "Atualização Adiada",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
        }
        private void IniciarAtualizacao()
        {
            // Simula a atualização com uma barra de progresso.
            progressBarAtualizacao.Value = 0;
            progressBarAtualizacao.Visible = true;

            for (int i = 0; i <= 100; i += 10)
            {
                System.Threading.Thread.Sleep(100); // Simula tempo de processamento.
                progressBarAtualizacao.Value = i;
            }

            // Atualiza a versão após completar a "atualização".
            versaoAtual = novaVersaoDisponivel;
            lblVersaoSistema.Text = $"Versão atual: {versaoAtual}";

            MessageBox.Show("Atualização concluída com sucesso!",
                            "Atualização Finalizada",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            progressBarAtualizacao.Visible = false;
        }
        private void btnatualização_Click(object sender, EventArgs e)
        {
            VerificarNovaAtualizacao();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Acesso form = new Acesso();
            form.Show();
            this.Visible = false;
        }
    }
}
