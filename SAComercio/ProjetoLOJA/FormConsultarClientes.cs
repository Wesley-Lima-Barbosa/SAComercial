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
    public partial class FormConsultarClientes : FormModelo
    {
        public FormConsultarClientes()
        {
            InitializeComponent();
        }

        private void BtnConsulta_Click(object sender, EventArgs e)
        {
            ProjetoMercado2Entities banco = new ProjetoMercado2Entities();

            dgvClientes.DataSource = (from cliente in banco.Clientes
                                      where (cliente.Nome + " " + cliente.Sobrenome).Contains(txtConsulta.Text)
                                      select new
                                      {
                                          Id = cliente.ID,
                                          Nome = cliente.Nome,
                                          Sobrenome = cliente.Sobrenome,
                                          CPF = cliente.CPF,
                                          CEP = cliente.CEP,
                                          Cidade = cliente.Cidade,


                                          DataNascimento = cliente.DataNascimento,
                                          Endereço = cliente.Endereço,
                                          Estado = cliente.Estado,

                                          Número = cliente.Número,

                                          Telefone = cliente.Telefone,

                                          Sexo = cliente.Sexo,

                                          Fidelidade = cliente.Fidelidade,

                                          QntFidelidade = cliente.QntFidelidade,









                                      }).ToList();


            dgvClientes.Columns["Id"].Visible = false;
        }


        public DataGridViewCellEventArgs CelulaClicada { get; set; }




        private void DgvClientes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            CelulaClicada = e;
        }

        private void TxtConsulta_TextChanged(object sender, EventArgs e)
        {
            BtnConsulta_Click(sender, e);
        }

        private void DgvClientes_CellContentClick(object sender, EventArgs e)
        {
            BtnConsulta_Click(sender, e);
        }

        private void dgvClientes_ContextMenuStripChanged(object sender, EventArgs e)
        {
            BtnConsulta_Click(sender, e);
        }

        private void AlterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string textoID;


            if (CelulaClicada != null)
            {

                textoID = dgvClientes
                    .Rows[CelulaClicada.RowIndex]
                    .Cells["Id"].Value.ToString();

                ProjetoMercado2Entities banco = new ProjetoMercado2Entities();


                int Id = int.Parse(textoID);


                Cliente clientes = banco.Clientes.Find(Id);

                FormCliente form = new FormCliente();


                form.PrencherAlteracao(clientes);


                form.ShowDialog();


                BtnConsulta_Click(sender, e);
            }
        }

        private void ExcluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show(
                "Você tem certeza que quer excluir este item?",
                "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (dialogResult == DialogResult.Yes)
            {



                string textoID;


                if (CelulaClicada != null)
                {

                    textoID = dgvClientes
                        .Rows[CelulaClicada.RowIndex]
                        .Cells["Id"].Value.ToString();

                    ProjetoMercado2Entities banco = new ProjetoMercado2Entities();


                    int Id = int.Parse(textoID);


                    Cliente clientes = banco.Clientes.Find(Id);

                    banco.Clientes.Remove(clientes);


                    banco.SaveChanges();


                    BtnConsulta_Click(sender, e);
                }
            }
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show(
                "Você tem certeza que deseja sair da página de Consultar Clientes?", "Cancelar Saída",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Close();


            }
        }
    }
}

