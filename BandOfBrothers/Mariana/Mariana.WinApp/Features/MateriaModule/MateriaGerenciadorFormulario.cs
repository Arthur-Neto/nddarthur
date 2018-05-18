using Mariana.Aplicacao;
using Mariana.Dominio;
using Mariana.WinApp.Features.DisciplinaModule;
using Mariana.WinApp.Features.QuestaoModule;
using Mariana.WinApp.Features.SerieModule;
using Mariana.WinApp.Nucleo;
using Mariana.WinApp.Nucleo.CadastroDialog;
using Mariana.WinApp.Nucleo.ControleUsuario;
using System.Collections.Generic;

namespace Mariana.WinApp.Features.MateriaModule
{
    public class MateriaGerenciadorFormulario : GerenciadorFormulario<Materia>
    {
        private UserControlBasico<Materia> _control;
        private Servico<Materia> _servico;

        private MateriaGerenciadorFormulario()
        {
            

        }

        public static GerenciadorFormulario<Materia> ObterInstancia()
        {
            if (Instancia == null)
                Instancia = new MateriaGerenciadorFormulario();

            return Instancia;
        }

        public override CadastroBasicoDialog<Materia> ObterDialogoCadastro()
        {
            return new FormCadastroMateria(ObterServico() as MateriaService, DisciplinaGerenciadorFormulario.ObterInstancia().ObterServico() as DisciplinaService, SerieGerenciadorFormulario.ObterInstancia().ObterServico() as SerieService);
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

        public override UserControlBasico<Materia> ObterLista()
        {
            if (_control == null)
            {
                _control = new UserControlBasico<Materia>();
                IList<Materia> materias = ObterServico().BuscarTodos();

                ObterLista().PopularListagem(materias);
            }

            return _control;
        }
        public override UserControlBasico<Materia> Pesquisar(string pesquisa)
        {
            if (string.IsNullOrWhiteSpace(pesquisa) || pesquisa == "")
            {
                IList<Materia> materias2 = ObterServico().BuscarTodos();
                ObterLista().PopularListagem(materias2);
            }

            IList<Materia> materias = ObterServico().Pesquisar(pesquisa);

            ObterLista().PopularListagem(materias);

            return _control;
        }

        public override Servico<Materia> ObterServico()
        {
            if (_servico == null)
                _servico = new MateriaService(QuestaoGerenciadorFormulario.ObterInstancia().ObterServico() as QuestaoService);
            return _servico;
        }

        public override string ObterTitulo()
        {
            return "Cadastro de matéria";
        }

        public override TituloBotao ObterTituloBotao()
        {
            return new TituloBotao()
            {
                Adicionar = "Adicionar matéria",
                Atualizar = "Atualizar matéria",
                Excluir = "Excluir matéria",
                Pesquisar = "Pesquisar matéria"
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
