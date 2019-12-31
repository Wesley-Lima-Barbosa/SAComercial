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
    public partial class FormConsultarFuncionarios : Form
    {
        public FormConsultarFuncionarios()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ProjetoMercado2Entities banco = new ProjetoMercado2Entities();

            dgvFuncionarios.DataSource = (from funcionario in banco.Funcionarios
                                          where (funcionario.Nome + " " + funcionario.Sobrenome).Contains(txtConsulta.Text) && funcionario.Desativado == false
                                          select new
                                          {
                                              Id = funcionario.ID,
                                              Nome = funcionario.Nome,
                                              Sobrenome = funcionario.Sobrenome,
                                              CPF = funcionario.CPF,
                                              Admin = funcionario.Admin,


                                          }).ToList();


            dgvFuncionarios.Columns["Id"].Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        public DataGridViewCellEventArgs celulaClicada { get; set; }

        private void dgvFuncionarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




        private void CmsAlterar_Click(object sender, EventArgs e)
        {
            string textoID;


            if (celulaClicada != null)
            {

                textoID = dgvFuncionarios
                    .Rows[celulaClicada.RowIndex]
                    .Cells["Id"].Value.ToString();

                ProjetoMercado2Entities banco = new ProjetoMercado2Entities();


                int Id = int.Parse(textoID);


                Funcionario funcionario = banco.Funcionarios.Find(Id);

                FormFuncionarios form = new FormFuncionarios();


                form.PreencherAlteracao(funcionario);


                form.ShowDialog();


                btnConsultar_Click(sender, e);
            }
        }

        private void CmsExcluir_Click(object sender, EventArgs e)
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

                    textoID = dgvFuncionarios
                        .Rows[celulaClicada.RowIndex]
                        .Cells["Id"].Value.ToString();

                    ProjetoMercado2Entities banco = new ProjetoMercado2Entities();


                    int Id = int.Parse(textoID);


                    Funcionario funcionario = banco.Funcionarios.Find(Id);
                    if (funcionario.Admin == true && banco.Funcionarios.Count(x => x.Admin && x.Desativado == false) > 1)
                    {
                        funcionario.Desativado = true;


                        banco.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Não tem como excluir o único usuário administrador.");
                    }

                    btnConsultar_Click(sender, e);
                }
            }
        }

        private void dgvFuncionarios_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            celulaClicada = e;
        }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            btnConsultar_Click(sender, e);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show(
                "Você tem certeza que deseja sair da página de Consultar Funcionários?", "Cancelar Saída",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Close();


            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
