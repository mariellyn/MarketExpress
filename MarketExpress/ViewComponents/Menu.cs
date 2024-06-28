using MarketExpress.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MarketExpress.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MenuViewComponent(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sectionUser = _httpContextAccessor.HttpContext.Session.GetString("sectionUserLogged");

            if (string.IsNullOrEmpty(sectionUser))
            {
                // Se não houver usuário logado, você pode retornar um componente ou uma mensagem indicando isso.
                // Neste caso, vamos retornar uma ViewComponentResult vazia para não renderizar nada no menu.
                return Content("Usuário não está logado");
            }

            var user = JsonConvert.DeserializeObject<UserModel>(sectionUser);
            return View(user);
        }
    }
}
