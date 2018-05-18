namespace Mariana.WinApp.Features.SerieModule
{
    partial class FormCadastroSerie
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
            this.txtIdSerie = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownSerie = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSerie)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIdSerie
            // 
            this.txtIdSerie.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtIdSerie.Enabled = false;
            this.txtIdSerie.Location = new System.Drawing.Point(67, 28);
            this.txtIdSerie.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdSerie.Name = "txtIdSerie";
            this.txtIdSerie.Size = new System.Drawing.Size(55, 20);
            this.txtIdSerie.TabIndex = 64;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 31);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 63;
            this.label5.Text = "Id:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Serie:";
            // 
            // numericUpDownSerie
            // 
            this.numericUpDownSerie.Location = new System.Drawing.Point(68, 58);
            this.numericUpDownSerie.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDownSerie.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSerie.Name = "numericUpDownSerie";
            this.numericUpDownSerie.ReadOnly = true;
            this.numericUpDownSerie.Size = new System.Drawing.Size(126, 20);
            this.numericUpDownSerie.TabIndex = 65;
            this.numericUpDownSerie.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FormCadastroSerie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 162);
            this.Controls.Add(this.numericUpDownSerie);
            this.Controls.Add(this.txtIdSerie);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "FormCadastroSerie";
            this.Text = "Cadastro Serie";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtIdSerie, 0);
            this.Controls.SetChildIndex(this.numericUpDownSerie, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSerie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIdSerie;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownSerie;
    }
}