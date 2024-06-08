using MarketExpress.Enums;
using MarketExpress.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace MarketExpress.Filters
{
    public class PageSalesLogged : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sectionUser = context.HttpContext.Session.GetString("sectionUserLogged");

            if (!string.IsNullOrEmpty(sectionUser))
            {
                UserModel user = JsonConvert.DeserializeObject<UserModel>(sectionUser);

                if (user != null && user.Profile == ProfileEnum.Sales)
                {
                    // Aqui você pode adicionar a lógica para verificar se a ação atual é permitida para o perfil de "sales"
                    if (!IsSalesAllowedAction(context))
                    {
                        context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Restrict" }, { "action", "Index" } });
                        return;
                    }
                }
            }

            base.OnActionExecuting(context);
        }

        private bool IsSalesAllowedAction(ActionExecutingContext context)
        {
            // Adicione a lógica para permitir ou negar acesso para o perfil "sales" aqui
            // Por exemplo, verifique se a ação é relacionada a produtos ou vendas no estado "commissioned"
            string actionName = context.RouteData.Values["action"].ToString();
            string controllerName = context.RouteData.Values["controller"].ToString();
            string status = context.HttpContext.Request.Query["status"].ToString();

            if ((controllerName == "Product" || (controllerName == "Sales" && status == "Commissioned")) && actionName != "Index")
            {
                return true;
            }

            return false;
        }
    }
}
