using GeradorTestes.Servicos;
using GeradorTestes.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorTestes.Cadastros.Disciplinas
{
    public class DisciplinaGerenciadorFormulario : GerenciadorFormulario
    {
        DisciplinaServico _disciplinaServico = new DisciplinaServico();
        ListaDisciplinaUserControl _disciplinaUserControl;

        public override void Adicionar()
        {
            CadastroDisciplinaDialogs _cadastroDisciplinaDialog = new CadastroDisciplinaDialogs(_disciplinaServico, "Cadastro de disciplinas", null);

            _cadastroDisciplinaDialog.ShowDialog();


            AtualizarLista();
        }

        public override void Editar()
        {

            if (_disciplinaUserControl.GetSelect() != null)
            {

                CadastroDisciplinaDialogs _editarDisciplinaDialog = new CadastroDisciplinaDialogs(_disciplinaServico, "Edição de disciplina", _disciplinaUserControl.GetSelect());
                _editarDisciplinaDialog.ShowDialog();
                AtualizarLista();
            }
            else
            {
                 throw new Exception("Você precisa selecionar uma Disciplina!");
            }
        }


        public override void Excluir()
        {
            if (_disciplinaUserControl.GetSelect() != null)
            {

                try
                {
                    if (MessageBox.Show("Tem certeza que deseja excluir?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _disciplinaServico.Delete(_disciplinaUserControl.GetSelect());
                        MessageBox.Show("Exluído com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                AtualizarLista();
            }
            else
            {
                MessageBox.Show("Você precisa selecionar uma Disciplina!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override string ObtemTipoCadastro()
        {
            return "Cadastro de Disciplinas";
        }

        public override UserControl ObterTipoUserControl()
        {
            return _disciplinaUserControl = new ListaDisciplinaUserControl();
        }

        public void AtualizarLista()
        {

            _disciplinaUserControl.CarregaLista();

        }
    }
}
