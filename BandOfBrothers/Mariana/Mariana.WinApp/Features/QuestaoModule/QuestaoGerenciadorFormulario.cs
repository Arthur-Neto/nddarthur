using Mariana.Aplicacao;
using Mariana.Dominio;
using Mariana.WinApp.Features.DisciplinaModule;
using Mariana.WinApp.Features.MateriaModule;
using Mariana.WinApp.Nucleo;
using Mariana.WinApp.Nucleo.CadastroDialog;
using Mariana.WinApp.Nucleo.ControleUsuario;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mariana.WinApp.Features.QuestaoModule
{
    public class QuestaoGerenciadorFormulario : GerenciadorFormulario<Questao>
    {
        private UserControlBasico<Questao> _control;
        private QuestaoService _servico;

        private QuestaoGerenciadorFormulario()
        {

        }

        public override void Atualizar()
        {
            try
            {
                CadastroBasicoDialog<Questao> dialog = ObterDialogoCadastro();
                Questao entidade = ObterLista().ObterItemSelecionado();
                if (entidade == null)
                {
                    MessageBox.Show("Selecione um registro para alterar");
                    return;
                }

                entidade.Respostas = _servico.BuscarTodasRespostas(entidade.Id);

                dialog.Entidade = entidade;

                DialogResult resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    ObterServico().Atualizar(dialog.Entidade);
                    IList<Questao> entidades = ObterServico().BuscarTodos();

                    ObterLista().PopularListagem(entidades);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static GerenciadorFormulario<Questao> ObterInstancia()
        {
            if (Instancia == null)
                Instancia = new QuestaoGerenciadorFormulario();

            return Instancia;
        }

        public override CadastroBasicoDialog<Questao> ObterDialogoCadastro()
        {
            return new FormCadastroQuestao(ObterServico() as QuestaoService, DisciplinaGerenciadorFormulario.ObterInstancia().ObterServico() as DisciplinaService, MateriaGerenciadorFormulario.ObterInstancia().ObterServico() as MateriaService);
        }

        public override EstadoBotao ObterEstadoBotao()
        {
            return new EstadoBotao()
            {
                Adicionar = true,
                Atualizar = true,
                Excluir = true,
                Pesquisar = true 
            };
        }

        public override UserControlBasico<Questao> ObterLista()
        {
            if (_control == null)
            {
                _control = new UserControlBasico<Questao>();
                IList<Questao> questoes = ObterServico().BuscarTodos();

                ObterLista().PopularListagem(questoes);
            }

            return _control;
        }
        public override UserControlBasico<Questao> Pesquisar(string pesquisa)
        {
            //_control = new UserControlBasico<Teste>();

            if (string.IsNullOrWhiteSpace(pesquisa) || pesquisa == "")
            {
                IList<Questao> questao2 = ObterServico().BuscarTodos();
                ObterLista().PopularListagem(questao2);
            }

            IList<Questao> questoes = ObterServico().Pesquisar(pesquisa);

            ObterLista().PopularListagem(questoes);

            return _control;
        }


        public override Servico<Questao> ObterServico()
        {
            if (_servico == null)
                _servico = new QuestaoService(new RespostaService());
            return _servico;
        }

        public override string ObterTitulo()
        {
            return "Cadastro de questão";
        }

        public override TituloBotao ObterTituloBotao()
        {
            return new TituloBotao()
            {
                Adicionar = "Adicionar questão",
                Atualizar = "Atualizar questão",
                Excluir = "Excluir questão",
                Pesquisar = "Pesquisar questão"
            };
        }

        public override VisibilidadeBotao ObterVisibilidadeBotao()
        {
            return new VisibilidadeBotao()
            {
                Adicionar = true,
                Atualizar = true,
                Excluir = true,
                Pesquisar = true
            };
        }
    }
}
