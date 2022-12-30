using zoneFlower.ViewModel.System.User;

namespace zoneFlower.AdminApp.Services
{
    public interface IUserApiClient
    {
        public Task<string> Authenticate(LoginRequest request);
    }
}
