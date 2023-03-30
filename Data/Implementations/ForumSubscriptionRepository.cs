using forum.Data.Interfaces;
using forum.Models;
using Microsoft.EntityFrameworkCore;

namespace forum.Data.Implementations
{
    public class ForumSubscriptionRepository : IForumSubscription
    {
        private readonly DbContextClass context;

        public ForumSubscriptionRepository(DbContextClass context)
        {
            this.context = context;
        }
        public void createForumSubs(int user_id, MainForum forum)
        {
            var user = context.Users.FirstOrDefault(x => x.id == user_id);
            ForumSubscription forumSubs = new ForumSubscription();
            forumSubs.user = user;
            forumSubs.forum = forum;
            context.forumSubs.Add(forumSubs);
            saveChanges();
        }

        public Models.ForumSubscription forumSubsById(int id)
        {
            throw new NotImplementedException();
        }

        public bool saveChanges()
        {
            return (context.SaveChanges() >= 0);
        }

        public void updateForumSubs(int user_id, MainForum forum)
        {
            // var user = context.mainForums.Where(x => x.user.id == user_id);
            // foreach (var forum in forums)
            // {
            //     ForumSubscription forumSubs = new ForumSubscription();
            //     // forumSubs.user = user;
            //     // forumSubs.forum = forum;
            //     context.mainForums.Update(forum);
            //     saveChanges();
            // // }

            context.mainForums.Update(forum);
                saveChanges();

        }
    }
}