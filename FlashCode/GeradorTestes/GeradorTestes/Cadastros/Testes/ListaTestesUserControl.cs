using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeradorTestes.Servicos;
using GeradorTestes.Domain;

namespace GeradorTestes.Cadastros.Testes
{
    public partial class ListaTestesUserControl : UserControl
    {
        TesteServico _testService = new TesteServico();

        public ListaTestesUserControl()
        {
            InitializeComponent();
            CarregaLista();
        }
        public void CarregaLista()
        {
            ListBoxTest.Items.Clear();
            foreach (var item in _testService.GetAll())
            {
                ListBoxTest.Items.Add(item);
            }
        }
        public Teste GetSelected()
        {
            var test = ListBoxTest.SelectedItem as Teste;
            if (test == null)
            {
                return null;
            }
            else
            {
                test.listaQuestao = _testService.GetAllTesteQuestoes(test);

            }

            return test;
        }
    }
}