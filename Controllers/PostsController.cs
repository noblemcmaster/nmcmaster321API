using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Models.Interfaces;
using Microsoft.AspNetCore.Cors;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        // GET: api/Posts
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Post> Get()
        {
            IGetAllPosts readObject = new ReadPostData();
            return readObject.GetAllPosts();
        }

        // GET: api/Posts/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public Post Get(int id)
        {
            IGetPosts readObject = new ReadPostData();
            return readObject.GetPost(id);
        }

        // POST: api/Posts
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Post value)
        {
            IInsertPost insertObject = new SavePost();
            insertObject.InsertPost(value);
        }

        // PUT: api/Posts/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Post value)
        {
            IEditPost insertObject = new EditPost();
            insertObject.EditPosts(id, value.Text);
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeletePost insertObject = new DeletePost();
            insertObject.DeletePost(id);
        }
    }
}
