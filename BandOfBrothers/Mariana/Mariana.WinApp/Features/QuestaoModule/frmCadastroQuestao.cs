using Mariana.Aplicacao;
using Mariana.Dominio;
using Mariana.Dominio.Exceptions.Disciplina;
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

namespace Mariana.WinApp.Features.QuestaoModule
{
    public partial class frmCadastroQuestao : Form
    {
        private Questao questao;

        IList<Disciplina> ListaDisciplinas;
        IList<Materia> ListaMaterias;
        QuestaoControlResposta userControlResposta = new QuestaoControlResposta();

        public IList<Resposta> Respostas { get; }
        public IList<Resposta> RespostasAdicionadas { get; set; }
        public IList<Resposta> RespostasExcluidas { get; set; }

        public frmCadastroQuestao(IList<Disciplina> disciplinas, IList<Materia> materias, IList<Resposta> resposta)
        {
            InitializeComponent();
            if (resposta != null)
                Respostas = resposta;
            else
                Respostas = new List<Resposta>();

            ListaDisciplinas = disciplinas;
            ListaMaterias = materias;

            txtId.Text = "0";
            cmbMateria.Items.Clear();
            cmbDisciplina.Items.Clear();
            cmbBimestre.Items.Clear();

            foreach (var item in ListaDisciplinas)
            {
                cmbDisciplina.Items.Add(item);
            }
            foreach (var item in Enum.GetValues(typeof(Bimestre)))
            {
                cmbBimestre.Items.Add(item);
            }


            userControlResposta.Dock = DockStyle.Fill;
            panelResposta.Controls.Add(userControlResposta);
        }

        public Questao NovaQuestao
        {
            get
            {
                return questao;
            }
            set
            {
                questao = value;

                if (questao.Enunciado != null)
                {
                    txtId.Text = Convert.ToString(questao.Id);
                    txtEnunciado.Text = questao.Enunciado;
                    cmbBimestre.Text = questao.Bimestre.ToString();

                    if (questao.Disciplina != null)
                        cmbDisciplina.Text = questao.Disciplina.ToString();
                    if (questao.Materia != null)
                    {
                        cmbMateria.Text = questao.Materia.ToString();
                        cmbBimestre.Text = questao.Bimestre.ToString();
                    }
                    if (questao.Respostas != null)
                        userControlResposta.PopularListagemRespostas(Respostas);

                    EnableFields();
                    btnCadastrarQuestao.Text = "Atualizar";
                }
                else
                {
                    btnCadastrarQuestao.Text = "Cadastrar";
                }
            }
        }

        private void EnableFields()
        {
            cmbDisciplina.Enabled = true;
            cmbMateria.Enabled = true;
            cmbBimestre.Enabled = true;
            txtEnunciado.Enabled = true;
            btnAddResponse.Enabled = true;
            btnRemoveResponse.Enabled = true;
            ckbCorreta.Enabled = true;
            txtResposta.Enabled = true;
            btnCadastrarQuestao.Enabled = true;
        }

        public void AtualizarMaterias()
        {
            cmbMateria.Items.Clear();
            foreach (Materia materia in ListaMaterias)
            {
                if (materia.Disciplina.Id == questao.Disciplina.Id)
                {
                    cmbMateria.Items.Add(materia);
                }
            }
        }


        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            questao.Materia = cmbMateria.SelectedItem as Materia;

            cmbBimestre.Enabled = true;
        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            questao.Disciplina = cmbDisciplina.SelectedItem as Disciplina;

            AtualizarMaterias();

            cmbMateria.Enabled = true;
        }

        private void cmbBimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            questao.Bimestre = (Bimestre)cmbBimestre.SelectedItem;

            txtEnunciado.Enabled = true;
            btnAddResponse.Enabled = true;
            btnRemoveResponse.Enabled = true;
            ckbCorreta.Enabled = true;
            txtResposta.Enabled = true;
            btnCadastrarQuestao.Enabled = true;
        }

        private void btnCadastrarQuestao_Click(object sender, EventArgs e)
        {
            try
            {
                DominioHelper.ValidarEnunciado(txtEnunciado.Text);
                DominioHelper.ValidarListaRespostas(Respostas);
                questao.Enunciado = txtEnunciado.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                DialogResult = DialogResult.None;
            }
        }

        private void btnAddResponse_Click_1(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in Respostas)
                {
                    if (item.CorpoResposta == txtResposta.Text)
                        throw new DuplicadaException(String.Format("Resposta duplicada"));
                }
                DominioHelper.ValidarRespostaVazio(txtResposta.Text);
                DominioHelper.ValidarResposta(txtResposta.Text);
                Resposta res = new Resposta();
                res.CorpoResposta = txtResposta.Text;
                res.Correta = ckbCorreta.Checked;
                RespostasAdicionadas.Add(res);
                Respostas.Add(res);

                txtResposta.Text = "";
                ckbCorreta.Checked = false;
                userControlResposta.PopularListagemRespostas(Respostas);
            }
            catch (DuplicadaException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Não deve inserir uma resposta vazia ou com mais de um espaço em branco");
            }


        }

        private void btnRemoveResponse_Click_1(object sender, EventArgs e)
        {
            Resposta res = userControlResposta.GetResposta();
            Respostas.Remove(res);
            RespostasExcluidas.Add(res);

            txtResposta.Text = "";
            ckbCorreta.Checked = false;
            userControlResposta.PopularListagemRespostas(Respostas);
        }
    }
}
