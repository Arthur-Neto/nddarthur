using Mariana.Dominio;
using Mariana.Dominio.Exceptions;
using Mariana.Dominio.Interfaces;
using Mariana.Infra.Data.Nucleo;
using System;
using System.Collections.Generic;

namespace Mariana.Aplicacao
{
    public class SerieService : Servico<Serie>
    {
        private MateriaService _materiaServico;

        public SerieService(MateriaService materiaServico) : base(RepositorioIoC.Serie)
        {
            this._materiaServico = materiaServico;
        }

        public IList<Serie> CarregarPorNumero(int numero)
        {
            try
            {
                ISerieRepositorio serieRepositorio = base.Repositorio as ISerieRepositorio;
                return serieRepositorio.ConsultarPorNumero(numero);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ValidarExistenciaNumero(int numero, int id)
        {
            try
            {
                ISerieRepositorio serieRepositorio = base.Repositorio as ISerieRepositorio;
                IList<Serie> series = serieRepositorio.ConsultarPorNumeroEId(numero, id);
                if (series.Count > 0)
                {
                    throw new ValidacaoException("Esta série já foi cadastrada.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override int Excluir(Serie entidade)
        {
            if (_materiaServico.CarregarPorSerie(entidade.Id, this).Count > 0)
            {
                throw new ValidacaoException("Esta série não pode ser excluída pois está vínculada a uma matéria.");
            }

            return base.Excluir(entidade);
        }
    }
}
