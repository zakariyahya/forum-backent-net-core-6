using forum.Models;

namespace forum.Data.Interface
{
    public interface IForumRepository
    {
        IEnumerable<MainForum> forums();
        void createForum(MainForum forum);
        void updateForum(MainForum forum);
        void deleteForum(int id);
        MainForum forumById(int id);
        public bool saveChanges();
    }
}