using forum.Models;

namespace forum.Data.Interfaces
{
    public interface IForumSubscription
    {
        // IEnumerable<ForumSubscription> forumSubscriptions();
        void createForumSubs(int user_id, MainForum forum);
        void updateForumSubs(int user_id, MainForum forums);
        // void deleteForumSubs(ForumSubscription forum_subs);
        ForumSubscription forumSubsById(int id);
        public bool saveChanges();
    }
}