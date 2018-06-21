using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TutorialORM.Dominio.Features.Enderecos;
using TutorialORM.Infra.Data.Base;

namespace TutorialORM.Infra.Data.Features.Enderecos
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        public Endereco Atualizar(Endereco endereco)
        {
            using (var db = new EscolaContext())
            {
                db.Enderecos.Attach(endereco);
                db.Entry(endereco).State = EntityState.Modified;
                db.SaveChanges();
            }

            return endereco;
        }

        public void Deletar(Endereco endereco)
        {
            using (var db = new EscolaContext())
            {
                db.Enderecos.Attach(endereco);
                db.Enderecos.Remove(endereco);
                db.SaveChanges();
            }
        }

        public Endereco PegarPorId(long id)
        {
            Endereco endereco;
            using (var db = new EscolaContext())
            {
                endereco = db.Enderecos.Find(id);
            }
            return endereco;
        }

        public IEnumerable<Endereco> PegarTodos()
        {
            IEnumerable<Endereco> enderecos;
            using (var db = new EscolaContext())
            {
                enderecos = db.Enderecos.ToList();
            }
            return enderecos;
        }

        public Endereco Salvar(Endereco endereco)
        {
            using (var db = new EscolaContext()) {
                endereco = db.Enderecos.Add(endereco);
                db.SaveChanges();
            }
            return endereco;
        }
    }
}
