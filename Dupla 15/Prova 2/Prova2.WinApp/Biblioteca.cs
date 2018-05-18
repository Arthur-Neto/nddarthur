using Prova2.Applications;
using Prova2.Domain;
using System;
using System.Windows.Forms;

namespace Prova2.WinApp
{
    public partial class Biblioteca : Form
    {
        public Biblioteca()
        {
            InitializeComponent();
            ListLivros();
            ListEmprestimo();
        }

        Livro _livro = new Livro();
        Livro _livroSelecionado = new Livro();
        Emprestimo _emprestimo = new Emprestimo();
        LivroService _livroService = new LivroService();
        EmprestimoService _emprestimoService = new EmprestimoService();

        #region Livro

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                FormLivroToObject();

                if (_livro.Id == 0)
                {

                    _livroService.AddLivro(_livro);
                    ListLivros();
                }
                else
                {
                    _livroService.UpdateLivro(_livro);
                    ListLivros();
                }
                _livro = new Livro();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK);

            }
            tabBiblioteca.SelectedIndex = 1;
            LimparCampos();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            tabBiblioteca.SelectedIndex = 0;
            _livro = listLivros.SelectedItem as Livro;
            txtTitulo.Text = _livro.Titulo;
            txtTema.Text = _livro.Tema;
            txtAutor.Text = _livro.Autor;
            txtVolume.Text = _livro.Volume.ToString();
            dtpDataPublicacao.Value = _livro.DataPublicacao;
            cbDispobilidade.Checked = _livro.Disponibilidade;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            _livro = listLivros.SelectedItem as Livro;

            if (_livro != null)
            {
                var message = MessageBox.Show("Deseja excluir o livro " + _livro.Titulo + "?", "Atenção",
                    MessageBoxButtons.YesNo);

                if (message == DialogResult.Yes)
                {
                    try
                    {
                        _livroService.DeleteLivro(_livro);
                        ListLivros();
                        LimparCampos();
                    }
                    catch
                    {
                        MessageBox.Show("O Livro está relacionado a um emprestimo! Delete o emprestimo primeiro!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um Livro para excluir!");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        /// <summary>
        /// Converte os campos da tela de cadastro de produto para o objeto produto
        /// </summary>
        private void FormLivroToObject()
        {
            //Validação do componente txtBox para numérico
            if (!char.IsNumber(txtVolume.Text.ToCharArray()[0]))
            {
                throw new Exception("O valor deve ser numérico!");
            }

            _livro.Titulo = txtTitulo.Text;
            _livro.Tema = txtTema.Text;
            _livro.Autor = txtAutor.Text;
            _livro.Volume = int.Parse(txtVolume.Text);
            _livro.DataPublicacao = dtpDataPublicacao.Value;
            _livro.Disponibilidade = cbDispobilidade.Checked ? true : false;

        }


        private void listLivros_SelectedIndexChanged(object sender, EventArgs e)
        {

            btnExcluir.Enabled = true;
            btnEditar.Enabled = true;
        }

        /// <summary>
        /// Método privado que limpa a lista de vendas e lista novamente
        /// </summary>
        private void ListLivros()
        {
            listLivros.Items.Clear();
            cmbLivro.Items.Clear();

            var list = _livroService.GetAll();

            foreach (var item in list)
            {
                listLivros.Items.Add(item);

                if (item.Disponibilidade)
                {
                    cmbLivro.Items.Add(item);
                }
            }
        }

        private void btnPdfLivro_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "PDF|*.pdf";
                saveFileDialog1.Title = "Salvar";
                saveFileDialog1.ShowDialog();

                _livroService.ReportList(saveFileDialog1.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        #endregion

        #region Emprestimo

        private void ListEmprestimo()
        {
            listEmprestimo.Items.Clear();
            var list = _emprestimoService.GetAllEmprestimo();

            foreach (var item in list)
            {
                listEmprestimo.Items.Add(item);
            }
        }

        private void btnEditarEmprestimo_Click(object sender, EventArgs e)
        {
            tabBiblioteca.SelectedIndex = 2;
            _emprestimo = listEmprestimo.SelectedItem as Emprestimo;

            txtNomeCliente.Text = _emprestimo.Cliente;
            dtpDataDevolucao.Value = _emprestimo.DataDevolucao;
            cmbLivro.SelectedItem = _emprestimo.Livro;
        }

        private void btnSalvarEmprestimo_Click(object sender, EventArgs e)
        {
            try
            {

                FormEmprestimoToObject();

                if (_emprestimo.Id == 0)
                {
                    _emprestimoService.AddEmprestimo(_emprestimo);
                    LimparCampos();
                }
                else
                {
                    _emprestimoService.UpdateEmprestimo(_emprestimo);
                    LimparCampos();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            tabBiblioteca.SelectedIndex = 3;
            LimparCampos();
        }

        /// <summary>
        /// Converte os campos da tela de cadastro de Emprestimo para o objeto emprestimo
        /// </summary>
        private void FormEmprestimoToObject()
        {
            _emprestimo.Cliente = txtNomeCliente.Text;
            _emprestimo.Livro = _livroSelecionado;
            _emprestimo.DataDevolucao = dtpDataDevolucao.Value;

        }

        private void cmbLivro_SelectedIndexChanged(object sender, EventArgs e)
        {
            _livroSelecionado = cmbLivro.SelectedItem as Livro;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnExcluirEmprestimo_Click(object sender, EventArgs e)
        {
            _emprestimo = listEmprestimo.SelectedItem as Emprestimo;

            if (_emprestimo != null)
            {
                var message = MessageBox.Show("Deseja excluir o emprestimo do cliente " + _emprestimo.Cliente + "?", "Atenção",
                    MessageBoxButtons.YesNo);

                if (message == DialogResult.Yes)
                {
                    _emprestimoService.DeleteEmprestimo(_emprestimo);

                    ListEmprestimo();

                }
            }
            else
            {
                MessageBox.Show("Selecione um emprestimo para excluir!");
            }
        }

        private void listEmprestimo_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnExcluir.Enabled = true;
            btnEditar.Enabled = true;
        }

        private void btnMulta_Click(object sender, EventArgs e)
        {
            _emprestimo = listEmprestimo.SelectedItem as Emprestimo;

            if (_emprestimo != null)
            {
                if (_emprestimo.CalculaMulta <= 0)
                {
                    var message = MessageBox.Show("O Emprestimo não possui multas. ", "Atenção",
                       MessageBoxButtons.OK);
                }
                else
                {
                    var message = MessageBox.Show("Multa: R$" + _emprestimo.CalculaMulta, "Atenção",
                      MessageBoxButtons.OK);
                }
            } else
            {
                MessageBox.Show("Selecione um emprestimo para calcular a multa!");
            }
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "PDF|*.pdf";
                saveFileDialog1.Title = "Salvar";
                saveFileDialog1.ShowDialog();

                _emprestimoService.ReportList(saveFileDialog1.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }
        #endregion

        private void LimparCampos()
        {
            _livro = new Livro();
            txtTitulo.Clear();
            txtTema.Clear();
            txtAutor.Clear();
            txtVolume.Clear();
            dtpDataPublicacao.Value = DateTime.Now;
            cbDispobilidade.Checked = false;

            _emprestimo = new Emprestimo();
            txtNomeCliente.Clear();
            cmbLivro.SelectedIndex = -1;
            dtpDataDevolucao.Value = DateTime.Now;

            ListLivros();
            ListEmprestimo();
        }

    }
}
