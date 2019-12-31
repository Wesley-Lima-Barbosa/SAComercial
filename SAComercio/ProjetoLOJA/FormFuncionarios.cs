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
    public partial class FormFuncionarios : Form
    {
        private bool all;

        public FormFuncionarios()
        {
            InitializeComponent();
        }


        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            if (Idalt == 0)

            {
                bool all = false;
                ProjetoMercado2Entities banco = new ProjetoMercado2Entities();

                Funcionario funcionario = new Funcionario();
                Funcionario exi = banco.Funcionarios.FirstOrDefault(x => x.CPF == mskCPF.Text.Replace(",", "").Replace("-", "") && x.Desativado == true);


                if (exi != null && exi.Desativado == true)
                {
                    DialogResult dialog = MessageBox.Show("Já existe um funcionário desativado com este CPF, deseja carregar as informações e reativar? (Poderá desativar novamente em consultar funcionários.)", "Funcionário Desativado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        Idalt = exi.ID;
                        mskCPF.Text = exi.CPF;
                        chkAdmin.Checked = exi.Admin;
                        txtNome.Text = exi.Nome;
                        txtSobrenome.Text = exi.Sobrenome;
                        btnCadastrar.Text = "Alterar";
                        exi.Desativado = false;
                        banco.SaveChanges();

                    }


                }
                else
                if (banco.Funcionarios.FirstOrDefault(x => x.CPF == mskCPF.Text.Replace(",", "").Replace("-", "")) == null)
                {

                    if (!string.IsNullOrWhiteSpace(mskCPF.Text.Replace(",", "").Replace("-", "")) && mskCPF.TextLength == 14)
                    {

                        funcionario.CPF = mskCPF.Text.Replace(",", "").Replace("-", "");
                        lblCPF.ForeColor = Color.Black;
                    }
                    else
                    {
                        all = true;
                        lblCPF.ForeColor = Color.Red;
                    }
                    if (!string.IsNullOrWhiteSpace(txtNome.Text))
                    {
                        funcionario.Nome = txtNome.Text;
                        lblNome.ForeColor = Color.Black;
                    }
                    else
                    {
                        all = true;
                        lblNome.ForeColor = Color.Red;
                    }
                    if (!string.IsNullOrWhiteSpace(txtSobrenome.Text))
                    {
                        funcionario.Sobrenome = txtSobrenome.Text;
                        lblSobrenome.ForeColor = Color.Black;
                    }
                    else
                    {
                        all = true;
                        lblSobrenome.ForeColor = Color.Red;
                    }
                    if (!string.IsNullOrWhiteSpace(txtSenha.Text))
                    {
                        funcionario.Senha = txtSenha.Text;
                        lblSenha.ForeColor = Color.Black;
                    }
                    else
                    {
                        all = true;
                        lblSenha.ForeColor = Color.Red;
                    }
                    funcionario.Admin = chkAdmin.Checked;
                    funcionario.Desativado = false;

                    if (all == false)
                    {
                        banco.Funcionarios.Add(funcionario);
                        banco.SaveChanges();
                        MessageBox.Show("O Funcionário " + "" + funcionario.Nome + " foi cadastrado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Verifique os campos obrigatórios.");
                    }
                }
                else
                {
                    MessageBox.Show("Já existe um funcionário com este CPF");
                }
            }



            else
            {
                ProjetoMercado2Entities banco = new ProjetoMercado2Entities();

                Funcionario funcionario = banco.Funcionarios.Find(Idalt);
                Funcionario exi = banco.Funcionarios.FirstOrDefault(x => x.CPF == mskCPF.Text.Replace(",", "").Replace("-", "") && x.Desativado == true);


                if (exi != null && exi.Desativado == true)
                {
                    DialogResult dialog = MessageBox.Show("Já existe um funcionário desativado com este CPF, deseja carregar as informações?", "Funcionário Desativado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        Idalt = exi.ID;
                        mskCPF.Text = exi.CPF;
                        chkAdmin.Checked = exi.Admin;
                        txtNome.Text = exi.Nome;
                        txtSobrenome.Text = exi.Sobrenome;
                        exi.Desativado = false;
                        btnCadastrar.Text = "Alterar";
                        banco.SaveChanges();
                    }


                }
                else

                if (banco.Funcionarios.FirstOrDefault(x => x.CPF == mskCPF.Text.Replace(",", "").Replace("-", "")) == null || funcionario.CPF == mskCPF.Text.Replace(",", ""))
                {

                    if (!string.IsNullOrWhiteSpace(mskCPF.Text.Replace(",", "").Replace("-", "")) && mskCPF.TextLength == 14)
                    {

                        funcionario.CPF = mskCPF.Text.Replace(",", "").Replace("-", "");
                        lblCPF.ForeColor = Color.Black;
                    }
                    else
                    {
                        all = true;
                        lblCPF.ForeColor = Color.Red;
                    }
                    if (!string.IsNullOrWhiteSpace(txtNome.Text))
                    {
                        funcionario.Nome = txtNome.Text;
                        lblNome.ForeColor = Color.Black;
                    }
                    else
                    {
                        all = true;
                        lblNome.ForeColor = Color.Red;
                    }
                    if (!string.IsNullOrWhiteSpace(txtSobrenome.Text))
                    {
                        funcionario.Sobrenome = txtSobrenome.Text;
                        lblSobrenome.ForeColor = Color.Black;
                    }
                    else
                    {
                        all = true;
                        lblSobrenome.ForeColor = Color.Red;
                    }
                    if (!string.IsNullOrWhiteSpace(txtSenha.Text))
                    {
                        funcionario.Senha = txtSenha.Text;
                        lblSenha.ForeColor = Color.Black;
                    }
                    else
                    {
                        all = true;
                        lblSenha.ForeColor = Color.Red;
                    }
                    funcionario.Admin = chkAdmin.Checked;
                    funcionario.Desativado = false;
                    if (all == false)
                    {

                        banco.SaveChanges();
                        MessageBox.Show("O Funcionário " + "" + funcionario.Nome + " foi alterado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Verifique os campos obrigatórios.");
                        all = false;
                    }
                }
                else
                {
                    MessageBox.Show("Já existe um funcionário com este CPF");
                }


            }
        }

        public long Idalt { get; set; }
        public void PreencherAlteracao(Funcionario funcionario)
        {
            Idalt = funcionario.ID;
            mskCPF.Text = funcionario.CPF;
            chkAdmin.Checked = funcionario.Admin;
            txtNome.Text = funcionario.Nome;
            txtSobrenome.Text = funcionario.Sobrenome;
            btnCadastrar.Text = "Alterar";

        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show(
                "Você tem certeza que deseja sair do Cadastro de Funcionários?", "Cancelar Saída",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Close();


            }
        }

        private void FormFuncionarios_Load(object sender, EventArgs e)
        {

        }
    }
}
