using System.IO;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;

namespace Microsoft.PowerBI.AspNet.Mvc.Tests
{
    public static class TestHelper
    {
        public static HtmlHelper<TModel> CreateHtmlHelper<TModel>(ViewDataDictionary<TModel> viewDataDictionary, IPrincipal principal = null)
        {
            var httpContextMock = new Mock<HttpContextBase>();

            if (principal != null)
            {
                httpContextMock
                    .Setup(m => m.User)
                    .Returns(principal);
            }

            var controllerContext = new ControllerContext(
                httpContextMock.Object,
                new RouteData(),
                new Mock<ControllerBase>().Object);

            var viewContext = new ViewContext(
                controllerContext,
                new Mock<IView>().Object,
                viewDataDictionary,
                new TempDataDictionary(),
                new StreamWriter(new MemoryStream()));

            var viewDataContainerMock = new Mock<IViewDataContainer>();
            viewDataContainerMock
                .Setup(v => v.ViewData)
                .Returns(viewDataDictionary);

            return new HtmlHelper<TModel>(viewContext, viewDataContainerMock.Object);
        }
    }
}
