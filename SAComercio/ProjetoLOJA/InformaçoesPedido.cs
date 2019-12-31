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
    public partial class InformaçoesPedido : Form
    {
        public InformaçoesPedido()
        {
            InitializeComponent();
        }

        private void labelFuncionario_Click(object sender, EventArgs e)
        {

        }

        private void InformaçoesPedido_Load(object sender, EventArgs e)
        {
            ProjetoMercado2Entities banco = new ProjetoMercado2Entities();

            Pedido pedido = banco.Pedidos.Find(FormConsultarPedidos.textoid);
            dgvInformacoes.DataSource =
                (from itens in banco.ItensPedidos
                 where (itens.Códigopedido == FormConsultarPedidos.textoid)
                 select new
                 {
                     Nome = itens.Produto1.Nome,
                     Preço = itens.Produto1.Preço,
                     Quantidade = 1,
                 }).ToList();

            labelPedido.Text = pedido.ID.ToString();
            if (pedido.Cliente != null)
            {
                labelCliente.Text =  "\r\n"+ pedido.Cliente.Nome + " " + pedido.Cliente.Sobrenome;
            }
            else
            {
                labelCliente.Text = "Cliente Sem Cadastro";
            }

            lblFuncionario.Text = pedido.Funcionario.Nome + " " + pedido.Funcionario.Sobrenome;

           
        }
    }
}
