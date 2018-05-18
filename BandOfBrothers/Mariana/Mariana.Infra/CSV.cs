using CsvHelper;
using Mariana.Dominio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariana.Infra
{
    public class CSV
    {
        //Gera toda a lista repassada para CSV
        public void GeraCSV(string caminho, IList<Teste> teste)
        {
            string respostaCorreta = "";

            using (var fs = new FileStream(caminho, FileMode.OpenOrCreate))
            {
                using (var streamWriter = new StreamWriter(fs, Encoding.UTF8))
                using (var csvWriter = new CsvWriter(streamWriter))
                {
                    csvWriter.Configuration.Delimiter = ";";
                    csvWriter.Configuration.CultureInfo = CultureInfo.GetCultureInfo("pt-BR");
                    csvWriter.Configuration.HasHeaderRecord = true;

                    foreach (var item in teste)
                    {
                        csvWriter.WriteField(item.Id);
                        csvWriter.WriteField(item.Nome);
                        csvWriter.WriteField(item.Serie);
                        csvWriter.WriteField(item.Disciplina);
                        csvWriter.WriteField(item.Materia);
                        csvWriter.WriteField(item.NumeroQuestoes);
                        csvWriter.WriteField(item.DataTesteGerado);
                        foreach (var itemQuestao in item.Questoes)
                        {
                            csvWriter.WriteField(itemQuestao.Enunciado);
                            foreach (var itemRespostas in itemQuestao.Respostas)
                                csvWriter.WriteField(itemRespostas.CorpoResposta);
                            foreach (var itemQuestaoResposta in item.Questoes)
                                respostaCorreta = AlternativaCorreta(itemQuestao.Respostas);
                            csvWriter.WriteField(respostaCorreta);
                        }
                        csvWriter.NextRecord();
                    }
                }
                fs.Close();
            }
        }

        //Transforma o Teste em CSV e grava no arquivo
        public bool GeraCSVPorItem(Teste teste, string caminho)
        {
            string respostaCorreta = "";

            try
            {
                if (File.Exists(caminho))
                {
                    File.Delete(caminho);
                }
                using (var fs = new FileStream(caminho, FileMode.OpenOrCreate))
                {
                    using (var streamWriter = new StreamWriter(fs, Encoding.UTF8))
                    using (var csvWriter = new CsvWriter(streamWriter))
                    {
                        csvWriter.Configuration.Delimiter = ";";
                        csvWriter.Configuration.CultureInfo = CultureInfo.GetCultureInfo("pt-BR");
                        csvWriter.Configuration.HasHeaderRecord = true;

                        csvWriter.WriteField(teste.Id);
                        csvWriter.WriteField(teste.Nome);
                        csvWriter.WriteField(teste.Serie);
                        csvWriter.WriteField(teste.Disciplina);
                        csvWriter.WriteField(teste.Materia);
                        csvWriter.WriteField(teste.NumeroQuestoes);
                        csvWriter.WriteField(teste.DataTesteGerado);
                        foreach (var itemQuestao in teste.Questoes)
                        {
                            csvWriter.WriteField(itemQuestao.Enunciado);
                            foreach (var itemRespostas in itemQuestao.Respostas)
                                csvWriter.WriteField(itemRespostas.CorpoResposta);
                            foreach (var itemQuestaoResposta in teste.Questoes)
                                respostaCorreta = AlternativaCorreta(itemQuestao.Respostas);
                            csvWriter.WriteField(respostaCorreta);
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string AlternativaCorreta(IList<Resposta> listaResposta)
        {
            int i = 1;
            string resposta = "";
            foreach (var itemResposta in listaResposta)
            {
                i++;

                if (itemResposta.Correta == true)
                    resposta = " - (" + i + ") - " + itemResposta.CorpoResposta;
            }

            return resposta;
        }
    }
}
