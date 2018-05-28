using CsvHelper;
using Loterica.Dominio.Features.Concursos;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Loterica.Infra.CSV.Features.Concursos
{
    public static class ConcursoCSVRepository
    {
        public static void GerarCSV(IEnumerable<Concurso> concursos, string caminho)
        {
            using (var fs = new FileStream(caminho, FileMode.Truncate))
            {
                using (var streamWriter = new StreamWriter(fs, Encoding.UTF8))
                using (var csvWriter = new CsvWriter(streamWriter))
                {
                    csvWriter.Configuration.Delimiter = ";";
                    csvWriter.Configuration.CultureInfo = CultureInfo.GetCultureInfo("pt-BR");
                    csvWriter.Configuration.HasHeaderRecord = true;
                    csvWriter.WriteField("Id");
                    csvWriter.WriteField("Numeros Sorteados");
                    csvWriter.WriteField("Data");
                    csvWriter.WriteField("Faturamento");
                    csvWriter.WriteField("Esta Fechado?");
                    csvWriter.WriteField("Premio Total");
                    csvWriter.WriteField("Premio Quadra");
                    csvWriter.WriteField("Premio Quina");
                    csvWriter.WriteField("Premio Sena");
                    csvWriter.WriteField("Premio média quadra");
                    csvWriter.WriteField("Premio média quina");
                    csvWriter.WriteField("Premio média sena");
                    csvWriter.WriteField("Ganhadores Quadra");
                    csvWriter.WriteField("Ganhadores Quina");
                    csvWriter.WriteField("Ganhadores Sena");
                    csvWriter.WriteField("Numero de boloes");
                    csvWriter.WriteField("Numero de apostas");
                    csvWriter.NextRecord();

                    StringBuilder str = new StringBuilder();
                    foreach (var concurso in concursos)
                    {
                        str.Clear();
                        csvWriter.WriteField(concurso.Id);
                        foreach (var numero in concurso.Resultado.NumerosSorteados)
                        {
                            str.Append(numero);
                            str.Append(",");
                        }
                        csvWriter.WriteField(str);
                        csvWriter.WriteField(concurso.Data);
                        csvWriter.WriteField(concurso.Faturamento);
                        csvWriter.WriteField(concurso.IsFechado ? "Sim" : "Não");
                        csvWriter.WriteField(concurso.Premio.Total);
                        csvWriter.WriteField(concurso.Premio.Quadra);
                        csvWriter.WriteField(concurso.Premio.Quina);
                        csvWriter.WriteField(concurso.Premio.Sena);
                        csvWriter.WriteField(concurso.Resultado.MediaQuadra);
                        csvWriter.WriteField(concurso.Resultado.MediaQuina);
                        csvWriter.WriteField(concurso.Resultado.MediaSena);
                        csvWriter.WriteField(concurso.Ganhadores.Quadra);
                        csvWriter.WriteField(concurso.Ganhadores.Quina);
                        csvWriter.WriteField(concurso.Ganhadores.Sena);
                        csvWriter.WriteField(concurso.Boloes.Count);
                        csvWriter.WriteField(concurso.Apostas.Count);
                        csvWriter.NextRecord();
                    }
                }
            }
        }
    }
}
