using forum.Models;
using Microsoft.EntityFrameworkCore;

namespace forum.Data
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly DbContextClass context;

        public UserRoleRepository(DbContextClass context)
        {
            this.context = context;
        }
        public void createUserRoles(string[] roles, User user)
        {
            foreach (var roleName in roles)
            {
                var role = context.Roles.FirstOrDefault(x => x.name == roleName);
                if(role != null)
                {
                    UserRole userRole = new UserRole();
                    userRole.user = user;
                    userRole.role = role;
                    context.UserRoles.Add(userRole);
                    saveChanges();
                }
            }
        }

        public bool saveChanges()
        {
            return (context.SaveChanges() >= 0);
        }

        public IEnumerable<UserRole> userRoles(int id)
        {
            var items = context.UserRoles.Include(u => u.user).Include(r => r.role).Where(u=> u.user.id == id).ToList();
            return items;
        }
    }
}