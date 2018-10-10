using AutoMapper;

namespace Prova1.Application.Mapping
{
    /// <summary>
    /// 
    /// Inicializador do AutoMapper. 
    /// 
    /// É responsavel por registrar todos os mapeamentos realizados.
    /// 
    /// </summary>
    public class AutoMapperInitializer
    {
        /// <summary>
        /// Método para inicializar o automapper. 
        /// </summary>
        public static void Initialize()
        {
            // Obtém a configuração do automapper (cfg) 
            // e adiciona todas as configurações realizadas nesse projeto (assembly) 
            // que são classes que herdam da classe Profile (aqui chamada de MappingProfile)
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(typeof(AutoMapperInitializer));
            });
        }

        public static void Reset() => Mapper.Reset();
    }
}