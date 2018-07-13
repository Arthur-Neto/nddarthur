namespace Pizzaria.WinApp.Features.Produtos
{
    partial class FormCadastrarProduto
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBoxPizza = new System.Windows.Forms.GroupBox();
            this.numericUpDownGrande = new System.Windows.Forms.NumericUpDown();
            this.checkBoxGrande = new System.Windows.Forms.CheckBox();
            this.numericUpDownMedia = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownPequena = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxPequena = new System.Windows.Forms.CheckBox();
            this.checkBoxMedia = new System.Windows.Forms.CheckBox();
            this.groupBoxTamanhoPadrao = new System.Windows.Forms.GroupBox();
            this.checkBoxTamanhoPadrao = new System.Windows.Forms.CheckBox();
            this.numericUpDownValorPadrao = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSabor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxTipoProduto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxPizza.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGrande)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMedia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPequena)).BeginInit();
            this.groupBoxTamanhoPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValorPadrao)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtSabor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxTipoProduto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 396);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Produto";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBoxPizza);
            this.groupBox2.Controls.Add(this.groupBoxTamanhoPadrao);
            this.groupBox2.Location = new System.Drawing.Point(21, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(313, 257);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tamanhos";
            // 
            // groupBoxPizza
            // 
            this.groupBoxPizza.Controls.Add(this.numericUpDownGrande);
            this.groupBoxPizza.Controls.Add(this.checkBoxGrande);
            this.groupBoxPizza.Controls.Add(this.numericUpDownMedia);
            this.groupBoxPizza.Controls.Add(this.label4);
            this.groupBoxPizza.Controls.Add(this.label6);
            this.groupBoxPizza.Controls.Add(this.numericUpDownPequena);
            this.groupBoxPizza.Controls.Add(this.label5);
            this.groupBoxPizza.Controls.Add(this.checkBoxPequena);
            this.groupBoxPizza.Controls.Add(this.checkBoxMedia);
            this.groupBoxPizza.Enabled = false;
            this.groupBoxPizza.Location = new System.Drawing.Point(6, 109);
            this.groupBoxPizza.Name = "groupBoxPizza";
            this.groupBoxPizza.Size = new System.Drawing.Size(297, 129);
            this.groupBoxPizza.TabIndex = 21;
            this.groupBoxPizza.TabStop = false;
            this.groupBoxPizza.Text = "Outros Tamanhos";
            // 
            // numericUpDownGrande
            // 
            this.numericUpDownGrande.DecimalPlaces = 2;
            this.numericUpDownGrande.Location = new System.Drawing.Point(192, 103);
            this.numericUpDownGrande.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownGrande.Name = "numericUpDownGrande";
            this.numericUpDownGrande.Size = new System.Drawing.Size(90, 20);
            this.numericUpDownGrande.TabIndex = 17;
            this.numericUpDownGrande.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBoxGrande
            // 
            this.checkBoxGrande.AutoSize = true;
            this.checkBoxGrande.Location = new System.Drawing.Point(8, 104);
            this.checkBoxGrande.Name = "checkBoxGrande";
            this.checkBoxGrande.Size = new System.Drawing.Size(61, 17);
            this.checkBoxGrande.TabIndex = 19;
            this.checkBoxGrande.Text = "Grande";
            this.checkBoxGrande.UseVisualStyleBackColor = true;
            // 
            // numericUpDownMedia
            // 
            this.numericUpDownMedia.DecimalPlaces = 2;
            this.numericUpDownMedia.Location = new System.Drawing.Point(192, 63);
            this.numericUpDownMedia.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownMedia.Name = "numericUpDownMedia";
            this.numericUpDownMedia.Size = new System.Drawing.Size(90, 20);
            this.numericUpDownMedia.TabIndex = 10;
            this.numericUpDownMedia.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Valor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(142, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Valor";
            // 
            // numericUpDownPequena
            // 
            this.numericUpDownPequena.DecimalPlaces = 2;
            this.numericUpDownPequena.Location = new System.Drawing.Point(192, 23);
            this.numericUpDownPequena.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownPequena.Name = "numericUpDownPequena";
            this.numericUpDownPequena.Size = new System.Drawing.Size(90, 20);
            this.numericUpDownPequena.TabIndex = 9;
            this.numericUpDownPequena.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(142, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Valor";
            // 
            // checkBoxPequena
            // 
            this.checkBoxPequena.AutoSize = true;
            this.checkBoxPequena.Location = new System.Drawing.Point(8, 26);
            this.checkBoxPequena.Name = "checkBoxPequena";
            this.checkBoxPequena.Size = new System.Drawing.Size(69, 17);
            this.checkBoxPequena.TabIndex = 15;
            this.checkBoxPequena.Text = "Pequena";
            this.checkBoxPequena.UseVisualStyleBackColor = true;
            // 
            // checkBoxMedia
            // 
            this.checkBoxMedia.AutoSize = true;
            this.checkBoxMedia.Location = new System.Drawing.Point(8, 64);
            this.checkBoxMedia.Name = "checkBoxMedia";
            this.checkBoxMedia.Size = new System.Drawing.Size(55, 17);
            this.checkBoxMedia.TabIndex = 16;
            this.checkBoxMedia.Text = "Media";
            this.checkBoxMedia.UseVisualStyleBackColor = true;
            // 
            // groupBoxTamanhoPadrao
            // 
            this.groupBoxTamanhoPadrao.Controls.Add(this.checkBoxTamanhoPadrao);
            this.groupBoxTamanhoPadrao.Controls.Add(this.numericUpDownValorPadrao);
            this.groupBoxTamanhoPadrao.Controls.Add(this.label3);
            this.groupBoxTamanhoPadrao.Enabled = false;
            this.groupBoxTamanhoPadrao.Location = new System.Drawing.Point(6, 27);
            this.groupBoxTamanhoPadrao.Name = "groupBoxTamanhoPadrao";
            this.groupBoxTamanhoPadrao.Size = new System.Drawing.Size(297, 67);
            this.groupBoxTamanhoPadrao.TabIndex = 20;
            this.groupBoxTamanhoPadrao.TabStop = false;
            this.groupBoxTamanhoPadrao.Text = "Tamanho Padrão";
            // 
            // checkBoxTamanhoPadrao
            // 
            this.checkBoxTamanhoPadrao.AutoSize = true;
            this.checkBoxTamanhoPadrao.Checked = true;
            this.checkBoxTamanhoPadrao.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTamanhoPadrao.Enabled = false;
            this.checkBoxTamanhoPadrao.Location = new System.Drawing.Point(6, 19);
            this.checkBoxTamanhoPadrao.Name = "checkBoxTamanhoPadrao";
            this.checkBoxTamanhoPadrao.Size = new System.Drawing.Size(60, 17);
            this.checkBoxTamanhoPadrao.TabIndex = 14;
            this.checkBoxTamanhoPadrao.Text = "Padrão";
            this.checkBoxTamanhoPadrao.UseVisualStyleBackColor = true;
            // 
            // numericUpDownValorPadrao
            // 
            this.numericUpDownValorPadrao.DecimalPlaces = 2;
            this.numericUpDownValorPadrao.Location = new System.Drawing.Point(192, 16);
            this.numericUpDownValorPadrao.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownValorPadrao.Name = "numericUpDownValorPadrao";
            this.numericUpDownValorPadrao.Size = new System.Drawing.Size(90, 20);
            this.numericUpDownValorPadrao.TabIndex = 8;
            this.numericUpDownValorPadrao.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Valor";
            // 
            // txtSabor
            // 
            this.txtSabor.Location = new System.Drawing.Point(21, 96);
            this.txtSabor.Name = "txtSabor";
            this.txtSabor.Size = new System.Drawing.Size(303, 20);
            this.txtSabor.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sabor";
            // 
            // comboBoxTipoProduto
            // 
            this.comboBoxTipoProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoProduto.FormattingEnabled = true;
            this.comboBoxTipoProduto.Items.AddRange(new object[] {
            "Pizza",
            "Calzone",
            "Adicional",
            "Bebida"});
            this.comboBoxTipoProduto.Location = new System.Drawing.Point(21, 42);
            this.comboBoxTipoProduto.Name = "comboBoxTipoProduto";
            this.comboBoxTipoProduto.Size = new System.Drawing.Size(303, 21);
            this.comboBoxTipoProduto.TabIndex = 1;
            this.comboBoxTipoProduto.SelectedIndexChanged += new System.EventHandler(this.comboBoxProdutos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo do produto";
            // 
            // FormCadastrarProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 482);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormCadastrarProduto";
            this.Text = "Produtos";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBoxPizza.ResumeLayout(false);
            this.groupBoxPizza.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGrande)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMedia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPequena)).EndInit();
            this.groupBoxTamanhoPadrao.ResumeLayout(false);
            this.groupBoxTamanhoPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValorPadrao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownValorPadrao;
        private System.Windows.Forms.TextBox txtSabor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTipoProduto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownMedia;
        private System.Windows.Forms.NumericUpDown numericUpDownPequena;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBoxPizza;
        private System.Windows.Forms.NumericUpDown numericUpDownGrande;
        private System.Windows.Forms.CheckBox checkBoxGrande;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxPequena;
        private System.Windows.Forms.CheckBox checkBoxMedia;
        private System.Windows.Forms.GroupBox groupBoxTamanhoPadrao;
        private System.Windows.Forms.CheckBox checkBoxTamanhoPadrao;
        private System.Windows.Forms.Label label3;
    }
}