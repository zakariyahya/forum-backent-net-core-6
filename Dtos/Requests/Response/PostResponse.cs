using forum.Models;

namespace forum.Dtos

{
    public class PostResponse : BaseResponse
    {
        public PostModel Post {get; set;}
    }
}