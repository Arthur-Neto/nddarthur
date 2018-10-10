using NUnit.Framework;
using Prova1.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova1.Application.Tests.Initializer
{
    [TestFixture]
    public class TestServiceBase
    {
        [OneTimeSetUp]
        public void InitializeOnceTime()
        {
            AutoMapperInitializer.Reset();
            AutoMapperInitializer.Initialize();
        }
    }
}
