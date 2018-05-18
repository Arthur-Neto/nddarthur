using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BancoApp.dominio;

namespace BancoWindowsApp1.Features.ContaCorrenteModule
{
    public partial class ContaCorrenteControl : UserControl
    {
        public ContaCorrenteControl()
        {
            InitializeComponent();
        }

        public void popularListagemContaCorrente(List<ContaCorrente> contas)
        {
            listContaCorrente.Items.Clear();
            
            foreach (ContaCorrente c in contas)
            {
                listContaCorrente.Items.Add(c);
            }
        }

        public ContaCorrente ObtemContaSelecionada()
        {
            return (ContaCorrente) listContaCorrente.SelectedItem;
        }
    }
}
