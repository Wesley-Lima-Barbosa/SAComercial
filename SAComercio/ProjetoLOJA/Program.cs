using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoLOJA
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ProjetoMercado2Entities entity = new ProjetoMercado2Entities();            
            if (entity.Database.CreateIfNotExists())
            {
                Funcionario funcionario = new Funcionario();
                funcionario.Admin = true;
                funcionario.CPF = "00000000000";
                funcionario.Nome = "Admin";
                funcionario.Senha = "";
                funcionario.Sobrenome = "";
                funcionario.Desativado = false;
                entity.Funcionarios.Add(funcionario);
                entity.SaveChanges();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }
    }
}
