namespace BancoWindowsApp1.Features
{
    partial class CadastroCliente
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
            this.btnCancelarCliente = new System.Windows.Forms.Button();
            this.btnSalvarCliente = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.txtEnderecoCliente = new System.Windows.Forms.TextBox();
            this.txtEmailCliente = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancelarCliente
            // 
            this.btnCancelarCliente.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelarCliente.Location = new System.Drawing.Point(197, 126);
            this.btnCancelarCliente.Name = "btnCancelarCliente";
            this.btnCancelarCliente.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarCliente.TabIndex = 0;
            this.btnCancelarCliente.Text = "Cancelar";
            this.btnCancelarCliente.UseVisualStyleBackColor = true;
            // 
            // btnSalvarCliente
            // 
            this.btnSalvarCliente.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSalvarCliente.Location = new System.Drawing.Point(116, 126);
            this.btnSalvarCliente.Name = "btnSalvarCliente";
            this.btnSalvarCliente.Size = new System.Drawing.Size(75, 23);
            this.btnSalvarCliente.TabIndex = 1;
            this.btnSalvarCliente.Text = "Salvar";
            this.btnSalvarCliente.UseVisualStyleBackColor = true;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(23, 24);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(38, 13);
            this.label.TabIndex = 2;
            this.label.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Endereço:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Email:";
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.Location = new System.Drawing.Point(67, 20);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(205, 20);
            this.txtNomeCliente.TabIndex = 5;
            // 
            // txtEnderecoCliente
            // 
            this.txtEnderecoCliente.Location = new System.Drawing.Point(67, 76);
            this.txtEnderecoCliente.Name = "txtEnderecoCliente";
            this.txtEnderecoCliente.Size = new System.Drawing.Size(205, 20);
            this.txtEnderecoCliente.TabIndex = 7;
            // 
            // txtEmailCliente
            // 
            this.txtEmailCliente.Location = new System.Drawing.Point(67, 48);
            this.txtEmailCliente.Name = "txtEmailCliente";
            this.txtEmailCliente.Size = new System.Drawing.Size(205, 20);
            this.txtEmailCliente.TabIndex = 6;
            // 
            // CadastroCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.txtEmailCliente);
            this.Controls.Add(this.txtEnderecoCliente);
            this.Controls.Add(this.txtNomeCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label);
            this.Controls.Add(this.btnSalvarCliente);
            this.Controls.Add(this.btnCancelarCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CadastroCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelarCliente;
        private System.Windows.Forms.Button btnSalvarCliente;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.TextBox txtEnderecoCliente;
        private System.Windows.Forms.TextBox txtEmailCliente;
    }
}