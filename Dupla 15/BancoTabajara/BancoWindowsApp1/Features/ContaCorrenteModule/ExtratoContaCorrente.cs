using BancoApp.dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoWindowsApp1.Features.ContaCorrenteModule
{
    public partial class ExtratoContaCorrente : Form
    {
        public ExtratoContaCorrente(ContaCorrente contaSelecionada)
        {
            InitializeComponent();
            labelNumeroExtrato.Text = Convert.ToString(contaSelecionada.Numero);
            txtExtrato.Text = contaSelecionada.Extrato();
        }
    }
}
