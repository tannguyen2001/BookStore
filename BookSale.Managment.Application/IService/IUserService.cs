namespace BookSale.Managment.Application.IService
{
    public interface IUserService
    {
        Task<bool> CheckLogin(string username, string password);
        Task Logout();
    }
}