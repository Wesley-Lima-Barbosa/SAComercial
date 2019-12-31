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
    public partial class FormProdutos : Form
    {
        public FormProdutos()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (idalt == 0)
            {
                bool all = false;
                ProjetoMercado2Entities banco = new ProjetoMercado2Entities();

                Produto produto = new Produto();
                Produto verificacao = banco.Produtos.FirstOrDefault(x => x.Codigo == maskedTextBox2.Text);
                if (verificacao != null)
                {
                    if (verificacao.Desativado == true)
                    {
                        Produto produtos = verificacao;
                        produtos.Nome = txtNome.Text;
                        produtos.Marca = txtMarca.Text;
                        produtos.Preço = Convert.ToDecimal(txtPreco.Text);
                        produtos.Codigo = maskedTextBox2.Text;
                        produtos.Desativado = false;
                        banco.SaveChanges();
                    }
                    else
                    {

                        MessageBox.Show("Já existe um produto com esse código!");
                    }
                    if (!string.IsNullOrWhiteSpace(txtNome.Text))
                    {
                        produto.Nome = txtNome.Text;
                        lblNome.ForeColor = Color.Black;
                    }
                    else
                    {
                        all = true;
                        lblNome.ForeColor = Color.Red;
                    }

                    if (!string.IsNullOrWhiteSpace(txtMarca.Text))
                    {
                        produto.Marca = txtMarca.Text;
                        lblMarca.ForeColor = Color.Black;
                    }
                    else
                    {
                        all = true;
                        lblMarca.ForeColor = Color.Red;
                    }
                    if (!string.IsNullOrWhiteSpace(txtPreco.Text))
                    {
                        produto.Preço = Convert.ToDecimal(txtPreco.Text);
                        lblPreco.ForeColor = Color.Black;
                    }
                    else
                    {
                        all = true;
                        lblPreco.ForeColor = Color.Red;
                    }
                    if (!string.IsNullOrWhiteSpace(maskedTextBox2.Text.Replace(",", "").Replace("-", "")) && maskedTextBox2.TextLength == 13)
                    {
                        produto.Codigo = maskedTextBox2.Text;
                        lblCodigo.ForeColor = Color.Black;
                    }
                    else
                    {
                        all = true;
                        lblCodigo.ForeColor = Color.Red;
                    }


                }
                else
                {
                    Produto produtos = new Produto();
                    produtos.Nome = txtNome.Text;
                    produtos.Marca = txtMarca.Text;
                    produtos.Preço = Convert.ToDecimal(txtPreco.Text.Replace("R", "").Replace("$", ""));
                    produtos.Codigo = maskedTextBox2.Text;
                    produtos.Desativado = false;
                    banco.Produtos.Add(produtos);
                    banco.SaveChanges();
                    MessageBox.Show("O Produto " + txtNome.Text + " foi cadastrado!");
                }
            }
            else
            {
                ProjetoMercado2Entities banco = new ProjetoMercado2Entities();
                Produto produtos = banco.Produtos.Find(idalt);
                produtos.Nome = txtNome.Text;
                produtos.Marca = txtMarca.Text;
                produtos.Preço = Convert.ToDecimal(txtPreco.Text);
                produtos.Codigo = maskedTextBox2.Text;
                banco.SaveChanges();
            }
        }
            public long idalt { get; set; }
        public void PrencherAlteracao(Produto produto)
        {
            txtNome.Text = produto.Nome;
            txtMarca.Text = produto.Marca;
            txtPreco.Text = Convert.ToString(produto.Preço);
            maskedTextBox2.Text = produto.Codigo;
        }

        private void txtPreco_Leave(object sender, EventArgs e)
        {


            decimal value;
            if (decimal.TryParse(txtPreco.Text, out value))
            {
                txtPreco.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", value);
            }
            else
            {
                txtPreco.Text = string.Empty;

            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show(
                "Você tem certeza que deseja sair do Cadastro de Produtos?", "Cancelar Saída",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Close();


            }
        }

        
    } }
        
        


