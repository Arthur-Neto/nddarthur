using Loterica.Dominio.Base;
using Loterica.Dominio.Features.Apostas;
using Loterica.Dominio.Features.Concursos;
using System;
using System.Collections.Generic;

namespace Loterica.Dominio.Features.Boloes
{
    public class Bolao : Entidade
    {
        public virtual List<Aposta> Apostas { get; set; }

        public Bolao()
        {
            Apostas = new List<Aposta>();
        }

        public override void Validar()
        {
            if (Apostas.Count < 2)
                throw new BolaoApostasInsuficienteException();
        }

        public Bolao GerarBolao(int quantidadeApostas, Concurso concurso)
        {
            Random random = new Random();
            Aposta aposta;
            for (int i = 0; i < quantidadeApostas; i++)
            {
                aposta = new Aposta();
                aposta.Concurso = concurso;
                aposta.Data = DateTime.Now;
                aposta.Validade = DateTime.Now.AddDays(+90);
                aposta.Valor = 3.5m;
                for (int j = 0; j < 6; j++)
                {
                    var num = 0;
                    while(aposta.Numeros.Contains(num))
                        num = random.Next(1, 60);

                    aposta.Numeros.Add(num);
                }
                aposta.Numeros.Sort();
                this.Apostas.Add(aposta);
            }
            return this;
        }
    }
}
