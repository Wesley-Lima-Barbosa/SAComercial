using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoLOJA
{
    public partial class FormMenu : FormModelo
    {
        public FormMenu()
        {
            InitializeComponent();
        }
        Models.Abrirform abrir = new Models.Abrirform();
        public static bool closedpedidos = true;

        private void abrirform(Form form)
        {
           
           
            // form.WindowState = FormWindowState.Maximized;
            //form.ControlBox = false;
            form.ShowDialog();
        }
        private void abrirformdialog(Form form)
        {
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.ControlBox = false;
            form.ShowDialog();
        }

        

        public void novoPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            FormPedidos form = new FormPedidos();
            item = novoPedidoToolStripMenuItem;
            form.ControlBox = false;
            form.habilitarBotao += habilitarBotao;
            
            form.MdiParent = this;
            novoPedidoToolStripMenuItem.Enabled = false;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
           

        }

        private ToolStripMenuItem item { get; set; }

        private void habilitarBotao(object sender, EventArgs e)
        {
            if (sender != null)
            {
                item.Enabled = true;
            }
        }

        private void consultarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormConsultarPedidos form = new FormConsultarPedidos();
            //form.habilitarconsultarpedidos += habilitarBotao;
            abrirform(form);

            //  consultarPedidoToolStripMenuItem.Enabled = false;
        }

        private void cadastrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Cliente = new FormCliente();
            abrirform(Cliente);
            //    cadastrarClienteToolStripMenuItem.Enabled = false;

        }

        private void consultarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  consultarClienteToolStripMenuItem.Enabled = false;

            abrirform(new FormConsultarClientes());
        }

        private void cadastrarFuncionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //   cadastrarFuncionáriosToolStripMenuItem.Enabled = false;

            abrirform(new FormFuncionarios());
        }

        private void consultarFuncionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // consultarFuncionáriosToolStripMenuItem.Enabled = false;

            abrirform(new FormConsultarFuncionarios());
        }

        private void caToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //   caToolStripMenuItem.Enabled = false;

            abrirform(new FormProdutos());
        }

        private void consuiltarProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //   consuiltarProdutosToolStripMenuItem.Enabled = false;

            abrirform(new FormConsultarProdutos());
        }





        private void sairToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormLogin.isclosed = true;
            Close();
        }

        private void FormMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyValue == Keys.N)
            {
                novoPedidoToolStripMenuItem.PerformClick();
            }
        }

        private void opçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

            foreach (Control c in this.Controls)
            {
                if (c is MdiClient)
                    c.BackColor = this.BackColor;
            }
        }
    }


}
