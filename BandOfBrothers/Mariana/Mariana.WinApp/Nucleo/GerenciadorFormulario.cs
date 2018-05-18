using Mariana.Aplicacao;
using Mariana.Dominio;
using Mariana.WinApp.Nucleo.CadastroDialog;
using Mariana.WinApp.Nucleo.ControleUsuario;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mariana.WinApp.Nucleo
{
    public abstract class GerenciadorFormulario<T> where T : Entidade
    {
        protected static GerenciadorFormulario<T> _instancia;

        protected static GerenciadorFormulario<T> Instancia
        {
            get{
            return _instancia;
            }
            set
            {
                _instancia = value;
            }
        }

        protected GerenciadorFormulario()
        {

        }

        public virtual void Adicionar()
        {
            try
            {
                CadastroBasicoDialog<T> dialog = ObterDialogoCadastro();
                DialogResult resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    ObterServico().Adicionar(dialog.Entidade);
                    IList<T> questoes = ObterServico().BuscarTodos();

                    ObterLista().PopularListagem(questoes);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public virtual void Atualizar()
        {
            try
            {
                CadastroBasicoDialog<T> dialog = ObterDialogoCadastro();
                T entidade = ObterLista().ObterItemSelecionado();
                if (entidade == null)
                {
                    MessageBox.Show("Selecione um registro para alterar");
                    return;
                }

                dialog.Entidade = entidade;

                DialogResult resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    ObterServico().Atualizar(dialog.Entidade);
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
                throw e;
            }
        }

        public virtual void GerarCSV(string caminho)
        {

        }

        public virtual void GerarXML(string caminho)
        {

        }

        public virtual void GerarPDF()
        {

        }

        public abstract UserControlBasico<T> ObterLista();
        public virtual UserControlBasico<T> Pesquisar(string pesquisa)
        {
            return new UserControlBasico<T>();
        }

        public abstract string ObterTitulo();
        public abstract Servico<T> ObterServico();
        public abstract CadastroBasicoDialog<T> ObterDialogoCadastro();
        public abstract EstadoBotao ObterEstadoBotao();
        public abstract VisibilidadeBotao ObterVisibilidadeBotao();
        public abstract TituloBotao ObterTituloBotao();

    }
}
