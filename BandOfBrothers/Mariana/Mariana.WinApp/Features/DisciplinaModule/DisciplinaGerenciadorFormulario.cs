using Mariana.Aplicacao;
using Mariana.Dominio;
using Mariana.WinApp.Features.MateriaModule;
using Mariana.WinApp.Nucleo;
using Mariana.WinApp.Nucleo.CadastroDialog;
using Mariana.WinApp.Nucleo.ControleUsuario;
using System.Collections.Generic;

namespace Mariana.WinApp.Features.DisciplinaModule
{
    public class DisciplinaGerenciadorFormulario : GerenciadorFormulario<Disciplina>
    {
        private UserControlBasico<Disciplina> _control;
        private Servico<Disciplina> _servico;

        private DisciplinaGerenciadorFormulario()
        {
            
        }

        public static GerenciadorFormulario<Disciplina> ObterInstancia()
        {
            if (Instancia == null)
                Instancia = new DisciplinaGerenciadorFormulario();

            return Instancia;
        }

        public override CadastroBasicoDialog<Disciplina> ObterDialogoCadastro()
        {
            return new FormCadastroDisciplina(ObterServico() as DisciplinaService);
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

        public override UserControlBasico<Disciplina> ObterLista()
        {
            if (_control == null)
            {
                _control = new UserControlBasico<Disciplina>();
                IList<Disciplina> disciplinas = ObterServico().BuscarTodos();

                ObterLista().PopularListagem(disciplinas);
            }

            return _control;
        }
        public override UserControlBasico<Disciplina> Pesquisar(string pesquisa)
        {
            //_control = new UserControlBasico<Teste>();

            if (string.IsNullOrWhiteSpace(pesquisa) || pesquisa == "")
            {
                IList<Disciplina> disciplina2 = ObterServico().BuscarTodos();
                ObterLista().PopularListagem(disciplina2);
            }

            IList<Disciplina> disciplinas = ObterServico().Pesquisar(pesquisa);

            ObterLista().PopularListagem(disciplinas);

            return _control;
        }

        public override Servico<Disciplina> ObterServico()
        {
            if (_servico == null)
                _servico = new DisciplinaService(MateriaGerenciadorFormulario.ObterInstancia().ObterServico() as MateriaService);
            return _servico;
        }

        public override string ObterTitulo()
        {
            return "Cadastro de disciplina";
        }

        public override TituloBotao ObterTituloBotao()
        {
            return new TituloBotao()
            {
                Adicionar = "Adicionar disciplina",
                Atualizar = "Atualizar disciplina",
                Excluir = "Excluir disciplina",
                Pesquisar = "Pesquisar disciplina"
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
