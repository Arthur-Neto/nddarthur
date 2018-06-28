using GeradorTestes.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorTestes.Cadastros.Questões
{
    class QuestoesGerenciadorFormulario : GerenciadorFormulario
    {
        #region Declaração de objetos

        QuestoesUSerControl _questoesUserControl = new QuestoesUSerControl();

        QuestoesServico _questoesServico = new QuestoesServico();



        SerieServico _serieServico = new SerieServico();

        DisciplinaServico _disciplinaServico = new DisciplinaServico();
        MateriaServico _materiaServico = new MateriaServico();
        CadastroQuestoesDialog _cadastroDialog;
        #endregion


        public override void Adicionar()
        {
            _cadastroDialog = new CadastroQuestoesDialog(_questoesServico, "Cadastro de questão");
            _cadastroDialog.InsertBimestreInComomBox();
            _cadastroDialog.InsertDisciplinaInComomBox(_disciplinaServico.GetAll());
            _cadastroDialog.InsertMateriaInComomBox(_materiaServico.GetAllMaterias());
            _cadastroDialog.InsertSerieInComomBox(_serieServico.GetAllSeries());
            DialogResult result = _cadastroDialog.ShowDialog();

           
            AtualizarLista();
        }
        public override string btnEdit => "Ver/Editar";
        public override void Editar()
        {
            if (_questoesUserControl.GetSelect() != null)
            {

                _cadastroDialog = new CadastroQuestoesDialog(_questoesServico, "Edição de Questão", _questoesUserControl.GetSelect());
                _cadastroDialog.InsertMateriaInComomBox(_materiaServico.GetAllMaterias());
                _cadastroDialog.InsertSerieInComomBox(_serieServico.GetAllSeries());
                _cadastroDialog.InsertDisciplinaInComomBox(_disciplinaServico.GetAll());
                _cadastroDialog.InsertBimestreInComomBox();
                _cadastroDialog.MarcaMateria();
                _cadastroDialog.ShowDialog();
                AtualizarLista();
            }
            else
            {
                MessageBox.Show("Você precisa selecionar uma Questão!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public override void Excluir()
        {
            if (_questoesUserControl.GetSelect() != null)
            {
                try
                {

                    if (MessageBox.Show("Tem certeza que deseja excluir?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var questaoDelete = _questoesUserControl.GetSelect();
                        _questoesServico.Delete(questaoDelete);
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
                MessageBox.Show("Você precisa selecionar uma Questão!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            AtualizarLista();
        }

        public override string ObtemTipoCadastro()
        {
            return "Cadastro de Questões";
        }

        public override UserControl ObterTipoUserControl()
        {
            return _questoesUserControl = new QuestoesUSerControl();
        }

        public void AtualizarLista()
        {
            _questoesUserControl.CarregaLista();

        }
    }
}
