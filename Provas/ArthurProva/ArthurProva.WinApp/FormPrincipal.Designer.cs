namespace ArthurProva.WinApp
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
            this.cadastrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contatoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compromissoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAdicionar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAtualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExcluir = new System.Windows.Forms.ToolStripButton();
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
            this.cadastrarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(677, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrarToolStripMenuItem
            // 
            this.cadastrarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contatoToolStripMenuItem,
            this.compromissoToolStripMenuItem});
            this.cadastrarToolStripMenuItem.Name = "cadastrarToolStripMenuItem";
            this.cadastrarToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.cadastrarToolStripMenuItem.Text = "Cadastrar";
            // 
            // contatoToolStripMenuItem
            // 
            this.contatoToolStripMenuItem.Name = "contatoToolStripMenuItem";
            this.contatoToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.contatoToolStripMenuItem.Text = "Contato";
            this.contatoToolStripMenuItem.Click += new System.EventHandler(this.contatoToolStripMenuItem_Click);
            // 
            // compromissoToolStripMenuItem
            // 
            this.compromissoToolStripMenuItem.Name = "compromissoToolStripMenuItem";
            this.compromissoToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.compromissoToolStripMenuItem.Text = "Compromisso";
            this.compromissoToolStripMenuItem.Click += new System.EventHandler(this.compromissoToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAdicionar,
            this.toolStripButtonAtualizar,
            this.toolStripButtonExcluir,
            this.toolStripSeparator1,
            this.toolStripLabelTipoCadastro});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(677, 28);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAdicionar
            // 
            this.toolStripButtonAdicionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonAdicionar.Enabled = false;
            this.toolStripButtonAdicionar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAdicionar.Image")));
            this.toolStripButtonAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdicionar.Name = "toolStripButtonAdicionar";
            this.toolStripButtonAdicionar.Padding = new System.Windows.Forms.Padding(3);
            this.toolStripButtonAdicionar.Size = new System.Drawing.Size(68, 25);
            this.toolStripButtonAdicionar.Text = "Adicionar";
            this.toolStripButtonAdicionar.Click += new System.EventHandler(this.toolStripButtonAdicionar_Click);
            // 
            // toolStripButtonAtualizar
            // 
            this.toolStripButtonAtualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonAtualizar.Enabled = false;
            this.toolStripButtonAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAtualizar.Image")));
            this.toolStripButtonAtualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAtualizar.Name = "toolStripButtonAtualizar";
            this.toolStripButtonAtualizar.Padding = new System.Windows.Forms.Padding(3);
            this.toolStripButtonAtualizar.Size = new System.Drawing.Size(63, 25);
            this.toolStripButtonAtualizar.Text = "Atualizar";
            this.toolStripButtonAtualizar.Click += new System.EventHandler(this.toolStripButtonAtualizar_Click);
            // 
            // toolStripButtonExcluir
            // 
            this.toolStripButtonExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonExcluir.Enabled = false;
            this.toolStripButtonExcluir.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExcluir.Image")));
            this.toolStripButtonExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExcluir.Name = "toolStripButtonExcluir";
            this.toolStripButtonExcluir.Padding = new System.Windows.Forms.Padding(3);
            this.toolStripButtonExcluir.Size = new System.Drawing.Size(51, 25);
            this.toolStripButtonExcluir.Text = "Excluir";
            this.toolStripButtonExcluir.Click += new System.EventHandler(this.toolStripButtonExcluir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripLabelTipoCadastro
            // 
            this.toolStripLabelTipoCadastro.Name = "toolStripLabelTipoCadastro";
            this.toolStripLabelTipoCadastro.Size = new System.Drawing.Size(60, 25);
            this.toolStripLabelTipoCadastro.Text = "[cadastro]";
            // 
            // panelControl
            // 
            this.panelControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl.Location = new System.Drawing.Point(12, 55);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(653, 396);
            this.panelControl.TabIndex = 2;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 463);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.ShowIcon = false;
            this.Text = "Agenda";
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
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contatoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compromissoToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdicionar;
        private System.Windows.Forms.ToolStripButton toolStripButtonAtualizar;
        private System.Windows.Forms.ToolStripButton toolStripButtonExcluir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelTipoCadastro;
        private System.Windows.Forms.Panel panelControl;
    }
}

