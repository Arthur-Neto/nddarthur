using Prova1.Infra.ORM.Contexts;
using System.Data.Entity;

namespace Prova1.Infra.ORM.Initializer
{
    /// <summary>
    /// Inicializador do Banco de dados.
    /// 
    /// Essa classe define a estratégia de inicializaçaõ do banco.
    /// </summary>
    public class DbInitializer : MigrateDatabaseToLatestVersion<Prova1DbContext, MigrationConfiguration>
    {
    }
}
