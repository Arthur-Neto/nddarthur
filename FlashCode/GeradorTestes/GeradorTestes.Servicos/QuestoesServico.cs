using GeradorTestes.Domain;
using GeradorTestes.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Servicos
{
    public class QuestoesServico
    {
        QuestaoDAO _questaoDAO = new QuestaoDAO();
        TesteDAO testeDAO = new TesteDAO();
        public void Adicionar(Questao questao)
        {
            try
            {
                IList<Questao> listaQuestao = GetAll();

                foreach (var item in listaQuestao)
                {
                    if (questao.Pergunta.Trim().Equals(item.Pergunta.Trim()))
                        throw new Exception("A questão já existe");
                }

                questao.Validacao();
                _questaoDAO.Adicionar(questao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public IList<Questao> GetAll()
        {
            try
            {
                return _questaoDAO.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(Questao questao)
        {
            try
            {
                if (testeDAO.GetByQuestion(questao.ID))
                {
                    _questaoDAO.Delete(questao);
                }
                else
                {
                    throw new Exception("O questão não pode ser excluída pois está vinculada a um teste");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Questao questao)
        {
            try
            {
                questao.Validacao();
                IList<Questao> listaQuestao = GetAll();
                foreach (var item in listaQuestao)
                {
                    if (questao.ID != item.ID)
                        if (questao.Pergunta.Trim().Equals(item.Pergunta.Trim()))
                            throw new Exception("A questão já existe");
                }
                _questaoDAO.Editar(questao);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<Questao> GetAllRandom(Teste teste, Materia materia, Questao questao)
        {
            try
            {
                var List = _questaoDAO.GetAllRandom(teste, materia, questao);
                return List;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



    }
}
