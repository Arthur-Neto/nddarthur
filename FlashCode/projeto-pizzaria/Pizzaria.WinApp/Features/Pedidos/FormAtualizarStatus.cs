using System;
using Pizzaria.Dominio.Features.Pedidos;
using Pizzaria.Dominio.Features.Produtos;
using Pizzaria.WinApp.Base;

namespace Pizzaria.WinApp.Features.Pedidos
{
    public partial class FormAtualizarStatus : FormCadastroBasico<Pedido>
    {
        
        private StatusPedidoEnum _status;

        public FormAtualizarStatus(Pedido pedido)
        {
            InitializeComponent();
            _entidade = pedido;
            txtCliente.Text = _entidade.Cliente.Nome;
            mskTelefone.Text = _entidade.Cliente.Telefone;
            MudaRadioButtonParaStatus(_entidade.Status);
        }

        private void MudaRadioButtonParaStatus(StatusPedidoEnum status)
        {
            if (status == StatusPedidoEnum.AGUARDANDO_MONTAGEM)
                rbtAguardandoMontagem.Checked = true;
            else if (status == StatusPedidoEnum.EM_MONTAGEM)
                rbtEmMontagem.Checked = true;
            else if (status == StatusPedidoEnum.AGUARDANDO_ENTREGA)
                rbtAguardandoEntrega.Checked = true;
            else if (status == StatusPedidoEnum.EM_ENTREGA)
                rbtEmEntrega.Checked = true;
            else
                rbtEntregue.Checked = true;
        }

        protected override void Salvar()
        {
            _entidade.Status = _status;
        }

        private void rbtAguardandoMontagem_CheckedChanged(object sender, System.EventArgs e) => _status = StatusPedidoEnum.AGUARDANDO_MONTAGEM;

        private void rbtEmMontagem_CheckedChanged(object sender, System.EventArgs e) => _status = StatusPedidoEnum.EM_MONTAGEM;

        private void rbtAguardandoEntrega_CheckedChanged(object sender, System.EventArgs e) => _status = StatusPedidoEnum.AGUARDANDO_ENTREGA;

        private void rbtEmEntrega_CheckedChanged(object sender, System.EventArgs e) => _status = StatusPedidoEnum.EM_ENTREGA;

        private void rbtEntregue_CheckedChanged(object sender, System.EventArgs e) => _status = StatusPedidoEnum.ENTREGUE;
    }
}
