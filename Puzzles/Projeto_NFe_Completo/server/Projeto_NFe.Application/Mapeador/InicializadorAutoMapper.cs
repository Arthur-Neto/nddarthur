using AutoMapper;

namespace Projeto_NFe.Application.Mapeador
{
    /// <summary>
    /// 
    /// Inicializador do AutoMapper. 
    /// 
    /// É responsavel por registrar todos os mapeamentos realizados.
    /// 
    /// </summary>
    public class InicializadorAutoMapper
    {
        /// <summary>
        /// Método para inicializar o automapper. 
        /// </summary>
        public static void Inicializar()
        {
            // Obtém a configuração do automapper (cfg) 
            // e adiciona todas as configurações realizadas nesse projeto (assembly) 
            // que são classes que herdam da classe Profile (aqui chamada de MappingProfile)
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(typeof(InicializadorAutoMapper));
            });
        }

        public static void Resetar() => Mapper.Reset();
    }
}