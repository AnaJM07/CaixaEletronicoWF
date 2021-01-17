using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFCaixaEletronico
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            bool isvalid = true;
            int valor;
            int c100 = 0;
            int c50 = 0;
            int c20 = 0;
            int c10 = 0;

            valor = String.IsNullOrEmpty(txtValor1.Text) ? 0 : Convert.ToInt32(txtValor1.Text);
            if (valor == 0 )
            {
                MessageBox.Show("Valor Invalido");
                isvalid = false;
                return;
            }
            while (valor > 0)
            {
                if (valor >= 100)
                {
                    valor -= 100;
                    c100++;
                }
                else if (valor >= 50)
                {
                    valor -= 50;
                    c50++;
                }
                else if (valor >= 20)
                {
                    valor -= 20;
                    c20++;
                }
                else if (valor >= 10)
                {
                    valor -= 10;
                    c10++;
                }
                else
                {
                    MessageBox.Show("Valor Invalido");
                    isvalid = false;
                    break;
                }
            }
            if (isvalid == true)
            {
                txtNotas.Text = $"Foram utilizadas: {c100} - Notas de 100," +
                    $" {c50} - Notas de 50, {c20} " +
                    $"- Notas de 20," +
                    $" {c10} - Notas de 10";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtNotas.Clear();
            txtValor1.Clear();
        }

        private void txtValor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }
    }
}
