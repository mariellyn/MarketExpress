using MarketExpress.Models;

namespace MarketExpress.Helper
{
    public interface ISection
    {
        void CreateUserSection(UserModel user);
        void RemoveUserSection();
        UserModel SearchUserSection();
    }
}
