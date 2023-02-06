using forum.Models;

namespace forum.Data.Interface
{
    public interface IUserServiceRepository
    {
        User authenticate(string username, string password);
        User getById(int id);
        User create(User user, string password);

    }
}