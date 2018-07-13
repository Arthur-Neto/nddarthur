using Pizzaria.Aplicacao.Base;
using Pizzaria.Aplicacao.Features.Clientes;
using Pizzaria.Dominio.Features.Clientes;
using Pizzaria.Infra.Base;
using Pizzaria.WinApp.Base;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pizzaria.WinApp.Features.Clientes
{
    public class GerenciadorFormularioCliente : GerenciadorFormulario<Cliente>
    {
        private UserControlBasico<Cliente> _controle;
        private ClienteServico _clienteServico;
        private bool ehSelecionar = true;
        public GerenciadorFormularioCliente(ClienteServico clienteServico)
        {
            _clienteServico = clienteServico;
            _clienteServico = ObterServico() as ClienteServico;
        }

        public override FormCadastroBasico<Cliente> ObterDialogoCadastro()
        {
            return new FormCadastrarCliente(_clienteServico, ehSelecionar);
        }

        public override EstadoBotao ObterEstadoBotao()
        {
            return new EstadoBotao()
            {
                Adicionar = true,
                Atualizar = true,
                Excluir = true,
                Pesquisar = false
            };
        }

        public override void Adicionar()
        {
            ehSelecionar = false;
            FormCadastrarCliente formCadastrarCliente = new FormCadastrarCliente(_clienteServico, ehSelecionar);
            if (formCadastrarCliente.ShowDialog() == DialogResult.OK)
            {
                if (formCadastrarCliente.Entidade.Id == 0)
                    ObterServico().Adicionar(formCadastrarCliente.Entidade);
                else
                    ObterServico().Atualizar(formCadastrarCliente.Entidade);

                IEnumerable<Cliente> entidades = ObterServico().ObterTodos();

                ObterLista().PopularListagem(entidades);
            }
        }

        public override UserControlBasico<Cliente> ObterLista()
        {
            if (_controle == null)
            {
                _controle = new UserControlBasico<Cliente>();
                IEnumerable<Cliente> clientes = ObterServico().ObterTodos();

                ObterLista().PopularListagem(clientes);
            }

            return _controle;
        }

        public override IServico<Cliente> ObterServico()
        {
            if (_clienteServico == null)
                _clienteServico = new ClienteServico(RepositorioIoC.RepositorioCliente);
            return _clienteServico;
        }


        public override string ObterTitulo()
        {
            return "Cadastro de Clientes";
        }

        public override TituloBotao ObterTituloBotao()
        {
            return new TituloBotao()
            {
                Adicionar = "Adicionar/Atualizar Cliente",
                Atualizar = "Atualizar Cliente",
                Excluir = "Excluir Cliente",
                Pesquisar = "Pesquisar Cliente"
            };
        }

        public override VisibilidadeBotao ObterVisibilidadeBotao()
        {
            return new VisibilidadeBotao()
            {
                Adicionar = true,
                Atualizar = false,
                Excluir = true,
                Pesquisar = true
            };
        }
    }
}
