namespace Pizzaria.WinApp.Base
{
    partial class FormCadastroBasico<T>
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
            this.flowLayoutPanelError = new System.Windows.Forms.FlowLayoutPanel();
            this.labelError = new System.Windows.Forms.Label();
            this.flowLayoutPanelBotoes = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.flowLayoutPanelError.SuspendLayout();
            this.flowLayoutPanelBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelError
            // 
            this.flowLayoutPanelError.Controls.Add(this.labelError);
            this.flowLayoutPanelError.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelError.Location = new System.Drawing.Point(0, 52);
            this.flowLayoutPanelError.Name = "flowLayoutPanelError";
            this.flowLayoutPanelError.Size = new System.Drawing.Size(218, 24);
            this.flowLayoutPanelError.TabIndex = 0;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(3, 0);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(44, 13);
            this.labelError.TabIndex = 0;
            this.labelError.Text = "[ERRO]";
            this.labelError.Visible = false;
            // 
            // flowLayoutPanelBotoes
            // 
            this.flowLayoutPanelBotoes.Controls.Add(this.buttonCancelar);
            this.flowLayoutPanelBotoes.Controls.Add(this.buttonSalvar);
            this.flowLayoutPanelBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelBotoes.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanelBotoes.Location = new System.Drawing.Point(0, 8);
            this.flowLayoutPanelBotoes.Name = "flowLayoutPanelBotoes";
            this.flowLayoutPanelBotoes.Size = new System.Drawing.Size(218, 44);
            this.flowLayoutPanelBotoes.TabIndex = 99;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Location = new System.Drawing.Point(134, 3);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(81, 35);
            this.buttonCancelar.TabIndex = 99;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSalvar.Location = new System.Drawing.Point(47, 3);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(81, 35);
            this.buttonSalvar.TabIndex = 98;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = true;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // FormCadastroBasico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 76);
            this.Controls.Add(this.flowLayoutPanelBotoes);
            this.Controls.Add(this.flowLayoutPanelError);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCadastroBasico";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro";
            this.flowLayoutPanelError.ResumeLayout(false);
            this.flowLayoutPanelError.PerformLayout();
            this.flowLayoutPanelBotoes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelError;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBotoes;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.Button buttonCancelar;
        protected System.Windows.Forms.Label labelError;
    }
}