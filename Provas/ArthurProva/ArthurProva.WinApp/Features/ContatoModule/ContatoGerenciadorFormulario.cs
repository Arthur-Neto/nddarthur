using ArthurProva.Aplicacao;
using ArthurProva.Domain;
using ArthurProva.WinApp.Base;
using ArthurProva.WinApp.Base.CadastroDialog;
using ArthurProva.WinApp.Base.ControlBasico;
using ArthurProva.WinApp.Features.CompromissoModule;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ArthurProva.WinApp.Features.ContatoModule
{
    public class ContatoGerenciadorFormulario : GerenciadorFormulario<Contato>
    {
        private UserControlBasico<Contato> _control;
        private ContatoService _servico;

        private ContatoGerenciadorFormulario()
        {

        }

        public static GerenciadorFormulario<Contato> ObterInstancia()
        {
            if (Instancia == null)
                Instancia = new ContatoGerenciadorFormulario();

            return Instancia;
        }

        public override CadastroBasicoDialog<Contato> ObterDialogoCadastro()
        {
            return new FormCadastroContato(ObterServico() as ContatoService);
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

        public override UserControlBasico<Contato> ObterLista()
        {
            if (_control == null)
            {
                _control = new UserControlBasico<Contato>();
                IList<Contato> contatos = ObterServico().BuscarTodos();

                ObterLista().PopularListagem(contatos);
            }

            return _control;
        }

        public override Service<Contato> ObterServico()
        {
            if (_servico == null)
                _servico = new ContatoService(CompromissoGerenciadorFormulario.ObterInstancia().ObterServico() as CompromissoService);
            return _servico;
        }

        public override string ObterTitulo()
        {
            return "Cadastro de contato";
        }

        public override TituloBotao ObterTituloBotao()
        {
            return new TituloBotao()
            {
                Adicionar = "Adicionar contato",
                Atualizar = "Atualizar contato",
                Excluir = "Excluir contato"
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
