using GeradorTestes.Domain;
using GeradorTestes.Servicos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace GeradorTestes.Cadastros.Testes
{
    public partial class GerarTestesDialog : Form
    {

        MateriaServico _materiaServico = new MateriaServico();
        QuestoesServico _questoesServico = new QuestoesServico();
        TesteServico _testeServico = new TesteServico();
        public GerarTestesDialog()
        {
            InitializeComponent();
            InsertBimestreInComomBox();
        }

        private void btnGerarTeste_Click(object sender, EventArgs e)
        {

            var materia = new Materia();
            var questao = new Questao();
            var teste = new Teste();

            try
            {
                VerificaCampos();
                materia.Nome = cmbMateria.SelectedItem.ToString();
                questao.Bimestre = cmbBimestre.SelectedItem.ToString();
                teste.QuantidadeQuestoes = Convert.ToInt32(quantidadeQuestoes.Value);
                teste.dataGeracao = DateTime.Now;
                teste.Descricao = "Descrição";
                teste.listaQuestao = _questoesServico.GetAllRandom(teste, materia, questao);

               _testeServico.GerarTeste(teste, materia, questao);

                MessageBox.Show("Adicionado com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.None;
              
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void VerificaCampos()
        {
            if (cmbBimestre.SelectedItem == null)
            {
                throw new Exception("Selecione um Bimestre");
            }

            if (cmbMateria.SelectedItem == null)
            {
                throw new Exception("Selecione uma Matéria");
            }

            if (quantidadeQuestoes.Value <= 0)
            {
                throw new Exception("A quantidade de questões deve ser maior que zero");
            }
        }
        public void InsertSerieInComomBox(IList<Serie> serie)
        {

            foreach (var item in serie)
            {
                cmbSerie.Items.Add(item);
            }
        }

        public void InsertDisciplinaInComomBox(IList<Disciplina> disciplina)
        {

            foreach (var item in disciplina)
            {
                cmbDisciplina.Items.Add(item);
            }
        }

        public void InsertMateriaInComomBox(IList<Materia> materia)
        {

            foreach (var item in materia)
            {
                cmbMateria.Items.Add(item);
            }
        }

        public void InsertBimestreInComomBox()
        {

            cmbBimestre.Items.Add("1º Bimestre");
            cmbBimestre.Items.Add("2º Bimestre");
            cmbBimestre.Items.Add("3º Bimestre");
            cmbBimestre.Items.Add("4º Bimestre");
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

        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnLimpar_Click(object sender, EventArgs e)
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
