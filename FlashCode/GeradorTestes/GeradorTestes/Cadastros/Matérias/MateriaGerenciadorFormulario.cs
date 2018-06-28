using GeradorTestes.Domain;
using GeradorTestes.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorTestes.Cadastros.Matérias
{
    class MateriaGerenciadorFormulario : GerenciadorFormulario
    {
        #region Declaração de objetos

        ListaMateriaUserControl _listaMateriaUserControl = new ListaMateriaUserControl();

        SerieServico _serieServico = new SerieServico();

        MateriaServico _materiaServico = new MateriaServico();

        DisciplinaServico _disciplinaServico = new DisciplinaServico();
        CadastroMateriasDialog _cadastroMateriasDialog;
        #endregion



        public override void Adicionar()
        {
            _cadastroMateriasDialog = new CadastroMateriasDialog(_materiaServico, "Cadastro de matérias");
            _cadastroMateriasDialog.CriaListaSerie(_serieServico.GetAllSeries());
            _cadastroMateriasDialog.CriaListaDisciplina(_disciplinaServico.GetAll());
            _cadastroMateriasDialog.ShowDialog();

            AtualizarLista();
        }

        public override void Editar()
        {
            if (_listaMateriaUserControl.GetSelect() != null)
            {
                _cadastroMateriasDialog = new CadastroMateriasDialog(_materiaServico,"Edição de Matérias",  _listaMateriaUserControl.GetSelect());
                _cadastroMateriasDialog.CriaListaSerie(_serieServico.GetAllSeries());
                _cadastroMateriasDialog.CriaListaDisciplina(_disciplinaServico.GetAll());
                _cadastroMateriasDialog.ShowDialog();

                AtualizarLista();
            }
            else
            {
                throw new Exception("Você precisa selecionar uma Matéria!");
            }
        }

        public override void Excluir()
        {
            if (_listaMateriaUserControl.GetSelect() != null)
            {
                try
                {

                    if (MessageBox.Show("Tem certeza que deseja excluir?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var materiaDelete = _listaMateriaUserControl.GetSelect();
                        _materiaServico.Delete(materiaDelete);
                        MessageBox.Show("Exluído com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                AtualizarLista();
            }
            else
            {
                MessageBox.Show("Você precisa selecionar uma Matéria!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override string ObtemTipoCadastro()
        {
            return "Cadastro de Materias";
        }

        public override UserControl ObterTipoUserControl()
        {
            return _listaMateriaUserControl = new ListaMateriaUserControl();
        }

        public void AtualizarLista()
        {

            _listaMateriaUserControl.CarregaLista();

        }
    }
}
