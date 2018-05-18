namespace BancoWindowsApp1.Features.ContaCorrenteModule
{
    partial class TransferirContaCorrente
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
            this.label3 = new System.Windows.Forms.Label();
            this.labelNumero = new System.Windows.Forms.Label();
            this.labelSaldo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbContaDestino = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtValorTransferencia = new System.Windows.Forms.TextBox();
            this.btnTransferir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(4, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 75);
            this.label1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Saldo: ";
            // 
            // labelNumero
            // 
            this.labelNumero.AutoSize = true;
            this.labelNumero.Location = new System.Drawing.Point(79, 47);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(35, 13);
            this.labelNumero.TabIndex = 3;
            this.labelNumero.Text = "label4";
            // 
            // labelSaldo
            // 
            this.labelSaldo.AutoSize = true;
            this.labelSaldo.Location = new System.Drawing.Point(79, 87);
            this.labelSaldo.Name = "labelSaldo";
            this.labelSaldo.Size = new System.Drawing.Size(35, 13);
            this.labelSaldo.TabIndex = 4;
            this.labelSaldo.Text = "label5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Conta Destino:";
            // 
            // cbContaDestino
            // 
            this.cbContaDestino.FormattingEnabled = true;
            this.cbContaDestino.Location = new System.Drawing.Point(95, 132);
            this.cbContaDestino.Name = "cbContaDestino";
            this.cbContaDestino.Size = new System.Drawing.Size(159, 21);
            this.cbContaDestino.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Valor:";
            // 
            // txtValorTransferencia
            // 
            this.txtValorTransferencia.Location = new System.Drawing.Point(95, 173);
            this.txtValorTransferencia.Name = "txtValorTransferencia";
            this.txtValorTransferencia.Size = new System.Drawing.Size(159, 20);
            this.txtValorTransferencia.TabIndex = 9;
            // 
            // btnTransferir
            // 
            this.btnTransferir.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnTransferir.Location = new System.Drawing.Point(95, 226);
            this.btnTransferir.Name = "btnTransferir";
            this.btnTransferir.Size = new System.Drawing.Size(75, 23);
            this.btnTransferir.TabIndex = 10;
            this.btnTransferir.Text = "Transferir";
            this.btnTransferir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(179, 226);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Numero:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Conta Origem:";
            // 
            // TransferirContaCorrente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(266, 261);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnTransferir);
            this.Controls.Add(this.txtValorTransferencia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbContaDestino);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelSaldo);
            this.Controls.Add(this.labelNumero);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TransferirContaCorrente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transferir";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelNumero;
        private System.Windows.Forms.Label labelSaldo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbContaDestino;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtValorTransferencia;
        private System.Windows.Forms.Button btnTransferir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
    }
}