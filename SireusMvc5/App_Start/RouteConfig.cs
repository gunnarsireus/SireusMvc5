using System.Web.Mvc;
using System.Web.Routing;

namespace SireusMvc5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Handler", // Route name
                "{Controller}/{action}/{arg1}/{arg2}");

            routes.MapRoute(
                "Calculateen", // Route name
                "{Controller}/{action}/{Conf}/{RLD}/{LTBMM}/{LTBDD}/{LTBYY}/{EOSMM}/{EOSDD}/{EOSYY}/{IB0}/{IB1}/{IB2}/{IB3}/{IB4}/{IB5}/{IB6}/{IB7}/{IB8}/{IB9}/{IB10}/{RS0}/{RS1}/{RS2}/{RS3}/{RS4}/{RS5}/{RS6}/{RS7}/{RS8}/{RS9}/{FR0}/{FR1}/{FR2}/{FR3}/{FR4}/{FR5}/{FR6}/{FR7}/{FR8}/{FR9}/{RL0}/{RL1}/{RL2}/{RL3}/{RL4}/{RL5}/{RL6}/{RL7}/{RL8}/{RL9}");

            routes.MapRoute(
                "Calculatesv", // Route name
                "{Controller}/{action}/{Conf}/{RLD}/{LTB}/{EOS}/{IB0}/{IB1}/{IB2}/{IB3}/{IB4}/{IB5}/{IB6}/{IB7}/{IB8}/{IB9}/{IB10}/{RS0}/{RS1}/{RS2}/{RS3}/{RS4}/{RS5}/{RS6}/{RS7}/{RS8}/{RS9}/{FR0}/{FR1}/{FR2}/{FR3}/{FR4}/{FR5}/{FR6}/{FR7}/{FR8}/{FR9}/{RL0}/{RL1}/{RL2}/{RL3}/{RL4}/{RL5}/{RL6}/{RL7}/{RL8}/{RL9}");

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}