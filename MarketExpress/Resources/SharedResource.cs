using Microsoft.Extensions.Localization;

namespace MarketExpress.Resources
{
    public class SharedResource
    {
        private readonly IStringLocalizer<SharedResource> _localizer;

        public SharedResource(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
        }

        public string WelcomeMessage => GetString("WelcomeMessage");
        public string AddCategory => GetString("AddCategory");
        public string AddCategoryTitle => GetString("AddCategoryTitle");
        public string CategoryTitle => GetString("CategoryTitle");
        public string ConfirmDeletion => GetString("ConfirmDeletion");
        public string DeleteCategoryConfirm(string categoryName) => GetString("DeleteCategoryConfirm", categoryName);
        public string DeleteCategoryTitle => GetString("DeleteCategoryTitle");
        public string EditCategory => GetString("EditCategory");
        public string EditCategoryTitle => GetString("EditCategoryTitle");
        public string ListCategory => GetString("ListCategory");

        private string GetString(string key)
        {
            return _localizer[key];
        }

        private string GetString(string key, params object[] args)
        {
            return _localizer[key, args];
        }
    }
}
