namespace BancoWindowsApp1
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.contaCorrenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contaCorrenteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCadastrar = new System.Windows.Forms.ToolStripButton();
            this.btnDepositar = new System.Windows.Forms.ToolStripButton();
            this.btnSaque = new System.Windows.Forms.ToolStripButton();
            this.btnTransferir = new System.Windows.Forms.ToolStripButton();
            this.btnExtrato = new System.Windows.Forms.ToolStripButton();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsLabel = new System.Windows.Forms.ToolStripLabel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contaCorrenteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(862, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // contaCorrenteToolStripMenuItem
            // 
            this.contaCorrenteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroClienteToolStripMenuItem,
            this.contaCorrenteMenuItem});
            this.contaCorrenteToolStripMenuItem.Name = "contaCorrenteToolStripMenuItem";
            this.contaCorrenteToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.contaCorrenteToolStripMenuItem.Text = "Cadastros";
            // 
            // contaCorrenteMenuItem
            // 
            this.contaCorrenteMenuItem.Name = "contaCorrenteMenuItem";
            this.contaCorrenteMenuItem.Size = new System.Drawing.Size(161, 22);
            this.contaCorrenteMenuItem.Text = "Conta Corrente";
            this.contaCorrenteMenuItem.Click += new System.EventHandler(this.contaCorrenteMenuItem_Click);
            // 
            // cadastroClienteToolStripMenuItem
            // 
            this.cadastroClienteToolStripMenuItem.Name = "cadastroClienteToolStripMenuItem";
            this.cadastroClienteToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.cadastroClienteToolStripMenuItem.Text = "Cadastro Cliente";
            this.cadastroClienteToolStripMenuItem.Click += new System.EventHandler(this.cadastroClienteToolStripMenuItem_Click);
            // 
            // panelControl
            // 
            this.panelControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl.Location = new System.Drawing.Point(13, 52);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(837, 351);
            this.panelControl.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCadastrar,
            this.btnDepositar,
            this.btnSaque,
            this.btnTransferir,
            this.btnExtrato,
            this.btnExcluir,
            this.toolStripSeparator1,
            this.tsLabel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(862, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCadastrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCadastrar.Image")));
            this.btnCadastrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(62, 22);
            this.btnCadastrar.Text = "Adicionar";
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnDepositar
            // 
            this.btnDepositar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDepositar.Image = ((System.Drawing.Image)(resources.GetObject("btnDepositar.Image")));
            this.btnDepositar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDepositar.Name = "btnDepositar";
            this.btnDepositar.Size = new System.Drawing.Size(61, 22);
            this.btnDepositar.Text = "Depositar";
            this.btnDepositar.Click += new System.EventHandler(this.btnDepositar_Click);
            // 
            // btnSaque
            // 
            this.btnSaque.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSaque.Image = ((System.Drawing.Image)(resources.GetObject("btnSaque.Image")));
            this.btnSaque.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaque.Name = "btnSaque";
            this.btnSaque.Size = new System.Drawing.Size(43, 22);
            this.btnSaque.Text = "Saque";
            this.btnSaque.Click += new System.EventHandler(this.btnSaque_Click);
            // 
            // btnTransferir
            // 
            this.btnTransferir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnTransferir.Image = ((System.Drawing.Image)(resources.GetObject("btnTransferir.Image")));
            this.btnTransferir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTransferir.Name = "btnTransferir";
            this.btnTransferir.Size = new System.Drawing.Size(60, 22);
            this.btnTransferir.Text = "Transferir";
            this.btnTransferir.Click += new System.EventHandler(this.btnTransferir_Click);
            // 
            // btnExtrato
            // 
            this.btnExtrato.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExtrato.Image = ((System.Drawing.Image)(resources.GetObject("btnExtrato.Image")));
            this.btnExtrato.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExtrato.Name = "btnExtrato";
            this.btnExtrato.Size = new System.Drawing.Size(47, 22);
            this.btnExtrato.Text = "Extrato";
            this.btnExtrato.Click += new System.EventHandler(this.btnExtrato_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(45, 22);
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsLabel
            // 
            this.tsLabel.Name = "tsLabel";
            this.tsLabel.Size = new System.Drawing.Size(60, 22);
            this.tsLabel.Text = "[cadastro]";
            this.tsLabel.Click += new System.EventHandler(this.tsLabel_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 415);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BancoApp";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem contaCorrenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contaCorrenteMenuItem;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCadastrar;
        private System.Windows.Forms.ToolStripButton btnDepositar;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.ToolStripButton btnSaque;
        private System.Windows.Forms.ToolStripButton btnTransferir;
        private System.Windows.Forms.ToolStripButton btnExtrato;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tsLabel;
        private System.Windows.Forms.ToolStripMenuItem cadastroClienteToolStripMenuItem;
    }
}

