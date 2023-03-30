using forum.Data.Interfaces;
using forum.Dtos;
using forum.Models;


namespace forum.Data.Implementations
{
    public class PostService : IPostService
    {
        private readonly DbContextClass context;
        private readonly IWebHostEnvironment environment;
        public PostService(DbContextClass context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        public async Task<PostResponse> CreatePostAsync(PostRequest postRequest)
        {
            var user = context.Users.FirstOrDefault(x => x.id == postRequest.UserId);
            var uniqueFileName = FileHelper.GetUniqueFileName(postRequest.Image.FileName);
            var uploads = Path.Combine(environment.WebRootPath, "users", "posts", postRequest.UserId.ToString());
            var filePath = Path.Combine(uploads, uniqueFileName).Replace("\\", "/");
            var post = new Post()
            {
                user = user,
                Description = postRequest.Description,
                Imagepath = filePath,
                Ts = DateTime.Now,
                Published = true
            };
            post.Description = postRequest.Description;

            var postEntry = await context.Post.AddAsync(post);
            var saveResponse = await context.SaveChangesAsync();
            if (saveResponse < 0)
            {
                return new PostResponse { Success = false, Error = "Issue while saving the post", ErrorCode = "CP01" };
            }

            var postEntity = postEntry.Entity;
            var postModel = new PostModel();
            postModel.Id = postEntity.Id;
            postModel.Description = postEntity.Description;
            postModel.Ts = postEntity.Ts;
            postModel.Imagepath = postEntity.Imagepath;
            return new PostResponse { Success = true, Post = postModel };
        }

        public async Task SavePostImageAsync(PostRequest postRequest)
        {
            var uniqueFileName = FileHelper.GetUniqueFileName(postRequest.Image.FileName);
            var uploads = Path.Combine(environment.WebRootPath, "users", "posts", postRequest.UserId.ToString());
            var filePath = Path.Combine(uploads, uniqueFileName);
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            await postRequest.Image.CopyToAsync(new FileStream(filePath, FileMode.Create));
            return;
        }
    }
}