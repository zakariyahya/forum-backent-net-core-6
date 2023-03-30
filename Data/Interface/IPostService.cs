
using forum.Dtos;

namespace forum.Data.Interfaces

{


    public interface IPostService


    {


        Task SavePostImageAsync(PostRequest postRequest);


        Task<PostResponse> CreatePostAsync(PostRequest postRequest);


    }

}