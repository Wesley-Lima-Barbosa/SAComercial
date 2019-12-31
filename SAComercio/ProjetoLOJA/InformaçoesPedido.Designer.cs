namespace ProjetoLOJA
{
    partial class InformaçoesPedido
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvInformacoes = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelCliente = new System.Windows.Forms.Label();
            this.labelPedido = new System.Windows.Forms.Label();
            this.lblFuncionario = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInformacoes)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.dgvInformacoes, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.95092F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.04908F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(475, 326);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvInformacoes
            // 
            this.dgvInformacoes.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvInformacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInformacoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInformacoes.Location = new System.Drawing.Point(3, 54);
            this.dgvInformacoes.Name = "dgvInformacoes";
            this.dgvInformacoes.Size = new System.Drawing.Size(469, 269);
            this.dgvInformacoes.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.labelCliente);
            this.panel1.Controls.Add(this.labelPedido);
            this.panel1.Controls.Add(this.lblFuncionario);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(469, 45);
            this.panel1.TabIndex = 1;
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelCliente.Location = new System.Drawing.Point(361, 6);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(35, 13);
            this.labelCliente.TabIndex = 2;
            this.labelCliente.Text = "label3";
            // 
            // labelPedido
            // 
            this.labelPedido.AutoSize = true;
            this.labelPedido.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelPedido.Location = new System.Drawing.Point(188, 6);
            this.labelPedido.Name = "labelPedido";
            this.labelPedido.Size = new System.Drawing.Size(35, 13);
            this.labelPedido.TabIndex = 1;
            this.labelPedido.Text = "label2";
            // 
            // lblFuncionario
            // 
            this.lblFuncionario.AutoSize = true;
            this.lblFuncionario.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblFuncionario.Location = new System.Drawing.Point(20, 6);
            this.lblFuncionario.Name = "lblFuncionario";
            this.lblFuncionario.Size = new System.Drawing.Size(35, 13);
            this.lblFuncionario.TabIndex = 0;
            this.lblFuncionario.Text = "label1";
            this.lblFuncionario.Click += new System.EventHandler(this.labelFuncionario_Click);
            // 
            // InformaçoesPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 326);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "InformaçoesPedido";
            this.Text = "InformaçoesPedido";
            this.Load += new System.EventHandler(this.InformaçoesPedido_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInformacoes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.DataGridView dgvInformacoes;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label labelCliente;
        public System.Windows.Forms.Label labelPedido;
        public System.Windows.Forms.Label lblFuncionario;
    }
}