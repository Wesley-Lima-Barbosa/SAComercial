namespace ProjetoLOJA
{
    partial class FormLogin
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.maskedcpflogin = new System.Windows.Forms.MaskedTextBox();
            this.txtsenha = new System.Windows.Forms.TextBox();
            this.btnentrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnsair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // maskedcpflogin
            // 
            this.maskedcpflogin.BackColor = System.Drawing.SystemColors.Desktop;
            this.maskedcpflogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.maskedcpflogin.ForeColor = System.Drawing.SystemColors.Menu;
            this.maskedcpflogin.Location = new System.Drawing.Point(42, 62);
            this.maskedcpflogin.Mask = "000.000.000-00";
            this.maskedcpflogin.Name = "maskedcpflogin";
            this.maskedcpflogin.Size = new System.Drawing.Size(134, 27);
            this.maskedcpflogin.TabIndex = 1;
            this.maskedcpflogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedcpflogin_KeyPress);
            // 
            // txtsenha
            // 
            this.txtsenha.BackColor = System.Drawing.SystemColors.Desktop;
            this.txtsenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.txtsenha.ForeColor = System.Drawing.SystemColors.Menu;
            this.txtsenha.Location = new System.Drawing.Point(42, 117);
            this.txtsenha.Name = "txtsenha";
            this.txtsenha.PasswordChar = '*';
            this.txtsenha.Size = new System.Drawing.Size(134, 27);
            this.txtsenha.TabIndex = 2;
            this.txtsenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsenha_KeyPress);
            // 
            // btnentrar
            // 
            this.btnentrar.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnentrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btnentrar.Location = new System.Drawing.Point(35, 172);
            this.btnentrar.Name = "btnentrar";
            this.btnentrar.Size = new System.Drawing.Size(75, 31);
            this.btnentrar.TabIndex = 3;
            this.btnentrar.Text = "Entrar";
            this.btnentrar.UseVisualStyleBackColor = false;
            this.btnentrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.label1.Location = new System.Drawing.Point(38, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuário";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.label2.Location = new System.Drawing.Point(38, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Senha";
            // 
            // btnsair
            // 
            this.btnsair.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnsair.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btnsair.Location = new System.Drawing.Point(116, 172);
            this.btnsair.Name = "btnsair";
            this.btnsair.Size = new System.Drawing.Size(75, 31);
            this.btnsair.TabIndex = 5;
            this.btnsair.Text = "Sair";
            this.btnsair.UseVisualStyleBackColor = false;
            this.btnsair.Click += new System.EventHandler(this.btnsair_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(226, 249);
            this.Controls.Add(this.btnsair);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnentrar);
            this.Controls.Add(this.txtsenha);
            this.Controls.Add(this.maskedcpflogin);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.CursorChanged += new System.EventHandler(this.FormLogin_CursorChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormLogin_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedcpflogin;
        private System.Windows.Forms.TextBox txtsenha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnsair;
        private System.Windows.Forms.Button btnentrar;
    }
}

