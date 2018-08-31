using Arthur.MF7.WebAPI.Controllers.Common;
using FluentAssertions;
using NUnit.Framework;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Arthur.MF7.Controllers.Tests.Common
{
    [TestFixture]
    public class PublicControllerTests
    {
        private PublicController _publicController;

        [SetUp]
        public void Initialize()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _publicController = new PublicController()
            {
                Request = request
            };
        }

        #region GET

        [Test]
        public void Public_Controller_Get_ShouldOk()
        {
            // Action
            IHttpActionResult callback = _publicController.IsAlive();

            //Assert
            OkNegotiatedContentResult<bool> httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
        }

        #endregion
    }
}
