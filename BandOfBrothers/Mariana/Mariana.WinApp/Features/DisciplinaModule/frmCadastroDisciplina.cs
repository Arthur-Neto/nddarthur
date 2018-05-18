using Mariana.Dominio;
using Mariana.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mariana.WinApp.Features.DisciplinaModule
{
    public partial class frmCadastroDisciplina : Form
    {
        private Disciplina disciplina;

        public frmCadastroDisciplina()
        {
            InitializeComponent();
        }

        public Disciplina NovaDisciplina
        {
            get
            {
                return disciplina;
            }
            set
            {
                disciplina = value;

                txtId.Text = disciplina.Id.ToString();
                if (disciplina.Nome != null)
                {
                    txtDisciplina.Text = disciplina.Nome.ToString();
                    btnCadastrar.Text = "Atualizar";
                }
                else
                {
                    btnCadastrar.Text = "Cadastrar";
                }
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDisciplina.Text != "")
                {
                    disciplina.Nome = txtDisciplina.Text;

                    DominioHelper.ValidarEspaçoVazioETamanho(disciplina.Nome);
                    DominioHelper.ValidarNomeSemNumero(disciplina.Nome);
                    disciplina.Nome = DominioHelper.FormatarNome(disciplina.Nome);
                }
                else
                {
                    MessageBox.Show("O Nome não pode estar vazio");

                    DialogResult = DialogResult.None;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                DialogResult = DialogResult.None;
            }
        }
        private void txtDisciplina_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                btnCadastrar.PerformClick();
            }
            if(e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
