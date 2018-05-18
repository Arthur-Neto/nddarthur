using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mariana.Dominio;
using System.Xml;

namespace Mariana.Infra
{
    public class XML
    {
        public void GeraXml(string caminho, IList<Teste> teste)
        {
            XmlTextWriter writer = new XmlTextWriter(caminho, null);
            writer.WriteStartDocument();
            writer.WriteStartElement("Testes");
            string respostaCorreta = "";
            foreach (var item in teste)
            {
                writer.WriteStartElement("Teste");
                writer.WriteElementString("Id", item.Id.ToString());
                writer.WriteElementString("Nome", item.Nome);
                writer.WriteElementString("Data", item.DataTesteGerado.ToString());
                writer.WriteElementString("Serie", item.Serie.NumeroSerie.ToString());
                writer.WriteElementString("Disciplina", item.Disciplina.Nome);
                writer.WriteElementString("Materia", item.Materia.Nome);
                writer.WriteElementString("NumeroQuestoes", item.NumeroQuestoes.ToString());
                writer.WriteStartElement("Questoes");
                foreach (var itemQuestao in item.Questoes)
                {
                    writer.WriteElementString("Enunciado", itemQuestao.Enunciado);
                    foreach (var itemRespostas in itemQuestao.Respostas)
                        writer.WriteElementString("Respostas", itemRespostas.CorpoResposta);
                    foreach (var itemQuestaoResposta in item.Questoes)
                        respostaCorreta = AlternativaCorreta(itemQuestao.Respostas);
                    writer.WriteElementString("RespostaCorreta", respostaCorreta);
                }

                writer.WriteEndElement();//Questoes
                writer.WriteEndElement();//Teste
            }
            writer.WriteEndElement();//Testes
            writer.Close();
        }

        public void GeraItemXML(string caminho, Teste teste)
        {
            XmlTextWriter writer = new XmlTextWriter(caminho, null);
            writer.WriteStartDocument();
            string respostaCorreta = "";
            writer.WriteStartElement("Testes");
            writer.WriteStartElement("Teste");
            writer.WriteElementString("Id", teste.Id.ToString());
            writer.WriteElementString("Nome", teste.Nome);
            writer.WriteElementString("Data", teste.DataTesteGerado.ToString());
            writer.WriteElementString("Serie", teste.Serie.NumeroSerie.ToString());
            writer.WriteElementString("Disciplina", teste.Disciplina.Nome);
            writer.WriteElementString("Materia", teste.Materia.Nome);
            writer.WriteElementString("NumeroQuestoes", teste.NumeroQuestoes.ToString());
            writer.WriteStartElement("Questoes");
            foreach (var itemQuestao in teste.Questoes)
            {
                writer.WriteElementString("Enunciado", itemQuestao.Enunciado);
                foreach (var itemRespostas in itemQuestao.Respostas)
                    writer.WriteElementString("Respostas", itemRespostas.CorpoResposta);
                foreach (var itemQuestaoResposta in teste.Questoes)
                    respostaCorreta = AlternativaCorreta(itemQuestao.Respostas);
                writer.WriteElementString("RespostaCorreta", respostaCorreta);
            }

            writer.WriteEndElement();//Questoes
            writer.WriteEndElement();//Teste

            writer.Close();
        }

        public string AlternativaCorreta(IList<Resposta> listaResposta)
        {
            int i = 0;
            int t = 0;
            string resposta = "";
            foreach (var itemResposta in listaResposta)
            {
                t = i + 1;
                i++;

                if (itemResposta.Correta == true)
                    resposta = " - (" + t + ") - " + itemResposta.CorpoResposta;
            }

            return resposta;
        }
    }
}
