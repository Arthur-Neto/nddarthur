using GeradorTestes.Domain;
using GeradorTestes.Domain.Interfaces;
using GeradorTestes.Infra;
using System;
using System.Collections.Generic;
using GeradorTestes.Infra.Util.Serializables;
using GeradorTestes.Infra.PDF;

namespace GeradorTestes.Servicos
{
    public class TesteServico : ITesteService
    {
        TesteDAO testeDAO = new TesteDAO();
        QuestaoDAO questaoDAO = new QuestaoDAO();
        public void GerarTeste(Teste teste, Materia materia, Questao questao)
        {
            try
            {
                IList<Questao> questaoList = questaoDAO.GetAllRandom(teste, materia, questao);

                if (teste.QuantidadeQuestoes > questaoList.Count)
                {

                    throw new Exception("A quantidade de questões do " + questao.Bimestre + " e na Matéria " + materia.Nome + " é de " + questaoList.Count);
                }
                else
                {

                    if (questaoList.Count < 1)
                    {
                        throw new Exception("Não há nenhuma questão cadastrada nesse Bimestre e nessa matéria");
                    }
                    else
                    {
                        int testeID = testeDAO.AdicionarTBTestes(teste);
                        teste.ID = testeID;

                        foreach (var item in questaoList)
                        {
                            testeDAO.AdicionarTBTestes_Questoes(Convert.ToInt32(item.ID), testeID);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<Teste> GetAll()
        {
            try
            {
                return testeDAO.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<Questao> GetAllTesteQuestoes(Teste teste)
        {
            try
            {
                return testeDAO.GetQuestoes(teste);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void GerarTeste(Teste teste, string caminho)
        {
            try
            {
                teste.GerarPDF(caminho + ".pdf");
                teste.SerializeCSV<Teste>(caminho + ".csv");
                teste.listaQuestao.SerializeXML<Questao>(caminho + ".xml");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Deletar(Teste teste)
        {
            try
            {
                testeDAO.Delete(teste);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}