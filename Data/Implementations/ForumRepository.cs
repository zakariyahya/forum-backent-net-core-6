using forum.Data.Interface;
using forum.Models;

namespace forum.Data.Implementations
{
    public class ForumRepository : IForumRepository
    {
        private readonly DbContextClass context;

        public ForumRepository(DbContextClass context)
        {
            this.context = context;
        }
        public void createForum(MainForum forum)
        {
            context.mainForums.Add(forum);
            context.SaveChanges();
        }

        public void deleteForum(int id)
        {
            throw new NotImplementedException();
        }

        public MainForum forumById(int id)
        {
            return context.mainForums.FirstOrDefault(x => x.id == id);
        }

        public IEnumerable<MainForum> forums()
        {
            return context.mainForums.ToList();
        }

        public bool saveChanges()
        {
            return (context.SaveChanges() >= 0);

        }

        public void updateForum(MainForum forum)
        {
            // throw new NotImplementedException();
        }
    }
}