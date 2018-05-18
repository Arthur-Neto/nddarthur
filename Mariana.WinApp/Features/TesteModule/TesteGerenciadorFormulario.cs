using Mariana.Aplicacao;
using Mariana.Dominio;
using Mariana.WinApp.Features.DisciplinaModule;
using Mariana.WinApp.Features.MateriaModule;
using Mariana.WinApp.Features.QuestaoModule;
using Mariana.WinApp.Features.SerieModule;
using Mariana.WinApp.Nucleo;
using Mariana.WinApp.Nucleo.CadastroDialog;
using Mariana.WinApp.Nucleo.ControleUsuario;
using System.Collections.Generic;
using System;
using System.Windows.Forms;

namespace Mariana.WinApp.Features.TesteModule
{
    public class TesteGerenciadorFormulario : GerenciadorFormulario<Teste>
    {
        private UserControlBasico<Teste> _control;
        private Servico<Teste> _servico;

        private TesteGerenciadorFormulario()
        {

        }

        public static GerenciadorFormulario<Teste> ObterInstancia()
        {
            if (Instancia == null)
                Instancia = new TesteGerenciadorFormulario();

            return Instancia;
        }

        public override CadastroBasicoDialog<Teste> ObterDialogoCadastro()
        {
            return new FormCadastroTeste(ObterServico() as TesteService, DisciplinaGerenciadorFormulario.ObterInstancia().ObterServico() as DisciplinaService, MateriaGerenciadorFormulario.ObterInstancia().ObterServico() as MateriaService, SerieGerenciadorFormulario.ObterInstancia().ObterServico() as SerieService);
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

        public override UserControlBasico<Teste> ObterLista()
        {
            if (_control == null)
            {
                _control = new UserControlBasico<Teste>();
                IList<Teste> testes = ObterServico().BuscarTodos();

                ObterLista().PopularListagem(testes);
            }

            return _control;
        }

        public override UserControlBasico<Teste> Pesquisar(string pesquisa)
        {
            //_control = new UserControlBasico<Teste>();

            if (string.IsNullOrWhiteSpace(pesquisa) || pesquisa == "")
            {
                IList<Teste> testes2 = ObterServico().BuscarTodos();
                ObterLista().PopularListagem(testes2);
            }

            IList<Teste> testes = ObterServico().Pesquisar(pesquisa);

            ObterLista().PopularListagem(testes);

            return _control;
        }


        public override Servico<Teste> ObterServico()
        {
            if (_servico == null)
                _servico = new TesteService(QuestaoGerenciadorFormulario.ObterInstancia().ObterServico() as QuestaoService);
            return _servico;
        }

        public override string ObterTitulo()
        {
            return "Cadastro de teste";
        }

        public override TituloBotao ObterTituloBotao()
        {
            return new TituloBotao()
            {
                Adicionar = "Adicionar teste",
                Atualizar = "Atualizar teste",
                Excluir = "Excluir teste",
                Pesquisar = "Pesquisar Teste"
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

        public override void GerarCSV(string caminho)
        {
            _servico.GerarArquivo(_control.ObterItemSelecionado(), caminho, 2);
        }

        public override void GerarXML(string caminho)
        {
            _servico.GerarArquivo(_control.ObterItemSelecionado(), caminho, 3);
        }

        public override void GerarPDF()
        {
            Teste teste = _control.ObterItemSelecionado();
            if (teste != null)
            {
                _servico.GerarArquivo(_control.ObterItemSelecionado(), "", 4);
            }
            else
            {
                MessageBox.Show("Selecione um item para gerar o PDF");
            }
        }
    }
}
