using ArthurProva.Aplicacao;
using ArthurProva.Domain;
using ArthurProva.WinApp.Base.CadastroDialog;
using ArthurProva.WinApp.Base.ControlBasico;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ArthurProva.WinApp.Base
{
    public abstract class GerenciadorFormulario<T> where T : Entidade
    {
        protected static GerenciadorFormulario<T> _instancia;

        protected CadastroBasicoDialog<T> _dialog;

        protected static GerenciadorFormulario<T> Instancia
        {
            get => _instancia;
            set => _instancia = value;
        }

        protected GerenciadorFormulario()
        {

        }

        public virtual void Adicionar()
        {
            try
            {
                _dialog = ObterDialogoCadastro();
                DialogResult resultado = _dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    ObterServico().Adicionar(_dialog.Entidade);
                    IList<T> entidades = ObterServico().BuscarTodos();

                    ObterLista().PopularListagem(entidades);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public virtual void Atualizar()
        {
            try
            {
                _dialog = ObterDialogoCadastro();
                T entidade = ObterLista().ObterItemSelecionado();
                if (entidade == null)
                {
                    MessageBox.Show("Selecione um registro para alterar");
                    return;
                }

                _dialog.Entidade = entidade;

                DialogResult resultado = _dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    ObterServico().Atualizar(_dialog.Entidade);
                    IList<T> entidades = ObterServico().BuscarTodos();

                    ObterLista().PopularListagem(entidades);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual void Excluir()
        {
            try
            {
                T entidade = ObterLista().ObterItemSelecionado();
                if (entidade == null)
                {
                    MessageBox.Show("Selecione um registro para excluir");
                    return;
                }

                DialogResult result = MessageBox.Show("Você deseja excluir este registro?",
                    "Confirmação de exclusão", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        ObterServico().Excluir(entidade);
                        ObterLista().PopularListagem(ObterServico().BuscarTodos());
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public abstract UserControlBasico<T> ObterLista();
        public abstract string ObterTitulo();
        public abstract Service<T> ObterServico();
        public abstract CadastroBasicoDialog<T> ObterDialogoCadastro();
        public abstract EstadoBotao ObterEstadoBotao();
        public abstract VisibilidadeBotao ObterVisibilidadeBotao();
        public abstract TituloBotao ObterTituloBotao();
    }
}
