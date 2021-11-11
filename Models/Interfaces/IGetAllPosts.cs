using System.Collections.Generic;

namespace API.Models.Interfaces
{
    public interface IGetAllPosts
    {
         List<Post> GetAllPosts();
    }
}