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
    public partial class FormCliente : FormModelo
    {
        public FormCliente()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (idalt == 0)
            {
                bool all = false;
                ProjetoMercado2Entities banco = new ProjetoMercado2Entities();

                Cliente cliente = new Cliente();
                if (!string.IsNullOrWhiteSpace(mskcep.Text.Replace("-", "")) && mskcep.TextLength == 9)
                {
                    cliente.CEP = mskcep.Text.Replace("-", "");
                    lblCEP.ForeColor = Color.Black;
                }
                else
                {
                    all = true;
                    lblCEP.ForeColor = Color.Red;
                }
                if (!string.IsNullOrWhiteSpace(txtCidade.Text))
                {
                    cliente.Cidade = txtCidade.Text;
                    lblCidade.ForeColor = Color.Black;
                }
                else
                {
                    all = true;
                    lblCidade.ForeColor = Color.Red;
                }
                if (!string.IsNullOrWhiteSpace(mskCPF.Text.Replace(",", "").Replace("-", "")) && mskCPF.TextLength == 14)
                {
                    cliente.CPF = mskCPF.Text.Replace(",", "").Replace("-", "");
                    lblCPF.ForeColor = Color.Black;
                }
                else
                {
                    all = true;
                    lblCPF.ForeColor = Color.Red;
                }
                if (!string.IsNullOrWhiteSpace(mskNascimento.Text.Replace("/", "")))
                {
                    cliente.DataNascimento = Convert.ToDateTime(mskNascimento.Text).Date;
                    lblDDN.ForeColor = Color.Black;
                }
                else
                {
                    all = true;
                    lblDDN.ForeColor = Color.Red;
                }
                if (!string.IsNullOrWhiteSpace(txtEndereco.Text))
                {
                    cliente.Endereço = txtEndereco.Text;
                    lblEndereco.ForeColor = Color.Black;
                }
                else
                {
                    all = true;
                    lblEndereco.ForeColor = Color.Red;
                }
                if (!string.IsNullOrWhiteSpace(cmbEstado.Text))
                {
                    cliente.Estado = cmbEstado.Text;
                    lblEstado.ForeColor = Color.Black;
                }
                else
                {
                    all = true;
                    lblEstado.ForeColor = Color.Red;
                }
                if (!string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    cliente.Nome = txtNome.Text;
                    lblnome.ForeColor = Color.Black;
                }
                else
                {
                    all = true;
                    lblnome.ForeColor = Color.Red;
                }
                if (!string.IsNullOrWhiteSpace(txtNumero.Text))
                {
                    cliente.Número = txtNumero.Text;
                    lblnumero.ForeColor = Color.Black;
                }
                else
                {
                    all = true;
                    lblnumero.ForeColor = Color.Red;
                }
                if (!string.IsNullOrWhiteSpace(txtSobrenome.Text))
                {
                    cliente.Sobrenome = txtSobrenome.Text;
                    lblsobrenome.ForeColor = Color.Black;
                }
                else
                {
                    all = true;
                    lblsobrenome.ForeColor = Color.Red;
                }
                if (!string.IsNullOrWhiteSpace(mskTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "")))
                {
                    cliente.Telefone = mskTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "");
                    lblTelefone.ForeColor = Color.Black;
                }
                else
                {
                    all = true;
                    lblTelefone.ForeColor = Color.Red;
                }

                if (cmbSexo.Text == "Masculino")
                {
                    cliente.Sexo = "M";
                    lblsexo.ForeColor = Color.Black;
                }
                else
                if(cmbSexo.Text == "Feminino")
                {
                    cliente.Sexo = "F";
                    lblsexo.ForeColor = Color.Black;
                }
                else
                {
                    all = true;
                    lblsexo.ForeColor = Color.Red;
                }
                if (all == false)
                {
                    banco.Clientes.Add(cliente);
                    banco.SaveChanges();
                    MessageBox.Show("O Cliente " + "" + cliente.Nome + " foi cadastrado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Verifique os campos obrigatórios.");
                }
            }
            else
            {
                bool all = false;
                ProjetoMercado2Entities banco = new ProjetoMercado2Entities();
                Cliente cliente = banco.Clientes.Find(idalt);
                if (!string.IsNullOrWhiteSpace(mskcep.Text.Replace("-", "")) && mskcep.TextLength == 9)
                {
                    cliente.CEP = mskcep.Text.Replace("-", "");
                    lblCEP.ForeColor = Color.Black;
                }
                else
                {
                    all = true;
                    lblCEP.ForeColor = Color.Red;
                }
                if (!string.IsNullOrWhiteSpace(txtCidade.Text))
                {
                    cliente.Cidade = txtCidade.Text;
                    lblCidade.ForeColor = Color.Black;
                }
                else
                {
                    all = true;
                    lblCidade.ForeColor = Color.Red;
                }
                if (!string.IsNullOrWhiteSpace(mskCPF.Text.Replace(",", "").Replace("-", "")) && mskCPF.TextLength == 14)
                {
                    cliente.CPF = mskCPF.Text.Replace(",", "").Replace("-", "");
                    lblCPF.ForeColor = Color.Black;
                }
                else
                {
                    all = true;
                    lblCPF.ForeColor = Color.Red;
                }
                if (!string.IsNullOrWhiteSpace(mskNascimento.Text.Replace("/", "")))
                {
                    cliente.DataNascimento = Convert.ToDateTime(mskNascimento.Text).Date;
                    lblDDN.ForeColor = Color.Black;
                }
                else
                {
                    all = true;
                    lblDDN.ForeColor = Color.Red;
                }
                if (!string.IsNullOrWhiteSpace(txtEndereco.Text))
                {
                    cliente.Endereço = txtEndereco.Text;
                    lblEndereco.ForeColor = Color.Black;
                }
                else
                {
                    all = true;
                    lblEndereco.ForeColor = Color.Red;
                }
                if (!string.IsNullOrWhiteSpace(cmbEstado.Text))
                {
                    cliente.Estado = cmbEstado.Text;
                    lblEstado.ForeColor = Color.Black;
                }
                else
                {
                    all = true;
                    lblEstado.ForeColor = Color.Red;
                }
                if (!string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    cliente.Nome = txtNome.Text;
                    lblnome.ForeColor = Color.Black;
                }
                else
                {
                    all = true;
                    lblnome.ForeColor = Color.Red;
                }
                if (!string.IsNullOrWhiteSpace(txtNumero.Text))
                {
                    cliente.Número = txtNumero.Text;
                    lblnumero.ForeColor = Color.Black;
                }
                else
                {
                    all = true;
                    lblnumero.ForeColor = Color.Red;
                }
                if (!string.IsNullOrWhiteSpace(txtSobrenome.Text))
                {
                    cliente.Sobrenome = txtSobrenome.Text;
                    lblsobrenome.ForeColor = Color.Black;
                }
                else
                {
                    all = true;
                    lblsobrenome.ForeColor = Color.Red;
                }
                if (!string.IsNullOrWhiteSpace(mskTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "")))
                {
                    cliente.Telefone = mskTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "");
                    lblTelefone.ForeColor = Color.Black;
                }
                else
                {
                    all = true;
                    lblTelefone.ForeColor = Color.Red;
                }

                if (cmbSexo.Text == "Masculino")
                {
                    cliente.Sexo = "M";
                    lblsexo.ForeColor = Color.Black;
                }
                else
                if (cmbSexo.Text == "Feminino")
                {
                    cliente.Sexo = "F";
                    lblsexo.ForeColor = Color.Black;
                }
                else
                {
                    all = true;
                    lblsexo.ForeColor = Color.Red;
                }
                if (all == false)
                {
                    banco.Clientes.Add(cliente);
                    banco.SaveChanges();
                    MessageBox.Show("O Cliente " + "" + cliente.Nome + " foi alterado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Verifique os campos obrigatórios.");
                }
            }
        }

        public long idalt { get; set; }
        public void PrencherAlteracao(Cliente cliente)
        {
            idalt = cliente.ID;
            mskcep.Text = cliente.CEP;
            txtCidade.Text = cliente.Cidade;
            mskCPF.Text = cliente.CPF;
            mskNascimento.Text = Convert.ToString(cliente.DataNascimento);
            txtEndereco.Text = cliente.Endereço;
            cmbEstado.Text = cliente.Estado;
            txtNome.Text = cliente.Nome;
            txtNumero.Text = cliente.Número;
            txtSobrenome.Text = cliente.Sobrenome;
            mskTelefone.Text = cliente.Telefone;
            btnCadastrar.Text = "Alterar";
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show(
                "Você tem certeza que deseja sair do Cadastro de Clientes?", "Cancelar Saída",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Close();


            }
        }
    }
}
