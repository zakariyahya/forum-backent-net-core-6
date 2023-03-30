using forum.Models;

namespace forum.Data
{
    public interface IRoleRepository
    {
        void create(Role role);
        public bool saveChanges();
    }
}