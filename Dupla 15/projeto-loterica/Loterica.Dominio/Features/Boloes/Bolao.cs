using Loterica.Dominio.Base;
using Loterica.Dominio.Features.Apostas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Dominio.Features.Boloes
{
    public class Bolao : Entidade
    {
        public Bolao()
        {
            Apostas = new List<Aposta>();
        }

        public virtual List<Aposta> Apostas { get; set; }

        public override void Validar()
        {
            if (Apostas.Count < 2)
                throw new BolaoApostasInsuficienteException();
        }

        //public Bolao GerarBolao(int quantidadeApostas)
        //{
        //    Random random = new Random();
        //    Bolao bolao = new Bolao();

        //    for (int i = 0; i < quantidadeApostas; i++)
        //    {
        //        Aposta aposta = new Aposta();

        //        for (int j = 0; j < 6; j++)
        //        {
        //            aposta.Numeros[j] = random.Next(01, 60);
        //        }
                                
        //        bolao.Apostas.Add(aposta);
        //    }
        //    return bolao;
        //}
    }
}
