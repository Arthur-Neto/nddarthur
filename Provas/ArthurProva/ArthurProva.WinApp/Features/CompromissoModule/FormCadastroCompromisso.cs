using ArthurProva.Aplicacao;
using ArthurProva.Domain;
using ArthurProva.Domain.Exceptions;
using ArthurProva.WinApp.Base.CadastroDialog;
using ArthurProva.WinApp.Base.ControlBasico;
using ArthurProva.WinApp.Features.ContatoModule;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ArthurProva.WinApp.Features.CompromissoModule
{
    public partial class FormCadastroCompromisso : CadastroBasicoDialog<Compromisso>
    {
        private CompromissoService _service;
        UserControlBasico<Contato> _listagemContatos;
        private Contato _contato;

        public FormCadastroCompromisso(CompromissoService compromissoService) : base()
        {
            InitializeComponent();
            PopularListContatos();

            _service = compromissoService;
        }

        private void PopularListContatos()
        {
            _listagemContatos = ContatoGerenciadorFormulario.ObterInstancia().ObterLista();
            foreach (var item in _listagemContatos.RetornarTodosEmList())
            {
                listBoxContatos.Items.Add(item);
            }
        }

        protected override void Salvar()
        {
            try
            {
                AtribuirValores();
                _entidade.Validar();
            }
            catch (ValidacaoException exc)
            {
                DialogResult = DialogResult.None;

                //MessageBox.Show(ex.Message);
                labelStatus.Text = exc.Message;
            }
            catch (Exception exc)
            {
                DialogResult = DialogResult.None;

                labelStatus.Text = exc.Message;
                //MessageBox.Show(exc.Message);

            }
        }

        protected override void AtribuirValores()
        {
            if (_entidade == null)
            {
                _entidade = new Compromisso();
            }
            _entidade.Assunto = textBoxAssunto.Text;
            _entidade.Local = textBoxLocal.Text;
            _entidade.DataInicio = dateTimePickerDiaInicio.Value;
            _entidade.DataTermino = dateTimePickerDiaFim.Value;
            _entidade.IsDiaInteiro = checkBoxDiaInteiro.Checked;
            _entidade.Contatos.Clear();
            foreach (var item in listBoxAdicionarContatoCompromisso.Items)
            {
                _entidade.Contatos.Add((Contato)item);
            }
        }

        protected override void MostrarValores()
        {
            textBoxAssunto.Text = _entidade.Assunto;
            textBoxLocal.Text = _entidade.Local;
            dateTimePickerDiaInicio.Value = _entidade.DataInicio;
            dateTimePickerDiaFim.Value = _entidade.DataTermino;
            checkBoxDiaInteiro.Checked = _entidade.IsDiaInteiro;
            foreach (Contato item in _entidade.Contatos)
            {
                listBoxAdicionarContatoCompromisso.Items.Add(item);
            }

            foreach (var item in listBoxAdicionarContatoCompromisso.Items)
            {
                if (listBoxContatos.Items.Contains(item))
                    listBoxContatos.Items.Remove(item);
            }
        }

        protected override void LimparValores()
        {
            textBoxAssunto.Clear();
            textBoxLocal.Clear();
            dateTimePickerDiaInicio.ResetText();
            dateTimePickerDiaFim.ResetText();
            checkBoxDiaInteiro.Enabled = false;
            listBoxAdicionarContatoCompromisso.Items.Clear();
            listBoxContatos.Items.Clear();
        }

        private void checkBoxDiaInteiro_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDiaInteiro.Checked)
            {
                dateTimePickerDiaFim.Enabled = false;
                dateTimePickerDiaInicio.Enabled = true;
            }
            else
            {
                dateTimePickerDiaFim.Enabled = true;
                dateTimePickerDiaInicio.Enabled = true;
            }

        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            if (listBoxContatos.SelectedItem == null)
            {
                labelStatus.Text = string.Format("Nenhum contato selecionado");
                return;
            }
            listBoxAdicionarContatoCompromisso.Items.Add(_contato);
            listBoxContatos.Items.Remove(_contato);
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxAdicionarContatoCompromisso.SelectedItem == null)
            {
                labelStatus.Text = string.Format("Nenhum contato selecionado");
                return;
            }

            listBoxContatos.Items.Add(_contato);
            listBoxAdicionarContatoCompromisso.Items.Remove(_contato);
        }

        private void listBoxAdicionarContatoCompromisso_SelectedIndexChanged(object sender, EventArgs e)
        {
            _contato = listBoxAdicionarContatoCompromisso.SelectedItem as Contato;
        }

        private void listBoxContatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            _contato = listBoxContatos.SelectedItem as Contato;
        }
    }
}
