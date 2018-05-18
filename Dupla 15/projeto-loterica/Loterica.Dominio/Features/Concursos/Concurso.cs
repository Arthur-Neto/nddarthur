using Loterica.Dominio.Base;
using Loterica.Dominio.Features.Apostas;
using Loterica.Dominio.Features.Boloes;
using Loterica.Dominio.Features.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Dominio.Features.Concursos
{
    public class Concurso : Entidade
    {
        public virtual bool IsFechado { get; set; } = false;
        public virtual DateTime Data { get; set; }
        public virtual List<Aposta> Apostas { get; set; }
        public virtual List<Bolao> Boloes { get; set; }
        public virtual decimal Faturamento { get; set; }
        public virtual Resultado Resultado { get; set; }
        private List<Aposta> _ganhadores;
        public virtual List<Aposta> Ganhadores
        {
            get
            {
                _ganhadores = new List<Aposta>();

                foreach (var aposta in Apostas)
                {
                    if (aposta.IsGanhadora())
                        _ganhadores.Add(aposta);
                }

                return _ganhadores;
            }
        }

        private decimal _premio = 0;
        public virtual decimal Premio
        {
            get
            {
                CalcularPremio();
                return _premio;
            }
            set
            {
                _premio = value;
            }
        }

        private decimal _premioQuadra = 0;
        public virtual decimal PremioQuadra
        {
            get
            {
                CalcularPremio();
                return _premioQuadra;
            }
            set
            {
                _premioQuadra = value;
            }
        }

        private decimal _premioQuina = 0;
        public virtual decimal PremioQuina
        {
            get
            {
                CalcularPremio();
                return _premioQuina;
            }
            set
            {
                _premioQuina = value;
            }
        }

        private decimal _premioSena = 0;
        public virtual decimal PremioSena
        {
            get
            {
                CalcularPremio();
                return _premioSena;
            }
            set
            {
                _premioSena = value;
            }
        }

        private void CalcularPremio()
        {
            if (_premio != 0)
            {
                return;
            }

            var ganhadoresQuadra = 0;
            var ganhadoresQuina = 0;
            var ganhadoresSena = 0;
            if (Boloes.Count != 0)
            {
                foreach (var boloes in Boloes)
                {
                    foreach (var apostas in boloes.Apostas)
                    {
                        _premio += apostas.Valor;
                        CalcularGanhadores(ref ganhadoresQuadra, ref ganhadoresQuina, ref ganhadoresSena, apostas);
                    }
                }

                Faturamento = _premio * 0.05m;
                _premio *= 0.95m;
            }

            if (Apostas.Count != 0)
            {
                foreach (var apostas in Apostas)
                {
                    _premio += apostas.Valor;
                    CalcularGanhadores(ref ganhadoresQuadra, ref ganhadoresQuina, ref ganhadoresSena, apostas);
                }

                Faturamento += _premio * 0.1m;
                _premio *= 0.9m;
            }

            DividirPremio(ganhadoresQuadra, ganhadoresQuina, ganhadoresSena);

        }

        private void DividirPremio(int ganhadoresQuadra, int ganhadoresQuina, int ganhadoresSena)
        {
            if (ganhadoresSena > 0 && ganhadoresQuina == 0 && ganhadoresQuadra == 0)
            {
                _premioSena = _premio;
                return;
            }
            else if (ganhadoresSena > 0 && ganhadoresQuina > 0 && ganhadoresQuadra == 0)
            {
                _premioSena = _premio * 0.8m;
                _premioQuina = _premio * 0.2m;
            }
            else if (ganhadoresSena == 0 && ganhadoresQuina > 0 && ganhadoresQuadra == 0)
            {
                _premioQuina = _premio * 0.25m;
            }
            else if (ganhadoresSena == 0 && ganhadoresQuina > 0 && ganhadoresQuadra > 0)
            {
                _premioQuina = _premio * 0.2m;
                _premioQuadra = _premio * 0.1m;
            }
            else if (ganhadoresSena == 0 && ganhadoresQuina == 0 && ganhadoresQuadra > 0)
            {
                PremioQuadra = _premio * 0.1m;
            }
            else if (ganhadoresSena > 0 && ganhadoresQuina == 0 && ganhadoresQuadra > 0)
            {
                _premioQuadra = _premio * 0.1m;
                _premioSena = _premio * 0.9m;
            }
            else
            {
                _premioQuadra = _premio * 0.1m;
                _premioQuina = _premio * 0.2m;
                _premioSena = _premio * 0.7m;
            }
        }

        private static void CalcularGanhadores(ref int ganhadoresQuadra, ref int ganhadoresQuina, ref int ganhadoresSena, Aposta apostas)
        {
            if (apostas.NumerosAcertados == 4)
                ganhadoresQuadra++;
            if (apostas.NumerosAcertados == 5)
                ganhadoresQuina++;
            if (apostas.NumerosAcertados == 6)
                ganhadoresSena++;
        }

        public Concurso()
        {
            Apostas = new List<Aposta>();
            Boloes = new List<Bolao>();
        }

        public override void Validar()
        {

        }
    }
}
