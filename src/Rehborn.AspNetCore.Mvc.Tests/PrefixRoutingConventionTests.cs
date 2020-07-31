using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Rehborn.AspNetCore.Mvc.ApplicationModels.ApplicationModelConvention;
using System.Reflection;
using Xunit;

namespace Rehborn.AspNetCore.Mvc.Tests
{
    public class PrefixRoutingConventionTests
    {
        [Theory]
        [InlineData("simplePrefix")]
        public void Test1(string testPrefix)
        {
            var controller = new WeatherForecastController();
            var controllerModel = CreateControllerModel(controller);
            var convention = new PrefixRoutingConvention(testPrefix);
            convention.Apply(controllerModel);

            foreach (var selector in controllerModel.Selectors)
            {
                Assert.StartsWith(testPrefix + "/", selector.AttributeRouteModel.Template);
            }
        }

        private ControllerModel CreateControllerModel(ControllerBase controller)
        {
            return new ControllerModel(controller.GetType().GetTypeInfo(),
                                       System.Attribute.GetCustomAttributes(controller.GetType()));
        }
    }
}
