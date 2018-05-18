using Mariana.Aplicacao;
using Mariana.Dominio;
using Mariana.WinApp.Features.MateriaModule;
using Mariana.WinApp.Nucleo;
using Mariana.WinApp.Nucleo.CadastroDialog;
using Mariana.WinApp.Nucleo.ControleUsuario;
using System.Collections.Generic;

namespace Mariana.WinApp.Features.SerieModule
{
    public class SerieGerenciadorFormulario : GerenciadorFormulario<Serie>
    {
        private UserControlBasico<Serie> _control;
        private Servico<Serie> _servico;

        private SerieGerenciadorFormulario()
        {

        }

        public static GerenciadorFormulario<Serie> ObterInstancia()
        {
            if (Instancia == null)
                Instancia = new SerieGerenciadorFormulario();

            return Instancia;
        }

        public override CadastroBasicoDialog<Serie> ObterDialogoCadastro()
        {
            return new FormCadastroSerie(ObterServico() as SerieService);
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

        public override UserControlBasico<Serie> ObterLista()
        {
            if (_control == null)
            {
                _control = new UserControlBasico<Serie>();
                IList<Serie> series = ObterServico().BuscarTodos();

                ObterLista().PopularListagem(series);
            }

            return _control;
        }

        public override Servico<Serie> ObterServico()
        {
            if (_servico == null)
                _servico = new SerieService(MateriaGerenciadorFormulario.ObterInstancia().ObterServico() as MateriaService);
            return _servico;
        }

        public override string ObterTitulo()
        {
            return "Cadastro de série";
        }

        public override TituloBotao ObterTituloBotao()
        {
            return new TituloBotao()
            {
                Adicionar = "Adicionar série",
                Atualizar = "Atualizar série",
                Excluir = "Excluir série"
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
