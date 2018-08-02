using ArthurProva.Domain.Interfaces;
using ArthurProva.Infra.Data.SQL;
using ArthurProva.Infra.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArthurProva.Infra.Data
{
    public static class RepositorioIoC
    {
        public static IContatoRepositorio Contato { get; set; }
        public static ICompromissoRepositorio Compromisso { get; set; }

        static RepositorioIoC()
        {
            Contato = new ContatoRepositorio(ConfiguracaoSingleton.Instancia.Tipo);
            Compromisso = new CompromissoRepositorio(ConfiguracaoSingleton.Instancia.Tipo);
        }

    }
}
