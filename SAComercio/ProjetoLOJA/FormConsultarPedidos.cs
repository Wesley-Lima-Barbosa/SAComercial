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
    public partial class FormConsultarPedidos : Form
    {
        public FormConsultarPedidos()
        {
            InitializeComponent();
        }

        public static long textoid;
        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            ProjetoMercado2Entities banco = new ProjetoMercado2Entities();

            dgvPedidos.DataSource = (from pedido in banco.Pedidos
                                     where (pedido.Data + " " + pedido.CodigoFuncionario).Contains(txtConsultar.Text)
                                     select new
                                     {
                                         ID = pedido.ID,
                                         Data = pedido.Data,
                                         Funcionário = pedido.Funcionario.Nome + " " + pedido.Funcionario.Sobrenome,
                                         
                                     }).ToList();
            dgvPedidos.AutoResizeColumn(0);
        }
        public DataGridViewCellEventArgs CelulaClicada { get; set; }

 

        private void TxtConsultar_TextChanged(object sender, EventArgs e)
        {
            BtnConsultar_Click(sender, e);

        }

        private void DgvPedidos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            CelulaClicada = e;

        }

        private void DgvPedidos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            string texto = dgvPedidos.Rows[CelulaClicada.RowIndex].Cells["ID"].Value.ToString();
            textoid = Convert.ToInt64(texto);

            InformaçoesPedido form = new InformaçoesPedido();

            form.Show();
        }
       // public EventHandler habilitarconsultarpedidos { get; set; }

        private void FormConsultarPedidos_FormClosing(object sender, FormClosingEventArgs e)
        {
       //     habilitarconsultarpedidos.Invoke(sender, e);

        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show(
                "Você tem certeza que deseja sair da página de Consultar Pedidos?", "Cancelar Saída",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Close();


            }
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
