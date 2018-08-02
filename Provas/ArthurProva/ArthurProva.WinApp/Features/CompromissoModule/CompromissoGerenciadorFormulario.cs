using ArthurProva.Aplicacao;
using ArthurProva.Domain;
using ArthurProva.WinApp.Base;
using ArthurProva.WinApp.Base.CadastroDialog;
using ArthurProva.WinApp.Base.ControlBasico;
using ArthurProva.WinApp.Features.ContatoModule;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ArthurProva.WinApp.Features.CompromissoModule
{
    public class CompromissoGerenciadorFormulario : GerenciadorFormulario<Compromisso>
    {
        private UserControlBasico<Compromisso> _control;
        private CompromissoService _servico;

        public static GerenciadorFormulario<Compromisso> ObterInstancia()
        {
            if (Instancia == null)
                Instancia = new CompromissoGerenciadorFormulario();

            return Instancia;
        }

        public override void Atualizar()
        {
            try
            {
                _dialog = ObterDialogoCadastro();
                Compromisso entidade = ObterLista().ObterItemSelecionado();
                if (entidade == null)
                {
                    MessageBox.Show("Selecione um registro para alterar");
                    return;
                }


                entidade.Contatos = _servico.CarregarPorContato(entidade.Id);
                _dialog.Entidade = entidade;

                DialogResult resultado = _dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    ObterServico().Atualizar(_dialog.Entidade);
                    IList<Compromisso> entidades = ObterServico().BuscarTodos();

                    ObterLista().PopularListagem(entidades);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override CadastroBasicoDialog<Compromisso> ObterDialogoCadastro()
        {
            return new FormCadastroCompromisso(ObterServico() as CompromissoService);
        }

        public override EstadoBotao ObterEstadoBotao()
        {
            return new EstadoBotao()
            {
                Adicionar = true,
                Atualizar = true,
                Excluir = true
            };
        }

        public override UserControlBasico<Compromisso> ObterLista()
        {
            if (_control == null)
            {
                _control = new UserControlBasico<Compromisso>();
                IList<Compromisso> compromissos = ObterServico().BuscarTodos();

                ObterLista().PopularListagem(compromissos);
            }

            return _control;
        }

        public override Service<Compromisso> ObterServico()
        {
            if (_servico == null)
                _servico = new CompromissoService(new ContatoService(_servico));
            return _servico;
        }

        public override string ObterTitulo()
        {
            return "Cadastro de compromisso";
        }

        public override TituloBotao ObterTituloBotao()
        {
            return new TituloBotao()
            {
                Adicionar = "Adicionar compromisso",
                Atualizar = "Atualizar compromisso",
                Excluir = "Excluir compromisso"
            };
        }

        public override VisibilidadeBotao ObterVisibilidadeBotao()
        {
            return new VisibilidadeBotao()
            {
                Adicionar = true,
                Atualizar = true,
                Excluir = true
            };
        }
    }
}
