using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Infra
{
    public class TestPDF
    {
        private Document _document;
        private PdfWriter _pdfWriter;

        public TestPDF(string file)
        {
            _document = new Document(PageSize.A4); //Criando e estipulando o tipo da folha usada
            _document.SetMargins(40, 40, 40, 80);//estibulando o espaçamento das margens que queremos
            _document.AddCreationDate();//adicionando as configuracoes

            _pdfWriter = PdfWriter.GetInstance(_document, new FileStream(file, FileMode.Create)); // Pegando a instancia do PDF Writer
        }

        public void AbrirDocumento() //Abrindo documento
        {
            _document.Open();
        }

        public void FecharDocumento() //Fechamendo documento
        {
            _document.Close();
        }

        public void Escrever(string text) //Escxrevendo documento
        {
            //criando a variavel para paragrafo
            Paragraph paragraph = new Paragraph(String.Empty, new Font(Font.NORMAL, 14));

            //etipulando o alinhamneto
            paragraph.Alignment = Element.ALIGN_JUSTIFIED;

            //adicioando texto
            paragraph.Add(text);

            //acidionado paragrafo ao documento
            _document.Add(paragraph);
        }
    }
}
