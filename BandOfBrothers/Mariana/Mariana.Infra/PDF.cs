using iTextSharp.text;
using iTextSharp.text.pdf;
using Mariana.Dominio;
using System.Collections.Generic;
using System.IO;

namespace Mariana.Infra
{
    public class PDF
    {
        public PDF()
        {
        }

        public void GeneratePdf(Teste teste, IList<string> listaEnunciado, IList<string> listaResposta, IList<string> listaGabarito)
        {
            FileStream fs = new FileStream(teste.CaminhoDestino, FileMode.Create);
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            BaseFont bf = BaseFont.CreateFont("c:\\windows\\fonts\\calibri.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            document.Open();

            document.AddAuthor("Arthur, Diego, Luis e Zanella");
            document.AddTitle("Lista de Exercícios");

            iTextSharp.text.Image addLogo = default(iTextSharp.text.Image);
            addLogo = iTextSharp.text.Image.GetInstance("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR2B9Wnjrt5xJuEskrkGG_ymXscJyRrS4XohpG4dmBe8VBZKcfE");
            
            addLogo.SetAbsolutePosition(370, 660);

            document.Add(addLogo);

            Paragraph paragrafo = new Paragraph("", new Font(Font.NORMAL, 14));
            paragrafo.Alignment = Element.ALIGN_JUSTIFIED;

            paragrafo.Font = new Font(bf, 12, (int)System.Drawing.FontStyle.Bold);
            paragrafo.Add("Disciplina: ");
            paragrafo.Font = new Font(bf, 12, (int)System.Drawing.FontStyle.Regular);
            paragrafo.Add(teste.Disciplina.Nome + "\n");

            paragrafo.Font = new Font(bf, 12, (int)System.Drawing.FontStyle.Bold);
            paragrafo.Add("Matéria: ");
            paragrafo.Font = new Font(bf, 12, (int)System.Drawing.FontStyle.Regular);
            paragrafo.Add(teste.Materia.Nome + "\n");

            paragrafo.Font = new Font(bf, 12, (int)System.Drawing.FontStyle.Bold);
            paragrafo.Add("Série: ");
            paragrafo.Font = new Font(bf, 12, (int)System.Drawing.FontStyle.Regular);
            paragrafo.Add(teste.Serie.NumeroSerie.ToString() + "º \n");

            paragrafo.Font = new Font(bf, 12, (int)System.Drawing.FontStyle.Bold);
            paragrafo.Add("Nome: ");
            paragrafo.Font = new Font(bf, 12, (int)System.Drawing.FontStyle.Regular);
            paragrafo.Add("________________________________________\n");

            paragrafo.Font = new Font(bf, 12, (int)System.Drawing.FontStyle.Bold);
            paragrafo.Add("Data: ");
            paragrafo.Font = new Font(bf, 12, (int)System.Drawing.FontStyle.Regular);
            paragrafo.Add("____/_____/_________/ \n");

            document.Add(paragrafo);

            paragrafo = new Paragraph("", new Font(Font.NORMAL, 14));

            paragrafo.Alignment = Element.ALIGN_CENTER;
            paragrafo.Font = new Font(bf, 14, (int)System.Drawing.FontStyle.Bold);
            paragrafo.Add(teste.Nome.ToUpper() + "\n \n");

            document.Add(paragrafo);

            var i = 0;

            foreach (var item in listaEnunciado)
            {
                paragrafo = new Paragraph("", new Font(Font.NORMAL, 12));

                paragrafo.Alignment = Element.ALIGN_JUSTIFIED;
                paragrafo.Font = new Font(bf, 14, (int)System.Drawing.FontStyle.Regular);
                paragrafo.Add(item + "\n");

                document.Add(paragrafo);

                paragrafo = new Paragraph("", new Font(Font.NORMAL, 12));

                paragrafo.Alignment = Element.ALIGN_JUSTIFIED;
                paragrafo.Font = new Font(bf, 14, (int)System.Drawing.FontStyle.Regular);
                paragrafo.Add(listaResposta[i] + "\n");

                document.Add(paragrafo);

                i++;
            }

            document.NewPage();

            paragrafo = new Paragraph("", new Font(Font.NORMAL, 14));

            paragrafo.Alignment = Element.ALIGN_CENTER;
            paragrafo.Font = new Font(bf, 14, (int)System.Drawing.FontStyle.Bold);
            paragrafo.Add("GABARITO - " + teste.Nome.ToUpper() + "\n \n");

            document.Add(paragrafo);

            foreach (var item in listaGabarito)
            {
                paragrafo = new Paragraph("", new Font(Font.NORMAL, 12));

                paragrafo.Alignment = Element.ALIGN_JUSTIFIED;
                paragrafo.Font = new Font(bf, 14, (int)System.Drawing.FontStyle.Regular);
                paragrafo.Add(item + "\n");

                document.Add(paragrafo);
            }

            document.Close();
            writer.Close();
            fs.Close();
        }
    }
}
