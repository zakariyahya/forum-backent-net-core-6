using forum.Models;

namespace forum.Data
{   
    public interface IUserRoleRepository
    {
        void createUserRoles(string[] roles, User user);
        IEnumerable<UserRole> userRoles(int id);
        public bool saveChanges();

    }
}