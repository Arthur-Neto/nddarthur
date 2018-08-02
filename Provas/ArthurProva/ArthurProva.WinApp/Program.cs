using ArthurProva.Infra.Singleton;
using System;
using System.Windows.Forms;

namespace ArthurProva.WinApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfiguracaoSingleton.Instancia.Tipo = Infra.TipoRepositorio.SQL_SERVER;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormPrincipal());
        }
    }
}
