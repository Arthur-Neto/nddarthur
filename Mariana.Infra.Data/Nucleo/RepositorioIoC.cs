using Mariana.Dominio;
using Mariana.Dominio.Interfaces;
using Mariana.Infra.Data.SQL;
using Mariana.Infra.Singleton;

namespace Mariana.Infra.Data.Nucleo
{
    public static class RepositorioIoC
    {
        public static IDisciplinaRepositorio Disciplina { get; internal set; }
        public static ISerieRepositorio Serie { get; internal set; }
        public static IMateriaRepositorio Materia { get; internal set; }
        public static IQuestaoRepositorio Questao { get; internal set; }
        public static ITesteRepositorio Teste { get; internal set; }
        public static IRespostaRepositorio Resposta { get; internal set; }

        static RepositorioIoC()
        {
            Disciplina = new DisciplinaSQLRepositorio(ConfiguracaoSingleton.Instancia.Tipo);
            Serie = new SerieSQLRepositorio(ConfiguracaoSingleton.Instancia.Tipo);
            Materia = new MateriaSQLRepositorio(ConfiguracaoSingleton.Instancia.Tipo);
            Questao = new QuestaoSQLRepositorio(ConfiguracaoSingleton.Instancia.Tipo);
            Resposta = new RespostaSQLRepositorio(ConfiguracaoSingleton.Instancia.Tipo);
            Teste = new TesteSQLRepositorio(ConfiguracaoSingleton.Instancia.Tipo);
        }
    }
}
