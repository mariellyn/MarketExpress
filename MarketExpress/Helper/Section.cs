using MarketExpress.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MarketExpress.Helper
{
    public class Section : ISection
    {
        private readonly IHttpContextAccessor _httpContext;

        public Section(IHttpContextAccessor httpContext) 
        {
            _httpContext = httpContext;


        }
        public UserModel SearchUserSection()
        {
            string sectionUser = _httpContext.HttpContext.Session.GetString("sectionUserLogged");

            if (string.IsNullOrEmpty(sectionUser)) return null;

            return JsonConvert.DeserializeObject<UserModel>(sectionUser);
        }

        public void CreateUserSection(UserModel user)
        {
            string value = JsonConvert.SerializeObject(user);
            _httpContext.HttpContext.Session.SetString("sectionUserLogged", value);
        }

        public void RemoveUserSection()
        {
            _httpContext.HttpContext.Session.Remove("sectionUserLogged");
        }


    }
}
