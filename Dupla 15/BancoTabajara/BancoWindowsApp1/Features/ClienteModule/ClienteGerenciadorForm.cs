using BancoApp.dominio;
using BancoApp.Infra.Data;
using BancoWindowsApp1.Features.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoWindowsApp1.Features.ClienteModule
{
    public class ClienteGerenciadorForm : GerenciadorFormulario
    {
        private ClienteControl _clienteControl;
        private readonly ClienteMem _repositorioCliente;

        public ClienteGerenciadorForm(ClienteMem repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }

        public override void Adicionar()
        {
            CadastroCliente dialog = new CadastroCliente();
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                _repositorioCliente.AdicionarCliente(dialog.NovoCliente);
                List<Cliente> clientes = _repositorioCliente.ListarCliente();
                _clienteControl.popularListagemCliente(clientes);
            }
        }

        public override UserControl CarregarListagem()
        {
            if(_clienteControl == null)
                _clienteControl = new ClienteControl();

            return _clienteControl;
        }

        public override string ObtemTipoCadastro()
        {
            return "Cadastro de Clientes";
        }

        public override EstadoBotoes ObtemTipoBotoes()
        {
            return new EstadoBotoes
            {
                Cadastrar = true,
                Depositar = false,
                Sacar = false,
                Transferir = false,
                Extrato = false,
                Excluir = true
            };
        }

        public override void Excluir()
        {
            Cliente clienteSelecionado = _clienteControl.ObtemClienteSelecionado();
            DialogResult resultado = DialogResult.No;

            if (clienteSelecionado != null)
            {
                resultado = MessageBox.Show(
                   "Tem certeza que deseja excluir o cliente: " + clienteSelecionado.Nome, "Atenção",
                   MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    _repositorioCliente.Excluir(clienteSelecionado);
                    List<Cliente> cliente = _repositorioCliente.ListarCliente();
                    _clienteControl.popularListagemCliente(cliente);
                }

            }
            else
            {
                MessageBox.Show("Selecione um cliente para excluir", "Atenção",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
