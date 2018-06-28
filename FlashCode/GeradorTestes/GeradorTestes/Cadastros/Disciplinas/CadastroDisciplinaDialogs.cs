using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using GeradorTestes.Servicos;
using GeradorTestes.Domain;

namespace GeradorTestes.Cadastros.Disciplinas
{
    public partial class CadastroDisciplinaDialogs : Form
    {
        DisciplinaServico _disciplinaServico;
        Disciplina _disciplina;

        public CadastroDisciplinaDialogs(DisciplinaServico disciplinaServico, string titulo, Disciplina disciplina = null)
        {
            InitializeComponent();
            this.Text = titulo;
            _disciplinaServico = disciplinaServico;
            NovaDisciplina = disciplina;
            if (NovaDisciplina != null)
            {
                txtNomeDisciplina.Text = NovaDisciplina.Nome;
            }
        }
        public Disciplina NovaDisciplina
        {
            get
            {
                return _disciplina;
            }
            set
            {
                _disciplina = value;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;
            try
            {
                if (NovaDisciplina != null)
                {
                    if (NovaDisciplina.Nome.Trim() == txtNomeDisciplina.Text.Trim())
                        return;
                    NovaDisciplina.Nome = txtNomeDisciplina.Text.Trim();

                    try
                    {
                        _disciplinaServico.Update(NovaDisciplina);
                        MessageBox.Show("Disciplina Atualizada com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        DialogResult = DialogResult.None;
                        MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    NovaDisciplina = new Disciplina();
                    NovaDisciplina.Nome = txtNomeDisciplina.Text.Trim();
                    _disciplinaServico.Adicionar(NovaDisciplina);
                    MessageBox.Show("Disciplina Cadastrada com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.None;
                NovaDisciplina = null;
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
