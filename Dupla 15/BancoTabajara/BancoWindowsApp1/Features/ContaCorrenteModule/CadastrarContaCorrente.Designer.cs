namespace BancoWindowsApp1.Features.ContaCorrenteModule
{
    partial class CadastrarContaCorrente
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumeroConta = new System.Windows.Forms.TextBox();
            this.txtSaldoConta = new System.Windows.Forms.TextBox();
            this.txtLimiteConta = new System.Windows.Forms.TextBox();
            this.chkContaEspecial = new System.Windows.Forms.CheckBox();
            this.btnSalvarConta = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTitular = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Saldo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Limite:";
            // 
            // txtNumeroConta
            // 
            this.txtNumeroConta.Location = new System.Drawing.Point(64, 51);
            this.txtNumeroConta.Name = "txtNumeroConta";
            this.txtNumeroConta.Size = new System.Drawing.Size(184, 20);
            this.txtNumeroConta.TabIndex = 3;
            // 
            // txtSaldoConta
            // 
            this.txtSaldoConta.Location = new System.Drawing.Point(64, 81);
            this.txtSaldoConta.Name = "txtSaldoConta";
            this.txtSaldoConta.Size = new System.Drawing.Size(184, 20);
            this.txtSaldoConta.TabIndex = 4;
            // 
            // txtLimiteConta
            // 
            this.txtLimiteConta.Location = new System.Drawing.Point(64, 115);
            this.txtLimiteConta.Name = "txtLimiteConta";
            this.txtLimiteConta.Size = new System.Drawing.Size(184, 20);
            this.txtLimiteConta.TabIndex = 5;
            // 
            // chkContaEspecial
            // 
            this.chkContaEspecial.AutoSize = true;
            this.chkContaEspecial.Location = new System.Drawing.Point(64, 166);
            this.chkContaEspecial.Name = "chkContaEspecial";
            this.chkContaEspecial.Size = new System.Drawing.Size(103, 17);
            this.chkContaEspecial.TabIndex = 6;
            this.chkContaEspecial.Text = "Conta Especial?";
            this.chkContaEspecial.UseVisualStyleBackColor = true;
            // 
            // btnSalvarConta
            // 
            this.btnSalvarConta.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSalvarConta.Location = new System.Drawing.Point(92, 220);
            this.btnSalvarConta.Name = "btnSalvarConta";
            this.btnSalvarConta.Size = new System.Drawing.Size(75, 23);
            this.btnSalvarConta.TabIndex = 7;
            this.btnSalvarConta.Text = "Salvar";
            this.btnSalvarConta.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(173, 220);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Titular:";
            // 
            // cmbTitular
            // 
            this.cmbTitular.FormattingEnabled = true;
            this.cmbTitular.Location = new System.Drawing.Point(64, 19);
            this.cmbTitular.Name = "cmbTitular";
            this.cmbTitular.Size = new System.Drawing.Size(184, 21);
            this.cmbTitular.TabIndex = 2;
            // 
            // CadastrarContaCorrente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 252);
            this.Controls.Add(this.cmbTitular);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvarConta);
            this.Controls.Add(this.chkContaEspecial);
            this.Controls.Add(this.txtLimiteConta);
            this.Controls.Add(this.txtSaldoConta);
            this.Controls.Add(this.txtNumeroConta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CadastrarContaCorrente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Conta Corrente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumeroConta;
        private System.Windows.Forms.TextBox txtSaldoConta;
        private System.Windows.Forms.TextBox txtLimiteConta;
        private System.Windows.Forms.CheckBox chkContaEspecial;
        private System.Windows.Forms.Button btnSalvarConta;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTitular;
    }
}