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
    public partial class FormPedidos : Form
    {
        public FormPedidos()
        {
            InitializeComponent();
        }

        bool tempedido = false;
        long idpedido;
        decimal preço;
        bool salvarpedido;
        bool quantidade;
        long quant = 1;
        string CPF;
        bool firstcliente;

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {


            Models.VerificarProduto verificar = new Models.VerificarProduto();

            
                if ((Keys)e.KeyValue == Keys.Enter && lblcodigo.Text == "CPF do Cliente")

                {
                    if (string.IsNullOrWhiteSpace(txtCodigo.Text))
                    {
                        lblcodigo.Text = "Código do Produto";
                        txtCodigo.MaxLength = 13;
                        firstcliente = true;
                    }
                    else
                    {
                        if (!VerificarCPF.IsValid(txtCodigo.Text))
                        {
                            MessageBox.Show("Digite um CPF valido");
                        }
                        else
                        {
                            ProjetoMercado2Entities banco = new ProjetoMercado2Entities();
                            Cliente cliente = banco.Clientes.FirstOrDefault(x => x.CPF == txtCodigo.Text);
                            if (txtCodigo.Text.Length == 11 && cliente != null)
                            {
                                CPF = txtCodigo.Text;
                                lblcodigo.Text = "Código do Produto";
                                txtCodigo.MaxLength = 13;
                                txtCodigo.Text = string.Empty;
                            }
                            else
                            {
                                if (cliente == null)
                                {
                                    DialogResult dialogResult;

                                    dialogResult = MessageBox.Show("Não existe um cliente com esse CPF.", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        FormCliente form = new FormCliente();
                                        form.mskCPF.Text = txtCodigo.Text;
                                        form.ShowDialog();
                                    }

                                }
                            }
                        }
                    }
                }




                if ((Keys)e.KeyValue == Keys.Enter && quantidade == false && lblcodigo.Text != "CPF do Cliente")
                {



                    if (tempedido == false)
                    {
                        //Inicia um novo pedido
                        ProjetoMercado2Entities banco = new ProjetoMercado2Entities();
                        Pedido pedido = new Pedido();
                        pedido.Data = DateTime.Now;
                        pedido.CodigoFuncionario = FormLogin.idfuncionario;
                        if (!string.IsNullOrEmpty(CPF))
                        {
                            Cliente cliente = banco.Clientes.FirstOrDefault(x => x.CPF == CPF);
                            pedido.Cliente = cliente;

                        }



                        banco.Pedidos.Add(pedido);
                        banco.SaveChanges();
                        tempedido = true;
                        idpedido = pedido.ID;
                        preço = 0;
                        txtCodigo.MaxLength = 13;




                    }


                    bool produto = verificar.ProdutoExiste(txtCodigo.Text);
                    if (lblcodigo.Text == "Código do Produto" && firstcliente != true)
                    {
                        if (produto == true)
                        {
                            Models.CompraProdutos Pedido = new Models.CompraProdutos();

                            Pedido.AdicionarProduto(txtCodigo.Text, idpedido, quant);

                            preço = preço + (Pedido.Preco * Pedido.Quantidade);
                            txtCodigo.Text = "";

                            lblProduto.Text = "Produto: \r\n" + Pedido.Nome;
                            lblPreco.Text = "Preço: \r\n" + preço.ToString("c2");

                            lblQuantidade.Text = "Quantidade: \r\n " + Pedido.Quantidade;
                            attdgv();
                            quant = 1;
                        }
                        else
                        {
                            MessageBox.Show("Não existe produto com esse código.");
                        }
                    }
                    firstcliente = false;
                }

                if ((Keys)e.KeyValue == Keys.F1)
                {
                    btnfinalizar.PerformClick();
                }

                if ((Keys)e.KeyValue == Keys.F10)
                {
                    btncancelar.PerformClick();
                }


                if ((Keys)e.KeyValue == Keys.Enter && quantidade == true)
                {


                    quant = Convert.ToInt64(txtCodigo.Text);
                    lblcodigo.Text = "Código do Produto";
                    quantidade = false;
                    txtCodigo.Text = string.Empty;


                }


            }



            private void FormPedidos_Load(object sender, EventArgs e)
            {
                KeyPreview = true;
                lblData.Text = "Data: " + DateTime.Now.ToString("dd/MM/yyyy");
                lblcodigo.Text = "CPF do Cliente";
                txtCodigo.MaxLength = 11;
                dataGridView1.GridColor = Color.Black;
            }

            private void attdgv()
            {
                ProjetoMercado2Entities banco = new ProjetoMercado2Entities();
                var query = (from itens in banco.ItensPedidos
                             where (itens.Códigopedido == idpedido)
                             select new
                             {
                                 ID = itens.ID,
                                 Nome = itens.Produto1.Nome,
                                 Preço = itens.Produto1.Preço,
                                 Quantidade = itens.Quantidade,
                             }).ToList();

                dataGridView1.DataSource = (from itens in query.AsEnumerable()
                                            select new
                                            {
                                                ID = itens.ID,
                                                Nome = itens.Nome,
                                                Preço = itens.Preço.ToString("c2"),
                                                Quantidade = itens.Quantidade

                                            }
                     ).ToList();
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.ClearSelection();
                dataGridView1.Columns[0].Width = 350;
            }
            private void naosalvar()
            {
                if (tempedido == true)
                {
                    ProjetoMercado2Entities banco = new ProjetoMercado2Entities();
                    Pedido pedido = banco.Pedidos.Find(idpedido);
                    banco.Pedidos.Remove(pedido);
                    List<ItensPedido> itensPedidos = new List<ItensPedido>();
                    foreach (ItensPedido item in banco.ItensPedidos.Where(x => x.Códigopedido == idpedido))
                    {
                        itensPedidos.Add(item);
                    }

                    banco.ItensPedidos.RemoveRange(itensPedidos);
                    banco.SaveChanges();
                }
                MessageBox.Show("Pedido não salvo!");
                Close();
            }
        public EventHandler habilitarBotao { get; set; }

        private void FormPedidos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (habilitarBotao != null)
                habilitarBotao.Invoke(sender, e);

        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8)
            {
                if (e.KeyChar < 48 | e.KeyChar > 57)
                {
                    e.Handled = true;
                }
            }
        }

        private void FormPedidos_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyValue == Keys.Q)
            {
                btnquant.PerformClick();
            }
            if ((Keys)e.KeyValue == Keys.C)
            {
                btncliente.PerformClick();
            }
            if ((Keys)e.KeyValue == Keys.Delete)
            {
                btndel.PerformClick();
            }

        }

        private void btnfinalizar_Click(object sender, EventArgs e)
        {
            if (tempedido == true)
            {
                DialogResult dialogResult;
                dialogResult = MessageBox.Show("Você tem certeza que quer finalizar o pedido",
                    "Finalizar Pedido",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    salvarpedido = true;
                    MessageBox.Show("Pedido salvo com sucesso!");
                    Close();

                }
            }
            else
            {
                MessageBox.Show("Não existe um pedido neste momento!");
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show(
                "Você tem certeza que deseja cancelar este pedido?",
                "Cancelar Pedido",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {

                salvarpedido = false;
                naosalvar();

            }
        }

        private void btnquant_Click(object sender, EventArgs e)
        {
            lblcodigo.Text = "Quantidade:";
            quantidade = true;
        }

        private void btncliente_Click(object sender, EventArgs e)
        {
            lblcodigo.Text = "CPF do Cliente";
            txtCodigo.MaxLength = 11;
            txtCodigo.Text = CPF;
            quantidade = false;
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show(
                "Você tem certeza que deseja deletar este item do pedido?",
                "Deletar item",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                ProjetoMercado2Entities banco = new ProjetoMercado2Entities();
                foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                {
                    string textoid = item.Cells[0].Value.ToString();
                    int id = int.Parse(textoid);
                    ItensPedido itens = banco.ItensPedidos.FirstOrDefault(x => x.ID == id);
                    banco.ItensPedidos.Remove(itens);
                    banco.SaveChanges();
                    attdgv();
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblPreco_Click(object sender, EventArgs e)
        {

        }
    }
}