using GeradorTestes.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorTestes.Cadastros.Series
{
    public class SerieGerenciadorFormulario : GerenciadorFormulario
    {
        CadastroSerieDialog _cadastroSerieDialog;
        SerieServico _serieServico = new SerieServico();
        ListaSerieUserControl _serieUserControl = new ListaSerieUserControl();
        public override void Adicionar()
        {
            _cadastroSerieDialog = new CadastroSerieDialog(_serieServico, "Cadastro de séries", null);
            _cadastroSerieDialog.ShowDialog();

            AtualizarLista();
        }

        public override void Editar()
        {
            if (_serieUserControl.GetSelect() != null)
            {
                _cadastroSerieDialog = new CadastroSerieDialog(_serieServico, "Edição de série", _serieUserControl.GetSelect());
                _cadastroSerieDialog.ShowDialog();
                AtualizarLista();
            }
            else
            {
                throw new Exception("Você precisa selecionar uma série!");
            }
        }

        public override void Excluir()
        {
            if (_serieUserControl.GetSelect() != null)
            {

                try
                {
                    if (MessageBox.Show("Tem certeza que deseja excluir?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _serieServico.Excluir(_serieUserControl.GetSelect());
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
            return "Cadastro de Séries";
        }

        public override UserControl ObterTipoUserControl()
        {
            return _serieUserControl = new ListaSerieUserControl();
        }

        public void AtualizarLista()
        {
            _serieUserControl.CarregaLista();
        }

    }
}
