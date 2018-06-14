using NFe.Aplicacao.Base;
using NFe.Dominio.Exceptions;
using NFe.Dominio.Features.Notas_Fiscais;
using NFe.Infra.PDF.Features.Notas_Fiscais;
using NFe.Infra.XML.Features.NotasFiscais;
using System.Collections.Generic;
using System.Linq;

namespace NFe.Aplicacao.Features.Notas_Fiscais
{
    public class NotaFiscalServico : Servico<NotaFiscal>
    {
        NotaXmlRepositorio notaXml;

        public NotaFiscalServico(INotaFiscalRepositorio notaFiscalRepositorio) : base(notaFiscalRepositorio)
        {
            notaXml = new NotaXmlRepositorio();
        }

        public override NotaFiscal Atualizar(NotaFiscal entidade)
        {
            if (entidade.Emitido)
                throw new UnsupportedOperationException();

            if (entidade.Id == 0)
                throw new IdentifierUndefinedException();

            entidade.Validar();

            notaXml.NotaFiscalParaXml(entidade);
            entidade.NotaFiscalXml = notaXml.XmlNotaFiscal;
            return base.Atualizar(entidade);
        }

        public override void Deletar(NotaFiscal entidade)
        {
            if (entidade.Id == 0)
                throw new IdentifierUndefinedException();

            base.Deletar(entidade);
        }

        public override NotaFiscal PegarPorId(long id)
        {
            NotaFiscal nota = base.PegarPorId(id);

            if (nota == null)
                return null;

            nota = notaXml.XmlParaNotaFiscal(nota);

            return nota;
        }

        public override IEnumerable<NotaFiscal> PegarTodos()
        {
            IList<NotaFiscal> notas = base.PegarTodos().ToList();

            return (IEnumerable<NotaFiscal>)notas;
        }

        public override NotaFiscal Salvar(NotaFiscal entidade)
        {
            entidade.Validar();

            if (entidade.Emitido == false)
            {
                notaXml.NotaFiscalParaXml(entidade);
                entidade.NotaFiscalXml = notaXml.XmlNotaFiscal;
                entidade.GerarChaveAcesso();
                return base.Salvar(entidade);
            }
            else
                throw new SalvarNotaJaEmitidaException();
        }

        public NotaFiscal Emitir(NotaFiscal entidade)
        {
            entidade.Validar();

            if (entidade.Emitido == false)
            {
                entidade.Emitir();
                entidade.GerarChaveAcesso();
                return Repositorio.Salvar(entidade);
            }
            else
                throw new SalvarNotaJaEmitidaException();
        }

        public void ExportaXml(string caminho, NotaFiscal notaFiscal)
        {
            NotaXmlRepositorio NotaXml = new NotaXmlRepositorio();

            if (string.IsNullOrEmpty(caminho))
                throw new PathNullOrNotFound();
            else
                NotaXml.ExportaParaArquivoXml(caminho, notaFiscal);
        }

        public void ExportarPdf(string caminho, NotaFiscal notaFiscal)
        {
            if (string.IsNullOrEmpty(caminho))
                throw new PathNullOrNotFound();
            else
                NotaFiscalPdf.Exportar(caminho, notaFiscal);
        }
    }
}
