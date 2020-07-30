using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Linq;

namespace Rehborn.AspNetCore.Mvc.ApplicationModels.ApplicationModelConvention
{
    /// <summary>
    /// Add prefix to <see cref="Microsoft.AspNetCore.Mvc.RouteAttribute.Template"/>.
    /// </summary>
    public class PrefixRoutingConvention : Attribute, IControllerModelConvention
    {
        private readonly string _routePrefix;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="routePrefix">The prefix that should be added to route attribute template</param>
        public PrefixRoutingConvention(string routePrefix)
        {
            if (string.IsNullOrWhiteSpace(routePrefix))
            {
                throw new ArgumentException("message", nameof(routePrefix));
            }

            _routePrefix = routePrefix;
        }

        public void Apply(ControllerModel controller)
        {
            var hasRouteAttributes = controller.Selectors.Any(selector =>
                                                    selector.AttributeRouteModel != null);
            if (!hasRouteAttributes)
            {
                return;
            }

            foreach (var selector in controller.Selectors)
            {
                var newRoute = string.Join('/', _routePrefix, selector.AttributeRouteModel.Template);
                selector.AttributeRouteModel = new AttributeRouteModel()
                {
                    Template = newRoute
                };
            }
        }
    }
}
