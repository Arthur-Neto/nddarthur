using GeradorTestes.Domain;
using GeradorTestes.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Servicos
{
    public class MateriaServico
    {
        MateriaDAO _materiaDAO = new MateriaDAO();
        QuestaoDAO _questaoDAO = new QuestaoDAO();
        public void Adicionar(Materia materia)
        {
            try
            {
                materia.Valida();
                if (!_materiaDAO.GetByName(materia))
                {
                    _materiaDAO.Adicionar(materia);
                }
                else
                {
                    throw new Exception("A Matéria já existe!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public void Delete(Materia materia)
        {
            try
            {
                if (!_questaoDAO.GetByID(materia.ID))
                {
                    throw new Exception("A matéria está vinculada a uma Questão");
                }
                else
                {
                    _materiaDAO.Excluir(materia);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Materia materia)
        {
            try
            {
                materia.Valida();

                if (!_materiaDAO.GetByName(materia))
                {
                    _materiaDAO.Editar(materia);

                }
                else
                {
                    throw new Exception("A Matéria já existe!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<Materia> GetAllMaterias()
        {
            try
            {
                return _materiaDAO.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<Materia> GetMateriaBySerie(string serie)
        {
            return null;
        }

        public IList<Materia> GetMateriaByDisciplina(string disciplina)
        {
            return null;
        }
        public IList<Materia> GetMateriaBySerieAndDisciplina(Serie serie, Disciplina disciplina)
        {
            return _materiaDAO.GetByIDSerieAndDisciplina(serie, disciplina);
        }

    }
}
