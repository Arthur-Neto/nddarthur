namespace BancoWindowsApp
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbTipoConta = new System.Windows.Forms.CheckBox();
            this.txtLimite = new System.Windows.Forms.TextBox();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.txtNumConta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovaConta = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.listDeposito = new System.Windows.Forms.ListBox();
            this.btnDepositar = new System.Windows.Forms.Button();
            this.txtValorDeposito = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.listSaque = new System.Windows.Forms.ListBox();
            this.btnRealizarSaque = new System.Windows.Forms.Button();
            this.txtValorSaque = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cmbContaOrigem = new System.Windows.Forms.ComboBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.cbContaExtrato = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(330, 367);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbTipoConta);
            this.tabPage1.Controls.Add(this.txtLimite);
            this.tabPage1.Controls.Add(this.txtSaldo);
            this.tabPage1.Controls.Add(this.txtNumConta);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnCancelar);
            this.tabPage1.Controls.Add(this.btnNovaConta);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(322, 341);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Adicionar Conta";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // cbTipoConta
            // 
            this.cbTipoConta.AutoSize = true;
            this.cbTipoConta.Location = new System.Drawing.Point(117, 131);
            this.cbTipoConta.Name = "cbTipoConta";
            this.cbTipoConta.Size = new System.Drawing.Size(43, 17);
            this.cbTipoConta.TabIndex = 8;
            this.cbTipoConta.Text = "Sim";
            this.cbTipoConta.UseVisualStyleBackColor = true;
            // 
            // txtLimite
            // 
            this.txtLimite.Location = new System.Drawing.Point(115, 95);
            this.txtLimite.Name = "txtLimite";
            this.txtLimite.Size = new System.Drawing.Size(191, 20);
            this.txtLimite.TabIndex = 7;
            // 
            // txtSaldo
            // 
            this.txtSaldo.Location = new System.Drawing.Point(115, 63);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(191, 20);
            this.txtSaldo.TabIndex = 6;
            // 
            // txtNumConta
            // 
            this.txtNumConta.Location = new System.Drawing.Point(115, 29);
            this.txtNumConta.Name = "txtNumConta";
            this.txtNumConta.Size = new System.Drawing.Size(191, 20);
            this.txtNumConta.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Limite:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Saldo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Conta especial:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Numero da Conta:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(115, 178);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovaConta
            // 
            this.btnNovaConta.Location = new System.Drawing.Point(33, 178);
            this.btnNovaConta.Name = "btnNovaConta";
            this.btnNovaConta.Size = new System.Drawing.Size(75, 23);
            this.btnNovaConta.TabIndex = 0;
            this.btnNovaConta.Text = "Salvar";
            this.btnNovaConta.UseVisualStyleBackColor = true;
            this.btnNovaConta.Click += new System.EventHandler(this.btnNovaConta_Click_1);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.listDeposito);
            this.tabPage2.Controls.Add(this.btnDepositar);
            this.tabPage2.Controls.Add(this.txtValorDeposito);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(322, 341);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Deposito";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Selecione a conta para Deposito:";
            // 
            // listDeposito
            // 
            this.listDeposito.FormattingEnabled = true;
            this.listDeposito.Location = new System.Drawing.Point(6, 28);
            this.listDeposito.Name = "listDeposito";
            this.listDeposito.Size = new System.Drawing.Size(276, 160);
            this.listDeposito.TabIndex = 5;
            this.listDeposito.SelectedIndexChanged += new System.EventHandler(this.listDeposito_SelectedIndexChanged);
            // 
            // btnDepositar
            // 
            this.btnDepositar.Location = new System.Drawing.Point(3, 262);
            this.btnDepositar.Name = "btnDepositar";
            this.btnDepositar.Size = new System.Drawing.Size(75, 23);
            this.btnDepositar.TabIndex = 4;
            this.btnDepositar.Text = "Depositar";
            this.btnDepositar.UseVisualStyleBackColor = true;
            this.btnDepositar.Click += new System.EventHandler(this.btnDepositar_Click);
            // 
            // txtValorDeposito
            // 
            this.txtValorDeposito.Location = new System.Drawing.Point(88, 211);
            this.txtValorDeposito.Name = "txtValorDeposito";
            this.txtValorDeposito.Size = new System.Drawing.Size(100, 20);
            this.txtValorDeposito.TabIndex = 3;
            this.txtValorDeposito.TextChanged += new System.EventHandler(this.txtValorDeposito_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Valor Deposito:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.listSaque);
            this.tabPage3.Controls.Add(this.btnRealizarSaque);
            this.tabPage3.Controls.Add(this.txtValorSaque);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(322, 341);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Sacar";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Selecione a conta para Saque:";
            // 
            // listSaque
            // 
            this.listSaque.FormattingEnabled = true;
            this.listSaque.Location = new System.Drawing.Point(3, 24);
            this.listSaque.Name = "listSaque";
            this.listSaque.Size = new System.Drawing.Size(276, 160);
            this.listSaque.TabIndex = 10;
            this.listSaque.SelectedIndexChanged += new System.EventHandler(this.listSaque_SelectedIndexChanged);
            // 
            // btnRealizarSaque
            // 
            this.btnRealizarSaque.Location = new System.Drawing.Point(5, 247);
            this.btnRealizarSaque.Name = "btnRealizarSaque";
            this.btnRealizarSaque.Size = new System.Drawing.Size(75, 23);
            this.btnRealizarSaque.TabIndex = 9;
            this.btnRealizarSaque.Text = "Sacar";
            this.btnRealizarSaque.UseVisualStyleBackColor = true;
            this.btnRealizarSaque.Click += new System.EventHandler(this.btnRealizarSaque_Click);
            // 
            // txtValorSaque
            // 
            this.txtValorSaque.Location = new System.Drawing.Point(91, 200);
            this.txtValorSaque.Name = "txtValorSaque";
            this.txtValorSaque.Size = new System.Drawing.Size(100, 20);
            this.txtValorSaque.TabIndex = 8;
            this.txtValorSaque.TextChanged += new System.EventHandler(this.txtValorSaque_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Valor do Saque:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cmbContaOrigem);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(322, 341);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Transferir";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cmbContaOrigem
            // 
            this.cmbContaOrigem.FormattingEnabled = true;
            this.cmbContaOrigem.Location = new System.Drawing.Point(116, 36);
            this.cmbContaOrigem.Name = "cmbContaOrigem";
            this.cmbContaOrigem.Size = new System.Drawing.Size(121, 21);
            this.cmbContaOrigem.TabIndex = 0;
            this.cmbContaOrigem.SelectedIndexChanged += new System.EventHandler(this.cmbContaOrigem_SelectedIndexChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label5);
            this.tabPage5.Controls.Add(this.cbContaExtrato);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(322, 341);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Extrato";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Numero da Conta:";
            // 
            // cbContaExtrato
            // 
            this.cbContaExtrato.FormattingEnabled = true;
            this.cbContaExtrato.Location = new System.Drawing.Point(107, 28);
            this.cbContaExtrato.Name = "cbContaExtrato";
            this.cbContaExtrato.Size = new System.Drawing.Size(121, 21);
            this.cbContaExtrato.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 392);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnNovaConta;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox txtLimite;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.TextBox txtNumConta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbContaExtrato;
        private System.Windows.Forms.CheckBox cbTipoConta;
        private System.Windows.Forms.Button btnDepositar;
        private System.Windows.Forms.TextBox txtValorDeposito;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listDeposito;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listSaque;
        private System.Windows.Forms.Button btnRealizarSaque;
        private System.Windows.Forms.TextBox txtValorSaque;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbContaOrigem;
    }
}

