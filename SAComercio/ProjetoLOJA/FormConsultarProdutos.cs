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
    public partial class FormConsultarProdutos : Form
    {
        public FormConsultarProdutos()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ProjetoMercado2Entities banco = new ProjetoMercado2Entities();

            var query = (from produto in banco.Produtos
                         where (produto.Nome + " " + produto.Marca + " " + produto.Codigo).Contains(txtConsultar.Text) && produto.Desativado == false

                         select new
                         {
                             ID = produto.ID,
                             Preço = produto.Preço,
                             Nome = produto.Nome,
                             Marca = produto.Marca,
                             Código = produto.Codigo

                         }).ToList();

            dgvProdutos.DataSource = (from itens in query.AsEnumerable()
                                      select new
                                      {
                                          Código = itens.Código,
                                          Preço = itens.Preço.ToString("c2"),
                                          Nome = itens.Nome,
                                          Marca = itens.Marca,
                                          

                                      }
                                     ).ToList();
                
        }
        public DataGridViewCellEventArgs celulaClicada { get; set; }

        private void dgvProdutos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            celulaClicada = e;
        }

        private void txtConsultar_TextChanged(object sender, EventArgs e)
        {
            btnConsultar_Click(sender, e);
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string textoID;


            if (celulaClicada != null)
            {

                textoID = dgvProdutos
                    .Rows[celulaClicada.RowIndex]
                    .Cells["Código"].Value.ToString();

                ProjetoMercado2Entities banco = new ProjetoMercado2Entities();


                //        int Id = int.Parse(textoID);


                Produto produtos = banco.Produtos.FirstOrDefault(x => x.Codigo == textoID);

                FormProdutos form = new FormProdutos();


                form.PrencherAlteracao(produtos);


                form.ShowDialog();


                btnConsultar_Click(sender, e);
            }
        }

        private void exluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show(
                "Você tem certeza que quer excluir este item?",
                "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (dialogResult == DialogResult.Yes)
            {



                string textoID;


                if (celulaClicada != null)
                {

                    textoID = dgvProdutos
                        .Rows[celulaClicada.RowIndex]
                        .Cells["Código"].Value.ToString();

                    ProjetoMercado2Entities banco = new ProjetoMercado2Entities();


                   // int Id = int.Parse(textoID);


                    Produto produtos = banco.Produtos.FirstOrDefault(x => x.Codigo == textoID);


                    produtos.Desativado = true;


                    banco.SaveChanges();


                    btnConsultar_Click(sender, e);
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show(
                "Você tem certeza que deseja sair da página de Consultar Produtos?", "Cancelar Saída",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Close();


            }
        }
    }
}


