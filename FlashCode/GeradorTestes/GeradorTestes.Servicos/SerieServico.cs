using GeradorTestes.Domain;
using GeradorTestes.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Servicos
{
    public class SerieServico
    {
        SerieDAO _repositorioSerie = new SerieDAO();
        MateriaDAO _materiaDAO = new MateriaDAO();
        public void Adicionar(Serie serie)
        {
            try
            {
                serie.Validacao();
                if (!_repositorioSerie.GetByName(serie))
                {
                    _repositorioSerie.Add(serie);
                }
                else
                {
                    throw new Exception("A série já existe!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void Editar(Serie serie)
        {
            try
            {
                serie.Validacao();

                if (!_repositorioSerie.GetByName(serie))
                {
                    _repositorioSerie.Editar(serie);
                }
                else
                {
                    throw new Exception("A série já existe!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(Serie serie)
        {
            try
            {
                if (_materiaDAO.GetByIDSerie(serie.ID))
                    throw new Exception("A serie esta vinculada a uma materia.");

                _repositorioSerie.Excluir(serie);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<Serie> GetAllSeries()
        {
            try
            {
                return _repositorioSerie.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
