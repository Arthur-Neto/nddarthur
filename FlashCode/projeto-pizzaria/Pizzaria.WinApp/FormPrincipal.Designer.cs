namespace ExemploProjeto.WinApp
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonAdicionar = new System.Windows.Forms.ToolStripButton();
            this.buttonAtualizar = new System.Windows.Forms.ToolStripButton();
            this.buttonExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelTipoCadastro = new System.Windows.Forms.ToolStripLabel();
            this.panelControl = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pedidoToolStripMenuItem,
            this.clienteToolStripMenuItem,
            this.produtoToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // pedidoToolStripMenuItem
            // 
            this.pedidoToolStripMenuItem.Name = "pedidoToolStripMenuItem";
            this.pedidoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.pedidoToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.pedidoToolStripMenuItem.Text = "Pedido";
            this.pedidoToolStripMenuItem.Click += new System.EventHandler(this.pedidoToolStripMenuItem_Click);
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.clienteToolStripMenuItem.Text = "Cliente";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // produtoToolStripMenuItem
            // 
            this.produtoToolStripMenuItem.Name = "produtoToolStripMenuItem";
            this.produtoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.produtoToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.produtoToolStripMenuItem.Text = "Produto";
            this.produtoToolStripMenuItem.Click += new System.EventHandler(this.produtoToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonAdicionar,
            this.buttonAtualizar,
            this.buttonExcluir,
            this.toolStripSeparator1,
            this.toolStripLabelTipoCadastro});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 29);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdicionar.Image")));
            this.buttonAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Padding = new System.Windows.Forms.Padding(3);
            this.buttonAdicionar.Size = new System.Drawing.Size(84, 26);
            this.buttonAdicionar.Text = "Adicionar";
            this.buttonAdicionar.Click += new System.EventHandler(this.toolStripButtonAdicionar_Click);
            // 
            // buttonAtualizar
            // 
            this.buttonAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("buttonAtualizar.Image")));
            this.buttonAtualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAtualizar.Name = "buttonAtualizar";
            this.buttonAtualizar.Padding = new System.Windows.Forms.Padding(3);
            this.buttonAtualizar.Size = new System.Drawing.Size(79, 26);
            this.buttonAtualizar.Text = "Atualizar";
            this.buttonAtualizar.Click += new System.EventHandler(this.toolStripButtonAtualizar_Click);
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.Image = ((System.Drawing.Image)(resources.GetObject("buttonExcluir.Image")));
            this.buttonExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonExcluir.Name = "buttonExcluir";
            this.buttonExcluir.Padding = new System.Windows.Forms.Padding(3);
            this.buttonExcluir.Size = new System.Drawing.Size(67, 26);
            this.buttonExcluir.Text = "Excluir";
            this.buttonExcluir.Click += new System.EventHandler(this.toolStripButtonExcluir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripLabelTipoCadastro
            // 
            this.toolStripLabelTipoCadastro.Name = "toolStripLabelTipoCadastro";
            this.toolStripLabelTipoCadastro.Size = new System.Drawing.Size(60, 26);
            this.toolStripLabelTipoCadastro.Text = "[cadastro]";
            // 
            // panelControl
            // 
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 53);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(800, 397);
            this.panelControl.TabIndex = 2;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pizzaria Sartor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonAdicionar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelTipoCadastro;
        private System.Windows.Forms.ToolStripButton buttonAtualizar;
        private System.Windows.Forms.ToolStripButton buttonExcluir;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtoToolStripMenuItem;
    }
}

