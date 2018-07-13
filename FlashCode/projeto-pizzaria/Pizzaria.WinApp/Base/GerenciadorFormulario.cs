using Pizzaria.Aplicacao.Base;
using Pizzaria.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pizzaria.WinApp.Base
{
    public abstract class GerenciadorFormulario<T> where T : Entidade
    {
        public virtual void Adicionar()
        {
            try
            {
                FormCadastroBasico<T> dialog = ObterDialogoCadastro();
                DialogResult resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    ObterServico().Adicionar(dialog.Entidade);
                    IEnumerable<T> entidades = ObterServico().ObterTodos();

                    ObterLista().PopularListagem(entidades);
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
                FormCadastroBasico<T> dialog = ObterDialogoCadastro();
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
                    IEnumerable<T> entidades = ObterServico().ObterTodos();

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
                        ObterLista().PopularListagem(ObterServico().ObterTodos());
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

        public abstract UserControlBasico<T> ObterLista();
        public virtual UserControlBasico<T> Pesquisar(string pesquisa)
        {
            return new UserControlBasico<T>();
        }

        public abstract IServico<T> ObterServico();
        public abstract FormCadastroBasico<T> ObterDialogoCadastro();
        public abstract string ObterTitulo();
        public abstract EstadoBotao ObterEstadoBotao();
        public abstract VisibilidadeBotao ObterVisibilidadeBotao();
        public abstract TituloBotao ObterTituloBotao();
    }
}
