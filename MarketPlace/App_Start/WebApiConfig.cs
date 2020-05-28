using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MarketPlace
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("ProductList", "api/Products/List", new { controller = "Products", action = "ProductList" });
            config.Routes.MapHttpRoute("ProductCategoryList", "api/ProductCategory/List", new { controller = "Products", action = "ProductCategoryList" });
            config.Routes.MapHttpRoute("AddProduct", "api/Products/Add", new { controller = "Products", action = "AddProduct" });
            config.Routes.MapHttpRoute("AddCategory", "api/Products/Category/Add", new { controller = "Products", action = "AddCategory" });

            config.Routes.MapHttpRoute("Get", "api/Get", new { controller = "Products", action = "Get" });

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
        }
    }
}
