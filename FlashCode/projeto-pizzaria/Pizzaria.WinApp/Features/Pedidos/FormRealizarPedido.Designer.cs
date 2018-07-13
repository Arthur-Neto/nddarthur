namespace Pizzaria.WinApp.Features.Pedidos
{
    partial class FormRealizarPedido
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
            this.textBoxDepartamento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxResponsavel = new System.Windows.Forms.TextBox();
            this.tabControlProdutos = new System.Windows.Forms.TabControl();
            this.tabPagePizza = new System.Windows.Forms.TabPage();
            this.checkBoxAdicional = new System.Windows.Forms.CheckBox();
            this.cmbAdicional = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxDoisSabores = new System.Windows.Forms.CheckBox();
            this.comboBoxSegundoSabor = new System.Windows.Forms.ComboBox();
            this.comboBoxPrimeiroSabor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonTamanhoPequena = new System.Windows.Forms.RadioButton();
            this.radioButtonTamanhoMedia = new System.Windows.Forms.RadioButton();
            this.radioButtonTamanhoGrande = new System.Windows.Forms.RadioButton();
            this.labelTamanho = new System.Windows.Forms.Label();
            this.tabPageCalzone = new System.Windows.Forms.TabPage();
            this.comboBoxSaborCalzone = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPageBebida = new System.Windows.Forms.TabPage();
            this.comboBoxSaborBebida = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonRemoverItem = new System.Windows.Forms.Button();
            this.buttonAdicionarItem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listCarrinhoItens = new System.Windows.Forms.ListBox();
            this.labelFormaPagamento = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBoxTipoCartao = new System.Windows.Forms.ComboBox();
            this.radioButtonCartao = new System.Windows.Forms.RadioButton();
            this.radioButtonDinheiro = new System.Windows.Forms.RadioButton();
            this.checkBoxEmitirNota = new System.Windows.Forms.CheckBox();
            this.textBoxNotaFiscal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labelValorPagar = new System.Windows.Forms.Label();
            this.btnSelecionarCliente = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.tabControlProdutos.SuspendLayout();
            this.tabPagePizza.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPageCalzone.SuspendLayout();
            this.tabPageBebida.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Departamento:";
            // 
            // textBoxDepartamento
            // 
            this.textBoxDepartamento.Enabled = false;
            this.textBoxDepartamento.Location = new System.Drawing.Point(92, 45);
            this.textBoxDepartamento.Name = "textBoxDepartamento";
            this.textBoxDepartamento.Size = new System.Drawing.Size(130, 20);
            this.textBoxDepartamento.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Reponsável:";
            // 
            // textBoxResponsavel
            // 
            this.textBoxResponsavel.Enabled = false;
            this.textBoxResponsavel.Location = new System.Drawing.Point(298, 45);
            this.textBoxResponsavel.Name = "textBoxResponsavel";
            this.textBoxResponsavel.Size = new System.Drawing.Size(130, 20);
            this.textBoxResponsavel.TabIndex = 4;
            // 
            // tabControlProdutos
            // 
            this.tabControlProdutos.Controls.Add(this.tabPagePizza);
            this.tabControlProdutos.Controls.Add(this.tabPageCalzone);
            this.tabControlProdutos.Controls.Add(this.tabPageBebida);
            this.tabControlProdutos.Location = new System.Drawing.Point(12, 83);
            this.tabControlProdutos.Name = "tabControlProdutos";
            this.tabControlProdutos.SelectedIndex = 0;
            this.tabControlProdutos.Size = new System.Drawing.Size(416, 153);
            this.tabControlProdutos.TabIndex = 5;
            // 
            // tabPagePizza
            // 
            this.tabPagePizza.Controls.Add(this.checkBoxAdicional);
            this.tabPagePizza.Controls.Add(this.cmbAdicional);
            this.tabPagePizza.Controls.Add(this.label6);
            this.tabPagePizza.Controls.Add(this.checkBoxDoisSabores);
            this.tabPagePizza.Controls.Add(this.comboBoxSegundoSabor);
            this.tabPagePizza.Controls.Add(this.comboBoxPrimeiroSabor);
            this.tabPagePizza.Controls.Add(this.label5);
            this.tabPagePizza.Controls.Add(this.label4);
            this.tabPagePizza.Controls.Add(this.panel1);
            this.tabPagePizza.Controls.Add(this.labelTamanho);
            this.tabPagePizza.Location = new System.Drawing.Point(4, 22);
            this.tabPagePizza.Name = "tabPagePizza";
            this.tabPagePizza.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePizza.Size = new System.Drawing.Size(408, 127);
            this.tabPagePizza.TabIndex = 0;
            this.tabPagePizza.Text = "Pizzas";
            this.tabPagePizza.UseVisualStyleBackColor = true;
            // 
            // checkBoxAdicional
            // 
            this.checkBoxAdicional.AutoSize = true;
            this.checkBoxAdicional.Location = new System.Drawing.Point(285, 67);
            this.checkBoxAdicional.Name = "checkBoxAdicional";
            this.checkBoxAdicional.Size = new System.Drawing.Size(60, 17);
            this.checkBoxAdicional.TabIndex = 16;
            this.checkBoxAdicional.Text = "Borda?";
            this.checkBoxAdicional.UseVisualStyleBackColor = true;
            this.checkBoxAdicional.CheckedChanged += new System.EventHandler(this.checkBoxAdicional_CheckedChanged);
            // 
            // cmbAdicional
            // 
            this.cmbAdicional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAdicional.Enabled = false;
            this.cmbAdicional.FormattingEnabled = true;
            this.cmbAdicional.Location = new System.Drawing.Point(67, 90);
            this.cmbAdicional.Name = "cmbAdicional";
            this.cmbAdicional.Size = new System.Drawing.Size(212, 21);
            this.cmbAdicional.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Borda:";
            // 
            // checkBoxDoisSabores
            // 
            this.checkBoxDoisSabores.AutoSize = true;
            this.checkBoxDoisSabores.Location = new System.Drawing.Point(285, 38);
            this.checkBoxDoisSabores.Name = "checkBoxDoisSabores";
            this.checkBoxDoisSabores.Size = new System.Drawing.Size(93, 17);
            this.checkBoxDoisSabores.TabIndex = 8;
            this.checkBoxDoisSabores.Text = "Dois sabores?";
            this.checkBoxDoisSabores.UseVisualStyleBackColor = true;
            this.checkBoxDoisSabores.CheckedChanged += new System.EventHandler(this.checkBoxDoisSabores_CheckedChanged);
            // 
            // comboBoxSegundoSabor
            // 
            this.comboBoxSegundoSabor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSegundoSabor.Enabled = false;
            this.comboBoxSegundoSabor.FormattingEnabled = true;
            this.comboBoxSegundoSabor.Location = new System.Drawing.Point(67, 63);
            this.comboBoxSegundoSabor.Name = "comboBoxSegundoSabor";
            this.comboBoxSegundoSabor.Size = new System.Drawing.Size(212, 21);
            this.comboBoxSegundoSabor.TabIndex = 9;
            // 
            // comboBoxPrimeiroSabor
            // 
            this.comboBoxPrimeiroSabor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrimeiroSabor.FormattingEnabled = true;
            this.comboBoxPrimeiroSabor.Location = new System.Drawing.Point(67, 36);
            this.comboBoxPrimeiroSabor.Name = "comboBoxPrimeiroSabor";
            this.comboBoxPrimeiroSabor.Size = new System.Drawing.Size(212, 21);
            this.comboBoxPrimeiroSabor.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Sabor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Sabor:";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.radioButtonTamanhoPequena);
            this.panel1.Controls.Add(this.radioButtonTamanhoMedia);
            this.panel1.Controls.Add(this.radioButtonTamanhoGrande);
            this.panel1.Location = new System.Drawing.Point(67, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 24);
            this.panel1.TabIndex = 6;
            // 
            // radioButtonTamanhoPequena
            // 
            this.radioButtonTamanhoPequena.AutoSize = true;
            this.radioButtonTamanhoPequena.Location = new System.Drawing.Point(129, 4);
            this.radioButtonTamanhoPequena.Name = "radioButtonTamanhoPequena";
            this.radioButtonTamanhoPequena.Size = new System.Drawing.Size(68, 17);
            this.radioButtonTamanhoPequena.TabIndex = 6;
            this.radioButtonTamanhoPequena.Text = "Pequena";
            this.radioButtonTamanhoPequena.UseVisualStyleBackColor = true;
            this.radioButtonTamanhoPequena.CheckedChanged += new System.EventHandler(this.radioButtonTamanhoPequena_CheckedChanged);
            // 
            // radioButtonTamanhoMedia
            // 
            this.radioButtonTamanhoMedia.AutoSize = true;
            this.radioButtonTamanhoMedia.Checked = true;
            this.radioButtonTamanhoMedia.Location = new System.Drawing.Point(69, 3);
            this.radioButtonTamanhoMedia.Name = "radioButtonTamanhoMedia";
            this.radioButtonTamanhoMedia.Size = new System.Drawing.Size(54, 17);
            this.radioButtonTamanhoMedia.TabIndex = 6;
            this.radioButtonTamanhoMedia.TabStop = true;
            this.radioButtonTamanhoMedia.Text = "Media";
            this.radioButtonTamanhoMedia.UseVisualStyleBackColor = true;
            this.radioButtonTamanhoMedia.CheckedChanged += new System.EventHandler(this.radioButtonTamanhoMedia_CheckedChanged);
            // 
            // radioButtonTamanhoGrande
            // 
            this.radioButtonTamanhoGrande.AutoSize = true;
            this.radioButtonTamanhoGrande.Location = new System.Drawing.Point(3, 3);
            this.radioButtonTamanhoGrande.Name = "radioButtonTamanhoGrande";
            this.radioButtonTamanhoGrande.Size = new System.Drawing.Size(60, 17);
            this.radioButtonTamanhoGrande.TabIndex = 6;
            this.radioButtonTamanhoGrande.Text = "Grande";
            this.radioButtonTamanhoGrande.UseVisualStyleBackColor = true;
            this.radioButtonTamanhoGrande.CheckedChanged += new System.EventHandler(this.radioButtonTamanhoGrande_CheckedChanged);
            // 
            // labelTamanho
            // 
            this.labelTamanho.AutoSize = true;
            this.labelTamanho.Location = new System.Drawing.Point(9, 12);
            this.labelTamanho.Name = "labelTamanho";
            this.labelTamanho.Size = new System.Drawing.Size(55, 13);
            this.labelTamanho.TabIndex = 0;
            this.labelTamanho.Text = "Tamanho:";
            // 
            // tabPageCalzone
            // 
            this.tabPageCalzone.Controls.Add(this.comboBoxSaborCalzone);
            this.tabPageCalzone.Controls.Add(this.label7);
            this.tabPageCalzone.Location = new System.Drawing.Point(4, 22);
            this.tabPageCalzone.Name = "tabPageCalzone";
            this.tabPageCalzone.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCalzone.Size = new System.Drawing.Size(408, 127);
            this.tabPageCalzone.TabIndex = 1;
            this.tabPageCalzone.Text = "Calzones";
            this.tabPageCalzone.UseVisualStyleBackColor = true;
            // 
            // comboBoxSaborCalzone
            // 
            this.comboBoxSaborCalzone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSaborCalzone.FormattingEnabled = true;
            this.comboBoxSaborCalzone.Location = new System.Drawing.Point(51, 17);
            this.comboBoxSaborCalzone.Name = "comboBoxSaborCalzone";
            this.comboBoxSaborCalzone.Size = new System.Drawing.Size(337, 21);
            this.comboBoxSaborCalzone.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Sabor:";
            // 
            // tabPageBebida
            // 
            this.tabPageBebida.Controls.Add(this.comboBoxSaborBebida);
            this.tabPageBebida.Controls.Add(this.label8);
            this.tabPageBebida.Location = new System.Drawing.Point(4, 22);
            this.tabPageBebida.Name = "tabPageBebida";
            this.tabPageBebida.Size = new System.Drawing.Size(408, 127);
            this.tabPageBebida.TabIndex = 2;
            this.tabPageBebida.Text = "Bebidas";
            this.tabPageBebida.UseVisualStyleBackColor = true;
            // 
            // comboBoxSaborBebida
            // 
            this.comboBoxSaborBebida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSaborBebida.FormattingEnabled = true;
            this.comboBoxSaborBebida.Location = new System.Drawing.Point(51, 18);
            this.comboBoxSaborBebida.Name = "comboBoxSaborBebida";
            this.comboBoxSaborBebida.Size = new System.Drawing.Size(337, 21);
            this.comboBoxSaborBebida.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Sabor:";
            // 
            // buttonRemoverItem
            // 
            this.buttonRemoverItem.Location = new System.Drawing.Point(312, 242);
            this.buttonRemoverItem.Name = "buttonRemoverItem";
            this.buttonRemoverItem.Size = new System.Drawing.Size(112, 36);
            this.buttonRemoverItem.TabIndex = 12;
            this.buttonRemoverItem.Text = "Remover Item";
            this.buttonRemoverItem.UseVisualStyleBackColor = true;
            this.buttonRemoverItem.Click += new System.EventHandler(this.buttonRemoverItem_Click);
            // 
            // buttonAdicionarItem
            // 
            this.buttonAdicionarItem.Location = new System.Drawing.Point(194, 242);
            this.buttonAdicionarItem.Name = "buttonAdicionarItem";
            this.buttonAdicionarItem.Size = new System.Drawing.Size(112, 36);
            this.buttonAdicionarItem.TabIndex = 11;
            this.buttonAdicionarItem.Text = "Adicionar Item";
            this.buttonAdicionarItem.UseVisualStyleBackColor = true;
            this.buttonAdicionarItem.Click += new System.EventHandler(this.buttonAdicionarItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listCarrinhoItens);
            this.groupBox1.Location = new System.Drawing.Point(16, 284);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 132);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Itens Selecionados:";
            // 
            // listCarrinhoItens
            // 
            this.listCarrinhoItens.FormattingEnabled = true;
            this.listCarrinhoItens.Location = new System.Drawing.Point(7, 20);
            this.listCarrinhoItens.Name = "listCarrinhoItens";
            this.listCarrinhoItens.Size = new System.Drawing.Size(395, 95);
            this.listCarrinhoItens.TabIndex = 0;
            // 
            // labelFormaPagamento
            // 
            this.labelFormaPagamento.AutoSize = true;
            this.labelFormaPagamento.Location = new System.Drawing.Point(16, 428);
            this.labelFormaPagamento.Name = "labelFormaPagamento";
            this.labelFormaPagamento.Size = new System.Drawing.Size(111, 13);
            this.labelFormaPagamento.TabIndex = 12;
            this.labelFormaPagamento.Text = "Forma de Pagamento:";
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.comboBoxTipoCartao);
            this.panel3.Controls.Add(this.radioButtonCartao);
            this.panel3.Controls.Add(this.radioButtonDinheiro);
            this.panel3.Location = new System.Drawing.Point(132, 422);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(292, 27);
            this.panel3.TabIndex = 14;
            // 
            // comboBoxTipoCartao
            // 
            this.comboBoxTipoCartao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoCartao.Enabled = false;
            this.comboBoxTipoCartao.FormattingEnabled = true;
            this.comboBoxTipoCartao.Items.AddRange(new object[] {
            "Visa",
            "Master Card"});
            this.comboBoxTipoCartao.Location = new System.Drawing.Point(138, 3);
            this.comboBoxTipoCartao.Name = "comboBoxTipoCartao";
            this.comboBoxTipoCartao.Size = new System.Drawing.Size(151, 21);
            this.comboBoxTipoCartao.TabIndex = 15;
            // 
            // radioButtonCartao
            // 
            this.radioButtonCartao.AutoSize = true;
            this.radioButtonCartao.Location = new System.Drawing.Point(73, 4);
            this.radioButtonCartao.Name = "radioButtonCartao";
            this.radioButtonCartao.Size = new System.Drawing.Size(59, 17);
            this.radioButtonCartao.TabIndex = 14;
            this.radioButtonCartao.TabStop = true;
            this.radioButtonCartao.Text = "Cartão:";
            this.radioButtonCartao.UseVisualStyleBackColor = true;
            this.radioButtonCartao.CheckedChanged += new System.EventHandler(this.radioButtonCartao_CheckedChanged);
            // 
            // radioButtonDinheiro
            // 
            this.radioButtonDinheiro.AutoSize = true;
            this.radioButtonDinheiro.Checked = true;
            this.radioButtonDinheiro.Location = new System.Drawing.Point(3, 4);
            this.radioButtonDinheiro.Name = "radioButtonDinheiro";
            this.radioButtonDinheiro.Size = new System.Drawing.Size(64, 17);
            this.radioButtonDinheiro.TabIndex = 14;
            this.radioButtonDinheiro.TabStop = true;
            this.radioButtonDinheiro.Text = "Dinheiro";
            this.radioButtonDinheiro.UseVisualStyleBackColor = true;
            // 
            // checkBoxEmitirNota
            // 
            this.checkBoxEmitirNota.AutoSize = true;
            this.checkBoxEmitirNota.Location = new System.Drawing.Point(19, 461);
            this.checkBoxEmitirNota.Name = "checkBoxEmitirNota";
            this.checkBoxEmitirNota.Size = new System.Drawing.Size(113, 17);
            this.checkBoxEmitirNota.TabIndex = 16;
            this.checkBoxEmitirNota.Text = "Emitir Nota Fiscal?";
            this.checkBoxEmitirNota.UseVisualStyleBackColor = true;
            this.checkBoxEmitirNota.CheckedChanged += new System.EventHandler(this.checkBoxEmitirNota_CheckedChanged);
            // 
            // textBoxNotaFiscal
            // 
            this.textBoxNotaFiscal.Enabled = false;
            this.textBoxNotaFiscal.Location = new System.Drawing.Point(136, 459);
            this.textBoxNotaFiscal.Name = "textBoxNotaFiscal";
            this.textBoxNotaFiscal.Size = new System.Drawing.Size(285, 20);
            this.textBoxNotaFiscal.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(53, 516);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Valor a Pagar:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(131, 495);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 39);
            this.label10.TabIndex = 18;
            this.label10.Text = "R$";
            // 
            // labelValorPagar
            // 
            this.labelValorPagar.AutoSize = true;
            this.labelValorPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValorPagar.Location = new System.Drawing.Point(211, 495);
            this.labelValorPagar.Name = "labelValorPagar";
            this.labelValorPagar.Size = new System.Drawing.Size(84, 39);
            this.labelValorPagar.TabIndex = 19;
            this.labelValorPagar.Text = "0,00";
            // 
            // btnSelecionarCliente
            // 
            this.btnSelecionarCliente.Location = new System.Drawing.Point(353, 17);
            this.btnSelecionarCliente.Name = "btnSelecionarCliente";
            this.btnSelecionarCliente.Size = new System.Drawing.Size(75, 23);
            this.btnSelecionarCliente.TabIndex = 2;
            this.btnSelecionarCliente.Text = "Selecionar";
            this.btnSelecionarCliente.UseVisualStyleBackColor = true;
            this.btnSelecionarCliente.Click += new System.EventHandler(this.btnSelecionarCliente_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Location = new System.Drawing.Point(92, 19);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(255, 20);
            this.txtCliente.TabIndex = 1;
            // 
            // FormRealizarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 624);
            this.Controls.Add(this.btnSelecionarCliente);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.labelValorPagar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxNotaFiscal);
            this.Controls.Add(this.checkBoxEmitirNota);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.labelFormaPagamento);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonAdicionarItem);
            this.Controls.Add(this.buttonRemoverItem);
            this.Controls.Add(this.tabControlProdutos);
            this.Controls.Add(this.textBoxResponsavel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxDepartamento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormRealizarPedido";
            this.Text = "Realizar Pedido";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.textBoxDepartamento, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.textBoxResponsavel, 0);
            this.Controls.SetChildIndex(this.tabControlProdutos, 0);
            this.Controls.SetChildIndex(this.buttonRemoverItem, 0);
            this.Controls.SetChildIndex(this.buttonAdicionarItem, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.labelFormaPagamento, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.checkBoxEmitirNota, 0);
            this.Controls.SetChildIndex(this.textBoxNotaFiscal, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.labelValorPagar, 0);
            this.Controls.SetChildIndex(this.txtCliente, 0);
            this.Controls.SetChildIndex(this.btnSelecionarCliente, 0);
            this.tabControlProdutos.ResumeLayout(false);
            this.tabPagePizza.ResumeLayout(false);
            this.tabPagePizza.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPageCalzone.ResumeLayout(false);
            this.tabPageCalzone.PerformLayout();
            this.tabPageBebida.ResumeLayout(false);
            this.tabPageBebida.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDepartamento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxResponsavel;
        private System.Windows.Forms.TabControl tabControlProdutos;
        private System.Windows.Forms.TabPage tabPagePizza;
        private System.Windows.Forms.TabPage tabPageCalzone;
        private System.Windows.Forms.TabPage tabPageBebida;
        private System.Windows.Forms.Label labelTamanho;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonTamanhoPequena;
        private System.Windows.Forms.RadioButton radioButtonTamanhoMedia;
        private System.Windows.Forms.RadioButton radioButtonTamanhoGrande;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxSegundoSabor;
        private System.Windows.Forms.ComboBox comboBoxPrimeiroSabor;
        private System.Windows.Forms.CheckBox checkBoxDoisSabores;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxSaborCalzone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxSaborBebida;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonRemoverItem;
        private System.Windows.Forms.Button buttonAdicionarItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelFormaPagamento;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBoxTipoCartao;
        private System.Windows.Forms.RadioButton radioButtonCartao;
        private System.Windows.Forms.RadioButton radioButtonDinheiro;
        private System.Windows.Forms.CheckBox checkBoxEmitirNota;
        private System.Windows.Forms.TextBox textBoxNotaFiscal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelValorPagar;
        private System.Windows.Forms.Button btnSelecionarCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.ListBox listCarrinhoItens;
        private System.Windows.Forms.ComboBox cmbAdicional;
        private System.Windows.Forms.CheckBox checkBoxAdicional;
    }
}