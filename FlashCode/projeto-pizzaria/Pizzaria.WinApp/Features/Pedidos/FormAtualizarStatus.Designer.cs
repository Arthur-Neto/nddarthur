namespace Pizzaria.WinApp.Features.Pedidos
{
    partial class FormAtualizarStatus
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
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mskTelefone = new System.Windows.Forms.MaskedTextBox();
            this.rbtAguardandoMontagem = new System.Windows.Forms.RadioButton();
            this.rbtEmMontagem = new System.Windows.Forms.RadioButton();
            this.rbtAguardandoEntrega = new System.Windows.Forms.RadioButton();
            this.rbtEmEntrega = new System.Windows.Forms.RadioButton();
            this.rbtEntregue = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 100;
            this.label1.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Location = new System.Drawing.Point(62, 35);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(145, 20);
            this.txtCliente.TabIndex = 101;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 102;
            this.label2.Text = "Telefone:";
            // 
            // mskTelefone
            // 
            this.mskTelefone.Enabled = false;
            this.mskTelefone.Location = new System.Drawing.Point(271, 35);
            this.mskTelefone.Mask = "(00) 00000-0000";
            this.mskTelefone.Name = "mskTelefone";
            this.mskTelefone.Size = new System.Drawing.Size(100, 20);
            this.mskTelefone.TabIndex = 103;
            this.mskTelefone.ValidatingType = typeof(System.DateTime);
            // 
            // rbtAguardandoMontagem
            // 
            this.rbtAguardandoMontagem.AutoSize = true;
            this.rbtAguardandoMontagem.Location = new System.Drawing.Point(17, 105);
            this.rbtAguardandoMontagem.Name = "rbtAguardandoMontagem";
            this.rbtAguardandoMontagem.Size = new System.Drawing.Size(136, 17);
            this.rbtAguardandoMontagem.TabIndex = 104;
            this.rbtAguardandoMontagem.TabStop = true;
            this.rbtAguardandoMontagem.Text = "Aguardando Montagem";
            this.rbtAguardandoMontagem.UseVisualStyleBackColor = true;
            this.rbtAguardandoMontagem.CheckedChanged += new System.EventHandler(this.rbtAguardandoMontagem_CheckedChanged);
            // 
            // rbtEmMontagem
            // 
            this.rbtEmMontagem.AutoSize = true;
            this.rbtEmMontagem.Location = new System.Drawing.Point(159, 105);
            this.rbtEmMontagem.Name = "rbtEmMontagem";
            this.rbtEmMontagem.Size = new System.Drawing.Size(93, 17);
            this.rbtEmMontagem.TabIndex = 105;
            this.rbtEmMontagem.TabStop = true;
            this.rbtEmMontagem.Text = "Em Montagem";
            this.rbtEmMontagem.UseVisualStyleBackColor = true;
            this.rbtEmMontagem.CheckedChanged += new System.EventHandler(this.rbtEmMontagem_CheckedChanged);
            // 
            // rbtAguardandoEntrega
            // 
            this.rbtAguardandoEntrega.AutoSize = true;
            this.rbtAguardandoEntrega.Location = new System.Drawing.Point(258, 105);
            this.rbtAguardandoEntrega.Name = "rbtAguardandoEntrega";
            this.rbtAguardandoEntrega.Size = new System.Drawing.Size(123, 17);
            this.rbtAguardandoEntrega.TabIndex = 106;
            this.rbtAguardandoEntrega.TabStop = true;
            this.rbtAguardandoEntrega.Text = "Aguardando Entrega";
            this.rbtAguardandoEntrega.UseVisualStyleBackColor = true;
            this.rbtAguardandoEntrega.CheckedChanged += new System.EventHandler(this.rbtAguardandoEntrega_CheckedChanged);
            // 
            // rbtEmEntrega
            // 
            this.rbtEmEntrega.AutoSize = true;
            this.rbtEmEntrega.Location = new System.Drawing.Point(17, 138);
            this.rbtEmEntrega.Name = "rbtEmEntrega";
            this.rbtEmEntrega.Size = new System.Drawing.Size(80, 17);
            this.rbtEmEntrega.TabIndex = 107;
            this.rbtEmEntrega.TabStop = true;
            this.rbtEmEntrega.Text = "Em Entrega";
            this.rbtEmEntrega.UseVisualStyleBackColor = true;
            this.rbtEmEntrega.CheckedChanged += new System.EventHandler(this.rbtEmEntrega_CheckedChanged);
            // 
            // rbtEntregue
            // 
            this.rbtEntregue.AutoSize = true;
            this.rbtEntregue.Location = new System.Drawing.Point(159, 138);
            this.rbtEntregue.Name = "rbtEntregue";
            this.rbtEntregue.Size = new System.Drawing.Size(68, 17);
            this.rbtEntregue.TabIndex = 108;
            this.rbtEntregue.TabStop = true;
            this.rbtEntregue.Text = "Entregue";
            this.rbtEntregue.UseVisualStyleBackColor = true;
            this.rbtEntregue.CheckedChanged += new System.EventHandler(this.rbtEntregue_CheckedChanged);
            // 
            // FormAtualizarStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(393, 239);
            this.Controls.Add(this.rbtEntregue);
            this.Controls.Add(this.rbtEmEntrega);
            this.Controls.Add(this.rbtAguardandoEntrega);
            this.Controls.Add(this.rbtEmMontagem);
            this.Controls.Add(this.rbtAguardandoMontagem);
            this.Controls.Add(this.mskTelefone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormAtualizarStatus";
            this.Text = "Atualizar Status";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtCliente, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.mskTelefone, 0);
            this.Controls.SetChildIndex(this.rbtAguardandoMontagem, 0);
            this.Controls.SetChildIndex(this.rbtEmMontagem, 0);
            this.Controls.SetChildIndex(this.rbtAguardandoEntrega, 0);
            this.Controls.SetChildIndex(this.rbtEmEntrega, 0);
            this.Controls.SetChildIndex(this.rbtEntregue, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mskTelefone;
        private System.Windows.Forms.RadioButton rbtAguardandoMontagem;
        private System.Windows.Forms.RadioButton rbtEmMontagem;
        private System.Windows.Forms.RadioButton rbtAguardandoEntrega;
        private System.Windows.Forms.RadioButton rbtEmEntrega;
        private System.Windows.Forms.RadioButton rbtEntregue;
    }
}