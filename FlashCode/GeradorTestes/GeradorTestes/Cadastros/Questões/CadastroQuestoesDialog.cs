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
    public partial class CadastroQuestoesDialog : Form
    {
        QuestoesServico _questoesServico;
        private Questao _questao;
        IList<Serie> _listaSeries;
        IList<Disciplina> _listaDisciplinas;
        IList<Materia> _listaMaterias;
        MateriaServico _materiaServico = new MateriaServico();

        public CadastroQuestoesDialog(QuestoesServico questoesServico, string titulo, Questao questoes = null)
        {
            InitializeComponent();
            this.Text = titulo;
            _questoesServico = questoesServico;
            _questao = questoes;
            TextoEditarQuestao();
            CheckBoxSelecionado();

        }
        public void MarcaMateria()
        {
            if (_questao != null)
                cmbMateria.SelectedIndex = cmbMateria.FindString(_questao.materia.ToString());
        }

        private void CheckBoxSelecionado()
        {
            if (NovaQuestao != null)
            {
                string alternativaCerta = _questao.Alternativa.RetornaLetraAlternativaCorreta();
                if (alternativaCerta.Equals("A"))
                    ckbA.Checked = true;
                if (alternativaCerta.Equals("B"))
                    ckbB.Checked = true;
                if (alternativaCerta.Equals("C"))
                    ckbC.Checked = true;
                if (alternativaCerta.Equals("D"))
                    ckbD.Checked = true;
            }
        }

        public Questao NovaQuestao
        {
            get
            {
                return _questao;
            }
            set
            {
                _questao = value;
            }
        }

        public string VerificaQuestaoCorreta()
        {
            if (ckbA.Checked == true)
            {
                return txtAlternativaA.Text.Trim();
            }
            else if (ckbB.Checked == true)
            {
                return txtAlternativaB.Text.Trim();
            }
            else if (ckbC.Checked == true)
            {
                return txtAlternativaC.Text.Trim();
            }
            else if (ckbD.Checked == true)
            {
                return txtAlternativaD.Text.Trim();
            }
            else
            {
                throw new Exception("Nenhuma alternativa marcada como correta");
            }
        }
        public void InsertSerieInComomBox(IList<GeradorTestes.Domain.Serie> serie)
        {
            cmbSerie.Items.Clear();
            _listaSeries = serie;
            foreach (var item in serie)
            {
                cmbSerie.Items.Add(item);
            }
            SelectedFiltroSerie();
        }
        private void SelectedFiltroSerie()
        {
            if (NovaQuestao != null)
            {
                foreach (var serie in _listaSeries)
                {
                    if (NovaQuestao.materia.serie.ID == serie.ID)
                    {
                        cmbSerie.SelectedItem = serie as Serie;
                    }
                }

            }
        }

        public void InsertDisciplinaInComomBox(IList<GeradorTestes.Domain.Disciplina> disciplina)
        {
            cmbDisciplina.Items.Clear();
            _listaDisciplinas = disciplina;
            foreach (var item in disciplina)
            {
                cmbDisciplina.Items.Add(item);
            }
            SelectedFiltroDisciplina();
        }
        private void TextoEditarQuestao()
        {
            if (NovaQuestao != null)
            {
                txtQuestao.Text = NovaQuestao.Pergunta;
                txtAlternativaA.Text = NovaQuestao.Alternativa.A;
                txtAlternativaB.Text = NovaQuestao.Alternativa.B;
                txtAlternativaC.Text = NovaQuestao.Alternativa.C;
                txtAlternativaD.Text = NovaQuestao.Alternativa.D;
            }
        }
        private void SelectedFiltroDisciplina()
        {
            if (NovaQuestao != null)
            {
                foreach (var disciplina in _listaDisciplinas)
                {
                    if (NovaQuestao.materia.disciplina.ID == disciplina.ID)
                    {
                        cmbDisciplina.SelectedItem = disciplina as Disciplina;
                    }
                }

            }
        }

        public void InsertMateriaInComomBox(IList<Materia> materia)
        {
            cmbMateria.Items.Clear();
            _listaMaterias = materia;
            foreach (var item in materia)
            {
                cmbMateria.Items.Add(item);
            }
        }
        private void SelectedCmbBimestre()
        {
            if (NovaQuestao != null)
            {
                foreach (var bimestre in cmbBimestre.Items)
                {
                    if (NovaQuestao.Bimestre == bimestre.ToString())
                    {
                        cmbBimestre.SelectedItem = bimestre;
                    }
                }
            }
        }
        public void InsertBimestreInComomBox()
        {
            cmbBimestre.Items.Add("1º Bimestre");
            cmbBimestre.Items.Add("2º Bimestre");
            cmbBimestre.Items.Add("3º Bimestre");
            cmbBimestre.Items.Add("4º Bimestre");
            SelectedCmbBimestre();
        }

        private void ckbA_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbA.Checked == true)
            {
                ckbB.Checked = false;
                ckbC.Checked = false;
                ckbD.Checked = false;
            }
        }

        private void ckbB_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbB.Checked == true)
            {
                ckbA.Checked = false;
                ckbC.Checked = false;
                ckbD.Checked = false;
            }
        }

        private void ckbC_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbC.Checked == true)
            {
                ckbB.Checked = false;
                ckbA.Checked = false;
                ckbD.Checked = false;
            }
        }

        private void ckbD_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbD.Checked == true)
            {
                ckbB.Checked = false;
                ckbC.Checked = false;
                ckbA.Checked = false;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            try
            {
                if (cmbBimestre.SelectedItem is null)
                {
                    MessageBox.Show("Selecione um bimestre", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                    return;
                }
                if (NovaQuestao != null)
                {
                    NovaQuestao.Pergunta = txtQuestao.Text.Trim();
                    NovaQuestao.Alternativa.A = txtAlternativaA.Text.Trim();
                    NovaQuestao.Alternativa.B = txtAlternativaB.Text.Trim();
                    NovaQuestao.Alternativa.C = txtAlternativaC.Text.Trim();
                    NovaQuestao.Alternativa.D = txtAlternativaD.Text.Trim();
                    NovaQuestao.Bimestre = cmbBimestre.SelectedItem.ToString();
                    NovaQuestao.materia = cmbMateria.SelectedItem as Materia;
                    NovaQuestao.Alternativa.Correta = VerificaQuestaoCorreta();
                    try
                    {
                        /* if (NovaQuestao.Pergunta.Trim().Equals(txtQuestao.Text.Trim()))
                         {
                             return;
                         }*/
                        _questoesServico.Update(NovaQuestao);

                        MessageBox.Show("Questão Editada com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        DialogResult = DialogResult.None;
                        MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    NovaQuestao = new Questao();
                    NovaQuestao.Pergunta = txtQuestao.Text.Trim();
                    NovaQuestao.Alternativa = new Alternativas();
                    NovaQuestao.Alternativa.A = txtAlternativaA.Text.Trim();
                    NovaQuestao.Alternativa.B = txtAlternativaB.Text.Trim();
                    NovaQuestao.Alternativa.C = txtAlternativaC.Text.Trim();
                    NovaQuestao.Alternativa.D = txtAlternativaD.Text.Trim();
                    NovaQuestao.Bimestre = cmbBimestre.SelectedItem.ToString();
                    NovaQuestao.materia = cmbMateria.SelectedItem as Materia;
                    NovaQuestao.Alternativa.Correta = VerificaQuestaoCorreta();
                    _questoesServico.Adicionar(NovaQuestao);

                    MessageBox.Show("Questão adicionada com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.None;
                NovaQuestao = null;
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDisciplina.SelectedItem == null)
            {
                if (cmbSerie.SelectedItem == null)
                    AtualizaLista(_materiaServico.GetMateriaBySerieAndDisciplina(new Serie { Nome = "" }, new Disciplina { Nome = "" }));
                else
                    AtualizaLista(_materiaServico.GetMateriaBySerieAndDisciplina(cmbSerie.SelectedItem as Serie, new Disciplina { Nome = "" }));
            }
            else
            {
                if (cmbSerie.SelectedItem == null)
                    AtualizaLista(_materiaServico.GetMateriaBySerieAndDisciplina(new Serie { Nome = "" }, cmbDisciplina.SelectedItem as Disciplina));
                else
                    AtualizaLista(_materiaServico.GetMateriaBySerieAndDisciplina(cmbSerie.SelectedItem as Serie, cmbDisciplina.SelectedItem as Disciplina));
            }

        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbSerie.SelectedItem == null)
            {
                if (cmbDisciplina.SelectedItem == null)
                    AtualizaLista(_materiaServico.GetMateriaBySerieAndDisciplina(new Serie { Nome = "" }, new Disciplina { Nome = "" }));
                else
                    AtualizaLista(_materiaServico.GetMateriaBySerieAndDisciplina(new Serie { Nome = "" }, cmbDisciplina.SelectedItem as Disciplina));
            }
            else
            {
                if (cmbDisciplina.SelectedItem == null)
                    AtualizaLista(_materiaServico.GetMateriaBySerieAndDisciplina(cmbSerie.SelectedItem as Serie, new Disciplina { Nome = "" }));
                else
                    AtualizaLista(_materiaServico.GetMateriaBySerieAndDisciplina(cmbSerie.SelectedItem as Serie, cmbDisciplina.SelectedItem as Disciplina));
            }

        }
        private void AtualizaLista(IList<Materia> listaMateria)
        {
            cmbMateria.Items.Clear();

            if (listaMateria.Count <= 0)
            {
                MessageBox.Show("Nenhuma materia encontrada", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimparFiltro();
            }
                
            else
            {
                foreach (var item in listaMateria)
                {
                    cmbMateria.Items.Add(item);
                }
            }
        }

        private void CadastroQuestoesDialog_Load(object sender, EventArgs e)
        {

        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            LimparFiltro();
        }
        private void LimparFiltro()
        {
            cmbSerie.SelectedItem = null;
            cmbDisciplina.SelectedItem = null;
        }
    }
}
