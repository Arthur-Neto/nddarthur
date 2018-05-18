using System.Configuration;
using System.Data.Common;

namespace Mariana.Infra.Data.Nucleo
{
    public static class ConexaoDBFactory
    {
        public static DbConnection CriarConexao(TipoRepositorio tipo)
        {
            ConnectionStringSettings config = ObterStringDeConexao(tipo);

            DbProviderFactory factory = DbProviderFactories.GetFactory(config.ProviderName);

            return factory.CreateConnection();
        }

        public static ConnectionStringSettings ObterStringDeConexao(TipoRepositorio tipo)
        {
            string nome = TipoRepositorioUtil.ObterNomeDaPropriedade(tipo);
            foreach (ConnectionStringSettings css in ConfigurationManager.ConnectionStrings)
            {
                if (css.Name.Equals(nome))
                    return css;
            }

            return null;
        }
    }
}
