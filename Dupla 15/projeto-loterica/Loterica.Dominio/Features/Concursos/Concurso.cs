using Loterica.Dominio.Base;
using Loterica.Dominio.Features.Apostas;
using Loterica.Dominio.Features.Boloes;
using Loterica.Dominio.Features.Cortes;
using Loterica.Dominio.Features.Ganhadores;
using Loterica.Dominio.Features.Premios;
using Loterica.Dominio.Features.Resultados;
using System;
using System.Collections.Generic;

namespace Loterica.Dominio.Features.Concursos
{
    public class Concurso : Entidade
    {
        public virtual bool IsFechado { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual List<Aposta> Apostas { get; set; }
        public virtual List<Bolao> Boloes { get; set; }
        public virtual Resultado Resultado { get; set; }
        public virtual decimal Faturamento { get; set; }
        public virtual Ganhador Ganhadores { get; set; }
        public virtual Premio Premio { get; set; }
        public virtual Corte Corte { get; set; }

        public Concurso()
        {
            Apostas = new List<Aposta>();
            Boloes = new List<Bolao>();
            Resultado = new Resultado();
            Premio = new Premio();
            Ganhadores = new Ganhador();
        }
        
        public void FecharConcurso()
        {
            IsFechado = true;

            foreach (var aposta in Apostas)
            {
                aposta.NumerosAcertados = aposta.NumerosAcertos();
            }
            foreach (var bolao in Boloes)
            {
                foreach (var aposta in bolao.Apostas)
                {
                    aposta.NumerosAcertados = aposta.NumerosAcertos();
                }
            }

            CalcularGanhadores();
            CalcularPremio();
            Resultado.CalcularMediaPremio(this);
        }

        private void CalcularGanhadores()
        {
            foreach (var aposta in Apostas)
            {
                if (aposta.IsGanhadora() == EstadoAposta.GANHADORA_QUADRA)
                    Ganhadores.Quadra++;
                else if (aposta.IsGanhadora() == EstadoAposta.GANHADORA_QUINA)
                    Ganhadores.Quina++;
                else if (aposta.IsGanhadora() == EstadoAposta.GANHADORA_SENA)
                    Ganhadores.Sena++;
            }
        }

        private void CalcularPremio()
        {
            if (Boloes.Count != 0)
            {
                foreach (var boloes in Boloes)
                {
                    foreach (var apostas in boloes.Apostas)
                    {
                        Premio.Total += apostas.Valor;
                    }
                }

                Faturamento = Premio.Total * 0.05m;
                Premio.Total *= 0.95m;
            }

            if (Apostas.Count != 0)
            {
                foreach (var apostas in Apostas)
                {
                    Premio.Total += apostas.Valor;
                }

                Faturamento += Premio.Total * 0.1m;
                Premio.Total *= 0.9m;
            }

            Corte = new Corte();

            CalcularCortePorGanhador();

            Premio.Sena = Premio.Total * Corte.Sena;
            Premio.Quina = Premio.Total * Corte.Quina;
            Premio.Quadra = Premio.Total * Corte.Quadra;
        }

        private void CalcularCortePorGanhador()
        {
            if (Ganhadores.Sena > 0 && Ganhadores.Quina == 0 && Ganhadores.Quadra == 0)
            {
                Corte.Sena = 1;
                Corte.Quina = 0;
                Corte.Quadra = 0;
            }
            else if (Ganhadores.Sena > 0 && Ganhadores.Quina > 0 && Ganhadores.Quadra == 0)
            {
                Corte.Sena = 0.8m;
                Corte.Quina = 0.2m;
                Corte.Quadra = 0;
            }
            else if (Ganhadores.Sena == 0 && Ganhadores.Quina > 0 && Ganhadores.Quadra == 0)
            {
                Corte.Sena = 0;
                Corte.Quina = 0.25m;
                Corte.Quadra = 0;
            }
            else if (Ganhadores.Sena == 0 && Ganhadores.Quina > 0 && Ganhadores.Quadra > 0)
            {
                Corte.Sena = 0;
                Corte.Quina = 0.2m;
                Corte.Quadra = 0.1m;
            }
            else if (Ganhadores.Sena == 0 && Ganhadores.Quina == 0 && Ganhadores.Quadra > 0)
            {
                Corte.Sena = 0;
                Corte.Quina = 0;
                Corte.Quadra = 0.1m;
            }
            else if (Ganhadores.Sena > 0 && Ganhadores.Quina == 0 && Ganhadores.Quadra > 0)
            {
                Corte.Sena = 0.9m;
                Corte.Quina = 0;
                Corte.Quadra = 0.1m;
            }
            else
            {
                Corte.Sena = 0.7m;
                Corte.Quina = 0.2m;
                Corte.Quadra = 0.1m;
            }
        }

        public override void Validar()
        {
            throw new InvalidOperationException();
        }
    }
}
