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
    public partial class FormLogin : FormModelo
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        public static long idfuncionario;
        public static bool isclosed = false;
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            ProjetoMercado2Entities banco = new ProjetoMercado2Entities();
            Funcionario funcionario = banco.Funcionarios.FirstOrDefault(x => x.CPF == maskedcpflogin.Text.Replace(",", "").Replace("-", "") && x.Senha == txtsenha.Text && x.Desativado == false);
            if (funcionario != null)
            {
                FormMenu formMenu = new FormMenu();
                formMenu.nAMEFUNCToolStripMenuItem1.Text = funcionario.Nome + " " + funcionario.Sobrenome;


                if (funcionario.Admin == true)
                {
                    Hide();
                    idfuncionario = funcionario.ID;
                    formMenu.ShowDialog();
                    if (isclosed == true)
                    {
                        Show();
                    }
                    else
                    {
                        Application.Exit();
                    }

                }
                else
                {
                    Hide();
                    formMenu.opçõesToolStripMenuItem.Visible = false;
                    formMenu.funcionáriosToolStripMenuItem.Visible = false;
                    idfuncionario = funcionario.ID;
                    formMenu.ShowDialog();
                    if (isclosed == false)

                    {
                        Application.Exit();
                    }
                    else
                    {
                        Show();
                    }

                }
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorreta!");
            }

            isclosed = false;

        }

        private void txtsenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                btnentrar.PerformClick();
            }
        }

        private void maskedcpflogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                btnentrar.PerformClick();
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void FormLogin_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void FormLogin_CursorChanged(object sender, EventArgs e)
        {
            maskedcpflogin.Select(maskedcpflogin.Text.Length, 0);

        }

        private void btnsair_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show(
                "Você tem certeza que deseja sair do Login de Acesso?", "Cancelar Saída",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Close();


            }
        }
    }

}
       

    
