using forum.Models;

namespace forum.Data
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContextClass context;

        public RoleRepository(DbContextClass context)
        {
            this.context = context;
        }
        public void create(Role role)
        {
           context.Roles.Add(role);
           saveChanges();
        }

        public bool saveChanges()
        {
            return (context.SaveChanges() >= 0);
        }
    }
}