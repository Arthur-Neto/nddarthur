namespace Mariana.Infra
{
    public enum TipoRepositorio
    {

        SQL_SERVER,
        MY_SQL
    }

    public static class TipoRepositorioUtil
    {
        public static string ObterNomeDaPropriedade(TipoRepositorio tipo)
        {
            switch (tipo)
            {
                case TipoRepositorio.SQL_SERVER:
                    return "NDD.db.SQLServer";
                case TipoRepositorio.MY_SQL:
                    return "NDD.db.MySQL";
            }

            return null;
        }

        public static string ObterApelido(TipoRepositorio tipo)
        {
            switch (tipo)
            {
                case TipoRepositorio.SQL_SERVER:
                    return "@";
                case TipoRepositorio.MY_SQL:
                    return "?";
            }

            return null;
        }
    }
}
