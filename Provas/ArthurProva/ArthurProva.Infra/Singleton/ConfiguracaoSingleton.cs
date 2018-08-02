using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArthurProva.Infra.Singleton
{
    public class ConfiguracaoSingleton
    {
        private static ConfiguracaoSingleton _instancia;
        public TipoRepositorio Tipo { get; set; }

        private ConfiguracaoSingleton() { }

        public static ConfiguracaoSingleton Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new ConfiguracaoSingleton();
                }
                return _instancia;
            }
        }
    }
}
