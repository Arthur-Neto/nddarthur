using BancoApp.dominio;
using BancoApp.Infra.Data;
using BancoWindowsApp1.Features.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoWindowsApp1.Features.ContaCorrenteModule
{
    public class ContaCorrenteGerenciadorForm : GerenciadorFormulario
    {
        private ContaCorrenteControl _contaCorrenteControl;

        private readonly ContaMem _repositorioContaCorrente;
        private readonly ClienteMem _repositorioCliente;


        public ContaCorrenteGerenciadorForm(ContaMem repositorioContas, ClienteMem repositorioCliente)
        {
            _repositorioContaCorrente = repositorioContas;
            _repositorioCliente = repositorioCliente;
        }

        #region methods abstracts
        public override void Adicionar()
        {
            CadastrarContaCorrente dialog = new CadastrarContaCorrente(_repositorioCliente);
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {

                try
                {
                    _repositorioContaCorrente.ValidaContaExistente(dialog.NovaConta);

                    _repositorioContaCorrente.AdicionarConta(dialog.NovaConta);
                    List<ContaCorrente> contas = _repositorioContaCorrente.ListarContas();
                    _contaCorrenteControl.popularListagemContaCorrente(contas);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Atenção",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }

            }
        }

        public override UserControl CarregarListagem()
        {
            if (_contaCorrenteControl == null)
                _contaCorrenteControl = new ContaCorrenteControl();

            return _contaCorrenteControl;
        }

        public override string ObtemTipoCadastro()
        {
            return "Cadastro de Contas Correntes";
        }

        public override EstadoBotoes ObtemTipoBotoes()
        {
            return new EstadoBotoes
            {
                Cadastrar = true,
                Depositar = true,
                Sacar = true,
                Transferir = true,
                Extrato = true,
                Excluir = true
            };
        }

        public override void Excluir()
        {
            ContaCorrente contaCorrenteSelecionada = _contaCorrenteControl.ObtemContaSelecionada();
            DialogResult resultado = DialogResult.No;

            if (contaCorrenteSelecionada != null)
            {
                resultado = MessageBox.Show(
                   "Tem certeza que deseja excluir a conta " + contaCorrenteSelecionada.Numero, "Atenção",
                   MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    _repositorioContaCorrente.Excluir(contaCorrenteSelecionada);
                    List<ContaCorrente> contas = _repositorioContaCorrente.ListarContas();
                    _contaCorrenteControl.popularListagemContaCorrente(contas);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma conta para excluir", "Atenção",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        public void Depositar()
        {
            ContaCorrente contaCorrenteSelecionada = _contaCorrenteControl.ObtemContaSelecionada();
            DepositoSaqueContaCorrente dialog;
            DialogResult resultado;

            if (contaCorrenteSelecionada != null)
            {
                String tipo = "Depositar";
                dialog = new DepositoSaqueContaCorrente(contaCorrenteSelecionada, tipo);
                resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    contaCorrenteSelecionada.Deposito(dialog.Depositar);
                    List<ContaCorrente> contas = _repositorioContaCorrente.ListarContas();
                    _contaCorrenteControl.popularListagemContaCorrente(contas);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma conta", "Atenção",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        public void Sacar()
        {
            ContaCorrente contaCorrenteSelecionada = _contaCorrenteControl.ObtemContaSelecionada();
            DepositoSaqueContaCorrente dialog;
            DialogResult resultado;

            if (contaCorrenteSelecionada != null)
            {
                String tipo = "Sacar";
                dialog = new DepositoSaqueContaCorrente(contaCorrenteSelecionada, tipo);
                resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    contaCorrenteSelecionada.Saque(dialog.Sacar);
                    List<ContaCorrente> contas = _repositorioContaCorrente.ListarContas();
                    _contaCorrenteControl.popularListagemContaCorrente(contas);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma conta", "Atenção",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Transferir()
        {
            ContaCorrente contaCorrenteSelecionada = _contaCorrenteControl.ObtemContaSelecionada();
            if (contaCorrenteSelecionada != null)
            {
                TransferirContaCorrente dialog = new TransferirContaCorrente(contaCorrenteSelecionada, _repositorioContaCorrente.ListarContas());
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    contaCorrenteSelecionada.Transferencia(dialog.ContaDestino, dialog.Valor);
                    List<ContaCorrente> contas = _repositorioContaCorrente.ListarContas();
                    _contaCorrenteControl.popularListagemContaCorrente(contas);
                }

            }
            else
            {
                MessageBox.Show("Selecione uma conta de origem.", "Atenção",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public void Extrato()
        {
            ContaCorrente contaCorrenteSelecionada = _contaCorrenteControl.ObtemContaSelecionada();
            ExtratoContaCorrente dialog;
            DialogResult result;

            if (contaCorrenteSelecionada != null)
            {
                dialog = new ExtratoContaCorrente(contaCorrenteSelecionada);
                result = dialog.ShowDialog();
                contaCorrenteSelecionada.Extrato();
            }
            else
            {
                MessageBox.Show("Selecione uma conta de origem.", "Atenção",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
