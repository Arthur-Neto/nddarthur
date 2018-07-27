using Effort.Provider;
using NUnit.Framework;

namespace Bank.Infra.Data.Tests.Initializer
{
    [TestFixture]
    public class EffortTestBase
    {
        [OneTimeSetUp]
        public void InitializeOneTime()
        {
            EffortProviderConfiguration.RegisterProvider();
        }

        [SetUp]
        public void Initialize()
        {
            EffortProviderFactory.ResetDb();
        }
    }
}
