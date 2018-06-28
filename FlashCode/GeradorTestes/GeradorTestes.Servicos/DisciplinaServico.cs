using GeradorTestes.Domain;
using GeradorTestes.Infra;
using System;
using System.Collections.Generic;

namespace GeradorTestes.Servicos
{

    public class DisciplinaServico
    {
        DisciplinaDAO _repositorio = new DisciplinaDAO();
        MateriaDAO _materiaDAO = new MateriaDAO();

        public void Adicionar(Disciplina disciplina)
        {
            try
            {
                disciplina.Validacao();

                if (!_repositorio.GetByName(disciplina))
                {
                    _repositorio.Add(disciplina);

                }
                else
                {
                    throw new Exception("A Disciplina já existe!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(Disciplina disciplina)
        {
            try
            {
                if (_materiaDAO.GetByIDDiciplina(disciplina.ID))
                    throw new Exception("A Disciplina está vinculada a uma matéria");

                _repositorio.Delete(disciplina);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Disciplina disciplina)
        {
            try
            {
                disciplina.Validacao();

                if (!_repositorio.GetByName(disciplina))
                {
                    _repositorio.Update(disciplina);

                }
                else
                {
                    throw new Exception("A Disciplina já existe!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IList<Disciplina> GetAll()
        {
            try
            {
                return _repositorio.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }


    }
}
