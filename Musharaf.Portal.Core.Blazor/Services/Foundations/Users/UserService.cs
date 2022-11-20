namespace Musharaf.Portal.Core.Blazor.Services.Foundations.Users
{
    public class UserService : IUserService
    {
        public Guid GetCurrentlyLoggedInUser() => Guid.NewGuid();
    }
}
