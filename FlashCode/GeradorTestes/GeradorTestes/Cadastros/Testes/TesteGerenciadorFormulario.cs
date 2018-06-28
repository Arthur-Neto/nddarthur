using GeradorTestes.Domain;
using GeradorTestes.Servicos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorTestes.Cadastros.Testes
{
    public class TesteGerenciadorFormulario : GerenciadorFormulario
    {
        ListaTestesUserControl _testeUserControl = new ListaTestesUserControl();
        SerieServico serieServico = new SerieServico();
        DisciplinaServico disciplinaServico = new DisciplinaServico();
        MateriaServico materiaServico = new MateriaServico();
        TesteServico testeServico = new TesteServico();
        public override void Adicionar()
        {
            GerarTestesDialog gerarTesteDialog = new GerarTestesDialog();
            gerarTesteDialog.InsertDisciplinaInComomBox(disciplinaServico.GetAll());
            gerarTesteDialog.InsertMateriaInComomBox(materiaServico.GetAllMaterias());
            gerarTesteDialog.InsertSerieInComomBox(serieServico.GetAllSeries());
            gerarTesteDialog.ShowDialog();
            AtualizarLista();
        }

        public override void Editar()
        {
            if (_testeUserControl.GetSelected() != null)
            {
                try
                {
                    var testeSelecionado = _testeUserControl.GetSelected();

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Title = "Salvar como";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        testeServico.GerarTeste(testeSelecionado, saveFileDialog.FileName);
                       // Process.Start(saveFileDialog.FileName);

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Você precisa selecionar um teste!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override void Excluir()
        {
            if (_testeUserControl.GetSelected() != null)
            {
                try
                {

                    if (MessageBox.Show("Tem certeza que deseja excluir?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var testeDelete = _testeUserControl.GetSelected();
                        testeServico.Deletar(testeDelete);
                        MessageBox.Show("Exluído com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Você precisa selecionar um teste!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            AtualizarLista();
        }

        public override string ObtemTipoCadastro()
        {
            return "Gerador de Testes";
        }
        public override string btnEdit { get => "Gerar Teste"; }
        public override UserControl ObterTipoUserControl()
        {
            return _testeUserControl = new ListaTestesUserControl();
        }
        public void AtualizarLista()
        {
            _testeUserControl.CarregaLista();

        }
    }
}