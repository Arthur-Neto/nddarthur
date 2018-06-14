using NFe.Dominio.Features.Notas_Fiscais;

namespace NFe.Infra.XML.Features.NotasFiscais
{
    public interface INotaXmlRepositorio
    {
        void NotaFiscalParaXml(NotaFiscal notaFiscal);
        void ExportaParaArquivoXml(string caminho, NotaFiscal notaFiscal);
    }
}