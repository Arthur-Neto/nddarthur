using Effort;
using Effort.Provider;
using MF6.Infra.ORM.Tests.Contexts;
using NUnit.Framework;
using System;

namespace MF6.Infra.ORM.Tests.Initializer {

    [TestFixture]
    public class EffortTestBase {
        protected FakeDbContext _contexto;

        [OneTimeSetUp]
        public void InitializeOneTime() {
            EffortProviderConfiguration.RegisterProvider();
        }

        [SetUp]
        public virtual void Initialize() {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _contexto = new FakeDbContext(connection);

            EffortProviderFactory.ResetDb();

            //SEED

            _contexto.SaveChanges();
        }
    }
}