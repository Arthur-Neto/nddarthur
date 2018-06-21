using System;
using TutorialORM.Dominio.Base;

namespace TutorialORM.Dominio.Features.Turmas
{
    public class Turma : Entidade
    {
        public string Descricao { get; set; }

        public override void Validar()
        {
            if (String.IsNullOrWhiteSpace(Descricao))
                throw new TurmaDescricaoVaziaException();
        }
    }
}
