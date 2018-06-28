using GeradorTestes.Domain;
using GeradorTestes.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorTestes.Cadastros
{
    public partial class CadastroDisciplinaDialog : Form
    {
        DisciplinaServico _disciplinaService;

        public CadastroDisciplinaDialog(DisciplinaServico disciplinaService, SerieServico serieService)
        {
            InitializeComponent();
            this._disciplinaService = disciplinaService;
        }
        public Disciplina NovaDisciplina
        {
            get
            {
                var disciplina = new Disciplina();
                disciplina.Nome = txtDisciplina.Text;
                return disciplina;
            }
            set
            {
                NovaDisciplina = value;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (NovaDisciplina.ID != 0)
                {
                    _disciplinaService.Update(NovaDisciplina);
                }
                else
                {
                    _disciplinaService.Adicionar(NovaDisciplina);
                    MessageBox.Show("Adicionado com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
        public const string exNumCarac = @"^[a-zA-Z]+$";
        private void txtDisciplina_Leave(object sender, EventArgs e)
        {
            //var txt = sender as TextBox;

            //var valido = System.Text.RegularExpressions.Regex.IsMatch(txt.Text.Trim(), @"^[a-zA-Z]+$");

            //if (!valido)
            //{
            //    MessageBox.Show("Disciplina deve conter apenas letras!");
            //    txt.Focus();
            //}
        }

        private void CadastroDisciplinaDialog_Load(object sender, EventArgs e)
        {

            txtDisciplina.Text = "aaaaa";
        }
    }

}