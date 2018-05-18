using Mariana.Aplicacao;
using Mariana.Dominio;
using Mariana.Dominio.Exceptions;
using Mariana.WinApp.Nucleo.CadastroDialog;
using System;
using System.Windows.Forms;

namespace Mariana.WinApp.Features.SerieModule
{
    public partial class FormCadastroSerie : CadastroBasicoDialog<Serie>
    {
        private SerieService _servico;

        public FormCadastroSerie(SerieService servico) : base()
        {
            InitializeComponent();
            _servico = servico;
        }

        protected override void Salvar()
        {
            try
            {
                AtribuirValores();
                _entidade.Validar();
                ((SerieService)_servico).ValidarExistenciaNumero(_entidade.NumeroSerie, _entidade.Id);
            }
            catch (ValidacaoException ex)
            {
                DialogResult = DialogResult.None;
                labelStatus.Text = ex.Message;
            }
            catch (Exception exc)
            {
                DialogResult = DialogResult.None;
                labelStatus.Text = exc.Message;
            }
        }

        protected override void AtribuirValores()
        {
            if (_entidade == null)
            {
                _entidade = new Serie();
            }
            _entidade.NumeroSerie = (int)numericUpDownSerie.Value;
        }

        protected override void MostrarValores()
        {
            txtIdSerie.Text = Convert.ToString(_entidade.Id);
            numericUpDownSerie.Value = _entidade.NumeroSerie;
        }

        protected override void LimparValores()
        {
            txtIdSerie.Clear();
            numericUpDownSerie.Value = 1;
        }
    }
}
